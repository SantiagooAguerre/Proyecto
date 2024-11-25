using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Ucu.Poo.DiscordBot.Services;

/// <summary>
/// Esta clase ejecuta el bot de Discord hasta que en la terminal donde se
/// ejecuta el bot se oprime la tecla 'Q'.
/// </summary>
public static class BotLoader
{
    public static async Task LoadAsync()
    {
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets(Assembly.GetExecutingAssembly())
            .Build();

        var serviceProvider = new ServiceCollection()
            .AddLogging(options =>
            {
                options.ClearProviders();
                options.AddConsole();
            })
            .AddSingleton<IConfiguration>(configuration)
            .AddScoped<IBot, Bot>()
            .BuildServiceProvider();

        try
        {
            IBot bot = serviceProvider.GetRequiredService<IBot>();

            await bot.StartAsync(serviceProvider);

            Console.WriteLine("Conectado a Discord. Presione 'q' para salir...");

            do
            {
                var keyInfo = Console.ReadKey();

                if (keyInfo.Key != ConsoleKey.Q) continue;
                
                Console.WriteLine("\nFinalizado");
                await bot.StopAsync();
                
                return;
            } while (true);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            Environment.Exit(-1);
        }
    }
}
