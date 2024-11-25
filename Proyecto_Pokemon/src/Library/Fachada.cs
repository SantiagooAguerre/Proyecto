namespace Proyecto_Pokemon;

public static class Fachada
{
    private static LogicaDePokemones CantidadPokemones { get;  set; } = LogicaDePokemones.Instance;
    private static Lobby lobby { get; } = new Lobby();
    private static BatallasEnCurso batallaencurso { get; } = new BatallasEnCurso();
    
    public static string OpcionesPokemones()
    {
        return "**Opciones para el Equipo:**\n" + CantidadPokemones.MostrarPokemones();
    }
    
    public static string CrearBatalla(string NombreEntrenador1, string NombreEntrenador2)
    {
        Entrenadores entrenador1 = lobby.EntrenadorPorNombre(NombreEntrenador1);
        Entrenadores entrenador2 = lobby.EntrenadorPorNombre(NombreEntrenador2);
        lobby.SacarEntrenadores(NombreEntrenador1);
        lobby.SacarEntrenadores(NombreEntrenador2);
        batallaencurso.CrearPartida(entrenador1, entrenador2);
        return $"**EMPIEZA LA PELEA ENTRE {NombreEntrenador1} CONTRA {NombreEntrenador2}**\n";
    }
    
    public static string VerHabilidades(string nombreEntrenador)
    {
        Entrenadores entrenador = batallaencurso.EntrenadorPorNombre(nombreEntrenador);
    
        if (entrenador == null)
            return $"{nombreEntrenador}, no estás en ninguna partida.";
    
        if (entrenador.CantidadDePokemones == 0)
            return $"{nombreEntrenador}, no tienes ningún Pokémon.";
    
        Pokemon pokemonActivo = entrenador.PokemonActivo;
        if (pokemonActivo == null)
            return $"{nombreEntrenador}, no tienes un Pokémon activo.";
    
        string ataques = pokemonActivo.MostrarHabilidades();
        if (string.IsNullOrEmpty(ataques))
            return $"{nombreEntrenador}, tu Pokémon activo no tiene ataques disponibles.";
    
        return $"{nombreEntrenador}, estos son los ataques de tu Pokémon activo ({pokemonActivo.Nombre}):\n{ataques}";
    }

    public static string ElegirHabilidad(string nombreEntrenador, string nombreHabilidad) 
    {
        Entrenadores entrenador = batallaencurso.EntrenadorPorNombre(nombreEntrenador);
        if (entrenador == null)
        {
            return $"{nombreEntrenador}, necesitas estar en una batalla para atacar.";
        }
        Batallas batalla = batallaencurso.BatallaPorEntrenador(entrenador);
        if (!batalla.ConfirmandoEquipoCompleto())
        {
            return "Ambos jugadores no eligieron los 6 pokemones para iniciar el combate";
        }

        if (batalla == null)
        {
            return "No estás participando en una batalla activa.";
        }

        if (batalla.entrenadorActual.Nombre != nombreEntrenador)
        {
            return $"{nombreEntrenador}, no es tu turno.";
        }

        Pokemon atacante = batalla.entrenadorActual.PokemonActivo;

        if (atacante == null || atacante.Vida == 0)
        {
            return $"{nombreEntrenador}, tu pokemon actuall está fuera de combate. Cambie de pokemon.";
        }
        
        IHabilidades habilidad = atacante.Habilidades.FirstOrDefault(h => h.Nombre == nombreHabilidad);
        if (habilidad == null)
        {
            return $"La habilidad '{nombreHabilidad}' no pudo ser encontrada en {atacante.Nombre}.";
        }
        
        string finaladoAtaque = batalla.Atacar(habilidad);
        string estadoJuego = CierreDeLaBatalla(batalla);
        return $"{finaladoAtaque}\n{estadoJuego}";
    }


    public static string RevisarTurno(string nombreEntrenador)
    {
        Entrenadores entrenador = batallaencurso.EntrenadorPorNombre(nombreEntrenador);
        if (entrenador == null)
        {
            return $"El jugador {nombreEntrenador} no está en ninguna partida.";
        }

        Batallas batalla = batallaencurso.BatallaPorEntrenador(entrenador);
        if (batalla != null)
        {
            if (batalla.ConfirmarSiEntrenadorEstaPeleando(entrenador))
            {
                if (batalla.entrenadorActual.Nombre == nombreEntrenador)
                {
                    return $"{nombreEntrenador}, es tu turno";
                }
                return $"{nombreEntrenador}, no es tu turno";
            }
        }
        return null;
    }

    public static string CierreDeLaBatalla(Batallas batalla) //
    {
        if (batalla != null)
        {
            if (batalla.StatusBatalla())
            {
                Entrenadores proximoTurno = batalla.JugadoresDisponibles().FirstOrDefault(e => e.Nombre == batalla.entrenadorActual.Nombre);
                return $"Próximo turno, ahora es el turno de {proximoTurno?.Nombre ?? "desconocido"}";
            }
            batallaencurso.TerminarPartida(batalla);
            return batalla.Winner();
        }
        return "La partida no pudo ser encontrada";
    }
    
    public static string IniciarBatalla(string NombreEntrenador1, string NombreEntrenador2)
    {
        Entrenadores entrenador2;
        Entrenadores entrenador1 = batallaencurso.EntrenadorPorNombre(NombreEntrenador1);
        if (batallaencurso.BatallaPorEntrenador(entrenador1) != null)
        {
            return $"{NombreEntrenador1} se encuentra en una batalla.";
        }

        if (lobby.EntrenadorPorNombre(NombreEntrenador1) == null)
            return $"{NombreEntrenador1} no estás en el lobby.";
        
        if (!RevisarEntrenador2() && !HayEntrenadoresLobby())
            return "no hay nadie en el lobby.";
        
        if (!RevisarEntrenador2())
        {
            entrenador2 = batallaencurso.EntrenadorPorNombre(NombreEntrenador2);
            if (batallaencurso.BatallaPorEntrenador(entrenador2) != null)
            {
                return $"{NombreEntrenador2} se encuentra en una batalla.";
            }
            entrenador2 = lobby.AnadirRandom(NombreEntrenador1);
            if (entrenador2 == null)
            {
                return "No se encuentra un oponente en el Lobby";
            }
            return CrearBatalla(NombreEntrenador1, entrenador2!.Nombre);
        }
        
        entrenador2 = lobby.EntrenadorPorNombre(NombreEntrenador2!);
        if (!BuscarEntrenador2())
        {
            return $"{NombreEntrenador2} no se lo encontró en el Lobby";
        }

        if (batallaencurso.BatallaPorEntrenador(entrenador2) != null)
            return $"{NombreEntrenador2} se encuentra en una batalla.";
        
        return CrearBatalla(NombreEntrenador1, entrenador2!.Nombre);

        bool BuscarEntrenador2()
        {
            return entrenador2 != null;
        }
        
        bool HayEntrenadoresLobby()
        {
            return lobby.Cantidad != 0;
        }
        
        bool RevisarEntrenador2()
        {
            return !string.IsNullOrEmpty(NombreEntrenador2);
        }
    }
    
    public static string SacarEntrenadorDelLobby(string nombre)
    {
        if (lobby.SacarEntrenadores(nombre))
        {
            return $"{nombre} fue sacado del Lobby.";
        }
        return $"{nombre} ni siquiera está en el Lobby.";
    }
    
    public static string MeterUsuarioAlLobby(string nombre)
    {
        if (batallaencurso.EntrenadorPorNombre(nombre) != null)
        {
            return $"{nombre} ya te encuentras en una batalla y no puedes ser agregado al Lobby.";
        }
        
        if (lobby.AgregarEntrenadores(nombre))
        {
            
            return $"{nombre} ha sido agregado en el Lobby para un encuentro.";
        }

        return $"{nombre} ya se encuentra en el Lobby.";
    }

    public static string VerLobby()
    {
        if (lobby.VerListaLobby() == null)
        {
            return "Nadie se encuentra en el Lobby actualmente";
        }
        
        return "Gente en Lobby: \n" + lobby.VerListaLobby();
    }
    
    public static string EsquivarPokemon(string nombreEntrenador)
    {
        Entrenadores entrenador = batallaencurso.EntrenadorPorNombre(nombreEntrenador);
        if (entrenador == null)
        {
            return $"El jugador {nombreEntrenador} no está en ninguna partida.";
        }

        Batallas batalla = batallaencurso.BatallaPorEntrenador(entrenador);
        if (batalla == null)
        {
            return "La partida no pudo ser encontrada";
        }
        
        if (batalla.entrenadorActual.Nombre == nombreEntrenador)
        {
            if (!batalla.ConfirmandoEquipoCompleto())
            {
                return "Ambos jugadores no han seleccionado 6 pokemones para iniciar el combate";
            }
            string final = batalla.Esquivar();
            batalla.CambiarTurno();
            string cierre = CierreDeLaBatalla(batalla);
            return final + "\n" + cierre;
        }
        return "No eres el jugador activo, no puedes realizar acciones";
    }
    
    public static string CambiarPokemones(string nombreEntrenador, string nombrePokemon)
    {
        Entrenadores player = batallaencurso.EntrenadorPorNombre(nombreEntrenador);
        if (player == null)
        {
            return $"El jugador {nombreEntrenador} no está en ninguna partida.";
        }

        Batallas batalla = batallaencurso.BatallaPorEntrenador(player);
        if (batalla == null)
        {
            return "La partida no pudo ser encontrada";
        }

        if (batalla.entrenadorActual.Nombre == nombreEntrenador)
        {
            if (!batalla.ConfirmandoEquipoCompleto())
            {
                return "Ambos jugadores no han seleccionado 6 pokemones para iniciar el combate";
            }

            Pokemon choosenPokemon = player.BuscarPokemonYGuardar(nombrePokemon);
            if (choosenPokemon == null)
            {
                return $"El pokemon {nombrePokemon} no fue encontrado en tu equipo";
            }
            
            if (choosenPokemon.Vida == 0)
            {
                return $"{nombreEntrenador}, tu pokemon actual está fuera de combate. Cambie de pokemon.";
            }

            string final = batalla.CambiarPokemon(choosenPokemon);
            if (final == "Ese Pokemon no está en tu equipo.")
            {
                return final;
            }

            batalla.CambiarTurno();
            string cierre = CierreDeLaBatalla(batalla);
            return final + "\n" + cierre;
        }

        return "No eres el jugador activo, no puedes realizar acciones";
    }
    
    public static string VerMochila(string nombreEntrenador)
    {
        Entrenadores? entrenador = batallaencurso.EntrenadorPorNombre(nombreEntrenador);

        if (entrenador == null || batallaencurso.BatallaPorEntrenador(entrenador) == null)
        {
            return $"{nombreEntrenador}, no estás en una partida.";
        }

        List<Objetos> listaObjetosUnicos = entrenador.MostrarMochila();
        string final = $"{nombreEntrenador}, estos son tus items disponibles:\n";

        foreach (var objeto in listaObjetosUnicos)
        {
            int cantidad = entrenador.Mochila.Count(o => o.Nombre == objeto.Nombre);
            final += $"{cantidad} {objeto.Nombre}\n";
        }
        return final;
    }
    
    public static string UsarObjetoMochila(string nombreEntrenador, string item, string pokemon)
    {
        Entrenadores entrenador = batallaencurso.EntrenadorPorNombre(nombreEntrenador);
        Batallas batalla = batallaencurso.BatallaPorEntrenador(entrenador);
    
        if (entrenador == null)
        {
            return $"El jugador {nombreEntrenador} no está en ninguna partida.";
        }

        if (batalla == null)
        {
            return "Partida inexistente.";
        }
    
        if (batalla.JugadoresDisponibles()[batalla.entrenadorActual == batalla.entrenador1 ? 0 : 1].Nombre == nombreEntrenador)
        {
            if (!batalla.ConfirmandoEquipoCompleto())
            {
                return "Ambos jugadores no han seleccionado 6 pokemones para iniciar el combate";
            }

            Objetos objetoEncontrado = entrenador.BuscarObjeto(item);
            Pokemon pokemonEncontrado = entrenador.BuscarPokemonYGuardar(pokemon);

            if (objetoEncontrado == null)
            {
                return $"El objeto {item} no está disponible en la mochila del jugador.";
            }

            if (!pokemonEncontrado.Nombre.Equals(pokemon, StringComparison.OrdinalIgnoreCase))
            {
                return $"El Pokémon {pokemon} no pertenece al jugador.";
            }

            string final = batalla.UsarMochila(pokemonEncontrado, objetoEncontrado);
            if (final.Contains("éxito"))
            {
                batalla.CambiarTurno();
                string cierre = CierreDeLaBatalla(batalla);
                return final + "\n" + cierre;
            }
            return final;
        }

        return "No eres el jugador activo, no puedes realizar acciones.";
    }

    
    public static string SeleccionarEquipo(string nombreEntrenador, string nombrePokemon)
    {
        LogicaDePokemones logicaDePokemones = new LogicaDePokemones();
        List<Pokemon> listaPokemones = logicaDePokemones.InicializarPokemones();
        Entrenadores entrenador = batallaencurso.EntrenadorPorNombre(nombreEntrenador);
        if (entrenador == null)
        {
            return $"{nombreEntrenador}, para poder elegir un equipo, primero debes estar en una batalla";
        }
        if (entrenador.CantidadDePokemones < 6)
        {
            if (entrenador.BuscarPokemon(nombrePokemon))
            {
                return $"El pokemon {nombrePokemon} ya está en el equipo de {nombreEntrenador}, no puedes volver a añadirlo";
            }
            foreach (Pokemon pokemon in listaPokemones)
            {
                if (pokemon.Nombre == nombrePokemon)
                {
                    entrenador.AñadirPokemon(pokemon);
                    if (entrenador.CantidadDePokemones == 6)
                    {
                        return $"El pokemon {nombrePokemon} fue añadido al equipo de {nombreEntrenador}\nTu equipo está completo.";
                    }
                    return $"El pokemon {nombrePokemon} fue añadido al equipo de {nombreEntrenador}.\nElegiste {entrenador.CantidadDePokemones}/6";
                }
            }
            return $"{nombreEntrenador}, el pokemon {nombrePokemon} no fue encontrado";
        }
        return $"{nombreEntrenador} ya tienes 6 pokemones en el equipo, no puedes elegir más";
    }
    
    public static string elegirRandomente(string nombreEntrenador)
    {
        LogicaDePokemones logicaDePokemones = new LogicaDePokemones();
        List<Pokemon> listaPokemones = logicaDePokemones.InicializarPokemones();
        Entrenadores entrenador = batallaencurso.EntrenadorPorNombre(nombreEntrenador);
        if (entrenador == null)
        {
            return $"{nombreEntrenador}, no estás en una partida.";
        }
        if (entrenador.CantidadDePokemones >= 6)
        {
            return $"{nombreEntrenador}, ya tienes un equipo completo de Pokémon.";
        }
        List<int> availablePokemonIndexes = Enumerable.Range(0, listaPokemones.Count).ToList();
        Random random = new Random();
        string final = $"{nombreEntrenador}, estos son los Pokemones elegidos aleatoriamente:\n **";
        while (entrenador.CantidadDePokemones < 6)
        {
            int valorRandom = random.Next(availablePokemonIndexes.Count);
            Pokemon pokemonElegido = listaPokemones[availablePokemonIndexes[valorRandom]];

            if (!entrenador.BuscarPokemon(pokemonElegido.Nombre))
            {
                entrenador.AñadirPokemon(pokemonElegido);
                final += $"{pokemonElegido.Nombre}\n";
                availablePokemonIndexes.RemoveAt(valorRandom);
            }
        }
        return final += "**";
    }

    public static string VerPokemones(string nombreEntrenador, string? nombreEntrenador2 = null)
    {
        Entrenadores entrenador = batallaencurso.EntrenadorPorNombre(nombreEntrenador);
        if (entrenador == null)
        {
            return $"El jugador {nombreEntrenador} no está en ninguna partida.";
        }
        if (nombreEntrenador2 == null)
        {
            if (entrenador.CantidadDePokemones < 6)
            {
                return $"{entrenador.Nombre} aún no tenés tu equipo completo.";
            }
            string final = $"{nombreEntrenador} esta es la vida de tus Pokemons: \n";
            foreach (Pokemon pokemon in entrenador.RecibirEquipoPokemon())
            {
                string tipo = "";
                if (pokemon.TipoPrincipal != null)
                    tipo += $"{pokemon.TipoPrincipal.Nombre} ";

                if (pokemon == entrenador.PokemonActivo)
                {
                    if (pokemon.Estado != null)
                        final += $"**{pokemon.Nombre} | HP: {pokemon.Vida} / {pokemon.VidaBase} | Tipo: ({tipo})**" + $"**\n";
                    else
                        final += $"**{pokemon.Nombre} | HP: {pokemon.Vida} / {pokemon.VidaBase} | Tipo: ({tipo})**\n";
                }
                else if (pokemon.Vida == 0)
                {
                    final += $"~~{pokemon.Nombre} | HP: {pokemon.Vida} / {pokemon.VidaBase} | Tipo: ({tipo}) (MUERTO)~~\n";
                }
                else
                if (pokemon.Estado != null)
                    final += $"{pokemon.Nombre} | HP: {pokemon.Vida} / {pokemon.VidaBase} | Tipo: ({tipo})" + $"**({pokemon.Estado})**\n";
                else 
                    final += $"{pokemon.Nombre} | HP: {pokemon.Vida} / {pokemon.VidaBase} | Tipo: ({tipo})\n";
            }
            return final;
        }
        else
        {
            Entrenadores entrenador2 = batallaencurso.EntrenadorPorNombre(nombreEntrenador2);
            string final = $"Esta es la vida de los Pokemons de {nombreEntrenador2}: \n";
            Batallas batalla = batallaencurso.BatallaPorEntrenador(entrenador);
            if (batalla != null && batalla.ConfirmarSiEntrenadorEstaPeleando(entrenador) && batalla.ConfirmarSiEntrenadorEstaPeleando(entrenador2) && entrenador2 != null)
            {
                if (entrenador2.CantidadDePokemones < 6)
                {
                    return $"{nombreEntrenador2} aún no tiene su equipo completo.";
                }
                foreach (Pokemon pokemon in entrenador2.RecibirEquipoPokemon())
                {
                    string tipo = "";
                    if (pokemon.TipoPrincipal != null)
                        tipo += $"{pokemon.TipoPrincipal.Nombre} ";
    
                    if (pokemon == entrenador2.PokemonActivo)
                    {
                        if (pokemon.Estado != null)
                            final += $"**{pokemon.Nombre} | HP: {pokemon.Vida} / {pokemon.VidaBase} Tipo: ({tipo})**" + $"**\n";
                        else 
                            final += $"**{pokemon.Nombre} | HP: {pokemon.Vida} / {pokemon.VidaBase} ({tipo})**\n";
                    }
                    else if (pokemon.Vida == 0)
                        final += $"~~{pokemon.Nombre} | HP: {pokemon.Vida} / {pokemon.VidaBase} | Tipo: ({tipo}) **(MUERTO)**~~\n";
                    else
                        if (pokemon.Estado != null)
                            final += $"{pokemon.Nombre} | HP: {pokemon.Vida} / {pokemon.VidaBase} | Tipo: ({tipo})" + $" **({pokemon.Estado})**\n";
                        else 
                            final += $"{pokemon.Nombre} | HP: {pokemon.Vida} / {pokemon.VidaBase} | Tipo: ({tipo})\n";
                }
                return final;
            }

            return $"El jugador {nombreEntrenador2} no está en tu partida.";
        }
    }

}
