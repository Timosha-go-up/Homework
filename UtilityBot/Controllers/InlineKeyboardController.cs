using System;
using Telegram.Bot;
using Telegram.Bot.Types;
namespace UtilityBot.Controllers
{
    internal class InlineKeyboardController
    {
        private readonly ITelegramBotClient _telegramClient;
        
        public InlineKeyboardController(ITelegramBotClient telegramBotClient)
        {
            _telegramClient = telegramBotClient;
        }

        public async Task Handle(CallbackQuery? callbackQuery, CancellationToken ct)
        {
            if (callbackQuery?.Data == null)
                return;

            string celector = callbackQuery.Data switch
            {
                "кнопка 1" => "Считать числа",
                "кнопка 2" => "Считать символы",
                _ => String.Empty
            };

            switch (callbackQuery.Data)
            {
                case "кнопка 1":
                    {
                        // В этом типе клавиатуры обязательно нужно использовать следующий метод
                        await _telegramClient.AnswerCallbackQuery(callbackQuery.Id);
                        // Для того, чтобы отправить телеграмму запрос, что мы нажали на кнопку

                        await _telegramClient.SendMessage(callbackQuery.From.Id, $"Вы нажали: {celector}");

                        await _telegramClient.SendMessage(callbackQuery.Message.Chat, $"Введите цифры через пробел чтобы посчитать");

                        CheckButton.sumNumbersUpOn = true;
                        CheckButton.messageLenghtOn = false;

                        return;
                    }

                case "кнопка 2":
                    {
                        // В этом типе клавиатуры обязательно нужно использовать следующий метод
                        await _telegramClient.AnswerCallbackQuery(callbackQuery.Id);
                        // Для того, чтобы отправить телеграмму запрос, что мы нажали на кнопку

                        await _telegramClient.SendMessage(callbackQuery.From.Id, $"Вы нажали: {celector}");

                        _ = await _telegramClient.SendMessage(callbackQuery.Message.Chat, $"Отправте любое сообщение чтобы узнать количество символов ");
                        CheckButton.messageLenghtOn = true;
                        CheckButton.sumNumbersUpOn = false;
                        return;
                    }
            }
        }
    }
}

