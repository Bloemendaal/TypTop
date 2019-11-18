using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TypTop.Gui.SpaceGame;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace TypTop.Gui.SpaceGame
{
    [TestClass]
    class SpaceGameTest
    {
        private SpaceGame SpaceGame;

        [TestMethod]
        [TestCase(0, 0, 4)]
        [TestCase(2, 0, 2)]
        [TestCase(4, 0, 0)]
        [TestCase(0, 1, 5)]
        [TestCase(0, 2, 6)]
        [TestCase(2, 2, 4)]
        [TestCase(3, 6, 7)]
        public void Adapt_Lives_ReturnLives(int decrease, int increase, int result)
        {
            //Arrange
            SpaceGame = new SpaceGame();

            //Act
            while (decrease > 0)
            {
                SpaceGame.Player.LoseLife();
                decrease--;
            }

            while (increase > 0)
            {
                SpaceGame.Player.GainLife();
                increase--;
            }

            //Assert
            Assert.AreEqual(SpaceGame.Player.Lives, result);
        }

        [TestMethod]
        [TestCase(0, 0, 0)]
        [TestCase(1000, 0, 1000)]
        [TestCase(4000, 0, 4000)]
        [TestCase(4000, 4000, 0)]
        [TestCase(1000, 4000, -3000)]
        [TestCase(4000, 1000, 3000)]
        [TestCase(4000, 4000, 0)]
        public void Adapt_Score_ReturnScore(int increase, int decrease, int result)
        {
            //Arrange
            SpaceGame = new SpaceGame();

            //Act
            SpaceGame.Player.GainScore(increase);
            SpaceGame.Player.LoseScore(decrease);

            //Asert
            Assert.AreEqual(SpaceGame.Player.Score, result);
        }

        [TestMethod]
        [TestCase(0, 1, 0)]
        [TestCase(0, 2, 0)]
        [TestCase(100, 1, 100)]
        [TestCase(100, 2, 200)]
        [TestCase(200, 2, 400)]
        [TestCase(100, 0, 0)]
        [TestCase(200, 0, 0)]
        public void Move_Enemy_ReturnY(int steps, int speed, int result)
        {
            //Arrange
            SpaceGame = new SpaceGame();
            SpaceGame.EnemyQueue.Enqueue(new Enemy(speed));

            //Act
            while(steps > 0)
            {
                SpaceGame.MoveEnemies();
                steps--;
            }

            //Assert
            Assert.AreEqual(SpaceGame.EnemyQueue.Peek().Y, result);
        }

        [TestMethod]
        [TestCase(1000, 1, 1, 100, 3, 0)]
        [TestCase(1000, 1, 2, 100, 2, 0)]
        [TestCase(1000, 1, 3, 150, 2, 1)]
        [TestCase(1000, 1, 5, 200, 4, 2)]
        public void Move_Enemy_HitPlayer(int steps, int speed, int amount, int interval, int lives, int enemies)
        {
            //Arrange
            SpaceGame = new SpaceGame();
            int _steps = steps;

            //Act
            while (steps > 0)
            {
                SpaceGame.MoveEnemies();

                if ((_steps - steps) % interval == 0)
                    if (amount > 0)
                    {
                        SpaceGame.EnemyQueue.Enqueue(new Enemy(speed));
                        amount--;
                    }

                SpaceGame.EnemyHitPlayer();
                steps--;
            }

            //Assert
            if (SpaceGame.EnemyQueue.Count == enemies)
                Assert.AreEqual(SpaceGame.Player.Score, lives);
            else
                Assert.Fail();
        }
    }
}
