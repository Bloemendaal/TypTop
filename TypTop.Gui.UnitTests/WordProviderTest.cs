using System;
***REMOVED***
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TypTop.Gui.SpaceGame;
using TypTop.Logic;
using Assert = NUnit.Framework.Assert;

namespace TypTop.Gui.UnitTests
***REMOVED***
    [TestClass]
    public class WordProviderTest
    ***REMOVED***
        private WordProvider _wp;
        private List<string> testWords = new List<string>()***REMOVED***
                "aan", "aanbod", "aanraken", "aanval", "aap", "aardappel", "aarde", "aardig", "acht", "achter", "actief", "activiteit", "ademen", "af", "afgelopen", "afhangen", "afmaken", "afname", "afspraak", "afval", "al", "algemeen", "alleen", "alles", "als", "alsjeblieft", "altijd", "ander", "andere", "anders", "angst", "antwoord", "antwoorden", "appel", "arm", "auto", "avond", "avondeten",
                "baan", "baby", "bad", "bal", "bang", "bank", "basis", "bed", "bedekken", "bedreiging", "bedreven", "been", "beer", "beest", "beetje", "begin", "begrijpen", "begrip", "behalve", "beide", "beker", "bel", "belangrijk", "bellen", "belofte", "beneden", "benzine", "berg", "beroemd", "beroep", "bescherm", "beslissen", "best", "betalen", "beter", "bevatten", "bewegen", "bewolkt", "bezoek", "bibliotheek", "bieden", "bij", "bijna", "bijten", "bijvoorbeeld", "bijzonder", "binnen", "binnenkort", "blad", "blauw", "blazen", "blij", "blijven", "bloed", "bloem", "bodem", "boek", "boerderij", "boete", "boom", "boon", "boord", "boos", "bord", "borstelen", "bos", "bot", "bouwen", "boven", "branden", "brandstof", "breed", "breken", "brengen", "brief", "broer", "broek", "brood", "brug", "bruikbaar", "bruiloft", "bruin", "bui", "buiten", "bureau", "buren", "bus", "buurman", "buurvrouw",
                "cadeau", "chocolade", "cirkel", "comfortabel", "compleet", "computer", "conditie", "controle", "cool", "correct",
                "daar", "daarom", "dag", "dak", "dan", "dansen", "dapper", "dat", "de", "deel", "deken", "deksel", "delen", "derde", "deze", "dichtbij", "dienen", "diep", "dier", "dik", "ding", "dit", "dochter", "doen", "dom", "donker", "dood", "door", "doorzichtig", "doos", "dorp", "draad", "draaien", "dragen", "drie", "drijven", "drinken", "drogen", "dromen", "droog", "druk", "dubbel", "dun", "dus", "duur", "duwen",
                "echt", "een", "één", "eend", "eenheid", "eenzaam", "eerste", "eeuw", "effect", "ei", "eigen", "eiland", "einde", "eis", "elektrisch", "elk", "en", "enkele", "enthousiast", "erg", "eten", "even", "examen", "extreem ",
                "falen ", "familie", "feest", "feit", "fel", "fijn", "film", "fit", "fles", "foto", "fout", "fris", "fruit",
                "gaan", "gat", "gebeuren", "gebeurtenis", "gebied", "geboorte", "geboren", "gebruik", "gebruikelijk", "gebruiken", "gedrag", "gedragen", "geel", "geen", "gehoorzamen", "geit", "geld", "geliefde", "gelijk", "geloof", "geluid", "geluk", "gemak", "gemakkelijk", "gemeen", "genieten", "genoeg", "genot", "gerecht", "gereedschap", "geschikt", "gespannen", "geur", "gevaar", "gevaarlijk", "gevangenis", "geven", "gevolg", "gewicht", "gewoon", "gezicht", "gezond", "gif", "gisteren", "glad", "glas", "glimlach", "god", "goed", "goedkoop", "goud", "graf", "grap", "grappig", "gras", "grens", "grijs", "groeien", "groen", "groente", "groep", "grof", "grond", "groot", "grootmoeder", "grootvader",
                "haan", "haar", "haast", "hal", "halen", "half", "hallo", "hamer", "hand", "hard", "hart", "haten", "hebben", "heel", "heet", "helder", "helft", "help", "hem", "hemel", "hen", "herfst", "herinneren", "hert", "het", "heuvel", "hier", "hij", "hobby", "hoe", "hoed", "hoek", "hoeveel", "hoeveelheid", "hoewel", "hond", "honderd", "honger", "hoofd", "hoog", "hoogte", "hoop", "horen", "hotel", "houden", "huilen", "huis", "hun", "huren", "hut", "huur",
                "idee", "ieder", "iedereen", "iemand", "iets", "ijs", "ijzer", "ik", "in", "instrument",
                "ja", "jaar", "jagen", "jas", "jij", "jong", "jongen", "jouw", "jullie",
                "kaars", "kaart", "kaas", "kamer", "kans", "kant", "kantoor", "kap", "kast", "kasteel", "kat", "kennen", "kennis", "keuken", "keus", "kiezen", "kijken", "kind", "kip", "kist", "klaar", "klas", "klasse", "kleden", "klein", "kleren", "kleur", "klimmen", "klok", "kloppen", "klopt", "knie", "knippen", "koers", "koffer", "koffie", "kok", "koken", "kom", "komen", "koning", "koningin", "koorts", "kop", "kopen", "kort", "kost", "kosten", "koud", "kraam", "kracht", "krant", "krijgen", "kruis", "kuil", "kunnen", "kunst",
                "laag", "laat", "laatst", "lach", "lachen", "ladder", "laken", "lamp", "land", "lang", "langs", "langzaam", "laten", "leeftijd", "leeg", "leerling", "leeuw", "leger", "leiden", "lenen", "lengte", "lepel", "leren", "les", "leuk", "leven", "lezen", "lichaam", "licht", "liefde", "liegen", "liggen", "lijk", "lijken", "liniaal", "links", "lip", "list", "lomp", "lood", "lopen", "los", "lot", "lucht", "lui", "luisteren", "lunch",
                "maag", "maal", "maaltijd", "maan", "maand", "maar", "maat", "machine", "maken", "makkelijk", "mama", "man", "mand", "manier", "map", "markeren", "markt", "me", "medicijn", "meel", "meer", "meerdere", "meest", "meisje", "melk", "meneer", "mengsel", "mensen", "mes", "met", "meubel", "mevrouw", "middel", "midden", "mij", "mijn ", "miljoen", "min", "minder", "minuut", "mis", "missen", "mits", "model", "modern", "moeder", "moeilijk", "moeten", "mogelijk", "mogen", "moment", "mond", "mooi", "moord", "moorden", "morgen", "munt", "muziek",
                "na", "naald", "naam", "naar", "naast", "nacht", "nat", "natuur", "natuurlijk", "nee", "neer", "negen", "nek", "nemen", "net", "netjes", "neus", "niet", "niets", "nieuw", "nieuws", "nobel", "noch", "nodig", "noemen", "nog", "nood", "nooit", "noord", "noot", "normaal", "nu", "nul", "nummer",
                "object", "oceaan", "ochtend", "oefening", "of", "offer", "olie", "olifant", "om", "oma", "onder", "onderwerp", "onderzoek", "oneven", "ongeluk", "ons", "ontsnappen", "ontbijt", "ontdekken", "ontmoeten", "ontvangen", "ontwikkelen", "onze", "oog", "ooit", "ook", "oom", "oor", "oorlog", "oorzaak", "oost", "op", "opa", "opeens", "open", "openlijk", "opleiding", "opnemen", "oranje", "orde", "oud", "ouder", "over", "overal", "overeenkomen", "overleden", "overvallen",
                "paar", "paard", "pad", "pagina", "pan", "papa", "papier", "park", "partner", "pas", "passeren", "pen", "peper", "per", "perfect", "periode", "persoon", "piano", "pijn", "pistool", "plaat", "plaatje", "plaats", "plafond", "plank", "plant", "plastic", "plat", "plattegrond", "plein", "plus", "poes", "politie", "poort", "populair", "positie", "postzegel", "potlood", "praten", "presenteren", "prijs", "prins", "prinses", "privé", "proberen", "probleem", "product", "provincie", "publiek", "punt",
                "raak", "raam", "radio", "raken", "rapport", "recht", "rechtdoor", "rechts", "rechtvaardig", "redden", "reeds", "regen", "reiken", "reizen", "rekenmachine", "rennen", "repareren", "rest", "restaurant", "resultaat", "richting", "rijk", "rijst", "rijzen", "ring", "rok", "rond", "rood", "rook", "rots", "roze", "rubber", "ruiken", "ruimte",
                "samen", "sap", "schaap", "schaar", "schaduw", "scheiden", "scherp", "schetsen", "schieten", "schijnen", "schip", "school", "schoon", "schouder", "schreeuw", "schreeuwen", "schrijven", "schudden", "seconde", "sex", "signaal", "simpel", "sinds", "slaapkamer", "slapen", "slecht", "sleutel", "slim", "slot", "sluiten", "smaak", "smal", "sneeuw", "snel", "snelheid", "snijden", "soep", "sok", "soms", "soort", "sorry", "speciaal", "spel", "spelen", "sport", "spreken", "springen", "staal", "stad", "stap", "start", "station", "steen", "stelen", "stem", "stempel", "ster", "sterk", "steun", "stil", "stilte", "stoel", "stof", "stoffig", "stom", "stop", "storm", "straat", "straffen", "structuur", "student", "studie", "stuk", "succes", "suiker",
                "taal", "taart", "tafel", "tak", "tamelijk", "tand", "tante", "tas", "taxi", "te", "team", "teen", "tegen", "teken", "tekenen", "telefoon", "televisie", "tellen", "tennis", "terug", "terugkomst", "terwijl", "test", "tevreden", "thee", "thuis", "tien", "tijd", "titel", "toekomst", "toen", "toename", "totaal", "traan", "tram", "trein", "trekken", "trouwen", "trui", "tuin", "tussen", "tweede",
                "u", "uit", "uitleggen", "uitnodigen", "uitvinden", "uitzoeken", "uur",
                "vaak", "vaarwel", "vader", "vak", "vakantie", "vallen", "vals", "van", "vandaag", "vangen", "vanmorgen", "vannacht", "varken", "vast", "vechten", "veel", "veer", "veilig", "ver", "veranderen", "verandering", "verder", "verdienen", "verdrietig", "verenigen", "verf", "vergelijkbaar", "vergelijken", "vergelijking", "vergeten", "vergeven", "vergissen", "verhaal", "verhoging", "verjaardag", "verkeerd", "verkopen", "verlaten", "verleden", "verliezen", "vernietigen", "veroveren", "verrassen", "vers", "verschil", "verschrikkelijk", "verspreiden", "verstand", "verstoppen", "versturen", "vertellen", "vertrekken", "vertrouwen", "verwachten", "verwijderen", "verzamelen", "verzameling", "vet", "vier", "vierkant", "vies", "vijand", "vijf", "vijver", "vinden", "vinger", "vis", "vlag", "vlees", "vlieg", "vliegtuig", "vloer", "voeden", "voedsel", "voelen", "voet", "voetbal", "vogel", "vol", "volgende", "volgorde", "voor", "voorbeeld", "voorkomen", "voorzichtig", "voorzien", "vork", "vorm", "vos", "vouwen", "vraag", "vragen", "vrede", "vreemd", "vreemde", "vriend", "vriendelijk", "vriezen", "vrij", "vrijheid", "vroeg", "vroeger", "vrouw", "vullen", "vuur",
                "waar", "waarom", "waarschijnlijk", "wachten", "wakker", "wanneer", "want", "wapen", "warm", "wassen", "wat", "water", "we", "week", "weer", "weg", "welke", "welkom", "wens", "wereld", "werelddeel", "werk", "west", "wetenschap", "wie", "wiel", "wij", "wijn", "wijs", "wild", "willen", "wind", "winkel", "winnen", "winter", "wissen", "wit", "wolf", "wolk", "wonder", "woord", "woud", "wreed",
                "zaak", "zacht", "zak", "zand", "zee", "zeep", "zeer", "zeggen", "zeil", "zeker", "zelfde", "zes", "zetten", "zeven", "ziek", "ziekenhuis", "ziel", "zien", "zij", "zijn", "zilver", "zingen", "zinken", "zitten", "zo", "zoals", "zoeken", "zoet", "zomer", "zon", "zonder", "zonnig", "zoon", "zorg", "zorgen", "zou", "zout", "zuid", "zulke", "zullen", "zus", "zwaar", "zwak", "zwembad", "zwemmen"
        ***REMOVED***;
        
        [TestMethod]
        public void LimitByCharacter_LeftMiddleRow_ListOfWords()
        ***REMOVED***
            _wp = new WordProvider();

            _wp.LoadTestWords(testWords);

            List<Word> answer = new List<Word>()
            ***REMOVED***
                new Word("af"),
                new Word("dag")
        ***REMOVED***;

            List<char> testChars = new List<char>()
            ***REMOVED***
                'a','s','d','f','g'
        ***REMOVED***;

            //Filter
            _wp.LimitByCharacter(testChars);

            Assert.AreEqual(answer, _wp.Serve());
    ***REMOVED***

        [TestMethod]
        public void Shuffle_ListOfStrings_AreNotEqual()
        ***REMOVED***
            _wp = new WordProvider();

            _wp.LoadTestWords(testWords);


            WordProvider wpCopy = new WordProvider();
            wpCopy.LoadTestWords(testWords);

            _wp.Shuffle();

            Assert.AreNotEqual(wpCopy.Serve(), _wp.Serve());
    ***REMOVED***

        [TestMethod]
        public void WordLimit_Five_FirstFive()
        ***REMOVED***
            _wp = new WordProvider();
            _wp.LoadTestWords(testWords);
            _wp.WordLimit(5);

            List<Word> answer = new List<Word>()
            ***REMOVED***
                new Word("aan"),
                new Word("aanbod"),
                new Word("aanraken"),
                new Word("aanval"),
                new Word("aap")
        ***REMOVED***;

            Assert.AreEqual(answer, _wp.Serve());
    ***REMOVED***

        [TestMethod]
        public void SetMaxWordLength_One_WordsWithOneLetter()
        ***REMOVED***
            _wp = new WordProvider();
            _wp.LoadTestWords(testWords);
            _wp.SetMaxWordLength(1);

            List<Word> answer = new List<Word>()
            ***REMOVED***
                new Word("u"),
        ***REMOVED***;

            Assert.AreEqual(answer, _wp.Serve());
    ***REMOVED***

        [TestMethod]
        public void SetMinWordLength_MinLengthOfTwo_WordsInCollectionNotSame()
        ***REMOVED***
            _wp = new WordProvider();
            _wp.LoadTestWords(testWords);
            _wp.SetMinWordLength(2);

            List<Word> wordsWithOneLetter = new List<Word>()
            ***REMOVED***
                new Word("u"),
                new Word("i"),
                new Word("p"),
                new Word("w"),
        ***REMOVED***;

            int amountSame = (from w in _wp.Serve() from wwOL in wordsWithOneLetter where w.Letters == wwOL.Letters select w).Count();

            Assert.True(amountSame == 0);
    ***REMOVED***

        [TestMethod]
        public void UsageOfCharacter_Z_MoreThenOneWord()
        ***REMOVED***
            _wp = new WordProvider();
            _wp.LoadTestWords(testWords);

            List<char> testChars = new List<char>()
            ***REMOVED***
                'z'
        ***REMOVED***;

            _wp.UsageOfCharacter(testChars);

            List<Word> answer = new List<Word>()
            ***REMOVED***
                new Word("zaak"),
        ***REMOVED***;

            Assert.AreNotEqual(answer, _wp.Serve());
    ***REMOVED***

        [TestMethod]
        public void ResetToEmpty_reset_EmptyServe()
        ***REMOVED***
            _wp = new WordProvider();
            _wp.LoadTestWords(testWords);
            _wp.Shuffle();
            _wp.SetMinWordLength(2);
            _wp.SetMaxWordLength(8);
            _wp.ResetToEmpty();

            WordProvider answer = new WordProvider();

            Assert.AreEqual(answer.Serve(), _wp.Serve());
    ***REMOVED***

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException),
            "Variable WordProvider.WordsToServe is empty or not set.")]
        public void AreWordsSet_NoWords_Exception()
        ***REMOVED***
            _wp = new WordProvider();
            _wp.AreWordsSet();
    ***REMOVED***
***REMOVED***
***REMOVED***
