using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;

namespace TypTop.SpaceGame
{
    public class Player : Entity
    {
        public int Lives { get; private set; } 
        public int Score { get; private set; } 
        public Player(Game game) : this(4, game) { }

        public Player(int lives, Game game) : base(game)
        {
            Lives = lives;  // start amount of lives
            Score = 0;  // start amount of points

            AddComponent(new PositionComponent()
            {
                Position = new Vector2(885, 975)
            });

            AddComponent(new ImageComponent(new BitmapImage(new Uri(@"Images/spaceship.png", UriKind.Relative)))
            {
                Width = 100
            });
        }

        public void GainScore(int score) => Score += score;
        public void LoseScore(int score) => Score -= score;
        public void GainLife() => Lives++;
        public void LoseLife() => Lives--;
    }
}
