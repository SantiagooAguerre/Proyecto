// using NUnit.Framework;
// using Proyecto_Pokemon;
// using System.Collections.Generic;
//
// namespace Proyecto_Pokemon
// {
//     [TestFixture]
//     public class LobbyTests
//     {
//         private Lobby lobby;
//         private Entrenadores entrenador1;
//         private Entrenadores entrenador2;
//
//         [SetUp]
//         public void SetUp()
//         {
//             // Crear un Pokémon básico para los entrenadores
//             var pokemonBasico = new Pokemon("Pikachu", 100, new Tipo("Eléctrico", new Dictionary<string, double>()));
//
//             // Inicializamos el lobby y los entrenadores con un Pokémon en la lista
//             lobby = new Lobby("TestLobby", "Kanto", 2);
//             entrenador1 = new Entrenadores("Ash", new List<Pokemon> { pokemonBasico });
//             entrenador2 = new Entrenadores("Misty", new List<Pokemon> { pokemonBasico });
//         }
//
//         [Test]
//         public void AgregarEntrenadorConCapacidadDisponible()
//         {
//             string resultado = lobby.UnirseALaListaDeEspera(entrenador1);
//             Assert.That(resultado, Is.EqualTo("Ash ha sido agregado a la lista de espera en el lobby 'TestLobby' de la región Kanto."));
//         }
//
//         [Test]
//         public void AgregarEntrenadorCuandoLobbyEstaLleno()
//         {
//             lobby.UnirseALaListaDeEspera(entrenador1);
//             lobby.UnirseALaListaDeEspera(entrenador2);
//
//             // Intentamos agregar un tercer entrenador y verificamos el mensaje de error
//             var entrenador3 = new Entrenadores("Brock", new List<Pokemon> { new Pokemon("Onix", 120, new Tipo("Roca", new Dictionary<string, double>())) });
//             string resultado = lobby.UnirseALaListaDeEspera(entrenador3);
//
//             Assert.That(resultado, Is.EqualTo("El lobby 'TestLobby' está lleno. Capacidad máxima de 2 entrenadores."));
//         }
//
//         [Test]
//         public void AgregarEntrenadorQueYaEstaEnListaDeEspera()
//         {
//             lobby.UnirseALaListaDeEspera(entrenador1);
//             string resultado = lobby.UnirseALaListaDeEspera(entrenador1);
//
//             Assert.That(resultado, Is.EqualTo("Ash ya está en la lista de espera."));
//         }
//
//         [Test]
//         public void VerListaDeEspera()
//         {
//             lobby.UnirseALaListaDeEspera(entrenador1);
//             lobby.UnirseALaListaDeEspera(entrenador2);
//
//             List<string> listaEsperada = new List<string> { "Ash", "Misty" };
//             Assert.That(lobby.VerListaDeEspera(), Is.EqualTo(listaEsperada));
//         }
//
//         [Test]
//         public void IniciarBatallaConEntrenadoresDisponibles()
//         {
//             lobby.UnirseALaListaDeEspera(entrenador1);
//             lobby.UnirseALaListaDeEspera(entrenador2);
//
//             lobby.IniciarBatalla(entrenador1);
//
//             Assert.That(entrenador1.EnBatalla, Is.EqualTo(true));
//             Assert.That(entrenador2.EnBatalla, Is.EqualTo(true));
//         }
//
//         [Test]
//         public void IniciarBatallaConListaEsperaVacia()
//         {
//             string resultado = lobby.IniciarBatalla(entrenador1);
//
//             Assert.That(entrenador1.EnBatalla, Is.EqualTo(false));
//         }
//     }
// }
