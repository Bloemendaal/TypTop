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
        public int Lives { get; private set; }  //amount of chances left
        public int Score { get; private set; }  //total amount of earned points

        public Player(Game game) : this(4, game) { }

        public Player(int lives, Game game) : base("Player", game)
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

        // gain points, add to score
        public void GainScore(int score) => Score += score;

        // lose points, substract from score
        public void LoseScore(int score) => Score -= score;

        // gain one life
        public void GainLife() => Lives++;

        // lose on life
        public void LoseLife() => Lives--;
    }
}
