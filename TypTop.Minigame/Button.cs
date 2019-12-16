using System;
using System.Windows;
using System.Windows.Media.Imaging;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;

namespace TypTop.MinigameEngine
{
    public class Button : Entity
    {
        private readonly ClickComponent _clickComponent;

        private readonly ImageComponent _imageComponent;
        private readonly PositionComponent _positionComponent;

        public Button(string background, Rect bounds, Game game) : base(game)
        {
            ZIndex = -1;

            _positionComponent = new PositionComponent
            {
                Position = bounds.Location.ToVector2()
            };
            _imageComponent = new ImageComponent(new BitmapImage(new Uri($@"Images/{background}", UriKind.Relative)))
            {
                Width = bounds.Width,
                Height = bounds.Height
            };

            _clickComponent = new ClickComponent(bounds);
            _clickComponent.Clicked += ClickComponentOnClicked;
            AddComponent(_clickComponent);
            AddComponent(_positionComponent);
            AddComponent(_imageComponent);
        }

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

        public object Data { get; set; }

        public event EventHandler Clicked;

        private void ClickComponentOnClicked(object sender, EventArgs e)
        {
            OnClicked();
        }

        protected virtual void OnClicked()
        {
            Clicked?.Invoke(this, EventArgs.Empty);
        }
    }
}