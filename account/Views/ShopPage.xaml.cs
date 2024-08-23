namespace account.Views;
using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

public partial class ShopPage : ContentPage
{

    public ShopPage()
	{
		InitializeComponent();
    }


    private async void OnItemTapped(object sender, TappedEventArgs e)
    {
        var image = sender as Image;
        var itemName = image.GestureRecognizers.OfType<TapGestureRecognizer>().FirstOrDefault()?.CommandParameter as string;

        if (!string.IsNullOrEmpty(itemName))
        {
            // 這裡我們假設 PetMainPage 是一個單例，或者我們有某種方式可以訪問到它
            await PetMainPage.Instance.AddItemToChicken(itemName);
            await DisplayAlert("成功", $"已為雞添加 {itemName}", "確定");
        }
    }
}