using DomainModel;
using System.Linq;
using System.Windows;
using WinApp.Commands;
using WinApp.Events;

namespace WinApp.ViewModels
{
    /// <summary>
    /// Base Class
    /// </summary>
    /// 

    public interface X
    {

    }
    public interface IBaseViewModel
    {
        // USED IN OBJECT AND VIEW MODEL MAPPING
        void Initialize();
        void Load(int id);
        Window Window { get; set; }
    }
    public interface IBaseViewModel<T> : IBaseViewModel where T : DomainObject
    {
        // USED IN VIEW MODEL AND UI MAPPING
    }
    public abstract class BaseViewModel<T> : PropertyChangedBase, IBaseViewModel<T> where T : DomainObject
    {
        public virtual T Item { get; set; }
        public virtual string ViewCaption { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public RelayCommand OpenCommand { get; set; }

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
