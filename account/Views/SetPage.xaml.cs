namespace account.Views;
using account.Models;
using Microsoft.Maui.Controls;


public partial class SetPage : ContentPage
{

    public SetPage()
	{
		InitializeComponent();
     
    }
    private async void ChangeBackground_Clicked(object sender, EventArgs e)
    {
        string result = await DisplayActionSheet("選擇背景顏色", "取消", null, "白色", "黑色", "原始顏色");
        switch (result)
        {
            case "白色":
                this.BackgroundColor = Colors.White;
                break;
            case "黑色":
                this.BackgroundColor = Colors.Black;
                break;
            case "原始顏色":
                this.BackgroundColor = Colors.Transparent;
                break;
        }
    }

  

    private async void ReportIssue_Clicked(object sender, EventArgs e)
    {
        string issue = await DisplayPromptAsync("回報問題", "請描述您遇到的問題：");
        if (!string.IsNullOrEmpty(issue))
        {
            // TODO: 將問題保存到數據庫
            await DisplayAlert("謝謝", "您的問題已回報", "確定");
        }
    }

    private async void FAQ_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FAQPage());
    }
}