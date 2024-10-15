
//using Windows.UI.ApplicationSettings;

namespace account.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}


    private void MonthlyExpenseClicked(object sender, EventArgs e)
    {
        DisplayChart("���X");
    }

    private void MonthlyIncomeClicked(object sender, EventArgs e)
    {
        DisplayChart("�리�J");
    }

    private async void AddAccountingClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("AddAccountingPage");
    }
    private void DisplayChart(string chartType)
    {
        // �M����e�Ϫ�
        ChartContainer.Content = null;

        // �o�����Ӯھ� chartType �Ыب���ܬ������Ϫ�
        // �ѩ� .NET MAUI �S�����m���Ϫ���,�z�i��ݭn�ϥβĤT��w�Φ۩w�q����
        // �H�U�Ȭ��ܨ�,������Τ����������u�ꪺ�Ϫ�
        ChartContainer.Content = new Label
        {
            Text = $"�o�����{chartType}�Ϫ�",
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };
    }
}