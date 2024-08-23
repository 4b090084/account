namespace account.Views
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Register<IAccessoryService, AccessoryService>();
            //MainPage = new AppShell();
            MainPage = new NavigationPage(new PetMainPage());
        }
    }
}
