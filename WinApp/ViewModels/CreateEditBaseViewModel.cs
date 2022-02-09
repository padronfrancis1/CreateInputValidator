using DataAccess;
using DataAccess.Repositories.RepositoryBase;
using DomainModel;
using System.Linq;
using System.Windows;
using WinApp.Commands;
using WinApp.Events;

namespace WinApp.ViewModels
{
    public interface ICreateEditBaseViewModel : IBaseViewModel
    {
        void Initialize();
        void Load(int id);

        RelayCommand SaveCommand { get; set; }
        RelayCommand CancelCommand { get; set; }
    }

    public interface ICreateEditBaseViewModel<T> : IBaseViewModel<T>, ICreateEditBaseViewModel where T : DomainObject
    {
    }

    public abstract class CreateEditBaseViewModel<T> : BaseViewModel<T>, ICreateEditBaseViewModel<T> where T : DomainObject
    {
        protected CreateEditBaseViewModel(IDataGateway dataGateway) : base(dataGateway)
        {
        }
        public virtual T Item { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public RelayCommand OpenCommand { get; set; }

        public override void BuilCommands()
        {
            base.BuilCommands();
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
    }
}
