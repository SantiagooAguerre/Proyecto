namespace Proyecto_Pokemon;

public abstract class Objetos
{
    public string Nombre { get; }

    public Objetos(string nombre)
    {
        Nombre = nombre;
    }

    public abstract string Usar(Pokemon pokemon, Entrenadores entrenador);
}