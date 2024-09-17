using Microsoft.Maui.Controls;

namespace mobile1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnPage1ButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SliderPage());
        }

        private async void OnPage2ButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page2());
        }

        private async void OnPage3ButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page3());
        }
    }
}
