// App, which help easier send information to user people

using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using Microsoft.Maui.ApplicationModel.Communication;
using Microsoft.Maui.ApplicationModel;

namespace mobile1 // Замените на ваше пространство имен
{
    public partial class UserCom : ContentPage
    {
        public UserCom()
        {
            InitializeComponent();
        }

        private async void Saada_sms_Clicked(object sender, EventArgs e)
        {
            string phone = PhoneEntry.Text; // Получение номера телефона из поля ввода
            string message = MessageEntry.Text ?? "Tere tulemast! Saadan sõnumi"; // Сообщение по умолчанию

            if (!string.IsNullOrWhiteSpace(phone) && Sms.Default.IsComposeSupported)
            {
                SmsMessage sms = new SmsMessage(message, phone);
                await Sms.Default.ComposeAsync(sms); // Убедитесь, что этот метод возвращает Task
            }
            else
            {
                await DisplayAlert("Ошибка", "Введите корректный номер телефона.", "OK");
            }
        }

        private async void Saada_email_Clicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text; // Получение адреса электронной почты из поля ввода
            string message = MessageEntry.Text ?? "Tere tulemast! Saadan email"; // Сообщение по умолчанию

            if (!string.IsNullOrWhiteSpace(email) && Email.Default.IsComposeSupported)
            {
                EmailMessage e_mail = new EmailMessage
                {
                    Subject = "Тема письма",
                    Body = message,
                    BodyFormat = EmailBodyFormat.PlainText,
                    To = new List<string> { email }
                };

                await Email.Default.ComposeAsync(e_mail); // Убедитесь, что этот метод возвращает Task
            }
            else
            {
                await DisplayAlert("Ошибка", "Введите корректный адрес электронной почты.", "OK");
            }
        }

        private void Helista_Clicked(object sender, EventArgs e)
        {
            string phone = PhoneEntry.Text; // Получение номера телефона из поля ввода

            if (!string.IsNullOrWhiteSpace(phone) && PhoneDialer.IsSupported)
            {
                PhoneDialer.Open(phone); // Совершение звонка без await
            }
            else
            {
                DisplayAlert("Ошибка", "Введите корректный номер телефона для звонка.", "OK");
            }
        }
    }
}
