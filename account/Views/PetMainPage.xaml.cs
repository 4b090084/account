using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
namespace account.Views;

public partial class PetMainPage : ContentPage
{
    public static PetMainPage Instance { get; private set; }

    public PetMainPage()
	{
		InitializeComponent();
        Instance = this;
    }

    public async Task AddItemToChicken(string itemName)
    {
        // 將兩個圖片合併
        var combinedImage = await CombineImages("chicken.png", itemName);
        ChickenImage.Source = combinedImage;
    }
    private async Task<ImageSource> CombineImages(string baseImage, string overlayImage)
    {
        // 這裡需要實現圖片合併的邏輯
        // 這可能需要使用第三方庫或者自定義的圖片處理邏輯
        // 為了簡單起見，這裡我們只是返回基礎圖片
        return ImageSource.FromFile(baseImage);
    }

    private async void Food_Tapped(object sender, TappedEventArgs e)
    {
        // 跳轉餵養頁面的邏輯
        await Navigation.PushAsync(new FoodPage());
    }

    private async void Shop_Tapped(object sender, TappedEventArgs e)
    {
        // 跳轉商店頁面的邏輯
        await Navigation.PushAsync(new ShopPage());
    }

    private async void Set_Clicked(object sender, EventArgs e)
    {
        // 跳轉到設置頁面的邏輯
        await Navigation.PushAsync(new SetPage());
    }

    private async void Help_Clicked(object sender, EventArgs e)
    {
        // 跳轉到帮助頁面的邏輯
        await Navigation.PushAsync(new HelpPage());
    }

    private async void Home_Clicked(object sender, EventArgs e)
    {
        // 跳轉到主頁的邏輯
        await Navigation.PushAsync(new HomePage());
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