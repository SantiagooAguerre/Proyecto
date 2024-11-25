namespace Proyecto_Pokemon;

public interface ITipo
{
    string Nombre { get; }
    double EsEfectivoOPocoEfectivo(ITipo otroTipo);
}