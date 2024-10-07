// rgb slider c#

using System;
using System.Diagnostics; 
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace mobile1
{
    public partial class SliderPage : ContentPage
    {
        public SliderPage()
        {
            InitializeComponent();

            RedSlider.Value = 0;
            GreenSlider.Value = 0;
            BlueSlider.Value = 255; 
            OpacityStepper.Value = 1; 

            UpdateColor(); 
        }

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (sender == RedSlider)
            {
                redLabel.Text = String.Format("Red = {0:X2}", (int)e.NewValue);
            }
            else if (sender == GreenSlider)
            {
                greenLabel.Text = String.Format("Green = {0:X2}", (int)e.NewValue);
            }
            else if (sender == BlueSlider)
            {
                blueLabel.Text = String.Format("Blue = {0:X2}", (int)e.NewValue);
            }

            UpdateColor();
        }

        private void UpdateColor()
        {
            Debug.WriteLine($"Red: {RedSlider.Value}, Green: {GreenSlider.Value}, Blue: {BlueSlider.Value}");

            int red = (int)RedSlider.Value;
            int green = (int)GreenSlider.Value;
            int blue = (int)BlueSlider.Value;
            double opacity = OpacityStepper.Value; 

            ColorFrame.BackgroundColor = Color.FromRgba(red, green, blue, opacity);

            Debug.WriteLine($"Updated ColorFrame to R: {red}, G: {green}, B: {blue}, Opacity: {opacity:F1}");
        }

        private async void OnRandomColorButtonClicked(object sender, EventArgs e)
        {
            Random random = new Random();
            int randomRed = random.Next(0, 256);
            int randomGreen = random.Next(0, 256);
            int randomBlue = random.Next(0, 256);

            await AnimateSliders(randomRed, randomGreen, randomBlue);
        }

        private async Task AnimateSliders(int toRed, int toGreen, int toBlue)
        {
            var redTask = AnimateSlider(RedSlider, RedSlider.Value, toRed);
            var greenTask = AnimateSlider(GreenSlider, GreenSlider.Value, toGreen);
            var blueTask = AnimateSlider(BlueSlider, BlueSlider.Value, toBlue);

            await Task.WhenAll(redTask, greenTask, blueTask);

            UpdateColor();
        }

        private Task AnimateSlider(Slider slider, double fromValue, double toValue)
        {
            var tcs = new TaskCompletionSource<bool>();

            var animation = new Animation(v => slider.Value = v, fromValue, toValue);

            animation.Commit(slider, "SliderAnimation", length: 1000, easing: Easing.Linear, finished: (v, c) =>
            {
                tcs.SetResult(true);
            });

            return tcs.Task;
        }

        private void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            double newOpacity = e.NewValue;

            ColorFrame.Opacity = newOpacity;

            OpacityLabel.Text = $"Opacity: {newOpacity:F1}";

            UpdateColor(); 
        }
    }
}
