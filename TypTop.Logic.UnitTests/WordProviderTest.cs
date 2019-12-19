using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework.Internal;
using TypTop.Logic;

namespace TypTop.Logic.UnitTests
{
    class WordProviderTest
    {
        private WordProvider _wp;

        [TestCase()]
        public void LimitByCharacter_LeftMiddleRow_ListOfWords()
        {
            _wp = new WordProvider();

            _wp.LoadTestWords();

            List<Word> answer = new List<Word>()
            {
                new Word("af"),
                new Word("dag")
            };

            List<char> testChars = new List<char>()
            {
                'a','s','d','f','g'
            };

            //Filter
            _wp.LimitChars = testChars;

            Assert.AreEqual(answer, _wp.Serve(false));
        }

        [TestCase()]
        public void Shuffle_ListOfStrings_AreNotEqual()
        {
            _wp = new WordProvider();

            _wp.LoadTestWords();


            WordProvider wpCopy = new WordProvider();
            wpCopy.LoadTestWords();

            _wp.Shuffle();

            Assert.AreNotEqual(wpCopy.Serve(), _wp.Serve());
        }

        [TestCase()]
        public void WordLimit_Five_FirstFive()
        {
            _wp = new WordProvider();
            _wp.LoadTestWords();
            _wp.WordCount = 5;

            List<Word> answer = new List<Word>()
            {
                new Word("aan"),
                new Word("aanbod"),
                new Word("aanraken"),
                new Word("aanval"),
                new Word("aap")
            };

            Assert.AreEqual(answer, _wp.Serve(false));
        }

        [TestCase()]
        public void SetMaxWordLength_One_WordsWithOneLetter()
        {
            _wp = new WordProvider();
            _wp.LoadTestWords();
            _wp.MaxWordLength = 1;

            List<Word> answer = new List<Word>()
            {
                new Word("u"),
            };

            Assert.AreEqual(answer, _wp.Serve());
        }

        [TestCase()]
        public void SetMinWordLength_MinLengthOfTwo_WordsInCollectionNotSame()
        {
            _wp = new WordProvider();
            _wp.LoadTestWords();
            _wp.MinWordLength = 2;

            List<Word> wordsWithOneLetter = new List<Word>()
            {
                new Word("u"),
                new Word("i"),
                new Word("p"),
                new Word("w"),
            };

            int amountSame = (from w in _wp.Serve() from wwOL in wordsWithOneLetter where w.Letters == wwOL.Letters select w).Count();

            Assert.True(amountSame == 0);
        }

        [TestCase()]
        public void UsageOfCharacter_Z_MoreThenOneWord()
        {
            _wp = new WordProvider();
            _wp.LoadTestWords();

            List<char> testChars = new List<char>()
            {
                'z'
            };

            _wp.UsageChars = testChars;

            List<Word> answer = new List<Word>()
            {
                new Word("zaak"),
            };

            Assert.AreNotEqual(answer, _wp.Serve());
        }

        [TestCase()]
        public void ResetToEmpty_reset_EmptyServe()
        {
            _wp = new WordProvider();
            _wp.LoadTestWords();
            _wp.Shuffle();
            _wp.MinWordLength = (2);
            _wp.MaxWordLength = (8);
            _wp.ResetToEmpty();

            WordProvider answer = new WordProvider();

            Assert.AreEqual(answer.Serve(), _wp.Serve());
        }
    }
}
