using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DomainModel
{
    public class ValidationResults
    {
        public ValidationResults()
        {
            GetAllErrors = new List<string>();
        }

        public ValidationResults(IInputValidator inputValidator)
        {
            GetAllErrors = inputValidator.GetAllErrors().ToList();
        }

        public List<string> GetAllErrors { get; set; }

        public virtual bool IsValid
        {
            get
            {
                return GetAllErrors.Count == 0;
            }
        }
    }

    public abstract class PropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // Beacon method https://visualstudiogallery.msdn.microsoft.com/d5cd6aa1-57a5-4aaa-a2be-969c6db7f88a
        [MethodImpl(MethodImplOptions.NoInlining)]
        protected static void Raise() { }
        public void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                try
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
                }
                catch (NullReferenceException e)
                {
                    // Sometimes DevExpress randomly throws this
                    if (e.Source != "DevExpress.Xpf.Grid.v12.2.Core")
                    {
                        throw;
                    }
                }
            }
        }
        [XmlIgnore]
        public bool PropertyChanging { get; protected set; }
    }

    public abstract class DomainObject : PropertyChangedBase, INotifyDataErrorInfo
    {
        public int ID { get; set; }
        protected DomainObject()
        {
        }

        //Abstracts don't let you instantiate
        //Abstrct method don't have an initial body
        // - it let's you override the abstract method

        //A base class can be instantiated as its child classes
        //Difference between abstract and virtual is that virtual has a body that you can override
        public abstract IInputValidator CreateInputValidator();
        private IInputValidator _inputValidator;
        public virtual IInputValidator InputValidator
        {
            get
            {
                if (_inputValidator == null)
                {
                    // this will call the invoked instance of the InputValidator called on the class
                    // this will go to its implementation
                    _inputValidator = CreateInputValidator();
                }
                return _inputValidator;
            }
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged
        {
            add { }
            remove { }
        }

        public virtual ValidationResults ValidationResults
        {
            get
            {
                return new ValidationResults(InputValidator);
            }
        }

        public bool HasErrors => true;

        public IEnumerable GetErrors(string propertyName)
        {
            return InputValidator.GetErrors(propertyName);
        }

        public virtual IEnumerable<string> GetAllErrors()
        {
            return InputValidator == null ? new List<string>() : InputValidator.GetAllErrors();
        }

        public bool IsValid => GetAllErrors().Count() == 0;
        public bool IsNew =>ID == 0;
    }
}
