using account.Models;
namespace account.Views;
using System;
using Microsoft.Maui.Controls;

public partial class PetMainPage : ContentPage
{
    public static object Instance { get; internal set; }

    public PetMainPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        ConditionEntry.Text = $"Score: {ScoreManager.Instance.Score}";
    }

    private async void OnFeedPetClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FoodPage());
    }

    private async void SettingsButton_Click(object sender, TappedEventArgs e)
    {
        // 跳轉到設置頁面的邏輯
        await Shell.Current.GoToAsync("SetPage");
    }

    private async void HelpButton_Click(object sender, TappedEventArgs e)
    {
        // 跳轉到帮助頁面的邏輯
        await Shell.Current.GoToAsync("HelpPage");
    }

    private async void HomeButton_Click(object sender, TappedEventArgs e)
    {
        // 跳轉到主頁的邏輯
        await Shell.Current.GoToAsync("HomePage");
    }

    private async void FeedButton_Click(object sender, TappedEventArgs e)
    {
        // 跳轉餵養頁面的邏輯
        await Shell.Current.GoToAsync("FoodPage");
    }

    private async void ShopButton_Click(object sender, TappedEventArgs e)
    {
        // 跳轉商店頁面的邏輯
        await Shell.Current.GoToAsync("ShopPage");
    }

    internal void AddItemToChicken(string v)
    {
        throw new NotImplementedException();
    }
}