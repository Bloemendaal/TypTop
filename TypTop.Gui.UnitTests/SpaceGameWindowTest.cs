using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TypTop.Gui.SpaceGame;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using TypTop.Logic;


namespace TypTop.Gui.SpaceGame
{
    [TestClass]
    class SpaceGameWindowTest
    {
        SpaceGameWindow Window;
        Word word = new Word("word");

        [TestMethod]
        [TestCase(0, 0, 0, 0)]
        [TestCase(3, 0, 0, 3)]
        [TestCase(3, 3, 0, 3)]
        [TestCase(3, 3, 2, 3)]
        [TestCase(2, 2, 3, 3)]
        [TestCase(2, 1, 3, 4)]
        public void AddAndShoot_Enemies_ReturnAmount(int start, int shoot, int add, int result)
        {
            // Arrange
            Window = new SpaceGameWindow();
            while(start > 0)
            {
                Window.Game.EnemyQueue.Enqueue(new Enemy(1, word));
                start--;
            }
            
            // Act
            while(shoot > 0)
            {
                Window.Game.Shoot();
                shoot--;
            }
            while (add > 0)
            {
                Window.Game.EnemyQueue.Enqueue(new Enemy(1, word));
                add--;
            }

            //Assert
            Assert.AreEqual(Window.EnemyRectList.Count, result);
        }
    }
}
