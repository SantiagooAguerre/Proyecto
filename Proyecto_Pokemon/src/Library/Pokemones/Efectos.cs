namespace Proyecto_Pokemon;

public class Efectos : IEfectos
{
    public string Nombre { get; set; }

    public Efectos(string nombre)
    {
        Nombre = nombre;
    }
}