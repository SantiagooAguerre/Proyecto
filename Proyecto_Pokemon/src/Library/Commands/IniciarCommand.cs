using Discord.Commands;

namespace Proyecto_Pokemon;

public class IniciarCommand : ModuleBase<SocketCommandContext>
{
    [Command("iniciar")]
    [Summary("Empieza la batalla entre dos jugadores que estan en el Lobby.")]
    public async Task ExecuteAsync(
        [Remainder] [Summary("Es opcional tener un segundo entrendaor elegido")] string? entrenador2 = null)
    {
        string entrenador = CommandHelper.GetDisplayName(Context);
        string result = Fachada.IniciarBatalla(entrenador, entrenador2);
        await ReplyAsync(result);
        if (result.Contains(" CONTRA "))
        {
            await ReplyAsync("**!elegir** <NombrePokemonENMAYUSCULA> para elegir un Pokemon para el equipo\n**!elegirRandom** selecciona aleatoriamente a los Pokemones\n**!opciones** para ver todas los Pokemones para tu equipo.\n**!help** para ver los comandos disponibles");
        }
            
    }
}