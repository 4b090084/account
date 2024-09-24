
namespace account.Views
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            //MainPage = new NavigationPage(new PetMainPage());
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }
    }
}
