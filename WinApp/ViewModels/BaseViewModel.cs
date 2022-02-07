using DataAccess;
using DataAccess.Repositories.RepositoryBase;
using DomainModel;
using System.Linq;
using System.Windows;
using WinApp.Commands;
using WinApp.Events;

namespace WinApp.ViewModels
{
    public interface IBaseViewModel
    {
        // USED IN OBJECT AND VIEW MODEL MAPPING
        void Initialize();
        void Load(int id);
        Window Window { get; set; }

        string ViewCaption { get; set; }
        RelayCommand SaveCommand { get; set; }
        RelayCommand CancelCommand { get; set; }
        RelayCommand OpenCommand { get; set; }
    }
    public interface IBaseViewModel<T> : IBaseViewModel where T : DomainObject
    {
        // USED IN VIEW MODEL AND UI MAPPING
    }
    public abstract class BaseViewModel<T> : PropertyChangedBase, IBaseViewModel<T> where T : DomainObject
    {
        protected BaseViewModel(IDataGateway dataGateway)
        {
            _dataGateway = dataGateway;
        }
        public virtual T Item { get; set; }
        public virtual string ViewCaption { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public RelayCommand OpenCommand { get; set; }
        protected IDataGateway _dataGateway { get; set; }

        protected abstract IRepository<T> Repository { get; }


        public virtual void BuilCommands()
        {
            SaveCommand = new RelayCommand((arg) =>
            {
                if (!Item.IsValid)
                {
                    App.EventAggregator.GetEvent<ShowValidationErrorRequestedEvent>().Publish(new ValidationEventArgs()
                    {
                        Errors = Item.GetAllErrors().ToList(),
                        Message = $"Please resolve the following errors:",
                        Title = $"Validation errors on {Item.GetType().Name}",
                    });
                }
                else
                {
                    if (Item.IsNew)
                    {
                        Repository.Add(Item);
                    }
                    _dataGateway.SaveChanges();
                }
            });

            CancelCommand = new RelayCommand((arg) =>
            {
                Window.Close();
            });

            OpenCommand = new RelayCommand((arg) =>
            {
            });
        }

        public abstract void Initialize();
        public abstract void Load(int id);
        public Window Window { get; set; }
    }
}
