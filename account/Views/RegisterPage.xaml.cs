namespace account.Views;
using Firebase.Database;
using Firebase.Database.Query;
using account.Models;
using System.Collections.ObjectModel;

public partial class RegisterPage : ContentPage
{
    private readonly FirebaseClient _firebaseClient;
    //private readonly FirebaseClient firebase = new FirebaseClient("https://chicken-7bab7-default-rtdb.firebaseio.com/");
    public RegisterPage(FirebaseClient firebaseClient)
	{
		InitializeComponent();

        _firebaseClient = firebaseClient;
    }
    // 註冊按鈕
    private async void Register_Clicked(object sender, EventArgs e)
    {
        string UID = UIDEntry.Text;
        string UName = UNameEntry.Text;
        string UPwd = UPwdEntry.Text;
        string UPwd2 = UPwd2Entry.Text;

        if (string.IsNullOrEmpty(UID) || string.IsNullOrEmpty(UName) || string.IsNullOrEmpty(UPwd) || string.IsNullOrEmpty(UPwd2))
        {
            await DisplayAlert("錯誤", "請填寫所有欄位", "確定");
            return;
        }

        if (UPwd != UPwd2)
        {
            await DisplayAlert("錯誤", "兩次輸入的密碼不一致", "確定");
            return;
        }

        try
        {
            var existingUser = await _firebaseClient
                .Child("Users")
                .OrderBy("UID")
                .EqualTo(UID)
                .OnceAsync<Info>();

            if (existingUser.Any())
            {
                await DisplayAlert("錯誤", "該帳號已被使用", "確定");
                return;
            }

            var newnote = _firebaseClient.Child("Users").PostAsync(new Register 
            {
                UID = UIDEntry.Text,
                UName = UNameEntry.Text,
                UPwd = UPwdEntry.Text,
                UPwd2 =UPwd2Entry.Text
            });

            await DisplayAlert("成功", "註冊成功", "確定");
            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            await DisplayAlert("錯誤", $"註冊失敗: {ex.Message}", "確定");
        }


    }
    public class Info
    {
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}