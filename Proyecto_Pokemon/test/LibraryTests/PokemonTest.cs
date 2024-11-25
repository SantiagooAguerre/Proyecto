namespace Proyecto_Pokemon;

using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class PokemonTest
{
    private ITipo tipoFuego;
    private ITipo tipoAgua;
    private IHabilidades habilidad;
    private Pokemon charmander;

    [SetUp]
    public void Setup()
    {
        tipoFuego = new Tipo("Fuego", new Dictionary<string, double> { { "Agua", 0.5 }, { "Planta", 2.0 } });
        tipoAgua = new Tipo("Agua", new Dictionary<string, double> { { "Fuego", 2.0 }, { "Planta", 0.5 } });
        habilidad = new Habilidades("Llamarada", tipoFuego, 50, 80, 10, false);
        charmander = new Pokemon("Charmeleon", 100, tipoFuego);
    }

    [Test]
    public void Pokemon_CrearPokemon_DeberiaAsignarNombreYVida()
    {
        Assert.That(charmander.Nombre, Is.EqualTo("Charmeleon"));
        Assert.That(charmander.Vida, Is.EqualTo(100));
    }

    [Test]
    public void Pokemon_AprenderHabilidad_DeberiaAgregarHabilidadALaLista()
    {
        charmander.AprenderHabilidad(habilidad);
        Assert.That(charmander.Habilidades.Count, Is.EqualTo(1));
        Assert.That(charmander.Habilidades[0].Nombre, Is.EqualTo("Llamarada"));
    }

    [Test]
    public void Pokemon_MostrarHabilidades_DeberiaMostrarHabilidadCorrectamente()
    {
        charmander.AprenderHabilidad(habilidad);
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            charmander.MostrarHabilidades();
            var resultado = sw.ToString().Trim();
            Assert.That(resultado, Is.EqualTo("1. Llamarada - Daño: 50, Precisión: 80, Tipo: Fuego, PP: 10, Doble turno: False"));
        }
    }
}