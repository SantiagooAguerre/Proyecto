using NUnit.Framework;

namespace Proyecto_Pokemon
{
    [TestFixture]
    public class TipoTest
    {
        private Tipo fuego;
        private Tipo agua;
        private Tipo planta;

        [SetUp]
        public void Setup()
        {
            var ventajasFuego = new Dictionary<string, double>
            {
                { "Planta", 2.0 },
                { "Agua", 0.5 }
            };

            var ventajasAgua = new Dictionary<string, double>
            {
                { "Fuego", 2.0 },
                { "Planta", 0.5 }
            };

            var ventajasPlanta = new Dictionary<string, double>
            {
                { "Agua", 2.0 },
                { "Fuego", 0.5 }
            };

            fuego = new Tipo("Fuego", ventajasFuego);
            agua = new Tipo("Agua", ventajasAgua);
            planta = new Tipo("Planta", ventajasPlanta);
        }

        [Test]
        public void EsEfectivoOPocoEfectivo_DeberiaRetornarVentajaCuandoExistenVentajas()
        {
            double efectividad = fuego.EsEfectivoOPocoEfectivo(planta);
            Assert.That(efectividad, Is.EqualTo(2.0));
        }

        [Test]
        public void EsEfectivoOPocoEfectivo_DeberiaRetornarDesventajaCuandoExistenDesventajas()
        {
            double efectividad = fuego.EsEfectivoOPocoEfectivo(agua);
            Assert.That(efectividad, Is.EqualTo(0.5));
        }

        [Test]
        public void EsEfectivoOPocoEfectivo_DeberiaRetornarUnoCuandoNoHayVentajasNiDesventajas()
        {
            double efectividad = agua.EsEfectivoOPocoEfectivo(planta);
            Assert.That(efectividad, Is.EqualTo(0.5));
        }
    }
}