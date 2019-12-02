using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TypTop.GameEngine.Components
{
    public class ImageComponent : Component, IDrawable
    {
        private readonly BitmapImage _bitmapImage;
        private PositionComponent _positionComponent;

        public double? Width
        {
            get {
                if (_bitmapImage != null)
                {
                    if (_width == null)
                    {
                        if (_height == null)
                        {
                            return _bitmapImage.Width;
                        }

                        return _bitmapImage.Width * (double)_height / _bitmapImage.Height;
                    }

                    return (double)_width;
                }

                return null;
            }
            set
            {
                if (value != null && value < 0)
                {
                    value = 0;
                }

                _width = value;
            }
        }
        private double? _width;
        public double? Height
        {
            get
            {
                if (_bitmapImage != null)
                {
                    if (_height == null)
                    {
                        if (_width == null)
                        {
                            return _bitmapImage.Height;
                        }

                        return _bitmapImage.Height * (double)_width / _bitmapImage.Width;
                    }

                    return (double)_height;
                }

                return null;
            }
            set
            {
                if (value != null && value < 0)
                {
                    value = 0;
                }

                _height = value;
            }
        }
        private double? _height;

        public bool Hidden { get; set; }

        public ImageComponent(BitmapImage bitmapImage)
        {
            _bitmapImage = bitmapImage;
        }

        public override void AddedToEntity()
        {
            _positionComponent = Entity.GetComponent<PositionComponent>();
        }

        public void Draw(DrawingContext context)
        {
            context.DrawImage(_bitmapImage,
                new Rect(
                    new Point(_positionComponent.Position.X, _positionComponent.Position.Y),
                    new Size((double)Width, (double)Height)
                )
            );
        }
    }
}
