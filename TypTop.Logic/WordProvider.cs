using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TypTop.Database;
using Word = TypTop.Logic.Word;

namespace TypTop.SpaceGame
{
    public class WordProvider
    {
        // List of words to serve with conditions
        private List<Word> WordsToServe { get; set; }

        // Amount of words to provide.
        public int WordCount { get; private set; }
        // Max length of word.
        public int MaxWordLength { get; private set; }
        public int MinWordLength { get; private set; }
        // #Optional: select only words with char in list.
        public List<char> UsageChars { get; private set; }
        public List<char> LimitChars { get; private set; }
        
        public WordProvider()
        {
            UsageChars = new List<char>();
            LimitChars = new List<char>();
            WordsToServe = new List<Word>();
        }

        // Randomizes the list
        public void Shuffle()
        {
            if (!AreWordsSet()) return;
            var randomList = new List<Word>();

            var r = new Random();
            while (WordsToServe.Count > 0)
            {
                var randomIndex = r.Next(0, WordsToServe.Count);
                //add it to the new, random list
                randomList.Add(WordsToServe[randomIndex]);
                //remove to avoid duplicates
                WordsToServe.RemoveAt(randomIndex);
            }

            WordsToServe = randomList;
        }

        // Limit amount of words
        public void WordLimit(int limit)
        {
            if (!AreWordsSet()) return;
            WordCount = limit;

            WordsToServe = WordsToServe?
                .Take(limit)
                .ToList();
        }

        // Get max length of word.
        public void SetMaxWordLength(int limit)
        {
            if (!AreWordsSet()) return;
            MaxWordLength = limit;

            WordsToServe = WordsToServe?
                .Where(s => s.Letters.Length <= limit)
                .ToList();
        }

        // Get min length of word
        public void SetMinWordLength(int limit)
        {
            if (!AreWordsSet()) return;
            MinWordLength = limit;
            
            WordsToServe = WordsToServe?
                .Where(s => s.Letters.Length >= limit)
                .ToList();
        }

        // Words need to have on of the following letters
        public void UsageOfCharacter(List<char> chars)
        {
            if (!AreWordsSet()) return;
            UsageChars = chars;

            var filteredList = new List<Word>();
            foreach (var word in chars
                .SelectMany(c => WordsToServe
                .Where(word => word.Letters
                    .Contains(c))
                .Where(word => !filteredList
                    .Contains(word))))
            {
                filteredList.Add(word);
            }
            WordsToServe = filteredList;
        }

        // Words need to be made of...
        public void LimitByCharacter(List<char> chars)
        {
            if (!AreWordsSet()) return;
            LimitChars = chars;

            var charString = chars
                .Aggregate("", (current, c) => current + c);
            var filteredList = WordsToServe
                .Where(w => Regex.IsMatch(w.Letters, $@"^[{charString}]+$"))
                .ToList();

            WordsToServe = filteredList;
        }

        public bool AreWordsSet()
        {
            if (WordsToServe == null || !WordsToServe.Any()) throw new NullReferenceException("Variable WordProvider.WordsToServe is empty or not set.");
            return true;
        }

        public void LoadTestWords(List<string> tempWords)
        {
            foreach (var s in tempWords)
            {
                WordsToServe.Add(new Word(s));
            }
        }

        // Reset words to initial
        public void ResetToEmpty()
        {
            WordsToServe = new List<Word>();
        }

        // Loading words from database
        public void LoadWords()
        {
            using var db = new Context();
            var words = db.Word.OrderBy(w => w.Letters).ToList();
            foreach (var w in words)
            {
                WordsToServe.Add(new Word(w.Letters));
            }
        }

        // return filtered words
        public List<Word> Serve() => WordsToServe;
        
    }
}
