using System;
using System.Collections.Generic;
using System.Text;
using TypTop.GameEngine;
using TypTop.Logic;
using TypTop.SpaceMinigame;

namespace TypTop.SpaceMinigame
{
    public class Level
    {
        public List<Enemy> EnemyList { get; private set; }
        public int AmountOfEnemies { get; private set; }

        private readonly WordProvider _wordProvider;

        public Level(Game game)
        {
            _wordProvider = new WordProvider();
            _wordProvider.LoadTestWords();

            EnemyList = new List<Enemy>();
            Initialize(game);
        }

        public bool Initialize(Game game)
        {
            _wordProvider.LimitChars = new List<char>() { 'a','s','d','f','g','h','j','k','l' };
            _wordProvider.UsageChars = new List<char>() { 'a' };

            foreach (var word in _wordProvider.Serve())
            {
                EnemyList.Add(new Enemy(1, _wordProvider.Serve().Count, word, game));
            }

            AmountOfEnemies = EnemyList.Count;

            return true;
        }
    }
}
