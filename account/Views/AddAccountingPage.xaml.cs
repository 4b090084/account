namespace account.Views;
using account.Models;
using Firebase.Database;
using Firebase.Database.Query;

public partial class AddAccountingPage : ContentPage
{
    private readonly FirebaseClient _firebaseClient;
    private readonly List<string> expenseCategories = new List<string> { "食", "衣", "住", "行", "育", "樂" };
    private readonly List<string> incomeCategories = new List<string> { "薪水", "父母", "獎金" };
    public AddAccountingPage(FirebaseClient firebaseClient)
	{
		InitializeComponent();
        DatePicker.Date = DateTime.Now;  // 設置默認日期為今天
        _firebaseClient = firebaseClient;
    }

    private async void SaveClicked(object sender, EventArgs e)
    {
        // 獲取用戶輸入
        string type = TypePicker.SelectedItem?.ToString();
        decimal amount;
        if (!decimal.TryParse(AmountEntry.Text, out amount))
        {
            await DisplayAlert("錯誤", "請輸入有效的金額", "確定");
            return;
        }

        DateTime date = DatePicker.Date;
        string category = CategoryPicker.SelectedItem?.ToString();
        string note = NoteEditor.Text;

        // 創建 AddAccounting 對象
        var accountingEvent = new AddAccounting
        {
            Type = type,
            Amount = amount,
            Date = date,
            Category = category,
            Note = note
        };

        try
        {
            // 將記帳事件保存到 Firebase
            await _firebaseClient
                .Child("AEvents")
                .PostAsync(accountingEvent);

            await DisplayAlert("成功", "記帳事件已添加到 Firebase", "確定");
            // 返回上一頁
            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            await DisplayAlert("錯誤", $"無法保存到 Firebase: {ex.Message}", "確定");
        }
    }

    private async void TypeChanged(object sender, EventArgs e)
    {
        if (TypePicker.SelectedIndex == -1)
        {
            CategoryPicker.IsEnabled = false;
            CategoryPicker.ItemsSource = null;
            return;
        }

        CategoryPicker.IsEnabled = true;

        if (TypePicker.SelectedItem.ToString() == "支出")
        {
            CategoryPicker.ItemsSource = expenseCategories;
        }
        else if (TypePicker.SelectedItem.ToString() == "收入")
        {
            CategoryPicker.ItemsSource = incomeCategories;
        }

        CategoryPicker.SelectedIndex = -1;
    }
}