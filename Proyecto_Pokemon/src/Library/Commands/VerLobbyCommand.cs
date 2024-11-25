using Discord.Commands;

namespace Proyecto_Pokemon;

public class VerLobbyCommand : ModuleBase<SocketCommandContext>
{
    [Command("lobby")]
    [Summary("Muestra quienes estan en el lobby")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync()
    {
        await ReplyAsync(Fachada.VerLobby());
    }
}