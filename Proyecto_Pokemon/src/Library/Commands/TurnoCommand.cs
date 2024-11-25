using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Library;

namespace Proyecto_Pokemon;

/// <summary>
/// Esta clase implementa el comando 'checkturn' del bot.
/// </summary>
public class TurnoCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Devuelve de quien es el turno.
    /// </summary>
    [Command("turno")]
    [Summary(
        """
        Devuelve de quien es el turno.
        Se debe estar en partida para utilizar este comando.
        """)]
    public async Task ExecuteAsync()
    {
        string playerName = CommandHelper.GetDisplayName(Context);
        string result = Fachada.RevisarTurno(playerName);
        await ReplyAsync(result);
    }

}