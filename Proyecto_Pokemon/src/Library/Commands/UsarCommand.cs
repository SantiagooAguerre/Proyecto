using Discord.Commands;
namespace Proyecto_Pokemon;

public class UsarCommand : ModuleBase<SocketCommandContext>
{
    [Command("usar")]
    [Summary("")]
    public async Task ExecuteAsync(
        [Remainder]
        [Summary("Ataque que vas a usar.")]
        string? attack = null)
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        string result = Fachada.ElegirHabilidad(displayName, attack);
        await ReplyAsync(result);
    }
}