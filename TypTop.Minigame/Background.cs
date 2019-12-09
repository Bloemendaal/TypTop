
using TypTop.GameEngine;
using TypTop.GameEngine.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace TypTop.MinigameEngine
{
    public class Background : Entity
    {
        public double? Width
        {
            get => _imageComponent.Width;
            set => _imageComponent.Width = value;
        }
        public double? Height
        {
            get => _imageComponent.Height;
            set => _imageComponent.Height = value;
        }
        public float X
        {
            get => _positionComponent.X;
            set => _positionComponent.X = value;
        }
        public float Y
        {
            get => _positionComponent.Y;
            set => _positionComponent.Y = value;
        }

        private readonly ImageComponent _imageComponent;
        private readonly PositionComponent _positionComponent;

        public Background(string background, Game game) : base(game)
        {
            ZIndex = -1;

            _positionComponent = new PositionComponent() 
            { 
                Position = new System.Numerics.Vector2(0, 0) 
            };
            _imageComponent = new ImageComponent(new BitmapImage(new Uri($@"Images/{background}", UriKind.Relative)))
            {
                Width = Game.Width,
                Height = Game.Height
            };

            AddComponent(_positionComponent);
            AddComponent(_imageComponent);
        }
    }
}
