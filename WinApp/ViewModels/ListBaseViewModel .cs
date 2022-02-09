using DataAccess;
using DomainModel;
using System.Collections.Generic;
using System.Windows.Controls;
using WinApp.Commands;
using WinApp.Events;

namespace WinApp.ViewModels
{
    public interface IListBaseViewModel : IBaseViewModel
    {
        void Load(int? id);
        RelayCommand OpenCommand { get; set; }
        List<DataGridColumn> GridColumns { get; set; }
    }

    public interface IListBaseViewModel<T> : IBaseViewModel<T>, IListBaseViewModel where T : DomainObject
    {
    }

    public abstract class ListBaseViewModel<T> : BaseViewModel<T>, IListBaseViewModel<T> where T : DomainObject
    {
        protected ListBaseViewModel(IDataGateway dataGateway) : base(dataGateway)
        {
            BuildGridColumns();
        }
        public virtual T SelectedItem { get; set; }
        public List<T> GridItems { get; set; }
        public RelayCommand OpenCommand { get; set; }
        public List<DataGridColumn> GridColumns { get; set; }

        public override void BuilCommands()
        {
            base.BuilCommands();
            OpenCommand = new RelayCommand(x =>
            {
                if (SelectedItem != null)
                {
                    App.EventAggregator.GetEvent<OpenItemRequestedEvent<T>>().Publish(new OpenItemRequestedEventArgs<T>() { ID = SelectedItem.ID });
                }
            });
        }
        public abstract void BuildGridColumns();
        public abstract void Load(int? id);
    }
}
