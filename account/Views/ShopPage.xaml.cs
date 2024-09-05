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
            // �o�̧ڭ̰��] PetMainPage �O�@�ӳ�ҡA�Ϊ̧ڭ̦��Y�ؤ覡�i�H�X�ݨ쥦
            await PetMainPage.Instance.AddItemToChicken(itemName);
            await DisplayAlert("���\", $"�w�����K�[ {itemName}", "�T�w");
        }
    }
}