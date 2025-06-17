using Telegram.Bot;
using Telegram.Bot.Types;

namespace UtilityBot.Tools
{
   internal  class Calculator
    {    
        
        async public  void Sum(ITelegramBotClient client, Message message, CancellationToken ct)
        {
            message.Text ??= string.Empty;
           
            string[] strSplit = message.Text.Split([' ',',','.'], StringSplitOptions.RemoveEmptyEntries);

            int[] ArrayIntNumbers = new int[strSplit.Length];

            int result = default;

            for (int i = 0; i < strSplit.Length; i++) 
            {
                if (int.TryParse(strSplit[i], out _)) ArrayIntNumbers[i] = int.Parse(strSplit[i]);

                else { message.Text = $"Error: Ввведены не цифры попробуйте снова "; break; }
            }

           for (int i = 0; i < ArrayIntNumbers.Length; i++) result += ArrayIntNumbers[i];
                message.Text = result.ToString();
                                                        
            await client.SendMessage(message.Chat, $"Result: {message.Text}");            
        }
    }
}
