using Telegram.Bot;
using Telegram.Bot.Polling;
using Microsoft.Extensions.Configuration;

namespace CSharpTelegramBot
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var token = configuration["TelegramBot:Token"];

            TelegramBotClient botClient = new TelegramBotClient(token);
            BotMessageHandler messageHandler = new BotMessageHandler(botClient);

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Бот запущен...");

            ReceiverOptions receiverOptions = new ReceiverOptions();
            botClient.StartReceiving(
                messageHandler.HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions);

            CancellationTokenSource cts = new CancellationTokenSource();
            Thread.Sleep(Timeout.Infinite);
        }

        private static Task HandleErrorAsync(ITelegramBotClient botClient, Exception ex, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{ex.Message}");
            return Task.CompletedTask;
        }
    }
}
