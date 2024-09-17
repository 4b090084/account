namespace account
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //定義頁面路徑
            Routing.RegisterRoute(nameof(Views.LoginPage), typeof(Views.LoginPage));
            Routing.RegisterRoute(nameof(Views.RegisterPage), typeof(Views.RegisterPage));
            Routing.RegisterRoute(nameof(Views.ShopPage), typeof(Views.ShopPage));
            Routing.RegisterRoute(nameof(Views.FoodPage), typeof(Views.FoodPage));
            Routing.RegisterRoute(nameof(Views.SetPage), typeof(Views.SetPage));
            Routing.RegisterRoute(nameof(Views.HelpPage), typeof(Views.HelpPage));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        }
    }
}
