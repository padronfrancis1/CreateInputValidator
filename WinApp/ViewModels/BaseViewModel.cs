using DataAccess;
using DataAccess.Repositories.RepositoryBase;
using DomainModel;
using System.Windows;

namespace WinApp.ViewModels
{
    public interface IBaseViewModel
    {
        Window Window { get; set; }
        string ViewCaption { get; set; }
    }
    public interface IBaseViewModel<T> : IBaseViewModel where T : DomainObject
    {
    }
    public abstract class BaseViewModel<T> : PropertyChangedBase, IBaseViewModel<T> where T : DomainObject
    {
        protected BaseViewModel(IDataGateway dataGateway)
        {
            _dataGateway = dataGateway;
            BuilCommands();
        }
        public virtual string ViewCaption { get; set; }
        protected IDataGateway _dataGateway { get; set; }

        protected abstract IRepository<T> Repository { get; }

        public virtual void BuilCommands()
        {
        }

        public Window Window { get; set; }
    }
}
