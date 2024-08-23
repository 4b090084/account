using System.Collections.ObjectModel;

namespace account.Views;

public partial class IncreasePage : ContentPage
{
    public ObservableCollection<Record> Records { get; set; } = new ObservableCollection<Record>();
    public IncreasePage()
	{
		InitializeComponent();
        RecordsListView.ItemsSource = Records;
        //定義頁面路徑
        //Routing.RegisterRoute(nameof(Views.DiAccountPage), typeof(Views.DiAccountPage));
    }

    private void incomeButton_Clicked(object sender, EventArgs e)
    {

    }

    private void expendButton_Clicked(object sender, EventArgs e)
    {

    }

    private async void calculator_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CalculatorPage());
    }

    private async void plusbutton_Clicked(object sender, EventArgs e)
    {
        string result = await DisplayPromptAsync("輸入金额", "請輸入金额:", initialValue: "0", keyboard: Keyboard.Numeric);

        if (decimal.TryParse(result, out decimal amount))
        {
            AmountEntry.Text = result;
            AmountEntry.IsVisible = true;
        }
        else
        {
            await DisplayAlert("錯誤", "請輸入有效的數字", "確定");
        }
    }

    private void AddRecordClicked(object sender, EventArgs e)
    {
        if (decimal.TryParse(AmountEntry.Text, out decimal amount) && !string.IsNullOrWhiteSpace(DescriptionEntry.Text))
        {
            Records.Add(new Record { Amount = amount, Description = DescriptionEntry.Text });
            AmountEntry.Text = string.Empty;
            DescriptionEntry.Text = string.Empty;
        }
        else
        {
            DisplayAlert("錯誤", "請输入有效的金額和描述", "確定");
        }
    }
    public class Record
    {
        public decimal Amount { get; set; }
        public string? Description { get; set; }
    }
}