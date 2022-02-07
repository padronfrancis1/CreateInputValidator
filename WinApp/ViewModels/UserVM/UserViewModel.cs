using DomainModel;

namespace WinApp.ViewModels.UserVM
{
    public class UserViewModel : BaseViewModel<User>
    {
        public UserViewModel()
        {
            BuilCommands();

            ViewCaption = "MyUser Window";
        }

        public override void Initialize()
        {
            Item = new User();
        }

        public override void Load(int id)
        {
            Item = new User();
        }
    }
}