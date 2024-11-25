namespace Proyecto_Pokemon;

public class CuraTotal : Objetos
{
    public CuraTotal() : base("Cura Total") { }

    public override string Usar(Pokemon pokemon, Entrenadores entrenador)
    {
        if (pokemon.Estado == null)
        {
            return $"{pokemon.Nombre} no está afectado por ningún estado alterado.";
        }

        pokemon.Estado = null;
        return $"{entrenador.Nombre} usó {Nombre} en {pokemon.Nombre}. Todos los efectos negativos fueron curados.";
    }
}