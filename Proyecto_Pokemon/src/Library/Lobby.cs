using System.Collections.Generic;

namespace Proyecto_Pokemon;

public class Lobby
{
   private List<Entrenadores> Entrenadoress { get; }= new List<Entrenadores>();


   public Entrenadores BuscarJugadorPorIndex(int index)
   {
       return Entrenadoress[index];
   }
   
    public int Cantidad
    {
        get { return this.Entrenadoress.Count; }
    }
    public bool AgregarEntrenadores(string NombreEntrenador)
    {
        if (string.IsNullOrEmpty(NombreEntrenador))
            throw new ArgumentException(nameof(NombreEntrenador));
        if (this.EntrenadorPorNombre(NombreEntrenador) != null) 
            return false;
        this.Entrenadoress.Add(new Entrenadores(NombreEntrenador));
        return true;
    }
    
    public bool SacarEntrenadores(string EntrenadoresName)
    {
        Entrenadores? Entrenadores = EntrenadorPorNombre(EntrenadoresName);
        if (Entrenadores == null)
            return false;
        this.Entrenadoress.Remove(Entrenadores);
        return true;
    }
    
    public Entrenadores? EntrenadorPorNombre(string EntrenadoresName)
    {
        foreach (Entrenadores Entrenadores in this.Entrenadoress)
            if (Entrenadores.Nombre == EntrenadoresName)
            {
                return Entrenadores;
            }
        return null;
    }
    
    public Entrenadores? AnadirRandom(string EntrenadoresName)
    {
        Random random = new Random();
        if (this.Cantidad <= 1)
            return null;
        int numerorandom;
        do
        {
            numerorandom = random.Next(0, this.Cantidad);
        } while (this.Entrenadoress[numerorandom].Nombre == EntrenadoresName);
        return this.Entrenadoress[numerorandom];
    }
    
    public string VerListaLobby()
    {
        string result = null;

        foreach (var entrenador in this.Entrenadoress)
        {
            result += entrenador.Nombre + "\n";
        }

        return result;
    }

    
}
