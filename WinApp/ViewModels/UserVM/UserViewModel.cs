using DataAccess;
using DataAccess.Repositories.RepositoryBase;
using DomainModel;

namespace WinApp.ViewModels.UserVM
{
    public class UserViewModel : CreateEditBaseViewModel<User>
    {
        public UserViewModel(IDataGateway dataGateway) : base(dataGateway)
        {
            //ViewCaption = "MyUser Window";
        }

        protected override IRepository<User> Repository { get => _dataGateway.UserRepository; }

        public override void Initialize()
        {
            Item = new User();
        }

        public override void Load(int id)
        {
            Item = Repository.Get(id);
        }
    }
}