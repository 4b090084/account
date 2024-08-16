namespace account.Views;
using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.Maui.Storage;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}
    //跳轉至註冊頁面
    private async void Register_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("RegisterPage");
    }
    //登入按鈕
    private  void Login_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("登入", "登入按钮點擊!", "確定");
    }
}