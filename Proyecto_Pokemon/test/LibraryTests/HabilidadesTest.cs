using NUnit.Framework;

namespace Proyecto_Pokemon
{
    [TestFixture]
    public class HabilidadesTest
    {
        private Habilidades habilidad;
        private ITipo tipoFuego;

        [SetUp]
        public void Setup()
        {
            var elementoFuego = new Dictionary<string, double>
            {
                { "Acero", 2.0 }, { "Volador", 0.5 }, { "Agua", 0.5 }, { "Hielo", 2.0 }, { "Planta", 2.0 },
                { "Bicho", 2.0 }, { "Electrico", 1.0 }, { "Normal", 1.0 }, { "Roca", 2.0 }, { "Tierra", 1.0 },
                { "Fuego", 0.5 }, { "Lucha", 1.0 }, { "Hada", 1.0 }, { "Psiquico", 1.0 }, { "Veneno", 1.0 },
                { "Dragon", 1.0 }, { "Fantasma", 1.0 }, { "Siniestro", 1.0 }
            };
            tipoFuego = new Tipo("Fuego", elementoFuego);
            habilidad = new Habilidades("Llama", tipoFuego, 50, 90, 10, false);
        }

        [Test]
        public void Habilidad_DeberiaTenerNombreCorrecto()
        {
            Assert.That(habilidad.Nombre, Is.EqualTo("Llama"));
        }

        [Test]
        public void Habilidad_DeberiaTenerTipoCorrecto()
        {
            Assert.That(habilidad.Tipo, Is.EqualTo(tipoFuego));
        }

        [Test]
        public void Habilidad_DeberiaTenerDanioCorrecto()
        {
            Assert.That(habilidad.Danio, Is.EqualTo(50));
        }

        [Test]
        public void Habilidad_DeberiaTenerPrecisionCorrecta()
        {
            Assert.That(habilidad.Precision, Is.EqualTo(90));
        }

        [Test]
        public void Habilidad_DeberiaTenerPPCorrecto()
        {
            Assert.That(habilidad.PP, Is.EqualTo(10));
        }

        [Test]
        public void Habilidad_DeberiaSerDobleTurno()
        {
            Assert.That(habilidad.EsDobleTurno, Is.EqualTo(false));
        }
    }
}