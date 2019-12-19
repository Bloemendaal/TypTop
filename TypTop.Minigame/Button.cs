using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using TypTop.GameEngine;
using TypTop.GameEngine.Components;

namespace TypTop.MinigameEngine
{
    public class Button : Entity
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
        private readonly ClickComponent _clickComponent;
        private HoverComponent _hoverComponent;
        private BitmapImage defaultImage;
        private BitmapImage hoverImage;

        public event EventHandler Clicked;

        public object Data { get; set; }

        public Button(Rect bounds, Game game, string background, string hoverBackground = null) : base(game)
        {
            ZIndex = -1;
            _positionComponent = new PositionComponent()
            {
                Position = bounds.Location.ToVector2()
            };
            defaultImage = new BitmapImage(new Uri($@"Images/{background}", UriKind.Relative));
            if(hoverBackground != null)
                hoverImage = new BitmapImage(new Uri($@"Images/{hoverBackground}", UriKind.Relative));
            _imageComponent = new ImageComponent(defaultImage)
            {
                Width = bounds.Width,
                Height = bounds.Height
            };
            
            _clickComponent = new ClickComponent(bounds);
            _clickComponent.Clicked += ClickComponentOnClicked;

            if (hoverBackground != null)
            {
                _hoverComponent = new HoverComponent(bounds);
                _hoverComponent.Hover += HoverComponentOnHover;
                AddComponent(_hoverComponent);
            }

            AddComponent(_clickComponent);
            AddComponent(_positionComponent);
            AddComponent(_imageComponent);
        }

        private void HoverComponentOnHover(object? sender, HoverState e)
        {
            if (e == HoverState.Enter)
            {
                _imageComponent.UpdateImage(hoverImage);
            }
            else
            {
                _imageComponent.UpdateImage(defaultImage);
            }
        }

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