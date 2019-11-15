using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using TypTop.Gui.SpaceGame;
using TypTop.Logic;
using Assert = NUnit.Framework.Assert;

namespace TypTop.Gui.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private WordProvider wp;
        
        [TestMethod]
        public void LimitByCharacter_LeftMiddleRow_ListOfWords()
        {
            wp = new WordProvider();
            
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
            wp.LimitByCharacter(testChars);

            Assert.AreEqual(answer, wp.Serve());
        }
    }
}
