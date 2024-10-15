namespace account.Views;

public partial class AddAccountingPage : ContentPage
{
    private readonly List<string> expenseCategories = new List<string> { "食", "衣", "住", "行", "育", "樂" };
    private readonly List<string> incomeCategories = new List<string> { "薪水", "父母", "獎金" };
    public AddAccountingPage()
	{
		InitializeComponent();
        DatePicker.Date = DateTime.Now;  // 設置默認日期為今天
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

        // 在這裡處理數據,例如保存到數據庫
        // 這裡只是簡單地顯示一個成功消息
        await DisplayAlert("成功", "記帳事件已添加", "確定");

        // 返回上一頁
        await Shell.Current.GoToAsync("..");
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