
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
                "�\��C��",
                "����",
                null,
                "����",
                "��׳��i",
                "�~�׳��i"
                );

            switch (action)
            {
                case "����":
                    // �w�g�b�����A���ݭn�ާ@
                    break;
                case "��׳��i":
                    await Navigation.PushAsync(new PetMainPage());
                    break;
                case "�~�׳��i":
                    await Navigation.PushAsync(new PetMainPage());
                    break;
                case "�w��]�m":
                    await Navigation.PushAsync(new PetMainPage());
                    break;
            }
        }
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
        await Navigation.PushAsync(new AddAccountingPage());
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