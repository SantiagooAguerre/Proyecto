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
            "!ataques: Ataques disponibles del Pokemon activo del jugador.",
            "!cambiar: Cambiar Pokemon activo en batalla.",
            "!elegir: Elegir Pokemon.",
            "!elegirRandom: Agrega al equipo del jugador un Pokémon aleatorio.",
            "!esquivo: Esquivar.",
            "!iniciar: Empieza la batalla entre dos jugadores que estan en el Lobby.",
            "!salir: Saca al usuario del Lobby.",
            "!turno: Devuelve de quien es el turno.",
            "!unirse: Ingresa al usuario al Lobby",
            "!usar: Ataque que vas a usar.",
            "!curar:Usa el item seleccionado para beneficiar al Pokemon especificado.",
            "!lobby: Muestra quienes estan en el lobby.",
            "!verMochila: Muestra los items disponibles del jugador.",
            "!verVida: Saca al usuario del Lobby.",
        };
        string response = "Lista de comandos disponibles:\n" + string.Join("\n", commands);

        await ReplyAsync(response);
    }
}

