using System;
using System.Collections.Generic;
using System.Text;
using BasicGameEngine;
using TypTop.Logic;
using TypTop.SpaceGame;

namespace TypTop.Gui.SpaceGame
{
    public class Level
    {
        public List<Enemy> EnemyList { get; private set; }
        public int AmountOfEnemies { get; private set; }
        public int PlayerLives { get; set; }
        
        private readonly WordProvider _wordProvider;

        public Level(int level, Game game)
        {
            _wordProvider = new WordProvider();
            _wordProvider.LoadTestWords();

            EnemyList = new List<Enemy>();
            Initialize(game);
        }

        public bool Initialize(Game game)
        {
            var livesOfPlayer = 3;


            _wordProvider.LimitChars = new List<char>() { 'a','s','d','f','g','h','j','k','l' };
            _wordProvider.UsageChars = new List<char>() { 'a' };


            PlayerLives = livesOfPlayer;
            
            foreach (var word in _wordProvider.Serve())
            {
                EnemyList.Add(new Enemy(4, _wordProvider.Serve().Count, word, game));
            }


            AmountOfEnemies = EnemyList.Count;
            

            return true;
        }
    }
}
