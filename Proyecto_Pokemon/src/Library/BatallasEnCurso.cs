namespace Proyecto_Pokemon;

public class BatallasEnCurso
{
    private List<Batallas> Partidas = new List<Batallas>();
    
    private Lobby lobby = new Lobby();
    
    public bool TerminarPartida(Batallas partida)
    {
        if (Partidas.Remove(partida))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public string AgregarJugadorALobby(string Jugador)
    {
        if (lobby.AgregarEntrenadores(Jugador))
        {
            lobby.AgregarEntrenadores(Jugador);
            return $"El jugador {Jugador} ha sido agregado al lobby";
        }
        return $"El jugador {Jugador} ya se encuentra en el lobby";
    }

    public Batallas BatallaPorEntrenador(Entrenadores entrenador)
    {
        foreach (Batallas batalla in Partidas)
        {
            if (batalla.JugadoresDisponibles().Contains(entrenador))
            {
                return batalla;
            }
        }
        return null;
    }
    
    public Entrenadores? EntrenadorPorNombre(string nombre)
    {
        foreach (Batallas partida in Partidas)
        foreach (Entrenadores entrenador in partida.JugadoresDisponibles())
            if (entrenador.Nombre == nombre)
                return entrenador;
        return null;
    }

    public List<Batallas> ListaDeBatallas()
    {
        return Partidas;
    }
    
    public Batallas CrearPartida(Entrenadores entrenador1, Entrenadores entrenador2)
    {
        Batallas partida = new Batallas(entrenador1, entrenador2);
        partida.Iniciar(entrenador1, entrenador2);
        Partidas.Add(partida);
        return partida;
    }

}