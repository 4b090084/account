using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
namespace account.Views;

public partial class PetMainPage : ContentPage
{
    private readonly IAccessoryService _accessoryService;
    private Dictionary<string, Image> accessories = new Dictionary<string, Image>();
    private int petLevel = 1;


    public PetMainPage()
	{
		InitializeComponent();
        _accessoryService = DependencyService.Get<IAccessoryService>();
        _accessoryService.AccessorySelected += UpdateChickenAccessory;
    }


    protected override void OnAppearing()
    {
        base.OnAppearing();
        SubscribeToShopPage();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _accessoryService.AccessorySelected -= UpdateChickenAccessory;
    }

    public interface IAccessoryService
    {
        event Action<string> AccessorySelected;
        void SelectAccessory(string accessoryName);
    }

    public class AccessoryService : IAccessoryService
    {
        public event Action<string> AccessorySelected;

        public void SelectAccessory(string accessoryName)
        {
            AccessorySelected?.Invoke(accessoryName);
        }
    }
    private void SubscribeToShopPage()
    {
        if (Navigation.NavigationStack.LastOrDefault() is ShopPage shopPage)
        {
            shopPage.AccessorySelected += UpdateChickenAccessory;
        }
    }

    private void UnsubscribeFromShopPage()
    {
        if (Navigation.NavigationStack.LastOrDefault() is ShopPage shopPage)
        {
            shopPage.AccessorySelected -= UpdateChickenAccessory;
        }
    }

    private void UpdateChickenAccessory(string accessoryName)
    {
        if (accessories.ContainsKey(accessoryName))
        {
            AccessoriesGrid.Children.Remove(accessories[accessoryName]);
            accessories.Remove(accessoryName);
        }
        else
        {
            var accessory = new Image
            {
                Source = ImageSource.FromFile(accessoryName),
                Aspect = Aspect.AspectFit
            };

            AccessoriesGrid.Children.Add(accessory);
            accessories[accessoryName] = accessory;
        }
    }

    private async void SettingsButton_Click(object sender, TappedEventArgs e)
    {
        // 跳轉到設置頁面的邏輯
        await Shell.Current.GoToAsync("set");
    }

    private async void HelpButton_Click(object sender, TappedEventArgs e)
    {
        // 跳轉到帮助頁面的邏輯
        await Shell.Current.GoToAsync("help");
    }

    private async void HomeButton_Click(object sender, TappedEventArgs e)
    {
        // 跳轉到主頁的邏輯
        await Shell.Current.GoToAsync("home");
    }

    private async void FeedButton_Click(object sender, TappedEventArgs e)
    {
        // 跳轉餵養頁面的邏輯
        await Shell.Current.GoToAsync("food");
    }

    private async void ShopButton_Click(object sender, TappedEventArgs e)
    {
        // 跳轉商店頁面的邏輯
        await Navigation.PushAsync(new ShopPage());
    }
    // 這個方法可以被其他頁面調用來更新寵物狀態
    //public void UpdatePetStatus(string status)
    //{
    //    GetStatusImage().Source = status + ".png";
    //}

    //private static object GetStatusImage()
    //{
    //    return StatusImage;
    //}

    //// 這個方法可以被其他頁面調用來增加寵物等級
    //public void IncreasePetLevel()
    //{
    //    petLevel++;
    //    // 更新等級顯示
    //}
}