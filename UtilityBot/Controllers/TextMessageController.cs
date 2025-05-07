using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;
using UtilityBot.Configuration;
using System;

namespace UtilityBot.Controllers
{
    public class TextMessageController
    {
        private readonly ITelegramBotClient _telegramClient;

        public TextMessageController(ITelegramBotClient telegramBotClient)
        {
            _telegramClient = telegramBotClient;
        }
        public async Task Handle(Message message, CancellationToken ct)
        {
            switch (message.Text)
            {
                case "/start":
                    InlineKeyboardController.sumNumbersUpOn = false;
                    InlineKeyboardController.messageLenghtOn = false;

                    // Объект, представляющий кнопки
                    var buttons = new List<InlineKeyboardButton[]>();
                    buttons.Add(new[]
                    {
                        InlineKeyboardButton.WithCallbackData($"Посчитать числа" , $"кнопка 1"),
                        InlineKeyboardButton.WithCallbackData($"Посчитать символы" , $"кнопка 2"),
                    });
                    // передаем кнопки вместе с сообщением (параметр ReplyMarkup)
                    await _telegramClient.SendMessage(message.Chat.Id, $"<b>  Наш бот умеет складывать числа и считать символы.</b> {Environment.NewLine}" +
                    $"{Environment.NewLine}  Можно поменять: просто нажмите другую кнопку {Environment.NewLine}",
                    cancellationToken: ct, parseMode: ParseMode.Html, replyMarkup: new InlineKeyboardMarkup(buttons)); break;

                default:
                    if (!(InlineKeyboardController.sumNumbersUpOn || InlineKeyboardController.messageLenghtOn))
                        await _telegramClient.SendMessage(message.Chat, $"Пришло сообщение: {message.Text}");

                    break;

            }

            if (InlineKeyboardController.sumNumbersUpOn)
            {
                Calculator.Sum(_telegramClient, message, ct);
            }

            if (InlineKeyboardController.messageLenghtOn)
            {
                await _telegramClient.SendMessage(message.Chat, $"В сообщении: {message.Text.Length} символ(ов)");
            }
            return;


        }

    }
}