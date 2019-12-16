
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
        /// <summary>
        /// Geeft de breedte van de afbeelding, wanneer de waarde NULL wordt geset, wordt de get berekent aan de hand van de afbeelding proporties. De standaardwaarde is de breedte van het scherm.
        /// </summary>
        public double? Width
        {
            get => _imageComponent.Width;
            set => _imageComponent.Width = value;
        }

        /// <summary>
        /// Geeft de hoogte van de afbeelding, wanneer de waarde NULL wordt geset, wordt de get berekent aan de hand van de afbeelding proporties. De standaardwaarde is de hoogte van het scherm.
        /// </summary>
        public double? Height
        {
            get => _imageComponent.Height;
            set => _imageComponent.Height = value;
        }

        /// <summary>
        /// De x-positie van de achtergrond. Standaardwaarde is 0.
        /// </summary>
        public float X
        {
            get => _positionComponent.X;
            set => _positionComponent.X = value;
        }

        /// <summary>
        /// De y-positie van de achtergrond. Standaardwaarde is 0.
        /// </summary>
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
