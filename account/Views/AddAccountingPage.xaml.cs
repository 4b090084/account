namespace account.Views;

public partial class AddAccountingPage : ContentPage
{
	public AddAccountingPage()
	{
		InitializeComponent();
        DatePicker.Date = DateTime.Now;  // �]�m�q�{���������
    }

    private async void SaveClicked(object sender, EventArgs e)
    {
        // ����Τ��J
        string type = TypePicker.SelectedItem?.ToString();
        decimal amount;
        if (!decimal.TryParse(AmountEntry.Text, out amount))
        {
            await DisplayAlert("���~", "�п�J���Ī����B", "�T�w");
            return;
        }
        DateTime date = DatePicker.Date;
        string category = CategoryPicker.SelectedItem?.ToString();
        string note = NoteEditor.Text;

        // �b�o�̳B�z�ƾ�,�Ҧp�O�s��ƾڮw
        // �o�̥u�O²��a��ܤ@�Ӧ��\����
        await DisplayAlert("���\", "�O�b�ƥ�w�K�[", "�T�w");

        // ��^�W�@��
        await Navigation.PopAsync();
    }
}