namespace Proyecto_Pokemon;

public class SuperPocion : Objetos
{
    public SuperPocion() : base("Súper Poción") { }

    public override string Usar(Pokemon pokemon, Entrenadores entrenador)
    {
        if (pokemon.Vida <= 0)
        {
            return $"{pokemon.Nombre} está debilitado y no puede usar una Super Poción.";
            
        }

        int vidaRecuperada = 70;
        if ((vidaRecuperada + pokemon.Vida) > pokemon.VidaBase)
        {
            return $"{pokemon.Nombre} no puede curarse más de la vida base, pierdes el objeto.";
            
        }

        pokemon.Vida += vidaRecuperada;
        return $"{entrenador.Nombre} usó {Nombre} en {pokemon.Nombre}. Se recuperaron {vidaRecuperada} HP.";
    }
}