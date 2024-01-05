import telebot

bot = telebot.TeleBot('6981075954:AAFoMg-rbBKrZ3jBuZ34CqrtF47te42ISmk')

questions_file = 'C:\\Users\\admin\\Desktop\\Programm\\TelegramBOT\\TelegramBOT\\TextFile1.txt'

@bot.message_handler(func=lambda message: True)
def handle_all_messages(message):
    user_id = message.from_user.id
    user_question = message.text

    # Сохраняем вопрос в файле
    with open(questions_file, 'a') as file:
        file.write(f'User {user_id}: {user_question}\n')

    # Отвечаем пользователю
    bot.reply_to(message, "Спасибо за ваш вопрос! Мы скоро ответим на него.")
    
admin_chat_id = 334616671  # Замените на chat_id вашего администратора

def notify_admin():
    with open(questions_file, 'r') as file:
        lines = file.readlines()
        if lines:
            last_question = lines[-1]
            bot.send_message(admin_chat_id, f'Новый вопрос:\n{last_question}')

@bot.message_handler(commands=['notify'])
def handle_notify(message):
    if message.chat.id == admin_chat_id:
        notify_admin()
    else:
        bot.reply_to(message, "У вас нет доступа к этой команде.")


    

bot.polling(none_stop=True)



