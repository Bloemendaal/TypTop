using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BasicGameEngine.GameEngine.Components
***REMOVED***
    public class ImageComponent : Component, IDrawable, IResizable
    ***REMOVED***
        private readonly BitmapImage _bitmapImage;
        private TransformComponent _transformComponent;
        
        public double? Width
        ***REMOVED***
            get => _width;
            set
            ***REMOVED***
                if (value > MaxWidth)
                ***REMOVED***
                    value = MaxWidth;
            ***REMOVED***

                if (value < 0)
                ***REMOVED***
                    value = 0;
            ***REMOVED***

                if (value > 100 && Entity.Game.Relative)
                ***REMOVED***
                    value = 100;
            ***REMOVED***

                _width = value;
        ***REMOVED***
    ***REMOVED***
        private double? _width;
        public double? Height
        ***REMOVED***
            get => _height;
            set
            ***REMOVED***
                if (value > MaxHeight)
                ***REMOVED***
                    value = MaxHeight;
            ***REMOVED***

                if (value < 0)
                ***REMOVED***
                    value = 0;
            ***REMOVED***

                if (value > 100 && Entity.Game.Relative)
                ***REMOVED***
                    value = 100;
            ***REMOVED***

                _height = value;
        ***REMOVED***
    ***REMOVED***
        private double? _height;

        public double? MaxWidth
        ***REMOVED***
            get => _maxWidth;
            set
            ***REMOVED***
                if (value < Width)
                ***REMOVED***
                    value = Width;
            ***REMOVED***

                if (value < 0)
                ***REMOVED***
                    value = 0;
            ***REMOVED***

                if (value > 100 && Entity.Game.Relative)
                ***REMOVED***
                    value = 100;
            ***REMOVED***

                _maxWidth = value;
        ***REMOVED***
    ***REMOVED***
        private double? _maxWidth;
        public double? MaxHeight
        ***REMOVED***
            get => _maxHeight;
            set
            ***REMOVED***
                if (value < Height)
                ***REMOVED***
                    value = Height;
            ***REMOVED***

                if (value < 0)
                ***REMOVED***
                    value = 0;
            ***REMOVED***

                if (value > 100 && Entity.Game.Relative)
                ***REMOVED***
                    value = 100;
            ***REMOVED***

                _maxHeight = value;
        ***REMOVED***
    ***REMOVED***
        private double? _maxHeight;

        public ImageComponent(BitmapImage bitmapImage)
        ***REMOVED***
            _bitmapImage = bitmapImage;
    ***REMOVED***

        public double GetWidth()
        ***REMOVED***
            if (_bitmapImage != null)
            ***REMOVED***
                double width = _bitmapImage.Width;
                if (Width == null)
                ***REMOVED***
                    if (MaxWidth != null)
                    ***REMOVED***
                        if (Entity.Game.Relative)
                        ***REMOVED***
                            double tWidth = (double)MaxWidth * Entity.Game.Width;
                            width = width > tWidth ? tWidth : width;
                    ***REMOVED***
                        else
                        ***REMOVED***
                            width = width > (double)MaxWidth ? (double)MaxWidth : width;
                    ***REMOVED***
                ***REMOVED***
            ***REMOVED***
                else
                ***REMOVED***
                    width = Entity.Game.Relative ? (double)Width * Entity.Game.Width : (double)Width;
            ***REMOVED***

                return width;
        ***REMOVED***

            return 0;
    ***REMOVED***
        public double GetHeight()
        ***REMOVED***
            if (_bitmapImage != null)
            ***REMOVED***
                double height = _bitmapImage.Height;
                if (Height == null)
                ***REMOVED***
                    if (MaxHeight != null)
                    ***REMOVED***
                        if (Entity.Game.Relative)
                        ***REMOVED***
                            double tHeight = (double)MaxHeight * Entity.Game.Height;
                            height = height > tHeight ? tHeight : height;
                    ***REMOVED***
                        else
                        ***REMOVED***
                            height = height > (double)MaxHeight ? (double)MaxHeight : height;
                    ***REMOVED***
                ***REMOVED***
            ***REMOVED***
                else
                ***REMOVED***
                    height = Entity.Game.Relative ? (double)Height * Entity.Game.Height : (double)Height;
            ***REMOVED***

                return height;
        ***REMOVED***

            return 0;
    ***REMOVED***

        public override void AddedToEntity()
        ***REMOVED***
            _transformComponent = Entity.GetComponent<TransformComponent>();
    ***REMOVED***

        public void Draw(DrawingContext context)
        ***REMOVED***
            context.DrawImage(_bitmapImage,
                new Rect(
                    new Point(_transformComponent.Position.X, _transformComponent.Position.Y), 
                    new Size(GetWidth(), GetHeight())
                )
            );
    ***REMOVED***

        public void Resize()
        ***REMOVED***
            if (Entity.Game.Relative)
            ***REMOVED***
                _width = Width / Entity.Game.Width;
                _height = Height / Entity.Game.Height;
                _maxWidth = MaxWidth / Entity.Game.Width;
                _maxHeight = MaxHeight / Entity.Game.Height;
        ***REMOVED***
            else
            ***REMOVED***
                _width = Width / 100 * Entity.Game.Width;
                _height = Height / 100 * Entity.Game.Height;
                _maxWidth = MaxWidth / 100 * Entity.Game.Width;
                _maxHeight = MaxHeight / 100 * Entity.Game.Height;
        ***REMOVED***
    ***REMOVED***
***REMOVED***
***REMOVED***