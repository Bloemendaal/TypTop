using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;
using TypTop.Logic;
using TypTop.SpaceGame.Components;

namespace TypTop.SpaceGame
{
    public class Enemy : Entity
    {
        public Word Word { get; private set; }
        public int Speed { get; private set; }
        public int Score { get; private set; }
        public int Y { get; set; }
        private readonly SpaceGame _game;

        public Enemy(int speed, int amountOfWords, Word word, Game game) : base(game)
        {
            Y = (game.Rnd.Next(0, amountOfWords * 150) * -1);
            var positionComponent = new PositionComponent()
            {
                Position = new Vector2(game.Rnd.Next(150, 1720), Y)
            };
            AddComponent(positionComponent);
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
            Score = Word.Letters.Length * Speed;
            _game = (SpaceGame)game;
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
            var lineHeight = _game.Line.GetComponent<PositionComponent>().Y;

            if (GetComponent<PositionComponent>().Y > lineHeight)
            {
                _game.RemoveEntity(this);
                _game.EnemyQueue.Dequeue();
                _game.Player.LoseLife();
            }
        }
    }
}
