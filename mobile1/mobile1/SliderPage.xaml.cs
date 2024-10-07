// rgb slider c#

using System;
using System.Diagnostics; // Для логирования
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

            // Инициализация слайдеров и установка начального цвета
            RedSlider.Value = 0;
            GreenSlider.Value = 0;
            BlueSlider.Value = 255; // Синий по умолчанию
            OpacityStepper.Value = 1; // Прозрачность по умолчанию - полная непрозрачность

            UpdateColor(); // Применяем начальный цвет
        }

        // Метод вызывается при изменении значений слайдеров
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

        // Метод для обновления цвета
        private void UpdateColor()
        {
            // Логируем значения слайдеров для отладки
            Debug.WriteLine($"Red: {RedSlider.Value}, Green: {GreenSlider.Value}, Blue: {BlueSlider.Value}");

            // Получаем значения слайдеров и конвертируем в целые числа
            int red = (int)RedSlider.Value;
            int green = (int)GreenSlider.Value;
            int blue = (int)BlueSlider.Value;
            double opacity = OpacityStepper.Value; // Получаем значение прозрачности

            // Применяем цвет и прозрачность к ColorFrame
            ColorFrame.BackgroundColor = Color.FromRgba(red, green, blue, opacity);

            // Логируем примененный цвет
            Debug.WriteLine($"Updated ColorFrame to R: {red}, G: {green}, B: {blue}, Opacity: {opacity:F1}");
        }

        // Метод для случайного изменения цветов
        private async void OnRandomColorButtonClicked(object sender, EventArgs e)
        {
            Random random = new Random();
            int randomRed = random.Next(0, 256);
            int randomGreen = random.Next(0, 256);
            int randomBlue = random.Next(0, 256);

            // Анимация изменения значений слайдеров на случайные
            await AnimateSliders(randomRed, randomGreen, randomBlue);
        }

        // Метод для анимации слайдеров
        private async Task AnimateSliders(int toRed, int toGreen, int toBlue)
        {
            // Запуск анимации для всех слайдеров
            var redTask = AnimateSlider(RedSlider, RedSlider.Value, toRed);
            var greenTask = AnimateSlider(GreenSlider, GreenSlider.Value, toGreen);
            var blueTask = AnimateSlider(BlueSlider, BlueSlider.Value, toBlue);

            // Ожидание завершения всех анимаций
            await Task.WhenAll(redTask, greenTask, blueTask);

            // Обновляем цвет после завершения анимации
            UpdateColor();
        }

        // Анимация изменения значений слайдера
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

        // Обработчик изменения значения Stepper для прозрачности
        private void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            double newOpacity = e.NewValue;

            // Обновляем прозрачность Frame
            ColorFrame.Opacity = newOpacity;

            // Обновляем текст для отображения текущего значения прозрачности
            OpacityLabel.Text = $"Opacity: {newOpacity:F1}";

            UpdateColor(); // Применяем новый цвет с обновленной прозрачностью
        }
    }
}
