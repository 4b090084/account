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
                {"��", new ObservableCollection<string> {"���\","���\","���\","�I��","����"}},
                {"��", new ObservableCollection<string> {"�窫","�c�l"}},
                {"��", new ObservableCollection<string> {"�Я�","��Ϋ~","���q"}},
                {"��", new ObservableCollection<string> {"�q��","�[�o","����"}},
                {"�|", new ObservableCollection<string> {"�Ш|","��|","����"}},
                {"��", new ObservableCollection<string> {"�q�l","�T��","�ʪ�"}}
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
        // �B�z�l���O����޿�
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
        string result = await DisplayPromptAsync("�s��l���O", "�п�J�s���W��", initialValue: item);
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
        bool answer = await DisplayAlert("�R���l���O", $"�T�w�n�R�� '{item}' ��?", "�O", "�_");
        if (answer)
        {
            categories[currentCategory].Remove(item);
            SaveCategories();
        }
    }

}