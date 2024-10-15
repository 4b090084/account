using System.Collections.ObjectModel;
using System.Text.Json;
namespace account.Views;

public partial class SortPage : ContentPage
{
    private Dictionary<string, ObservableCollection<string>> categories;
    private string currentCategory;

    public SortPage()
	{
		InitializeComponent();
        LoadCategories();
    }

    private void LoadCategories()
    {
        string savedCategories = Preferences.Get("Categories", null);
        if (savedCategories != null)
        {
            categories = JsonSerializer.Deserialize<Dictionary<string, ObservableCollection<string>>>(savedCategories);
        }
        else
        {
            InitializeDefaultCategories();
        }
    }
    private void InitializeDefaultCategories()
    {
        categories = new Dictionary<string, ObservableCollection<string>>
            {
                {"食", new ObservableCollection<string> {"早餐","午餐","晚餐","點心","飲料"}},
                {"衣", new ObservableCollection<string> {"衣物","鞋子"}},
                {"住", new ObservableCollection<string> {"房租","日用品","水電"}},
                {"行", new ObservableCollection<string> {"通勤","加油","車輛"}},
                {"育", new ObservableCollection<string> {"教育","體育","醫療"}},
                {"樂", new ObservableCollection<string> {"電子","娛樂","購物"}}
            };
        SaveCategories();
    }

    private void SaveCategories()
    {
        string serializedCategories = JsonSerializer.Serialize(categories);
        Preferences.Set("Categories", serializedCategories);
    }
    private void CategoryButton_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            currentCategory = button.Text;
            SubcategoriesListView.ItemsSource = categories[currentCategory];
        }
    }

        private void SubcategorySelected(object sender, SelectedItemChangedEventArgs e)
    {
        // 處理子類別選擇邏輯
    }

    private void AddSubcategoryClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(NewSubcategoryEntry.Text) && currentCategory != null)
        {
            categories[currentCategory].Add(NewSubcategoryEntry.Text);
            NewSubcategoryEntry.Text = string.Empty;
            SaveCategories();
        }
    }

    private async void EditSubcategory(object sender, EventArgs e)
    {
        var item = ((SwipeItem)sender).BindingContext as string;
        string result = await DisplayPromptAsync("編輯子類別", "請輸入新的名稱", initialValue: item);
        if (!string.IsNullOrEmpty(result) && result != item)
        {
            int index = categories[currentCategory].IndexOf(item);
            categories[currentCategory][index] = result;
            SaveCategories();
        }
    }

    private async void DeleteSubcategory(object sender, EventArgs e)
    {
        var item = ((SwipeItem)sender).BindingContext as string;
        bool answer = await DisplayAlert("刪除子類別", $"確定要刪除 '{item}' 嗎?", "是", "否");
        if (answer)
        {
            categories[currentCategory].Remove(item);
            SaveCategories();
        }
    }

}