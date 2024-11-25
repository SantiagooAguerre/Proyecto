using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Library;

namespace Proyecto_Pokemon;

/// <summary>
/// Esta clase implementa el comando 'showitems' del bot.
/// </summary>
public class VerMochilaCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Muestra los items disponibles del jugador.
    /// </summary>
    [Command("verMochila")]
    [Summary(
        """
        Muestra los items disponibles del jugador.
        Se debe estar en partida para utilizar este comando.
        """)]
    public async Task ExecuteAsync()
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        string result = Fachada.VerMochila(displayName);
        await ReplyAsync(result);
    }
}