namespace account.Views;
using account.Models;
using Microsoft.Maui.Controls;


public partial class SetPage : ContentPage
{

    public SetPage()
	{
		InitializeComponent();
     
    }
    private async void ChangeBackground_Clicked(object sender, EventArgs e)
    {
        string result = await DisplayActionSheet("��ܭI���C��", "����", null, "�զ�", "�¦�", "��l�C��");
        switch (result)
        {
            case "�զ�":
                this.BackgroundColor = Colors.White;
                break;
            case "�¦�":
                this.BackgroundColor = Colors.Black;
                break;
            case "��l�C��":
                this.BackgroundColor = Colors.Transparent;
                break;
        }
    }

  

    private async void ReportIssue_Clicked(object sender, EventArgs e)
    {
        string issue = await DisplayPromptAsync("�^�����D", "�дy�z�z�J�쪺���D�G");
        if (!string.IsNullOrEmpty(issue))
        {
            // TODO: �N���D�O�s��ƾڮw
            await DisplayAlert("����", "�z�����D�w�^��", "�T�w");
        }
    }

    private async void FAQ_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FAQPage());
    }
}