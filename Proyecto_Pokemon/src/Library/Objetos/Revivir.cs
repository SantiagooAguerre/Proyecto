namespace Proyecto_Pokemon;

public class Revivir : Objetos
{
    public Revivir() : base("Revivir") { }

    public override string Usar(Pokemon pokemon, Entrenadores entrenador)
    {

        if (pokemon.Vida <= 0)
        {
            pokemon.Vida = (int)(pokemon.VidaBase / 2);
            return $"{pokemon.Nombre} ha sido revivido con {pokemon.Vida} puntos de vida.";
        }
        return $"{pokemon.Nombre} no está debilitado. No puedes revivirlo.";
    }
}