using Microsoft.Maui.Controls;
using System;

namespace mobile1
{
    public partial class SliderPage : ContentPage
    {
        public SliderPage()
        {
            InitializeComponent();
            UpdateColor(); // Инициализация начального цвета
        }

        // Обработчик изменения значений слайдеров
        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            UpdateColor();
        }

        // Метод для обновления цвета на основе значений слайдеров
        private void UpdateColor()
        {
            int red = Convert.ToInt32(RedSlider.Value);
            int green = Convert.ToInt32(GreenSlider.Value);
            int blue = Convert.ToInt32(BlueSlider.Value);

            // Обновляем цвет фона Frame
            ColorFrame.BackgroundColor = Color.FromRgb(red, green, blue);
        }

        private void OnRandomColorButtonClicked(object sender, EventArgs e)
        {
            Random random = new Random();
            int randomRed = random.Next(0, 256);
            int randomGreen = random.Next(0, 256);
            int randomBlue = random.Next(0, 256);

            // Устанавливаем новые значения слайдеров без анимации
            RedSlider.Value = randomRed;
            GreenSlider.Value = randomGreen;
            BlueSlider.Value = randomBlue;

            // Обновляем цвет сразу после изменения значений
            UpdateColor();
        }

        private void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            double newOpacity = e.NewValue;

            // Обновляем прозрачность Frame
            ColorFrame.Opacity = newOpacity;

            // Обновляем текст для отображения текущего значения прозрачности
            OpacityLabel.Text = $"Opacity: {newOpacity:F1}";
        }
    }
}
