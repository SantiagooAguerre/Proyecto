using Discord.Commands;


namespace Proyecto_Pokemon;
/// <summary>
/// 
/// </summary>
public class OpcionesCommand : ModuleBase<SocketCommandContext>
{
    [Command("opciones")]
    [Summary("Muestra todos los pokemones que se pueden seleccionar para el equipo")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync()
    {
        await ReplyAsync(Fachada.OpcionesPokemones());
    }
}