namespace account.Views;
using System;
using account.Models;
using Microsoft.Maui.Controls;

public partial class FoodPage : ContentPage
{
    public FoodPage()
	{
		InitializeComponent();
        SetupEventHandlers();
    }

    private void SetupEventHandlers()
    {
        Brocoli.GestureRecognizers.Add(CreateTapGestureRecognizer(OnHealthyFoodTapped));
        Carrots.GestureRecognizers.Add(CreateTapGestureRecognizer(OnHealthyFoodTapped));
        Chestnut.GestureRecognizers.Add(CreateTapGestureRecognizer(OnHealthyFoodTapped));
        Chips.GestureRecognizers.Add(CreateTapGestureRecognizer(OnUnhealthyFoodTapped));
        Kiwi.GestureRecognizers.Add(CreateTapGestureRecognizer(OnUnhealthyFoodTapped));
    }

    private TapGestureRecognizer CreateTapGestureRecognizer(EventHandler handler)
    {
        return new TapGestureRecognizer { Command = new Command(() => handler(this, EventArgs.Empty)) };
    }

    private void OnHealthyFoodTapped(object sender, EventArgs e)
    {
        ScoreManager.Instance.AddScore(10);
        UpdateScore();
    }

    private void OnUnhealthyFoodTapped(object sender, EventArgs e)
    {
        ScoreManager.Instance.AddScore(20);
        UpdateScore();
    }

    private async void UpdateScore()
    {
        await Navigation.PopAsync();
    }
}