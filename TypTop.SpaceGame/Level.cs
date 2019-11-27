using System;
using System.Collections.Generic;
using System.Text;
using BasicGameEngine;
using TypTop.Logic;
using TypTop.SpaceGame;

namespace TypTop.SpaceGame
{
    public class Level
    {
        public List<Enemy> EnemyList { get; private set; }
        public int AmountOfEnemies { get; private set; }
        public int PlayerLives { get; set; }
        
        private readonly WordProvider _wordProvider;

        public Level(int level, Game game)
        {
            _wordProvider = new WordProvider()
            {
                MinWordLength = 4
            };
            _wordProvider.LoadTestWords();

            EnemyList = new List<Enemy>();
            Initialize(game);
        }

        public bool Initialize(Game game)
        {
            var livesOfPlayer = 3;
            var limitChar = new List<char>()
            {
                'a','s','d','f','g','h','j','k','l'
            };

            var usageChar = new List<char>()
            {
                'a'
            };

            _wordProvider.LimitByCharacter(limitChar);
            _wordProvider.UsageOfCharacter(usageChar);

            PlayerLives = livesOfPlayer;
            
            foreach (var word in _wordProvider.Serve())
            {
                EnemyList.Add(new Enemy(1, _wordProvider.Serve().Count, word, game));
            }

            AmountOfEnemies = EnemyList.Count;
            
            return true;
        }
    }
}
