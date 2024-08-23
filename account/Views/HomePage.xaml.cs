
using Windows.UI.ApplicationSettings;

namespace account.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

    private async void listClicked(object sender, EventArgs e)
    {
        {
            var action = await DisplayActionSheet(
                "功能列表",
                "取消",
                null,
                "首頁",
                "月度報告",
                "年度報告"
                );

            switch (action)
            {
                case "首頁":
                    // 已經在首頁，不需要操作
                    break;
                case "月度報告":
                    await Navigation.PushAsync(new PetMainPage());
                    break;
                case "年度報告":
                    await Navigation.PushAsync(new PetMainPage());
                    break;
                case "預算設置":
                    await Navigation.PushAsync(new PetMainPage());
                    break;
            }
        }
    }

    private void MonthlyExpenseClicked(object sender, EventArgs e)
    {
        DisplayChart("月支出");
    }

    private void MonthlyIncomeClicked(object sender, EventArgs e)
    {
        DisplayChart("月收入");
    }

    private async void AddAccountingClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddAccountingPage());
    }
    private void DisplayChart(string chartType)
    {
        // 清除當前圖表
        ChartContainer.Content = null;

        // 這裡應該根據 chartType 創建並顯示相應的圖表
        // 由於 .NET MAUI 沒有內置的圖表控件,您可能需要使用第三方庫或自定義視圖
        // 以下僅為示例,實際應用中應替換為真實的圖表
        ChartContainer.Content = new Label
        {
            Text = $"這裡顯示{chartType}圖表",
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };
    }
}