using Discord.Commands;

namespace Proyecto_Pokemon;

public class CambiarCommand : ModuleBase<SocketCommandContext>
{
    [Command("cambiar")]
    [Summary("")]
    public async Task ExecuteAsync(
        [Remainder]
        [Summary("Nombre del Pokemon")]
        string pokemonName)
    {
        if (pokemonName == null)
        {await ReplyAsync("Para cambiar de Pokemon actual tenes que usar el siguiente formato: \n**!cambiar** <**nombre del pokemon**>");}
        string playerName = CommandHelper.GetDisplayName(Context);
        string result = Fachada.CambiarPokemones(playerName, pokemonName);
        await ReplyAsync(result);
    }

}