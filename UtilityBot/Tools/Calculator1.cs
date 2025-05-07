using Telegram.Bot;
using Telegram.Bot.Types;

namespace UtilityBot
{
    internal class Calculator
    {

        async public static void Sum(ITelegramBotClient client, Message message, CancellationToken ct)
        {
            string text = message.Text;
            string[] strSplit = text.Split([' '], StringSplitOptions.RemoveEmptyEntries);
            int[] ArrayIntNumbers = new int[strSplit.Length];
            int result = 0;

            try
            {
                for (int i = 0; i < strSplit.Length; i++) ArrayIntNumbers[i] = int.Parse(strSplit[i]);
                for (int i = 0; i < ArrayIntNumbers.Length; i++) result += ArrayIntNumbers[i];
                message.Text = result.ToString();
            }
            catch (Exception)
            {
                message.Text = $"Error: Ввведены не цифры попробуйте снова ";
            }
            await client.SendMessage(message.Chat, $"Result: {message.Text}");
        }
    }
}
