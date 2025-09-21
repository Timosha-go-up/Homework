using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;
using UtilityBot.Configuration;
using System;
using UtilityBot.Tools;

namespace UtilityBot.Controllers
{
    public class TextMessageController
    {
        private readonly ITelegramBotClient _telegramClient;
        private Calculator _calculator;

        public TextMessageController(ITelegramBotClient telegramBotClient)
        {
            _telegramClient = telegramBotClient;
            _calculator = new Calculator();

        }
        public async Task Handle(Message message, CancellationToken ct)
        {
            switch (message.Text)
            {
                case "/start":
                    CheckButton.sumNumbersUpOn = false;
                    CheckButton.messageLenghtOn = false;

                    // Объект, представляющий кнопки
                    var buttons = new List<InlineKeyboardButton[]>
                    {
                        ([
                        InlineKeyboardButton.WithCallbackData($"Посчитать числа" , $"кнопка 1"),
                        InlineKeyboardButton.WithCallbackData($"Посчитать символы" , $"кнопка 2"),
                    ])
                    };
                    // передаем кнопки вместе с сообщением (параметр ReplyMarkup)
                    await _telegramClient.SendMessage(message.Chat.Id, $"<b>  Наш бот умеет складывать числа и считать символы.</b> {Environment.NewLine}" +
                    $"{Environment.NewLine}  Можно поменять: просто нажмите другую кнопку {Environment.NewLine}",
                    cancellationToken: ct, parseMode: ParseMode.Html, replyMarkup: new InlineKeyboardMarkup(buttons)); break;

                default:

                    
                    if (!(CheckButton.sumNumbersUpOn || CheckButton.messageLenghtOn))
                        await _telegramClient.SendMessage(message.Chat, $"Пришло сообщение: {message.Text}");

                    break;

            }

            if (CheckButton.sumNumbersUpOn)
            {
                _calculator.Sum(_telegramClient, message, ct);
            }

            if (CheckButton.messageLenghtOn)
            {
                await _telegramClient.SendMessage(message.Chat, $"В сообщении: {message?.Text?.Length} символ(ов)");
            }
            return;


        }

    }
}