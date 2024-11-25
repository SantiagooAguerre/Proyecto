using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Ucu.Poo.DiscordBot.Services;

/// <summary>
/// Esta clase implementa el bot de Discord.
/// </summary>
public class Bot : IBot
{
    private ServiceProvider? serviceProvider;
    private readonly ILogger<Bot> logger;
    private readonly IConfiguration configuration;
    private readonly DiscordSocketClient client;
    private readonly CommandService commands;

    public Bot(ILogger<Bot> logger, IConfiguration configuration)
    {
        this.logger = logger;
        this.configuration = configuration;

        DiscordSocketConfig config = new()
        {
            AlwaysDownloadUsers = true,
            GatewayIntents =
                GatewayIntents.AllUnprivileged
                | GatewayIntents.MessageContent /*
                | GatewayIntents.GuildMembers*/
        };

        client = new DiscordSocketClient(config);
        commands = new CommandService();


    }

    public async Task StartAsync(ServiceProvider services)
    {
        string discordToken = configuration["DiscordToken"] ?? throw new Exception("Falta el token");

        logger.LogInformation("Iniciando el con token {Token}", discordToken);

        serviceProvider = services;

        await commands.AddModulesAsync(Assembly.GetExecutingAssembly(), serviceProvider);

        await client.LoginAsync(TokenType.Bot, discordToken);
        await client.StartAsync();

        client.MessageReceived += HandleCommandAsync;
        client.Ready += OnReadyAsync;

    }

    public async Task StopAsync()
    {
        logger.LogInformation("Finalizando");
        await client.LogoutAsync();
        await client.StopAsync();
    }

    private async Task HandleCommandAsync(SocketMessage arg)
    {
        if (arg is not SocketUserMessage message || message.Author.IsBot)
        {
            return;
        }

        int position = 0;
        bool messageIsCommand = message.HasCharPrefix('!', ref position);

        if (messageIsCommand)
        {
            await commands.ExecuteAsync(
                new SocketCommandContext(client, message),
                position,
                serviceProvider);

        }
    }


    private async Task OnReadyAsync()
    {
            // Toma el primer servidor (guild) donde esté el bot
            var guild = client.Guilds.FirstOrDefault();
            if (guild != null)
            {
                // Toma el primer canal de texto accesible
                var channel = guild.TextChannels.FirstOrDefault();
                if (channel != null)
                {
                    await channel.SendMessageAsync("¡Hola! El bot ha iniciado correctamente 🎉.");
                    logger.LogInformation("Mensaje enviado al canal {ChannelName} en el servidor {GuildName}.",
                        channel.Name, guild.Name);
                }
                else
                {
                    logger.LogWarning("No se encontró un canal de texto accesible en el servidor {GuildName}.",
                        guild.Name);
                }
            }
            else
            {
                logger.LogWarning("El bot no está en ningún servidor.");
            }
        }
    }


///private async Task OnReadyAsync()
    ///{
    /// channel.SendMessageAsync("¡Hola a todos! El bot ha iniciado correctamente 🎉.");
      ///  logger.LogInformation("¡El bot ha iniciado correctamente y está listo para operar! 🎉");
       /// await Task.CompletedTask;
    ///}
///}

///private async Task OnReadyAsync()
///{
///logger.LogInformation("El bot está listo para operar.");
///Console.WriteLine("El bot se ha iniciado correctamente.");
///}