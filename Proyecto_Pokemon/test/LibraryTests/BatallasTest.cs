// namespace Proyecto_Pokemon;
// using NUnit.Framework;
//
// [TestFixture]
// public class BatallasTest
// {
//     private Batallas batalla;
//     private Entrenadores entrenador1;
//     private Entrenadores entrenador2;
//     private Pokemon pikachu;
//     private Pokemon charmander;
//     private IHabilidades impactrueno;
//
//     [SetUp]
//     public void Setup()
//     {
//         
//         var elementoElectrico = new Dictionary<string, double>
//         {
//             { "Acero", 1.0 }, { "Volador", 2.0 }, { "Agua", 2.0 }, { "Hielo", 1.0 },
//             { "Planta", 0.5 }, { "Bicho", 1.0 }, { "Electrico", 0.5 }, { "Normal", 1.0 },
//             { "Roca", 0.5 }, { "Tierra", 0.0 }, { "Fuego", 1.0 }, { "Lucha", 1.0 },
//             { "Hada", 1.0 }, { "Psiquico", 1.0 }, { "Veneno", 1.0 }, { "Dragon", 0.5 },
//             { "Fantasma", 1.0 }, { "Siniestro", 1.0 }
//         };
//         
//         var elementoFuego = new Dictionary<string, double>
//         {
//             { "Acero", 2.0 }, { "Volador", 0.5 }, { "Agua", 0.5 }, { "Hielo", 2.0 }, { "Planta", 2.0 },
//             { "Bicho", 2.0 }, { "Electrico", 1.0 }, { "Normal", 1.0 }, { "Roca", 2.0 }, { "Tierra", 1.0 },
//             { "Fuego", 0.5 }, { "Lucha", 1.0 }, { "Hada", 1.0 }, { "Psiquico", 1.0 }, { "Veneno", 1.0 },
//             { "Dragon", 1.0 }, { "Fantasma", 1.0 }, { "Siniestro", 1.0 }
//         };
//         
//         impactrueno = new Habilidades("Impactrueno", null, 20, 80, 30, false);
//         
//         ITipo electrico = new Tipo("Electrico", elementoElectrico);
//         ITipo fuego = new Tipo("Fuego", elementoFuego);
//
//         pikachu = new Pokemon("pikachu", 100, electrico);
//         charmander = new Pokemon("charmander", 100, fuego);
//
//         entrenador1 = new Entrenadores("Asho Ketchu", new List<Pokemon>() { pikachu });
//         entrenador2 = new Entrenadores("Brokoso", new List<Pokemon>() { charmander });
//
//         batalla = new Batallas();
//     }
//
//     [Test]
//     public void Batalla_DeberiaIniciarConTurno1()
//     {
//         Assert.That(batalla.Turno, Is.EqualTo(1));
//     }
//
//     [Test]
//     
//     public void Batalla_DeberiaCambiarDeTurnoDespuesDeAtacar()
//     {
//         batalla.Atacar();
//         Assert.That(batalla.Turno, Is.EqualTo(2));
//     }
//
//
//     [Test]
//     public void Atacar_DeberiaReducirVidaDelPokemonDefensor()
//     {
//         batalla.Atacar();
//         Assert.That(charmander.Vida, Is.LessThan(100));
//     }
//
//     [Test]
//     public void Esquivar_DeberiaMostrarMensajeYPrepararEsquivar()
//     {
//         using (var sw = new StringWriter())
//         {
//             Console.SetOut(sw);
//
//             batalla.Esquivar();
//
//             var resultado = sw.ToString().Trim();
//             Assert.That(resultado, Does.Contain("está preparado para esquivar el proximo movimiento"));
//         }
//     }
//
//     [Test]
//     public void CambiarPokemon_DeberiaCambiarPokemonActivo()
//     {
//         using (var sr = new StringReader("1"))
//         {
//             Console.SetIn(sr);
//
//             using (var sw = new StringWriter())
//             {
//                 Console.SetOut(sw);
//
//                 batalla.CambiarPokemon();
//
//                 var resultado = sw.ToString().Trim();
//                 Assert.That(resultado, Does.Contain($"{entrenador1.Nombre} cambió a {entrenador1.Pokemones[0].Nombre}"));
//             }
//         }
//     }
//
//     [Test]
//     public void Atacar_PokemonDefensorDeberiaDebilitarse_CambiarTurno()
//     {
//         charmander.Vida = 10;
//         impactrueno.Danio = 20;
//
//         batalla.Atacar();
//
//         Assert.That(charmander.Vida, Is.LessThanOrEqualTo(0));
//     }
//
//     [Test]
//     
//     public void Atacar_HabilidadDobleTurnoDeberiaCargar()
//     {
//         IHabilidades habilidadDobleTurno = new Habilidades("Llamarada", null, 50, 100, 5, true);
//         pikachu.AprenderHabilidad(habilidadDobleTurno);
//
//         
//
//         using (var sr = new StringReader("1"))
//         {
//             Console.SetIn(sr);
//
//             batalla.Atacar();
//
//             // Verificar que la habilidad está en proceso de carga
//             Assert.That(pikachu.HabilidadCargando, Is.EqualTo(habilidadDobleTurno));
//         }
//     }
//
// }
