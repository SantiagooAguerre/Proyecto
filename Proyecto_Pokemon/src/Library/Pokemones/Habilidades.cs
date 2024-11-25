namespace Proyecto_Pokemon;

public class Habilidades : IHabilidades
{
    public string Nombre { set; get; }     
    public ITipo Tipo { set; get; }
    public int Danio { set; get; }
    public int Precision { get; set; }
    public int PP { get; set; }
    public bool EsDobleTurno { get; set; }
    public IEfectos Efectos { get; set; }
    

    public Habilidades(string nombre, ITipo tipo, int danio, int precision, int pp, bool esdobleturno, IEfectos efectos = null)
    {
        Nombre = nombre;
        Tipo = tipo;
        Danio = danio;
        Precision = precision;
        PP = pp;
        EsDobleTurno = esdobleturno;
        Efectos = efectos;
    }
}