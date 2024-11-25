using Discord.Commands;

namespace Proyecto_Pokemon;

public class SalirCommand : ModuleBase<SocketCommandContext>
{
    [Command("salir")]
    [Summary("Saca al usuario del Lobby")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync()
    {
        string nombre = CommandHelper.GetDisplayName(Context);
        await ReplyAsync(Fachada.SacarEntrenadorDelLobby(nombre));
    }
}
