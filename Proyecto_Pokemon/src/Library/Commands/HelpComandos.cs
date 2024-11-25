using Discord.Commands;
using Library.Commands;

namespace Proyecto_Pokemon;

public class HelpComandos : ModuleBase<SocketCommandContext>
{
    [Command("Help")]
    [Summary("Muestra la lista de comandos disponibles.")]
    public async Task ExecuteAsync()
    {
        string comandos =
        """
            **Lista de comandos disponibles:**
            
            - **!ataques**:  Ataques disponibles del Pokemon activo del jugador.
            - **!cambiar**:  Cambiar Pokemon activo en batalla.
            - **!elegir**:  Elegir Pokemon.
            - **!elegirRandom**:  Agrega al equipo del jugador un Pokémon aleatorio.
            - **!esquivo**:  Intenta esquivar el ataque del oponente.
            - **!iniciar**:  Empieza la batalla entre dos jugadores que estan en el Lobby.
            - **!salir**:  Saca al usuario del Lobby.
            - **!turno**:  Devuelve de quien es el turno.
            - **!unirse**:  Ingresa al usuario al Lobby.
            - **!usar**:  Ataque que vas a usar.
            - **!curar**:  Usa el item seleccionado para beneficiar al Pokemon especificado.
            - **!lobby**:  Muestra quienes estan en el lobby.
            - **!verMochila**:  Muestra los items disponibles del jugador.
            - **!verVida**:  Muestra la vida actual de los Pokémon en batalla.
        """;

        await ReplyAsync(comandos);
    }
}

