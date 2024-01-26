import telebot
from telebot import types
import stripe
import qrcode

token = '6981075954:AAFoMg-rbBKrZ3jBuZ34CqrtF47te42ISmk'
bot = telebot.TeleBot(token)

stripe.api_key = 'Yefkrvmrmfkrkrvm'
stripe_public_key = 'dvkrfmvrmvrvomf'

@bot.message_handler(commands=['start'])
def handle_start(message):
    markup = types.ReplyKeyboardMarkup(row_width=1, resize_keyboard=True)
    item = types.KeyboardButton("Купить билет")
    markup.add(item)

    bot.send_message(message.chat.id, "Привет! Выберите действие:", reply_markup=markup)

@bot.message_handler(func=lambda message: True)
def handle_all_messages(message):
    if message.text == "Купить билет":
        # Здесь должна быть ваша логика обработки платежа через Stripe
        # Вместо следующей строки вам нужно реализовать интеграцию с Stripe
        # и обработку ответа от платежной системы
        payment_intent = create_payment_intent()

        if payment_intent:
            qr_code = generate_qr_code(payment_intent)
            bot.send_photo(message.chat.id, qr_code, caption="Спасибо за покупку! Ваш билет.")
        else:
            bot.send_message(message.chat.id, "Ошибка при обработке оплаты. Попробуйте еще раз.")
    else:
        bot.send_message(message.chat.id, "Непонятная команда. Выберите доступную опцию.")

def create_payment_intent():
    try:
        intent = stripe.PaymentIntent.create(
            amount=1000,  # Сумма в центах (например, 1000 центов = $10)
            currency='usd',
            payment_method_types=['card'],
        )
        return intent
    except stripe.error.StripeError as e:
        print(f"Error creating PaymentIntent: {e}")
        return None

def generate_qr_code(payment_intent):
    # Генерация QR-кода с информацией о платеже
    payment_info = f"PaymentIntent ID: {payment_intent.id}\nAmount: {payment_intent.amount / 100} USD"
    qr = qrcode.QRCode(
        version=1,
        error_correction=qrcode.constants.ERROR_CORRECT_L,
        box_size=10,
        border=4,
    )
    qr.add_data(payment_info)
    qr.make(fit=True)

    img = qr.make_image(fill_color="black", back_color="white")
    img_bytes = BytesIO()
    img.save(img_bytes)

    return img_bytes.getvalue()

if __name__ == "__main__":
    bot.polling(none_stop=True)
