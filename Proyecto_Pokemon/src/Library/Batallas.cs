namespace Proyecto_Pokemon;

public class Batallas
{
    public Entrenadores entrenador1 {get; set;}
    public Entrenadores entrenador2 {get; set;}
    public Entrenadores entrenadorActual {get; set;}
    private int turno {get; set;}
    
    public bool esquivo;
    
    public Batallas(Entrenadores AshKetchup, Entrenadores diezMedallasGary)
    {
        entrenador1 = AshKetchup;
        entrenador2 = diezMedallasGary;
        entrenadorActual = entrenador1;
        turno = 1;
    }
    
    public string Winner()
    {
        int winner = 0;
        foreach (var pokemon in JugadoresDisponibles()[1].RecibirEquipoPokemon())
        {
            if (pokemon.Vida > 0)
            {
                winner = 1;
            }
        }
        int loser = (winner + 1) % 2;
        return $"\nGanador: {JugadoresDisponibles()[winner].Nombre}. Perdedor: {JugadoresDisponibles()[loser].Nombre}";
    }

    public bool ChequerMuerte()
    {
        return !entrenador1.TienePokemonesVivos() || !entrenador2.TienePokemonesVivos();
    }
    
    public bool ConfirmarSiEntrenadorEstaPeleando(Entrenadores entrenador)
    {
        if (entrenador != null)
        {
            foreach (Entrenadores player in JugadoresDisponibles())
            {
                if (player.Nombre == entrenador.Nombre)
                {
                    return true;
                }
            }
            
        }
        return false;
    }
    
    public bool ConfirmandoEquipoCompleto()
    {
        return entrenador1.RecibirEquipoPokemon().Count == 6 &&
               entrenador2.RecibirEquipoPokemon().Count == 6;
    }

    public string Iniciar(Entrenadores Entrenador1, Entrenadores Entrenador2)
    {
        if(entrenador1.EnBatalla && entrenador2.EnBatalla)
        {
            return "Ya hay una batalla en curso.";
        }
        entrenador1 = Entrenador1;
        entrenador2 = Entrenador2;
        entrenador1.EnBatalla = true;
        entrenador2.EnBatalla = true;
        Random Turno = new Random();
        if (Turno.Next(0, 2) == 0)
        {
            entrenadorActual = entrenador1;
        }
        else
        {
            entrenadorActual = entrenador2;
        }
        return $"{entrenador1.Nombre} y {entrenador2.Nombre} están listos para la batalla \n {entrenadorActual.Nombre} empieza.";
    }

    public string Atacar(IHabilidades habilidad)
    {
        Pokemon atacante = entrenadorActual.PokemonActivo;
        Pokemon defensor = (entrenadorActual == entrenador1) ? entrenador2.PokemonActivo : entrenador1.PokemonActivo;
        string estadoResultado;
        if (atacante.HabilidadCargando != null)
        {
            habilidad = atacante.HabilidadCargando;
            atacante.HabilidadCargando = null;
            bool esEsquivo = esquivo;
            esquivo = false;

            string resultadoAtaque = Pokemon.EjecutarAtaque(atacante, defensor, habilidad, esEsquivo);
            string cambioTurno = CambiarTurno();

            estadoResultado = VerificarEstado(atacante);
            return resultadoAtaque + "\n" + estadoResultado + "\n" + cambioTurno;
        }
        
        if (habilidad == null)
        {
            return "No se seleccionó ninguna habilidad.";
        }

        
        estadoResultado = VerificarEstado(atacante);
        if (!string.IsNullOrEmpty(estadoResultado))
        {
            return estadoResultado;
        }

        if (habilidad.EsDobleTurno)
        {
            atacante.HabilidadCargando = habilidad;
            CambiarTurno();
            return $"{atacante.Nombre} está cargando la habilidad {habilidad.Nombre}...\n";
        }

        if (atacante.HabilidadCargando != null)
        {
            habilidad = atacante.HabilidadCargando;
            atacante.HabilidadCargando = null;
            bool esEsquivo = esquivo;
            esquivo = false;

            string resultadoAtaque = Pokemon.EjecutarAtaque(atacante, defensor, habilidad, esEsquivo);
            string cambioTurno = CambiarTurno();

            estadoResultado = VerificarEstado(atacante);
            return resultadoAtaque + "\n" + estadoResultado + "\n" + cambioTurno;
        }

        bool esEsquivoNormal = esquivo;
        esquivo = false;
        string resultadoAtaqueNormal = Pokemon.EjecutarAtaque(atacante, defensor, habilidad, esEsquivoNormal);
        string cambioTurnoNormal = CambiarTurno();
        estadoResultado = VerificarEstado(atacante);
        return resultadoAtaqueNormal + "\n" + estadoResultado + "\n" + cambioTurnoNormal;
    }

    public List<Entrenadores> JugadoresDisponibles()
    {
        return new List<Entrenadores> { entrenador1, entrenador2 };
    }
    
    public string Esquivar()
    {
        Pokemon atacante = entrenadorActual.PokemonActivo;
        string estadoResultado = VerificarEstado(atacante);
        if (!string.IsNullOrEmpty(estadoResultado))
        {
            return estadoResultado;
        }
        esquivo = true;
        return $"{atacante.Nombre} de {entrenadorActual.Nombre} está preparado para esquivar el proximo movimiento";
    }
    
    public bool StatusBatalla()
    {
        foreach (var player in JugadoresDisponibles())
        {
            bool ongoing = false;
            foreach (var pokemon in player.RecibirEquipoPokemon())
            {
                if (pokemon.Vida > 0)
                {
                    ongoing = true;
                }
            }
            if (!ongoing)
            {
                return false;
            }
        }
        return true;
    }

    public string CambiarPokemon(Pokemon pokemon)
    {
        if (pokemon == null)
        {
            return "Ese Pokémon no está en tu equipo.";
        }
        if (pokemon.Nombre == entrenadorActual.PokemonActivo.Nombre)
        {
            return "Ese ya es tu Pokémon activo.";
        }
        bool cambioExitoso = entrenadorActual.FijarPokemonActual(pokemon);

        if (cambioExitoso)
        {
            return $"{pokemon.Nombre} es tu nuevo Pokémon activo.";
        }
        return $"{entrenadorActual.Nombre} no pudo cambiar a {pokemon.Nombre}.";
    }
    
    public string UsarMochila(Pokemon pokemon, Objetos objeto)
    {
        if (entrenadorActual.Pokemones.Contains(pokemon))
        {
            return "El pokemon que elegiste no pertenece a este entrenador";
        }
        if (entrenadorActual.Mochila.Contains(objeto))
        {
            return "El objeto que elegiste no pertenece a este entrenador";
        }
        return objeto.Usar(pokemon, entrenadorActual);
    }

    public string VerificarEstado(Pokemon atacante)
    {
        Random random = new Random();
        int turnos_noqueado = 4;
        switch (atacante.Estado)
        {
            case "envenenado":
                atacante.Vida -= (int)(atacante.VidaBase * 0.05);
                if (atacante.Vida <= 0)
                {
                    atacante.Vida = 0;
                    return $"{atacante.Nombre} fue derrotado por el veneno.";
                }
                return $"{atacante.Nombre} pierde vida por envenenamiento. Vida restante: {atacante.Vida} / {atacante.VidaBase}";
                break;
            
            case "quemado":
                atacante.Vida -= (int)(atacante.VidaBase * 0.10);
                if (atacante.Vida <= 0)
                {
                    atacante.Vida = 0;
                    return $"{atacante.Nombre} fue derrotado por la quemadura.";
                }
                return $"{atacante.Nombre} está quemado y pierde {(int)(atacante.VidaBase * 0.10)} HP. Vida restante: {atacante.Vida} / {atacante.VidaBase}";
                break;

            case "noqueado":
                if (random.Next(1, 5) < turnos_noqueado)
                {
                    atacante.Estado = null;
                    return $"{atacante.Nombre} se ha recuperado del noqueo y puede volver a atacar.";
                }
                return $"{atacante.Nombre} está noqueado. No puede moverse.";
                break;
        }

        return "";
    }

    public string CambiarTurno()
    {
        if (ChequerMuerte())
        {
            string ganador = DeterminarGanador();
            return $"El combate ha terminado. ¡El ganador es: {ganador}!";
        }
        entrenadorActual = (entrenadorActual == entrenador1) ? entrenador2 : entrenador1;
    
        return $"Es el turno de: {entrenadorActual.Nombre}";
    }
    
    private string DeterminarGanador()
    {
        if (entrenador1.TienePokemonesVivos()) return entrenador1.Nombre;
        if (entrenador2.TienePokemonesVivos()) return entrenador2.Nombre;
        return "Empate";
    }
    
}