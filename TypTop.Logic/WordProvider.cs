﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TypTop.Database;

namespace TypTop.Logic
{
    public class WordProvider
    {
        /// <summary>
        /// List of words to serve with conditions
        /// </summary>
        private List<Word> _wordsToServe = new List<Word>();

        /// <summary>
        /// Amount of words to provide.
        /// </summary>
        public int? WordCount
        {
            get => _wordCount;
            set
            {
                if (value != null && value < 0)
                {
                    value = 0;
                }

                _wordCount = value;
            }
        }
        private int? _wordCount = null;

        /// <summary>
        /// Max length of word.
        /// </summary>
        public int? MaxWordLength
        {
            get => _maxWordLength;
            set
            {
                if (value != null)
                {
                    if (value < 0)
                    {
                        value = 0;
                    }
                    if (MinWordLength != null && value < MinWordLength)
                    {
                        value = MinWordLength;
                    }
                }

                _maxWordLength = value;
            }
        }
        private int? _maxWordLength = null;

        /// <summary>
        /// Min length of word.
        /// </summary>
        public int? MinWordLength
        {
            get => _minWordLength;
            set
            {
                if (value != null)
                {
                    if (value < 0)
                    {
                        value = 0;
                    }
                    if (MaxWordLength != null && value > MaxWordLength)
                    {
                        value = MaxWordLength;
                    }
                }

                _minWordLength = value;
            }
        }
        private int? _minWordLength = null;

        /// <summary>
        ///  Optional: select only words with char in list.
        /// </summary>
        public List<char> UsageChars { get; set; }
        public List<char> LimitChars { get; set; }


        /// <summary>
        /// Randomizes the list
        /// </summary>
        public void Shuffle()
        {
            if (!AreWordsSet()) return;
            var randomList = new List<Word>();

            var r = new Random();
            while (_wordsToServe.Count > 0)
            {
                var randomIndex = r.Next(0, _wordsToServe.Count);
                //add it to the new, random list
                randomList.Add(_wordsToServe[randomIndex]);
                //remove to avoid duplicates
                _wordsToServe.RemoveAt(randomIndex);
            }

            _wordsToServe = randomList;
        }


        public bool AreWordsSet() => _wordsToServe != null && _wordsToServe.Any();


        /// <summary>
        /// Loading words from database.
        /// </summary>
        public void LoadWords()
        {
             using var db = new Context("");
             var words = db.Word.OrderBy(w => w.Letters).ToList();
             foreach (var w in words)
             {
                _wordsToServe.Add(new Word(w.Letters));
             }
        }
        public void LoadTestWords()
        {
            _wordsToServe = new List<string>(){
                "aan", "aanbod", "aanraken", "aanval", "aap", "aardappel", "aarde", "aardig", "acht", "achter", "actief", "activiteit", "ademen", "af", "afgelopen", "afhangen", "afmaken", "afname", "afspraak", "afval", "al", "algemeen", "alleen", "alles", "als", "alsjeblieft", "altijd", "ander", "andere", "anders", "angst", "antwoord", "antwoorden", "appel", "arm", "auto", "avond", "avondeten",
                "baan", "baby", "bad", "bal", "bang", "bank", "basis", "bed", "bedekken", "bedreiging", "bedreven", "been", "beer", "beest", "beetje", "begin", "begrijpen", "begrip", "behalve", "beide", "beker", "bel", "belangrijk", "bellen", "belofte", "beneden", "benzine", "berg", "beroemd", "beroep", "bescherm", "beslissen", "best", "betalen", "beter", "bevatten", "bewegen", "bewolkt", "bezoek", "bibliotheek", "bieden", "bij", "bijna", "bijten", "bijvoorbeeld", "bijzonder", "binnen", "binnenkort", "blad", "blauw", "blazen", "blij", "blijven", "bloed", "bloem", "bodem", "boek", "boerderij", "boete", "boom", "boon", "boord", "boos", "bord", "borstelen", "bos", "bot", "bouwen", "boven", "branden", "brandstof", "breed", "breken", "brengen", "brief", "broer", "broek", "brood", "brug", "bruikbaar", "bruiloft", "bruin", "bui", "buiten", "bureau", "buren", "bus", "buurman", "buurvrouw",
                "cadeau", "chocolade", "cirkel", "comfortabel", "compleet", "computer", "conditie", "controle", "cool", "correct",
                "daar", "daarom", "dag", "dak", "dan", "dansen", "dapper", "dat", "de", "deel", "deken", "deksel", "delen", "derde", "deze", "dichtbij", "dienen", "diep", "dier", "dik", "ding", "dit", "dochter", "doen", "dom", "donker", "dood", "door", "doorzichtig", "doos", "dorp", "draad", "draaien", "dragen", "drie", "drijven", "drinken", "drogen", "dromen", "droog", "druk", "dubbel", "dun", "dus", "duur", "duwen",
                "echt", "een", "één", "eend", "eenheid", "eenzaam", "eerste", "eeuw", "effect", "ei", "eigen", "eiland", "einde", "eis", "elektrisch", "elk", "en", "enkele", "enthousiast", "erg", "eten", "even", "examen", "extreem",
                "falen ", "familie", "feest", "feit", "fel", "fijn", "film", "fit", "fles", "foto", "fout", "fris", "fruit",
                "gaan", "gat", "gebeuren", "gebeurtenis", "gebied", "geboorte", "geboren", "gebruik", "gebruikelijk", "gebruiken", "gedrag", "gedragen", "geel", "geen", "gehoorzamen", "geit", "geld", "geliefde", "gelijk", "geloof", "geluid", "geluk", "gemak", "gemakkelijk", "gemeen", "genieten", "genoeg", "genot", "gerecht", "gereedschap", "geschikt", "gespannen", "geur", "gevaar", "gevaarlijk", "gevangenis", "geven", "gevolg", "gewicht", "gewoon", "gezicht", "gezond", "gif", "gisteren", "glad", "glas", "glimlach", "goed", "goedkoop", "goud", "graf", "grap", "grappig", "gras", "grens", "grijs", "groeien", "groen", "groente", "groep", "grof", "grond", "groot", "grootmoeder", "grootvader",
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
                "samen", "sap", "schaap", "schaar", "schaduw", "scheiden", "scherp", "schetsen", "schieten", "schijnen", "schip", "school", "schoon", "schouder", "schreeuw", "schreeuwen", "schrijven", "schudden", "seconde", "signaal", "simpel", "sinds", "slaapkamer", "slapen", "slecht", "sleutel", "slim", "slot", "sluiten", "smaak", "smal", "sneeuw", "snel", "snelheid", "snijden", "soep", "sok", "soms", "soort", "sorry", "speciaal", "spel", "spelen", "sport", "spreken", "springen", "staal", "stad", "stap", "start", "station", "steen", "stelen", "stem", "stempel", "ster", "sterk", "steun", "stil", "stilte", "stoel", "stof", "stoffig", "stom", "stop", "storm", "straat", "straffen", "structuur", "student", "studie", "stuk", "succes", "suiker",
                "taal", "taart", "tafel", "tak", "tamelijk", "tand", "tante", "tas", "taxi", "te", "team", "teen", "tegen", "teken", "tekenen", "telefoon", "televisie", "tellen", "tennis", "terug", "terugkomst", "terwijl", "test", "tevreden", "thee", "thuis", "tien", "tijd", "titel", "toekomst", "toen", "toename", "totaal", "traan", "tram", "trein", "trekken", "trouwen", "trui", "tuin", "tussen", "tweede",
                "u", "uit", "uitleggen", "uitnodigen", "uitvinden", "uitzoeken", "uur",
                "vaak", "vaarwel", "vader", "vak", "vakantie", "vallen", "vals", "van", "vandaag", "vangen", "vanmorgen", "vannacht", "varken", "vast", "vechten", "veel", "veer", "veilig", "ver", "veranderen", "verandering", "verder", "verdienen", "verdrietig", "verenigen", "verf", "vergelijkbaar", "vergelijken", "vergelijking", "vergeten", "vergeven", "vergissen", "verhaal", "verhoging", "verjaardag", "verkeerd", "verkopen", "verlaten", "verleden", "verliezen", "vernietigen", "veroveren", "verrassen", "vers", "verschil", "verschrikkelijk", "verspreiden", "verstand", "verstoppen", "versturen", "vertellen", "vertrekken", "vertrouwen", "verwachten", "verwijderen", "verzamelen", "verzameling", "vet", "vier", "vierkant", "vies", "vijand", "vijf", "vijver", "vinden", "vinger", "vis", "vlag", "vlees", "vlieg", "vliegtuig", "vloer", "voeden", "voedsel", "voelen", "voet", "voetbal", "vogel", "vol", "volgende", "volgorde", "voor", "voorbeeld", "voorkomen", "voorzichtig", "voorzien", "vork", "vorm", "vos", "vouwen", "vraag", "vragen", "vrede", "vreemd", "vreemde", "vriend", "vriendelijk", "vriezen", "vrij", "vrijheid", "vroeg", "vroeger", "vrouw", "vullen", "vuur",
                "waar", "waarom", "waarschijnlijk", "wachten", "wakker", "wanneer", "want", "wapen", "warm", "wassen", "wat", "water", "we", "week", "weer", "weg", "welke", "welkom", "wens", "wereld", "werelddeel", "werk", "west", "wetenschap", "wie", "wiel", "wij", "wijn", "wijs", "wild", "willen", "wind", "winkel", "winnen", "winter", "wissen", "wit", "wolf", "wolk", "wonder", "woord", "woud", "wreed",
                "zaak", "zacht", "zak", "zand", "zee", "zeep", "zeer", "zeggen", "zeil", "zeker", "zelfde", "zes", "zetten", "zeven", "ziek", "ziekenhuis", "ziel", "zien", "zij", "zijn", "zilver", "zingen", "zinken", "zitten", "zo", "zoals", "zoeken", "zoet", "zomer", "zon", "zonder", "zonnig", "zoon", "zorg", "zorgen", "zou", "zout", "zuid", "zulke", "zullen", "zus", "zwaar", "zwak", "zwembad", "zwemmen"
            }.Select(w => new Word(w)).ToList();
        }


        /// <summary>
        /// Reset words to initial.
        /// </summary>
        public void ResetToEmpty() => _wordsToServe.Clear();


        /// <summary>
        /// Serve the words.
        /// </summary>
        /// <param name="shuffle">
        /// Shuffle the words before serving. Default is true.
        /// </param>
        /// <returns>
        /// Returns the words that apply to this condition.
        /// </returns>
        public List<Word> Serve(bool shuffle = true) {
            if (shuffle) Shuffle();

            IEnumerable<Word> serve = _wordsToServe;

            if (LimitChars != null && LimitChars.Count > 0)
            {
                var charString = LimitChars.Aggregate("", (current, c) => current + c);
                serve = serve.Where(w => Regex.IsMatch(w.Letters, $@"^[{charString}]+$"));
            }
            if (UsageChars != null && UsageChars.Count > 0)
            {
                serve = serve.Where(w => UsageChars.Any(c => w.Letters.Contains(c)));
            }

            if (MaxWordLength != null)
            {
                serve = serve.Where(s => s.Letters.Length <= MaxWordLength);
            }
            if (MinWordLength != null)
            {
                serve = serve.Where(s => s.Letters.Length >= MinWordLength);
            }

            if (WordCount != null)
            {
                serve = serve.Take((int)WordCount);
            }

            return serve.Select(w => new Word(w.Letters)).ToList();
         }
    }
}
