namespace account.Views;

using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

public partial class ShopPage : ContentPage
{
    private readonly IAccessoryService _accessoryService;
    private string[] accessories =
        {
            "hat.png", "flower.png", "greenhat.png",
            "stick.png", "witchhat.png", "yellowhat.png",
            "wreath.png", "shoes.png", "pants.png"
        };

    public ShopPage()
	{
		InitializeComponent();
        _accessoryService = DependencyService.Get<IAccessoryService>();
        CreateShopGrid();
    }

    public Action<string> AccessorySelected { get; internal set; }

    private void CreateShopGrid()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                var imageName = accessories[i * 3 + j];
                var image = new Image
                {
                    Source = ImageSource.FromFile(imageName),
                    Aspect = Aspect.AspectFit
                };

                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += (s, e) => OnImageTapped(imageName);
                image.GestureRecognizers.Add(tapGestureRecognizer);

                ShopGrid.Add(image, j, i);
            }
        }
    }


    private void OnImageTapped(string imageName)
    {
        _accessoryService.SelectAccessory(imageName);
    }
}