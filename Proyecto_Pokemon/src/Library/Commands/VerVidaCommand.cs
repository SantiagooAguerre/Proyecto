using Discord.Commands;

namespace Proyecto_Pokemon;

public class VerVidaCommand : ModuleBase<SocketCommandContext>
{
    [Command("verVida")]
    [Summary("Saca al usuario del Lobby")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync(
        [Remainder] [Summary("Display name del oponente, opcional")]
        string? opponentDisplayName = null)
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        string result;
        result = Fachada.VerPokemones(displayName, opponentDisplayName);

        await ReplyAsync(result);
    }
}