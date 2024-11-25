namespace Proyecto_Pokemon;

public class Entrenadores
{
    public string Nombre { get; }
    public List<Pokemon> Pokemones { get; }
    public int CantidadDePokemones
    {
        get { return Pokemones.Count; }
    }
    public Pokemon PokemonActivo { get; set; }
    public List<Objetos> Mochila { get; }
    public bool EnBatalla { get; set; }

    public Entrenadores(string nombre)
    {
        Nombre = nombre;
        Pokemones = new List<Pokemon>();
        Mochila = InicializarMochila();
        EnBatalla = false;
    }

    public bool BuscarPokemon(string nombrePokemon)
    {
        foreach (Pokemon pokemon in Pokemones)
            if (pokemon.Nombre == nombrePokemon)
                return true;
        return false;
    }
    
    public Pokemon BuscarPokemonYGuardar(string nombrePokemon)
    {
        foreach (Pokemon pokemon in Pokemones)
        {
            if (pokemon.Nombre == nombrePokemon)
            {
                return pokemon;
            }
        }
        return null;
    }
    
    private List<Objetos> InicializarMochila()
    {
        return new List<Objetos>
        {
            new SuperPocion(),
            new SuperPocion(),
            new SuperPocion(),
            new SuperPocion(),
            new Revivir(),
            new CuraTotal(),
            new CuraTotal()
        };
    }
    
    public bool FijarPokemonActual(Pokemon? pokemon = null)
    {
        if (pokemon != null)
        {
            if (pokemon.Vida > 0)
            {
                PokemonActivo = pokemon;
                return true;
            }
            return false;
        }
        else
        {
            foreach (Pokemon poke in Pokemones)
            {
                if (poke.Vida > 0)
                {
                    PokemonActivo = poke;
                    return true;
                }
            }
        }
        return false;
    }
    
    public List<Pokemon> RecibirEquipoPokemon()
    {
        return Pokemones;
    }
    
    public bool TienePokemonesVivos()
    {
        return Pokemones.Any(pokemon => pokemon.Vida > 0);
    }

    public bool AñadirPokemon(Pokemon pokemon)
    {
        if (Pokemones.Count < 6)
        {
            if (!Pokemones.Contains(pokemon))
            {
                if (Pokemones.Count == 0)
                    FijarPokemonActual(pokemon);
                Pokemones.Add(pokemon);
                return true;
            }
        }
        return false;
    }
    
    public List<Objetos> MostrarMochila()
    {
        Dictionary<string, int> contadordeObjetos = new Dictionary<string, int>();
        List<Objetos> listaObjetosUnicos = new List<Objetos>();
        
        foreach (var objetos in Mochila)
        {
            if (contadordeObjetos.ContainsKey(objetos.Nombre))
            {
                contadordeObjetos[objetos.Nombre]++;
            }
            else
            {
                contadordeObjetos[objetos.Nombre] = 1;
                listaObjetosUnicos.Add(objetos);
            }
        }
        for (int i = 0; i < listaObjetosUnicos.Count; i++)
        {
            var objeto = listaObjetosUnicos[i];
            Console.WriteLine($"{i + 1}. {objeto.Nombre} ({contadordeObjetos[objeto.Nombre]}x)");
        }

        return listaObjetosUnicos;
    }
    
    public Objetos BuscarObjeto(string nombreObjeto)
    {
        foreach (Objetos objeto in Mochila)
        {
            if (objeto.Nombre == nombreObjeto)
            {
                return objeto;
            }
        }
        return null;
    }

    
    
}