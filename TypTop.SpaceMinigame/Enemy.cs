using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;
using TypTop.Logic;
using TypTop.SpaceMinigame.Components;

namespace TypTop.SpaceMinigame
{
    public class Enemy : Entity
    {
        //
        // Props
        //
        public Word Word { get; private set; }
        public float Speed { get; private set; }
        public int Score { get; private set; }
        
        //
        // Vars
        //
        public float Y => _positionComponent.Y;
        private readonly SpaceGame _minigame;
        private readonly PositionComponent _positionComponent;

        public Enemy(float speed, Word word, Game game) : base(game)
        {
            ZIndex = 2;

            _minigame = (SpaceGame)game;
            _positionComponent = new PositionComponent(
                game.Rnd.Next(150, 1720), 
                game.Rnd.Next(0, _minigame.EnemyAmount * 150) * -1
            );
            AddComponent(_positionComponent);
            
            AddComponent(new VelocityComponent()
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
            Score = 100 + Word.Letters.Length * (int)(Math.Round(Speed * 10));
        }

        //
        // This method is overridden from entity and is executed every "deltaTime".
        // The added functionality is checking whether the relevant Enemy is (already) under the line.
        // If this is the case, this Entity will be removed from the game and from the dependent lists.
        //
        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            if (Y > _minigame.LineHeight)
            {
                _minigame.RemoveEnemy(this);
                _minigame.Lives.Amount--;
                _minigame.Score.Amount -= Math.Max(50, 50 + (int)(100 - Math.Round(Speed * 10)));
            }
        }
    }
}
