using NUnit.Framework;
using System.Collections.Generic;
using TypTop.Logic;

namespace TypTop.Logic.UnitTests
{
    public class Tests
    {

        public enum Options
        {
            Default,
            CaseInsensitive,
            IgnoreNumbers,
            IgnorePunctuation,
            IgnoreSpace,
            SpecialChar,
            SpecialCharCaseInsensitive
        }


        public static readonly Word DefaultWord = new Word("Test 1234 È….");
        public static Dictionary<Options, Input> Inputs = new Dictionary<Options, Input>()
        {
            {
                Options.Default,
                new InputWord(DefaultWord)
            },
            {
                Options.CaseInsensitive,
                new InputWord(DefaultWord)
                {
                    CaseSensitive = false
                }
            },
            {
                Options.IgnoreNumbers,
                new InputWord(DefaultWord)
                {
                    IgnoreNumbers = true
                }
            },
            {
                Options.IgnorePunctuation,
                new InputWord(DefaultWord)
                {
                    IgnorePunctuation = true
                }
            },
            {
                Options.IgnoreSpace,
                new InputWord(DefaultWord)
                {
                    IgnoreSpace = true
                }
            },
            {
                Options.SpecialChar,
                new InputWord(DefaultWord)
                {
                    IgnoreSpecialChar = false
                }
            },
            {
                Options.SpecialCharCaseInsensitive,
                new InputWord(DefaultWord)
                {
                    IgnoreSpecialChar = false,
                    CaseSensitive = false
                }
            }
        };

        [SetUp]
        public void Setup()
        {
        }


        [TestCase(false, 't', 0)]
        [TestCase(true , 'T', 0)]

        [TestCase(true , 't', 0, Options.CaseInsensitive)]
        [TestCase(true , 'T', 0, Options.CaseInsensitive)]
        [TestCase(true,  'E', 1, Options.CaseInsensitive)]

        [TestCase(false, 't', 5)]
        [TestCase(false, 't', 5, Options.IgnoreNumbers)]
        [TestCase(true , ' ', 5, Options.IgnoreNumbers)]
        [TestCase(true , '1', 5)]
        [TestCase(true , '1', 5, Options.IgnoreNumbers)]
        [TestCase(true , '2', 5, Options.IgnoreNumbers)]

        [TestCase(false, 't', 13)]
        [TestCase(false, 't', 13, Options.IgnorePunctuation)]
        [TestCase(true , ' ', 13, Options.IgnorePunctuation)]
        [TestCase(true , '.', 13)]
        [TestCase(true , '.', 13, Options.IgnorePunctuation)]
        [TestCase(true , ',', 13, Options.IgnorePunctuation)]

        [TestCase(false, 't', 12)]
        [TestCase(false, 't', 12, Options.IgnoreSpace)]
        [TestCase(true,  '.', 12, Options.IgnoreSpace)]
        [TestCase(true,  ' ', 12)]
        [TestCase(true,  ' ', 12, Options.IgnoreSpace)]
        [TestCase(true,  '\n', 12, Options.IgnoreSpace)]

        [TestCase(false, 't', 10)]
        [TestCase(false, 't', 10, Options.SpecialChar)]
        [TestCase(true,  'e', 10)]
        [TestCase(false, 'e', 10, Options.SpecialChar)]
        [TestCase(false, 'e', 11, Options.SpecialChar)]
        [TestCase(false, 'e', 11)]
        [TestCase(true,  'E', 10, Options.CaseInsensitive)]
        [TestCase(true,  'e', 11, Options.CaseInsensitive)]
        [TestCase(true,  'E', 11)]
        [TestCase(false, 'e', 11, Options.SpecialCharCaseInsensitive)]
        [TestCase(false, 'E', 11, Options.SpecialCharCaseInsensitive)]
        public void CheckWord_CharIndex_returnsBool(bool result, char ch, int index = 0, Options option = Options.Default, Word word = null)
        {
            //Arrange
            if (word == null)
            {
                word = new Word("Test 1234 È… .. test");
            }
            //Act
            //Assert
            Assert.AreEqual(result, Inputs[option].CheckWord(ch, word, index));
        }


        [TestCase(null, Options.Default)]
        [TestCase(true, Options.IgnoreNumbers)]
        public void CheckWord_Correct_returnsUpdatedWord(bool? result, Options option)
        {
            //Arrange
            Word word = new Word("Test123");
            //Act
            Inputs[option].CheckWord('T', word);
            Inputs[option].CheckWord('e', word);
            Inputs[option].CheckWord('s', word);
            Inputs[option].CheckWord('t', word);
            Inputs[option].CheckWord('1', word);
            //Assert
            Assert.AreEqual(result, word.Correct);
        }


        [TestCase(false, Options.Default)]
        [TestCase(true,  Options.IgnoreNumbers)]
        public void CheckWord_Finished_returnsUpdatedWord(bool? result, Options option)
        {
            //Arrange
            Word word = new Word("Test123");
            //Act
            Inputs[option].CheckWord('T', word);
            Inputs[option].CheckWord('e', word);
            Inputs[option].CheckWord('s', word);
            Inputs[option].CheckWord('t', word);
            Inputs[option].CheckWord('1', word);
            //Assert
            Assert.AreEqual(result, word.Finished);
        }
    }
}