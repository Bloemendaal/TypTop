using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;
using TypTop.Logic;

namespace TypTop.SpaceGame
{
    public class Enemy : Entity
    {
        public Word Word { get; private set; }
        public int Speed { get; private set; }
        private PositionComponent _positionComponent;

        public Enemy(int speed, int amountOfWords, Word word, Game game) : base(game)
        {
            _positionComponent = new PositionComponent()
            {
                Position = new Vector2(game.Rnd.Next(150, 1720), (game.Rnd.Next(0, amountOfWords * 150)*-1))
            };
            AddComponent(_positionComponent);
            AddComponent(new VelocityComponent()
            {
                Velocity = new Vector2(0, (float)speed)
            });
            AddComponent(new WordComponent(word, Brushes.Red, Brushes.DarkRed)
            {
                TransformX = 75,
                TransformY = 150,
                Center = true
            });
            AddComponent(new ImageComponent(new BitmapImage(new Uri(@"Images/enemy.png", UriKind.Relative)))
            {
                Width = 150
            });
            Word = word;
            Speed = speed;
        }
    }
}
