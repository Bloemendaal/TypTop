using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TypTop.Logic;
using Assert = NUnit.Framework.Assert;

namespace TypTop.Gui.UnitTests
{
    [TestClass]
    public class WordProviderTest
    {
        private WordProvider _wp;

        [TestMethod]
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

            Assert.AreEqual(answer, _wp.Serve());
        }

        [TestMethod]
        public void Shuffle_ListOfStrings_AreNotEqual()
        {
            _wp = new WordProvider();

            _wp.LoadTestWords();


            WordProvider wpCopy = new WordProvider();
            wpCopy.LoadTestWords();

            _wp.Shuffle();

            Assert.AreNotEqual(wpCopy.Serve(), _wp.Serve());
        }

        [TestMethod]
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

            Assert.AreEqual(answer, _wp.Serve());
        }

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
        public void UsageOfCharacter_Z_MoreThenOneWord()
        {
            _wp = new WordProvider();
            _wp.LoadTestWords();

            List<char> testChars = new List<char>()
            {
                'z'
            };

            _wp.UsageChars = testChars ;

            List<Word> answer = new List<Word>()
            {
                new Word("zaak"),
            };

            Assert.AreNotEqual(answer, _wp.Serve());
        }

        [TestMethod]
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

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException),
            "Variable WordProvider.WordsToServe is empty or not set.")]
        public void AreWordsSet_NoWords_Exception()
        {
            _wp = new WordProvider();
            _wp.AreWordsSet();
        }
    }
}
