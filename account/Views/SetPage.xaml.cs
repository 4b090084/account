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
        string result = await DisplayActionSheet("��ܭI��", "����", null, "�]��", "�Ӷ���", "�X��ϧ�");
        switch (result)
        {
            case "�]��":
                this.BackgroundImageSource = "/Images/sky.png";
                break;
            case "�Ӷ���":
                this.BackgroundImageSource = "/Images/sunflower.png";
                break;
            case "�X��ϧ�":
                this.BackgroundImageSource = "/Images/orange.png";
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

    private  async void FAQ_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FAQPage());
    }
}