using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Library;

namespace Proyecto_Pokemon;

/// <summary>
/// Esta clase implementa el comando 'use' del bot.
/// </summary>
public class UsarMochilaCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Envía a la fachada un mensaje con el item a usar y el Pokemons que se verá beneficiado.
    /// </summary>
    /// <param name="itemAndPokemonName">Nombre de Pokemon a ser beneficiado y del item a utilizar concatenados.</param>
    [Command("curar")]
    [Summary(
        """
        Usa el item seleccionado para beneficiar al Pokemon especificado.
        Si no se pudo utilizar el item el jugador no pierde el turno.
        Este comando solo puede ser utilizado por un jugador mientras
        sea su turno.
        """)]
    public async Task ExecuteAsync(
        [Remainder]
        [Summary("Nombre del item a usar y del Pokemon a ser beneficiado concatenados")]
        string itemAndPokemonName
    )
    {
        string itemName = null;
        string pokemonName = null;
        string result;
        
        string[] itemAndPokemonSplit = itemAndPokemonName.Split(" ");
        if (itemAndPokemonSplit.Length > 2)
        {
            itemName = String.Join(" ", itemAndPokemonSplit, 0, itemAndPokemonSplit.Length-1);
            pokemonName = itemAndPokemonSplit[itemAndPokemonSplit.Length-1];
        }
        else if (itemAndPokemonSplit.Length == 2)
        {
            itemName = itemAndPokemonSplit[0];          
            pokemonName = itemAndPokemonSplit[1];
        }
        else
        {
            result = "Para usar un item debes usar el siguiente formato:\n**!use** <**item**> <**pokemon**>";
            await ReplyAsync(result);
            return;
        }

        string displayName = CommandHelper.GetDisplayName(Context);
        result = Fachada.UsarObjetoMochila(displayName, itemName, pokemonName);
        await ReplyAsync(result);
    }
}