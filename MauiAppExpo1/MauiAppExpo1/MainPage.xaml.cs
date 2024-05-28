using MauiAppExpo1.ViewModels;
using Microsoft.Maui.Devices;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Maui.Core.Platform;

namespace MauiAppExpo1
{
    public partial class MainPage : ContentPage
    {
        private Modelo _viewModel;

        public MainPage()
        {
            InitializeComponent();
            _viewModel = (Modelo)BindingContext;
            _viewModel.Mapa = map; // Asignar el control del mapa al ViewModel
        }

        private async void OnConsultarClicked(object sender, EventArgs e)
        {
            HideKeyboard();
            await _viewModel.ConsultarRegistroAsync();
        }

        private async void HideKeyboard()
        {
            if (KeyboardExtensions.IsSoftKeyboardShowing(entryID))
            {
                await KeyboardExtensions.HideKeyboardAsync(entryID);
            }
        }
    }
}