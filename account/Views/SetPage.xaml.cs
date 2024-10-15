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
        string result = await DisplayActionSheet("選擇背景", "取消", null, "夜空", "太陽花", "幾何圖形");
        switch (result)
        {
            case "夜空":
                this.BackgroundImageSource = "/Images/sky.png";
                break;
            case "太陽花":
                this.BackgroundImageSource = "/Images/sunflower.png";
                break;
            case "幾何圖形":
                this.BackgroundImageSource = "/Images/orange.png";
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

    private  async void FAQ_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FAQPage());
    }
}