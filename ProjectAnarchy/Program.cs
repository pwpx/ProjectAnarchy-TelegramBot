using Telegram.Bot;
using Telegram.Bot.Types;
using System;
using System.Threading.Tasks;
using System.Threading;
using Telegram.Bot.Types.ReplyMarkups;

namespace ProjectAnarchy
{
    class Program
    {
        public static TelegramBotClient Client;

        static async Task Main(string[] args)
        {
            Client = new TelegramBotClient("7919052486:AAFCgeMzAjGai5ibiJ8bNvcCchqieXw4vSs");
            Client.StartReceiving(Client_OnMessage, ErrorHandler);
            Thread.Sleep(Timeout.Infinite);
            
        }

        private static async Task Client_OnMessage(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var id = update.Message.Chat.Id;
            var message = update.Message.Text;

            if (message == "Boosters")
            {
                await botClient.SendTextMessageAsync(id,
                    "Information about Boosters" + Environment.NewLine + "Rubin: 400 done orders" + Environment.NewLine + "lonecore: 300 done orders" + Environment.NewLine + "mihan: 200 done orders"
                    );
            }
            else if (message == "Orders")
            {
                await botClient.SendTextMessageAsync(id, "Information about Orders");
            }
            else if (message == "Info")
            {
                await botClient.SendTextMessageAsync(id, "General Information");
            }
            else
            {
                await botClient.SendTextMessageAsync(id, $"You said: {message}");
            }

            GetButtons();
        }
        
        private static IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new[]
                {
                    new[]
                    {
                        new KeyboardButton("Boosters"),
                        new KeyboardButton("Orders"),
                        new KeyboardButton("Info")
                    }
                }
                
            };
        }
        private static Task ErrorHandler(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Error: {exception.Message}");
            return Task.CompletedTask;
        }
    }
}