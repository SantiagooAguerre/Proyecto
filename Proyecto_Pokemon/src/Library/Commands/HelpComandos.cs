using Discord.Commands;
using Library.Commands;

namespace Proyecto_Pokemon;

public class HelpComandos : ModuleBase<SocketCommandContext>
{
    [Command("Help")]
    [Summary("Ayuda con comandos")]
    public async Task ExecuteAsync()
    {
        var commands = new List<string>
        {
            "**!elegirRandom**: Agrega al equipo del jugador un Pokémon aleatorio.",
            "**!cambiar**: Muestra el nombre de un Pokémon dado su identificador.",
            "**!comandos**: Muestra la lista de comandos disponibles."
        };
        string response = "Lista de comandos disponibles:\n" + string.Join("\n", commands);

        await ReplyAsync(response);
    }
}

