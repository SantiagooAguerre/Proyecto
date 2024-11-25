using Discord.Commands;


namespace Proyecto_Pokemon;

public class UnirseCommand : ModuleBase<SocketCommandContext>
{
    [Command("unirse")]
    [Summary("Ingresa al usuario al Lobby")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync()
    {
        string nombre = CommandHelper.GetDisplayName(Context);
        await ReplyAsync(Fachada.MeterUsuarioAlLobby(nombre));
    }
}