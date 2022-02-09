using DataAccess;
using DataAccess.Repositories.RepositoryBase;
using DomainModel;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;

namespace WinApp.ViewModels.UserVM
{
    public class UserListViewModel : ListBaseViewModel<User>
    {
        protected override IRepository<User> Repository { get => _dataGateway.UserRepository; }

        public UserListViewModel(IDataGateway dataGateway) : base(dataGateway)
        {
            //ViewCaption = "User List View Model";
        }

        public override void Load(int? id)
        {
            GridItems = _dataGateway.UserRepository.GetAll().ToList();
        }

        public override void BuildGridColumns()
        {
            GridColumns = new List<DataGridColumn>()
            {
                new DataGridTextColumn(){ Header = nameof(User.ID), Binding = new Binding(nameof(User.ID)) },
                new DataGridTextColumn(){ Header = nameof(User.Name), Binding = new Binding(nameof(User.Name)) },
            };
        }
    }
}
