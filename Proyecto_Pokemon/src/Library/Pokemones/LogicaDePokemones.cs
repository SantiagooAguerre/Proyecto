namespace Proyecto_Pokemon;

public class LogicaDePokemones
{
    private static LogicaDePokemones? _instance;
    private Pokemon Sceptile;
    private Pokemon Arcanine;
    private Pokemon Blastoise;
    private Pokemon Snorlax;
    private Pokemon Pikachu;
    private Pokemon Jynx;
    private Pokemon Lucario;
    private Pokemon Tyranitar;
    private Pokemon Flygon;
    private Pokemon Pidgeot;
    private Pokemon Scyther;
    private Pokemon Amoonguss;
    private Pokemon Umbreon;
    private Pokemon Gengar;
    private Pokemon Lapras;
    private Pokemon Metagross;
    private Pokemon Dragonite;
    private Pokemon Sylveon;
    
    public static LogicaDePokemones Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new LogicaDePokemones();
            }

            return _instance;
        }
    }
    
    public List<Pokemon> InicializarPokemones()
    {
        var elementoFuego = new Dictionary<string, double>
        {
            { "Acero", 2.0 }, { "Volador", 0.5 }, { "Agua", 0.5 }, { "Hielo", 2.0 }, { "Planta", 2.0 },
            { "Bicho", 2.0 }, { "Electrico", 1.0 }, { "Normal", 1.0 }, { "Roca", 2.0 }, { "Tierra", 1.0 },
            { "Fuego", 0.5 }, { "Lucha", 1.0 }, { "Hada", 1.0 }, { "Psiquico", 1.0 }, { "Veneno", 1.0 },
            { "Dragon", 1.0 }, { "Fantasma", 1.0 }, { "Siniestro", 1.0 }
        };

        var elementoAgua = new Dictionary<string, double>
        {
            { "Acero", 1.0 }, { "Volador", 0.5 }, { "Agua", 0.5 }, { "Hielo", 1.0 }, { "Planta", 0.5 },
            { "Bicho", 1.0 }, { "Electrico", 1.0 }, { "Normal", 1.0 }, { "Roca", 2.0 }, { "Tierra", 2.0 },
            { "Fuego", 2.0 }, { "Lucha", 1.0 }, { "Hada", 1.0 }, { "Psiquico", 1.0 }, { "Veneno", 1.0 },
            { "Dragon", 1.0 }, { "Fantasma", 1.0 }, { "Siniestro", 1.0 }
        };

        var elementoPlanta = new Dictionary<string, double>
        {
            { "Acero", 0.5 }, { "Volador", 0.5 }, { "Agua", 2.0 }, { "Hielo", 1.0 },
            { "Planta", 0.5 }, { "Bicho", 0.5 }, { "Electrico", 1.0 }, { "Normal", 1.0 },
            { "Roca", 2.0 }, { "Tierra", 2.0 }, { "Fuego", 0.5 }, { "Lucha", 1.0 },
            { "Hada", 1.0 }, { "Psiquico", 1.0 }, { "Veneno", 0.5 }, { "Dragon", 0.5 },
            { "Fantasma", 1.0 }, { "Siniestro", 1.0 }
        };

        var elementoVolador = new Dictionary<string, double>
        {
            { "Acero", 0.5 }, { "Volador", 1.0 }, { "Agua", 1.0 }, { "Hielo", 1.0 },
            { "Planta", 2.0 }, { "Bicho", 2.0 }, { "Electrico", 0.5 }, { "Normal", 1.0 },
            { "Roca", 0.5 }, { "Tierra", 1.0 }, { "Fuego", 1.0 }, { "Lucha", 2.0 },
            { "Hada", 1.0 }, { "Psiquico", 1.0 }, { "Veneno", 1.0 }, { "Dragon", 1.0 },
            { "Fantasma", 1.0 }, { "Siniestro", 1.0 }
        };

        var elementoAcero = new Dictionary<string, double>
        {
            { "Acero", 0.5 }, { "Volador", 1.0 }, { "Agua", 0.5 }, { "Hielo", 2.0 },
            { "Planta", 1.0 }, { "Bicho", 1.0 }, { "Electrico", 0.5 }, { "Normal", 1.0 },
            { "Roca", 2.0 }, { "Tierra", 1.0 }, { "Fuego", 0.5 }, { "Lucha", 1.0 },
            { "Hada", 2.0 }, { "Psiquico", 1.0 }, { "Veneno", 1.0 }, { "Dragon", 1.0 },
            { "Fantasma", 1.0 }, { "Siniestro", 1.0 }
        };

        var elementoBicho = new Dictionary<string, double>
        {
            { "Acero", 0.5 }, { "Volador", 0.5 }, { "Agua", 1.0 }, { "Hielo", 1.0 },
            { "Planta", 2.0 }, { "Bicho", 1.0 }, { "Electrico", 1.0 }, { "Normal", 1.0 },
            { "Roca", 0.5 }, { "Tierra", 1.0 }, { "Fuego", 0.5 }, { "Lucha", 0.5 },
            { "Hada", 0.5 }, { "Psiquico", 2.0 }, { "Veneno", 0.5 }, { "Dragon", 1.0 },
            { "Fantasma", 0.5 }, { "Siniestro", 2.0 }
        };

        var elementoElectrico = new Dictionary<string, double>
        {
            { "Acero", 1.0 }, { "Volador", 2.0 }, { "Agua", 2.0 }, { "Hielo", 1.0 },
            { "Planta", 0.5 }, { "Bicho", 1.0 }, { "Electrico", 0.5 }, { "Normal", 1.0 },
            { "Roca", 0.5 }, { "Tierra", 0.0 }, { "Fuego", 1.0 }, { "Lucha", 1.0 },
            { "Hada", 1.0 }, { "Psiquico", 1.0 }, { "Veneno", 1.0 }, { "Dragon", 0.5 },
            { "Fantasma", 1.0 }, { "Siniestro", 1.0 }
        };

        var elementoNormal = new Dictionary<string, double>
        {
            { "Acero", 0.5 }, { "Volador", 1.0 }, { "Agua", 1.0 }, { "Hielo", 1.0 },
            { "Planta", 1.0 }, { "Bicho", 1.0 }, { "Electrico", 1.0 }, { "Normal", 1.0 },
            { "Roca", 0.5 }, { "Tierra", 1.0 }, { "Fuego", 1.0 }, { "Lucha", 1.0 },
            { "Hada", 1.0 }, { "Psiquico", 1.0 }, { "Veneno", 1.0 }, { "Dragon", 1.0 },
            { "Fantasma", 0.0 }, { "Siniestro", 1.0 }
        };

        var elementoHielo = new Dictionary<string, double>
        {
            { "Acero", 0.5 }, { "Volador", 2.0 }, { "Agua", 0.5 }, { "Hielo", 0.5 },
            { "Planta", 2.0 }, { "Bicho", 1.0 }, { "Electrico", 1.0 }, { "Normal", 1.0 },
            { "Roca", 2.0 }, { "Tierra", 2.0 }, { "Fuego", 0.5 }, { "Lucha", 1.0 },
            { "Hada", 1.0 }, { "Psiquico", 1.0 }, { "Veneno", 1.0 }, { "Dragon", 2.0 },
            { "Fantasma", 1.0 }, { "Siniestro", 1.0 }
        };

        var elementoLucha = new Dictionary<string, double>
        {
            { "Acero", 2.0 }, { "Volador", 0.5 }, { "Agua", 1.0 }, { "Hielo", 2.0 },
            { "Planta", 1.0 }, { "Bicho", 0.5 }, { "Electrico", 1.0 }, { "Normal", 2.0 },
            { "Roca", 2.0 }, { "Tierra", 1.0 }, { "Fuego", 1.0 }, { "Lucha", 1.0 },
            { "Hada", 0.5 }, { "Psiquico", 0.5 }, { "Veneno", 0.5 }, { "Dragon", 1.0 },
            { "Fantasma", 0.0 }, { "Siniestro", 2.0 }
        };

        var elementoHada = new Dictionary<string, double>
        {
            { "Acero", 0.5 }, { "Volador", 1.0 }, { "Agua", 1.0 }, { "Hielo", 1.0 },
            { "Planta", 1.0 }, { "Bicho", 1.0 }, { "Electrico", 1.0 }, { "Normal", 1.0 },
            { "Roca", 1.0 }, { "Tierra", 1.0 }, { "Fuego", 0.5 }, { "Lucha", 2.0 },
            { "Hada", 1.0 }, { "Psiquico", 1.0 }, { "Veneno", 0.5 }, { "Dragon", 2.0 },
            { "Fantasma", 1.0 }, { "Siniestro", 2.0 }
        };

        var elementoPsiquico = new Dictionary<string, double>
        {
            { "Acero", 0.5 }, { "Volador", 1.0 }, { "Agua", 1.0 }, { "Hielo", 1.0 },
            { "Planta", 1.0 }, { "Bicho", 1.0 }, { "Electrico", 1.0 }, { "Normal", 1.0 },
            { "Roca", 1.0 }, { "Tierra", 1.0 }, { "Fuego", 1.0 }, { "Lucha", 2.0 },
            { "Hada", 1.0 }, { "Psiquico", 0.5 }, { "Veneno", 2.0 }, { "Dragon", 1.0 },
            { "Fantasma", 1.0 }, { "Siniestro", 0.5 }
        };

        var elementoVeneno = new Dictionary<string, double>
        {
            { "Acero", 0.0 }, { "Volador", 1.0 }, { "Agua", 1.0 }, { "Hielo", 1.0 },
            { "Planta", 2.0 }, { "Bicho", 1.0 }, { "Electrico", 1.0 }, { "Normal", 1.0 },
            { "Roca", 0.5 }, { "Tierra", 0.5 }, { "Fuego", 1.0 }, { "Lucha", 1.0 },
            { "Hada", 2.0 }, { "Psiquico", 1.0 }, { "Veneno", 1.0 }, { "Dragon", 1.0 },
            { "Fantasma", 0.5 }, { "Siniestro", 1.0 }
        };

        var elementoRoca = new Dictionary<string, double>
        {
            { "Acero", 0.5 }, { "Volador", 2.0 }, { "Agua", 1.0 }, { "Hielo", 2.0 },
            { "Planta", 1.0 }, { "Bicho", 2.0 }, { "Electrico", 1.0 }, { "Normal", 1.0 },
            { "Roca", 1.0 }, { "Tierra", 0.5 }, { "Fuego", 2.0 }, { "Lucha", 0.5 },
            { "Hada", 1.0 }, { "Psiquico", 1.0 }, { "Veneno", 1.0 }, { "Dragon", 1.0 },
            { "Fantasma", 1.0 }, { "Siniestro", 1.0 }
        };

        var elementoTierra = new Dictionary<string, double>
        {
            { "Acero", 2.0 }, { "Volador", 0.0 }, { "Agua", 1.0 }, { "Hielo", 1.0 },
            { "Planta", 0.5 }, { "Bicho", 0.5 }, { "Electrico", 2.0 }, { "Normal", 1.0 },
            { "Roca", 2.0 }, { "Tierra", 1.0 }, { "Fuego", 2.0 }, { "Lucha", 1.0 },
            { "Hada", 1.0 }, { "Psiquico", 1.0 }, { "Veneno", 2.0 }, { "Dragon", 1.0 },
            { "Fantasma", 1.0 }, { "Siniestro", 1.0 }
        };

        var elementoFantasma = new Dictionary<string, double>
        {
            { "Acero", 1.0 }, { "Volador", 1.0 }, { "Agua", 1.0 }, { "Hielo", 1.0 },
            { "Planta", 1.0 }, { "Bicho", 1.0 }, { "Electrico", 1.0 }, { "Normal", 0.0 },
            { "Roca", 1.0 }, { "Tierra", 1.0 }, { "Fuego", 1.0 }, { "Lucha", 1.0 },
            { "Hada", 1.0 }, { "Psiquico", 1.0 }, { "Veneno", 1.0 }, { "Dragon", 1.0 },
            { "Fantasma", 2.0 }, { "Siniestro", 0.5 }
        };

        var elementoSiniestro = new Dictionary<string, double>
        {
            { "Acero", 1.0 }, { "Volador", 1.0 }, { "Agua", 1.0 }, { "Hielo", 1.0 },
            { "Planta", 1.0 }, { "Bicho", 1.0 }, { "Electrico", 1.0 }, { "Normal", 1.0 },
            { "Roca", 1.0 }, { "Tierra", 1.0 }, { "Fuego", 1.0 }, { "Lucha", 0.5 },
            { "Hada", 0.5 }, { "Psiquico", 2.0 }, { "Veneno", 1.0 }, { "Dragon", 1.0 },
            { "Fantasma", 2.0 }, { "Siniestro", 0.5 }
        };

        var elementoDragon = new Dictionary<string, double>
        {
            { "Acero", 0.5 }, { "Volador", 1.0 }, { "Agua", 1.0 }, { "Hielo", 2.0 },
            { "Planta", 1.0 }, { "Bicho", 1.0 }, { "Electrico", 1.0 }, { "Normal", 1.0 },
            { "Roca", 1.0 }, { "Tierra", 1.0 }, { "Fuego", 1.0 }, { "Lucha", 1.0 },
            { "Hada", 0.0 }, { "Psiquico", 1.0 }, { "Veneno", 1.0 }, { "Dragon", 2.0 },
            { "Fantasma", 1.0 }, { "Siniestro", 1.0 }
        };

        ITipo tipoFuego = new Tipo("Fuego", elementoFuego);
        ITipo tipoAgua = new Tipo("Agua", elementoAgua);
        ITipo tipoHielo = new Tipo("Hielo", elementoHielo);
        ITipo tipoLucha = new Tipo("Lucha", elementoLucha);
        ITipo tipoHada = new Tipo("Hada", elementoHada);
        ITipo tipoPsiquico = new Tipo("Psiquico", elementoPsiquico);
        ITipo tipoVeneno = new Tipo("Veneno", elementoVeneno);
        ITipo tipoDragon = new Tipo("Dragon", elementoDragon);
        ITipo tipoFantasma = new Tipo("Fantasma", elementoFantasma);
        ITipo tipoSiniestro = new Tipo("Siniestro", elementoSiniestro);
        ITipo tipoElectrico = new Tipo("Electrico", elementoElectrico);
        ITipo tipoBicho = new Tipo("Bicho", elementoBicho);
        ITipo tipoPlanta = new Tipo("Planta", elementoPlanta);
        ITipo tipoTierra = new Tipo("Tierra", elementoTierra);
        ITipo tipoRoca = new Tipo("Roca", elementoRoca);
        ITipo tipoAcero = new Tipo("Acero", elementoAcero);
        ITipo tipoNormal = new Tipo("Normal", elementoNormal);
        ITipo tipoVolador = new Tipo("Volador", elementoVolador);

        IEfectos paralisis = new Efectos("paralizado");
        IEfectos noqueado = new Efectos("noqueado");
        IEfectos quemadura = new Efectos("quemado");
        IEfectos envenenado = new Efectos("envenenado");

        Sceptile = new Pokemon("SCEPTILE", 281, tipoPlanta);
        Arcanine = new Pokemon("ARCANINE", 321, tipoFuego);
        Blastoise = new Pokemon("BLASTOISE", 299, tipoAgua);
        Snorlax = new Pokemon("SNORLAX", 461, tipoNormal);
        Pikachu = new Pokemon("PIKACHU", 211, tipoElectrico);
        Jynx = new Pokemon("JYNX", 271, tipoPsiquico, tipoHielo);
        Lucario = new Pokemon("LUCARIO", 281, tipoLucha, tipoAcero);
        Tyranitar = new Pokemon("TYRANITAR", 341, tipoRoca, tipoSiniestro);
        Flygon = new Pokemon("FLYGON", 301, tipoTierra, tipoDragon);
        Pidgeot = new Pokemon("PIDGEOT", 307, tipoVolador, tipoNormal);
        Scyther = new Pokemon("SCYTHER", 281, tipoBicho, tipoVolador);
        Amoonguss = new Pokemon("AMOONGUSS", 369, tipoVeneno, tipoPlanta);
        Umbreon = new Pokemon("UMBREON", 331, tipoSiniestro);
        Gengar = new Pokemon("GENGAR", 261, tipoFantasma, tipoSiniestro);
        Lapras = new Pokemon("LAPRAS", 401, tipoHielo, tipoAgua);
        Metagross = new Pokemon("METAGROSS", 351, tipoAcero, tipoPsiquico);
        Dragonite = new Pokemon("DRAGONITE", 323, tipoDragon, tipoVolador);
        Sylveon = new Pokemon("SYLVEON", 331, tipoHada);

        // SCEPTILE
        IHabilidades cortefuria = new Habilidades("Corte furia", tipoBicho, 40, 95, 20, false);
        IHabilidades energibola = new Habilidades("Energibola", tipoPlanta, 90, 100, 10, false);
        IHabilidades hojaguda = new Habilidades("Hoja Aguda", tipoPlanta, 90, 100, 15, false);
        IHabilidades lluevehojas = new Habilidades("Lluevehojas", tipoPlanta, 130, 80, 5, true);

        Sceptile.AprenderHabilidad(cortefuria);
        Sceptile.AprenderHabilidad(energibola);
        Sceptile.AprenderHabilidad(hojaguda);
        Sceptile.AprenderHabilidad(lluevehojas);
        
        // ARCANINE

        IHabilidades ascuas = new Habilidades("Ascuas", tipoFuego, 40, 100, 25, false);
        IHabilidades lanzallamas = new Habilidades("Lanzallamas", tipoFuego, 90, 90, 15, false);
        IHabilidades velocidadExtrema = new Habilidades("Velocidad Extrema", tipoNormal, 80, 70, 5, false);
        IHabilidades enviteigneo = new Habilidades("Envite Ígneo", tipoFuego, 120, 100, 15, true, quemadura);

        Arcanine.AprenderHabilidad(ascuas);
        Arcanine.AprenderHabilidad(lanzallamas);
        Arcanine.AprenderHabilidad(velocidadExtrema);
        Arcanine.AprenderHabilidad(enviteigneo);

        // BLASTOISE
        
        IHabilidades pistolaAgua = new Habilidades("Pistola Agua", tipoAgua, 40, 100, 25, false);
        IHabilidades hidropulso = new Habilidades("Hidropulso", tipoAgua, 60, 100, 20, false);
        IHabilidades acuacola = new Habilidades("Acua cola", tipoAgua, 90, 90, 10, false);
        IHabilidades hidroBomba = new Habilidades("Hidroomba", tipoAgua, 110, 80, 5, true);

        Blastoise.AprenderHabilidad(hidroBomba);
        Blastoise.AprenderHabilidad(hidropulso);
        Blastoise.AprenderHabilidad(acuacola);
        Blastoise.AprenderHabilidad(pistolaAgua);

        // SNORLAX
        
        IHabilidades golpecuerpo = new Habilidades("Golpe cuerpo", tipoNormal, 85, 100, 15, false);
        IHabilidades mordisco = new Habilidades("Mordisco", tipoSiniestro, 60, 100, 25, false);
        IHabilidades fuerzaequina = new Habilidades("Fuerza equina", tipoTierra, 95, 95, 10, false);
        IHabilidades gigaimpacto = new Habilidades("Gigaimpacto", tipoNormal, 150, 60, 5, true, noqueado);
        
        Snorlax.AprenderHabilidad(golpecuerpo);
        Snorlax.AprenderHabilidad(mordisco);
        Snorlax.AprenderHabilidad(fuerzaequina);
        Snorlax.AprenderHabilidad(gigaimpacto);

        // PIKACHU
        IHabilidades electrobola = new Habilidades("Electrobola", tipoElectrico, 90, 90, 6, false);
        IHabilidades rayo = new Habilidades("Rayo", tipoElectrico, 110, 70, 15, false);
        IHabilidades puniotrueno = new Habilidades("Puño Trueno", tipoElectrico, 60, 100, 15, false);
        IHabilidades trueno = new Habilidades("Trueno", tipoElectrico, 120, 50, 5, true, paralisis);

        Pikachu.AprenderHabilidad(electrobola);
        Pikachu.AprenderHabilidad(rayo);
        Pikachu.AprenderHabilidad(puniotrueno);
        Pikachu.AprenderHabilidad(trueno);

        // JYNX
        IHabilidades bolasombra = new Habilidades("Bola Sombra", tipoFantasma, 70, 80, 15, false);
        IHabilidades psiquico = new Habilidades("Psíquico", tipoPsiquico, 90, 90, 10, false);
        IHabilidades confusion = new Habilidades("Confusión", tipoPsiquico, 70, 100, 20, false);
        IHabilidades cabezazozen = new Habilidades("Cabezazo Zen", tipoPsiquico, 130, 70, 5, true, noqueado);

        Jynx.AprenderHabilidad(bolasombra);
        Jynx.AprenderHabilidad(psiquico);
        Jynx.AprenderHabilidad(confusion);
        Jynx.AprenderHabilidad(cabezazozen);

        // LUCARIO
        IHabilidades golperoca = new Habilidades("Golpe Roca", tipoLucha, 40, 100, 15, false);
        IHabilidades puniodehierro = new Habilidades("Puño de Hierro", tipoAcero, 80, 100, 10, false);
        IHabilidades garrametal = new Habilidades("Garra Metal", tipoAcero, 95, 90, 15, false);
        IHabilidades abocajarro = new Habilidades("A bocajarro", tipoLucha, 120, 80, 5, true);

        Lucario.AprenderHabilidad(golperoca);
        Lucario.AprenderHabilidad(puniodehierro);
        Lucario.AprenderHabilidad(garrametal);
        Lucario.AprenderHabilidad(abocajarro);

        // FLYGON
        IHabilidades terremoto = new Habilidades("Terremoto", tipoTierra, 70, 70, 15, false);
        IHabilidades pataleta = new Habilidades("Pataleta", tipoTierra, 75, 100, 10, false);
        IHabilidades danzadeldragon = new Habilidades("Danza del Dragón", tipoDragon, 80, 90, 20, false);
        IHabilidades cataclismo = new Habilidades("Cataclismo", tipoTierra, 140, 60, 5, true, noqueado);

        Flygon.AprenderHabilidad(terremoto);
        Flygon.AprenderHabilidad(pataleta);
        Flygon.AprenderHabilidad(danzadeldragon);
        Flygon.AprenderHabilidad(cataclismo);

        // TYRANITAR
        IHabilidades terratemblor = new Habilidades("Terratemblor", tipoTierra, 60, 100, 20, false);
        IHabilidades avalancha = new Habilidades("Avalancha", tipoRoca, 75, 80, 15, false);
        IHabilidades lanzarrocas = new Habilidades("Lanzarrocas", tipoRoca, 50, 100, 20, false);
        IHabilidades rocaafilada = new Habilidades("Roca afilada", tipoRoca, 110, 70, 10, true);

        Tyranitar.AprenderHabilidad(terratemblor);
        Tyranitar.AprenderHabilidad(avalancha);
        Tyranitar.AprenderHabilidad(lanzarrocas);
        Tyranitar.AprenderHabilidad(rocaafilada);

        // PIDGEOT
        IHabilidades aereocontrol = new Habilidades("Aereocontrol", tipoVolador, 85, 100, 10, false);
        IHabilidades corteAereo = new Habilidades("Corte Aéreo", tipoVolador, 90, 100, 15, false);
        IHabilidades vientoAullador = new Habilidades("Viento Aullador", tipoVolador, 75, 95, 20, false);
        IHabilidades tormentaAerea = new Habilidades("Tormenta Aérea", tipoVolador, 130, 70, 5, true);

        Pidgeot.AprenderHabilidad(aereocontrol);
        Pidgeot.AprenderHabilidad(corteAereo);
        Pidgeot.AprenderHabilidad(vientoAullador);
        Pidgeot.AprenderHabilidad(tormentaAerea);

        // SCYTHER
        IHabilidades tajoAereo = new Habilidades("Tajo Aéreo", tipoBicho, 80, 100, 15, false);
        IHabilidades danzaDeHojas = new Habilidades("Danza de Hojas", tipoPlanta, 70, 100, 20, false);
        IHabilidades punioDeAcero = new Habilidades("Puño de Acero", tipoBicho, 75, 100, 15, false);
        IHabilidades tormentaBichos = new Habilidades("Tormenta Bichos", tipoBicho, 130, 60, 5, true, envenenado);

        Scyther.AprenderHabilidad(tajoAereo);
        Scyther.AprenderHabilidad(danzaDeHojas);
        Scyther.AprenderHabilidad(punioDeAcero);
        Scyther.AprenderHabilidad(tormentaBichos);


        // AMOONGUSS
        IHabilidades tijeraDeHojas = new Habilidades("Tijera de Hojas", tipoPlanta, 65, 90, 15, false);
        IHabilidades bombardeoDeEsporas = new Habilidades("Bombardeo de Esporas", tipoVeneno, 70, 95, 15, false);
        IHabilidades ataqueVenenoso = new Habilidades("Ataque Venenoso", tipoVeneno, 80, 80, 15, false);
        IHabilidades tormentaVenenosa = new Habilidades("Tormenta Venenosa", tipoVeneno, 130, 60, 5, true, envenenado);

        Amoonguss.AprenderHabilidad(tijeraDeHojas);
        Amoonguss.AprenderHabilidad(bombardeoDeEsporas);
        Amoonguss.AprenderHabilidad(ataqueVenenoso);
        Amoonguss.AprenderHabilidad(tormentaVenenosa);

        // UMBREON
        IHabilidades sombraVil = new Habilidades("Sombra Vil", tipoSiniestro, 90, 80, 10, false);
        IHabilidades punioFuego = new Habilidades("Puño Fuego", tipoFuego, 75, 100, 15, false);
        IHabilidades oscuro = new Habilidades("Oscuro", tipoSiniestro, 80, 100, 15, false);
        IHabilidades mareaOscura = new Habilidades("Marea Oscura", tipoSiniestro, 130, 70, 5, true);

        Umbreon.AprenderHabilidad(sombraVil);
        Umbreon.AprenderHabilidad(punioFuego);
        Umbreon.AprenderHabilidad(oscuro);
        Umbreon.AprenderHabilidad(mareaOscura);

        // GENGAR
        IHabilidades sombraBola = new Habilidades("Sombra Bola", tipoFantasma, 80, 100, 15, false);
        IHabilidades sombraAterradora = new Habilidades("Sombra Aterradora", tipoSiniestro, 75, 100, 15, false);
        IHabilidades punioSiniestro = new Habilidades("Puño Siniestro", tipoSiniestro, 70, 100, 20, false);
        IHabilidades tormentaSombria = new Habilidades("Tormenta Sombría", tipoFantasma, 155, 60, 5, true);

        Gengar.AprenderHabilidad(sombraBola);
        Gengar.AprenderHabilidad(sombraAterradora);
        Gengar.AprenderHabilidad(punioSiniestro);
        Gengar.AprenderHabilidad(tormentaSombria);


        // LAPRAS
        IHabilidades rayoHielo = new Habilidades("Rayo Hielo", tipoHielo, 90, 100, 10, false);
        IHabilidades cascada = new Habilidades("Cascada", tipoAgua, 80, 100, 15, false);
        IHabilidades hipnosis = new Habilidades("Hipnosis", tipoPsiquico, 50, 70, 20, false);
        IHabilidades tormentaDeHielo = new Habilidades("Tormenta de Hielo", tipoHielo, 130, 60, 5, true);

        Lapras.AprenderHabilidad(rayoHielo);
        Lapras.AprenderHabilidad(cascada);
        Lapras.AprenderHabilidad(hipnosis);
        Lapras.AprenderHabilidad(tormentaDeHielo);

        // METAGROSS
        IHabilidades punioAcero = new Habilidades("Puño de Acero", tipoAcero, 90, 90, 10, false);
        IHabilidades poderPsiquico = new Habilidades("Poder Psíquico", tipoPsiquico, 90, 60, 10, false);
        IHabilidades golpePsíquico = new Habilidades("Golpe Psíquico", tipoPsiquico, 40, 100, 15, false);
        IHabilidades meteorito = new Habilidades("Meteorito", tipoAcero, 140, 50, 5, true);

        Metagross.AprenderHabilidad(punioAcero);
        Metagross.AprenderHabilidad(poderPsiquico);
        Metagross.AprenderHabilidad(golpePsíquico);
        Metagross.AprenderHabilidad(meteorito);


        // DRAGONITE
        IHabilidades golpeDragon = new Habilidades("Golpe Dragón", tipoDragon, 75, 100, 15, false);
        IHabilidades hiperrayo = new Habilidades("Hiperrayo", tipoNormal, 100, 90, 5, false);
        IHabilidades colasDeFuego = new Habilidades("Colas de Fuego", tipoFuego, 90, 100, 15, false);
        IHabilidades tormentaDeDragones = new Habilidades("Furia Dragón", tipoDragon, 150, 50, 5, true, paralisis);

        Dragonite.AprenderHabilidad(golpeDragon);
        Dragonite.AprenderHabilidad(hiperrayo);
        Dragonite.AprenderHabilidad(colasDeFuego);
        Dragonite.AprenderHabilidad(tormentaDeDragones);

        // SYLVEON
        IHabilidades besoEncantado = new Habilidades("Beso Encantado", tipoHada, 90, 100, 10, false);
        IHabilidades vientoHadas = new Habilidades("Viento Hadas", tipoHada, 75, 100, 15, false);
        IHabilidades golpeHada = new Habilidades("Golpe Hada", tipoHada, 80, 100, 15, false);
        IHabilidades poderDeLosSuenos = new Habilidades("Poder de los Sueños", tipoHada, 130, 60, 5, true);

        Sylveon.AprenderHabilidad(besoEncantado);
        Sylveon.AprenderHabilidad(vientoHadas);
        Sylveon.AprenderHabilidad(golpeHada);
        Sylveon.AprenderHabilidad(poderDeLosSuenos);
        
        return new List<Pokemon> { Sceptile, Arcanine, Blastoise, Snorlax, 
            Pikachu, Jynx, Lucario, Tyranitar, Flygon, Pidgeot, Scyther, Amoonguss, 
            Umbreon, Gengar, Lapras, Metagross, Dragonite, Sylveon };
    }
    
    public string MostrarPokemones()
    {
        string pokemones = "```";
        foreach (Pokemon pokemon in InicializarPokemones())
        {
            pokemones += pokemon.Nombre + ", Tipo: " +
                         pokemon.TipoPrincipal.Nombre + ", HP: " +
                         pokemon.Vida + "\n";
        }
        pokemones += "```";
        return pokemones;
    }
    
}