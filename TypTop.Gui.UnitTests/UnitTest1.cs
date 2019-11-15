using System;
***REMOVED***
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using TypTop.Gui.SpaceGame;
using TypTop.Logic;
using Assert = NUnit.Framework.Assert;

namespace TypTop.Gui.UnitTests
***REMOVED***
    [TestClass]
    public class UnitTest1
    ***REMOVED***
        private WordProvider wp;
        
        [TestMethod]
        public void LimitByCharacter_LeftMiddleRow_ListOfWords()
        ***REMOVED***
            wp = new WordProvider();
            
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
            wp.LimitByCharacter(testChars);

            Assert.AreEqual(answer, wp.Serve());
    ***REMOVED***
***REMOVED***
***REMOVED***
