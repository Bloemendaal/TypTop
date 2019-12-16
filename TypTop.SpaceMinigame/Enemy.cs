using System;
using System.Numerics;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;
using TypTop.Logic;

namespace TypTop.SpaceMinigame
{
    public class Enemy : Entity
    {
        private readonly SpaceGame _minigame;
        private readonly PositionComponent _positionComponent;

        public Enemy(float speed, Word word, Game game) : base(game)
        {
            ZIndex = 2;

            _minigame = (SpaceGame) game;
            _positionComponent = new PositionComponent(
                game.Rnd.Next(150, 1720),
                game.Rnd.Next(0, _minigame.EnemyAmount * 150) * -1
            );
            AddComponent(_positionComponent);
            AddComponent(new VelocityComponent
            {
                Velocity = new Vector2(0, speed)
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
            Score = 100 + Word.Letters.Length * (int) Math.Round(Speed * 10);
        }

        //
        // Props
        //
        public Word Word { get; }
        public float Speed { get; }
        public int Score { get; }

        //
        // Vars
        //
        public float Y => _positionComponent.Y;

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            if (Y > _minigame.LineHeight)
            {
                _minigame.RemoveEnemy(this);
                _minigame.Lives.Amount--;
                _minigame.Score.Amount -= Math.Max(50, 50 + (int) (100 - Math.Round(Speed * 10)));
            }
        }
    }
}