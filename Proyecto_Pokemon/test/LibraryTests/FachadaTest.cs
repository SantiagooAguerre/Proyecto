using NUnit.Framework;

namespace Proyecto_Pokemon
{
    [TestFixture]
    public class FachadaTest
    {
        private Batallas batalla;
        private Entrenadores entrenador1;
        private Entrenadores entrenador2;
        private Pokemon pikachu;
        private Pokemon charmander;
        private IHabilidades habilidad;

        [SetUp]
        public void Setup()
        {
            var elementoElectrico = new Dictionary<string, double>
            {
                { "Acero", 1.0 }, { "Volador", 2.0 }, { "Agua", 2.0 }, { "Hielo", 1.0 },
                { "Planta", 0.5 }, { "Bicho", 1.0 }, { "Electrico", 0.5 }, { "Normal", 1.0 },
                { "Roca", 0.5 }, { "Tierra", 0.0 }, { "Fuego", 1.0 }, { "Lucha", 1.0 },
                { "Hada", 1.0 }, { "Psiquico", 1.0 }, { "Veneno", 1.0 }, { "Dragon", 0.5 },
                { "Fantasma", 1.0 }, { "Siniestro", 1.0 }
            };

            var elementoFuego = new Dictionary<string, double>
            {
                { "Acero", 2.0 }, { "Volador", 0.5 }, { "Agua", 0.5 }, { "Hielo", 2.0 }, { "Planta", 2.0 },
                { "Bicho", 2.0 }, { "Electrico", 1.0 }, { "Normal", 1.0 }, { "Roca", 2.0 }, { "Tierra", 1.0 },
                { "Fuego", 0.5 }, { "Lucha", 1.0 }, { "Hada", 1.0 }, { "Psiquico", 1.0 }, { "Veneno", 1.0 },
                { "Dragon", 1.0 }, { "Fantasma", 1.0 }, { "Siniestro", 1.0 }
            };

            habilidad = new Habilidades("Impactrueno", null, 20, 80, 30, false);

            ITipo electrico = new Tipo("Electrico", elementoElectrico);
            ITipo fuego = new Tipo("Fuego", elementoFuego);

            pikachu = new Pokemon("pikachu", 100, electrico);
            charmander = new Pokemon("charmander", 100, fuego);

            // entrenador1 = new Entrenadores("Asho Ketchu", new List<Pokemon>() { pikachu });
            // entrenador2 = new Entrenadores("Brokoso", new List<Pokemon>() { charmander });

            batalla = new Batallas(entrenador1, entrenador2);
            
        }

        //[Test]
        //     public void EjecutarAtaque_DeberiaReducirVidaDelDefensor()
        //     {
        //         fachada.EjecutarAtaque(pikachu, charmander, habilidad, false);
        //         Assert.That(charmander.Vida, Is.LessThan(100));
        //     }
        //
        //     [Test]
        //     public void EjecutarAtaque_DeberiaNoReducirVidaSiAtaqueFalla()
        //     {
        //         habilidad = new Habilidades("Impactrueno", null, 20, 0, 30, false);
        //         pikachu.Habilidades[0] = habilidad;
        //
        //         fachada.EjecutarAtaque(pikachu, charmander, habilidad, false);
        //         Assert.That(charmander.Vida, Is.EqualTo(100));
        //     }
        //
        //     [Test]
        //     public void MostrarOpciones_DeberiaEjecutarAtaqueCuandoSelecciona1()
        //     {
        //         using (var sw = new StringWriter())
        //         {
        //             Console.SetOut(sw);
        //             Console.SetIn(new StringReader("1"));
        //
        //             fachada.MostrarOpciones(batalla);
        //
        //             string output = sw.ToString();
        //             Assert.That(output, Does.Contain("usó Impactrueno"));
        //         }
        //     }
        //     
        //     [Test]
        //     public void MostrarOpciones_DeberiaCambiarPokemonCuandoSelecciona2()
        //     {
        //         using (var sw = new StringWriter())
        //         {
        //             Console.SetOut(sw);
        //             Console.SetIn(new StringReader("2"));
        //
        //             fachada.MostrarOpciones(batalla);
        //
        //             string output = sw.ToString();
        //             Assert.That(output, Does.Contain("cambió a"));
        //         }
        //     }
        //     
        //     [Test]
        //     public void MostrarOpciones_DeberiaEsquivarCuandoSelecciona3()
        //     {
        //         using (var sw = new StringWriter())
        //         {
        //             Console.SetOut(sw);
        //             Console.SetIn(new StringReader("3"));
        //
        //             fachada.MostrarOpciones(batalla);
        //
        //             string output = sw.ToString();
        //             Assert.That(output, Does.Contain("está preparado para esquivar"));
        //         }
        //     }
        //     
        //     [Test]
        //     public void MostrarOpciones_DeberiaPedirOpcionNuevamenteSiEsInvalida()
        //     {
        //         using (var sw = new StringWriter())
        //         {
        //             Console.SetOut(sw);
        //             Console.SetIn(new StringReader("4\n1"));
        //
        //             fachada.MostrarOpciones(batalla);
        //
        //             string output = sw.ToString();
        //             Assert.That(output, Does.Contain("Opcion incorrecta"));
        //         }
        //     }
        // }
        [Test]
        public void TestCrearPartida()
        {

            // Crear entrenadores
            Entrenadores entrenador1 = new Entrenadores("Asho Ketchu");
            Entrenadores entrenador2 = new Entrenadores("Brokoso");

            // Usar Fachada para meter jugadores al lobby
            Fachada.MeterUsuarioAlLobby(entrenador1.Nombre);
            Fachada.MeterUsuarioAlLobby(entrenador2.Nombre);

            // Ejecutar y verificar
            string resultado = Fachada.CrearBatalla();
            Assert.That(resultado, Is.EqualTo($"EMPIEZA LA BATALLA, EL ENTRENADOR {entrenador1.Nombre} CONTRA {entrenador2.Nombre}"));
        }


    }
}