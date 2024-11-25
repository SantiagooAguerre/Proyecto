using NUnit.Framework;
using Proyecto_Pokemon;

namespace Proyecto_Pokemon
{
    public class LogicaDePokemonesTests
    {
        private LogicaDePokemones logicaDePokemones;

        [SetUp]
        public void Setup()
        {
            logicaDePokemones = new LogicaDePokemones();
        }

        [Test]
        public void InicializarPokemones_CreaDosPokemonesConHabilidades()
        {
            var pokemones = logicaDePokemones.InicializarPokemones();

            Assert.That(pokemones.Count, Is.EqualTo(18));

            Assert.That(pokemones[0].Nombre, Is.EqualTo("SCEPTILE"));
            Assert.That(pokemones[0].Vida, Is.EqualTo(200));
            Assert.That(pokemones[0].Habilidades.Count, Is.EqualTo(4));

            Assert.That(pokemones[0].Habilidades[0].Nombre, Is.EqualTo("Corte furia"));
            Assert.That(pokemones[0].Habilidades[1].Nombre, Is.EqualTo("Energibola"));
            Assert.That(pokemones[0].Habilidades[2].Nombre, Is.EqualTo("Hoja Aguda"));
            Assert.That(pokemones[0].Habilidades[3].Nombre, Is.EqualTo("Lluevehojas"));

            Assert.That(pokemones[1].Nombre, Is.EqualTo("ARCANINE"));
            Assert.That(pokemones[1].Vida, Is.EqualTo(200));
            Assert.That(pokemones[1].Habilidades.Count, Is.EqualTo(4));

            Assert.That(pokemones[1].Habilidades[0].Nombre, Is.EqualTo("Ascuas"));
            Assert.That(pokemones[1].Habilidades[1].Nombre, Is.EqualTo("Lanzallamas"));
            Assert.That(pokemones[1].Habilidades[2].Nombre, Is.EqualTo("Velocidad Extrema"));
            Assert.That(pokemones[1].Habilidades[3].Nombre, Is.EqualTo("Envite Ígneo"));
        }
    }
}