***REMOVED***
***REMOVED***
using System.Linq;
***REMOVED***
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TypTop.Logic;

namespace TypTop.Gui.SpaceGame
***REMOVED***
    public class WordProvider
    ***REMOVED***
        // List of words to serve with conditions
        private List<Word> WordsToServe ***REMOVED*** get; set; ***REMOVED***

        // Amount of words to provide.
        public int WordCount ***REMOVED*** get; private set; ***REMOVED***
        // Max length of word.
        public int MaxWordLength ***REMOVED*** get; private set; ***REMOVED***
        public int MinWordLength ***REMOVED*** get; private set; ***REMOVED***
        // #Optional: select only words with char in list.
        public List<char> UsageChars ***REMOVED*** get; private set; ***REMOVED***
        public List<char> LimitChars ***REMOVED*** get; private set; ***REMOVED***
        
        public WordProvider()
        ***REMOVED***
            UsageChars = new List<char>();
            LimitChars = new List<char>();
            WordsToServe = new List<Word>();
    ***REMOVED***

        // Randomizes the list
        public void Shuffle()
        ***REMOVED***
            if (!AreWordsSet()) return;
            var randomList = new List<Word>();

            var r = new Random();
            while (WordsToServe.Count > 0)
            ***REMOVED***
                var randomIndex = r.Next(0, WordsToServe.Count);
                //add it to the new, random list
                randomList.Add(WordsToServe[randomIndex]);
                //remove to avoid duplicates
                WordsToServe.RemoveAt(randomIndex);
        ***REMOVED***

            WordsToServe = randomList;
    ***REMOVED***

        // Limit amount of words
        public void WordLimit(int limit)
        ***REMOVED***
            if (!AreWordsSet()) return;
            WordCount = limit;

            WordsToServe = WordsToServe?
                .Take(limit)
                .ToList();
    ***REMOVED***

        // Get max length of word.
        public void SetMaxWordLength(int limit)
        ***REMOVED***
            if (!AreWordsSet()) return;
            MaxWordLength = limit;

            WordsToServe = WordsToServe?
                .Where(s => s.Letters.Length <= limit)
                .ToList();
    ***REMOVED***

        // Get min length of word
        public void SetMinWordLength(int limit)
        ***REMOVED***
            if (!AreWordsSet()) return;
            MinWordLength = limit;
            
            WordsToServe = WordsToServe?
                .Where(s => s.Letters.Length >= limit)
                .ToList();
    ***REMOVED***

        // Words need to have on of the following letters
        public void UsageOfCharacter(List<char> chars)
        ***REMOVED***
            if (!AreWordsSet()) return;
            UsageChars = chars;

            var filteredList = new List<Word>();
            foreach (var word in chars
                .SelectMany(c => WordsToServe
                .Where(word => word.Letters
                    .Contains(c))
                .Where(word => !filteredList
                    .Contains(word))))
            ***REMOVED***
                filteredList.Add(word);
        ***REMOVED***
            WordsToServe = filteredList;
    ***REMOVED***

        // Words need to be made of...
        public void LimitByCharacter(List<char> chars)
        ***REMOVED***
            if (!AreWordsSet()) return;
            LimitChars = chars;

            var charString = chars
                .Aggregate("", (current, c) => current + c);
            var filteredList = WordsToServe
                .Where(w => Regex.IsMatch(w.Letters, $@"^[***REMOVED***charString***REMOVED***]+$"))
                .ToList();

            WordsToServe = filteredList;
    ***REMOVED***

        public bool AreWordsSet()
        ***REMOVED***
            if (WordsToServe == null || !WordsToServe.Any()) throw new NullReferenceException("Variable WordProvider.WordsToServe is empty or not set.");
            return true;
    ***REMOVED***

        public void LoadTestWords(List<string> tempWords)
        ***REMOVED***
            foreach (var s in tempWords)
            ***REMOVED***
                WordsToServe.Add(new Word(s));
        ***REMOVED***
    ***REMOVED***

        // Reset words to initial
        public void ResetToEmpty()
        ***REMOVED***
            WordsToServe = new List<Word>();
    ***REMOVED***

        // Loading words from database
        public void LoadWords()
        ***REMOVED***
            
    ***REMOVED***

        // return filtered words
        public List<Word> Serve() => WordsToServe;
        
***REMOVED***
***REMOVED***
