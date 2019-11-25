using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BasicGameEngine.GameEngine.Components
{
    public class ImageComponent : Component, IDrawable
    {
        private readonly BitmapImage _bitmapImage;
        private TransformComponent _transformComponent;
        
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

                        return _bitmapImage.Width * _bitmapImage.Height / (double)_height;
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

                        return _bitmapImage.Height * _bitmapImage.Width / (double)_width;
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

        public ImageComponent(BitmapImage bitmapImage)
        {
            _bitmapImage = bitmapImage;
        }

        public double GetHeight()
        {
            if (_bitmapImage != null)
            {
                if (Height == null)
                {
                    if (Width == null)
                    {
                        return _bitmapImage.Height;
                    }

                    return _bitmapImage.Height * _bitmapImage.Width / (double)Width;
                }

                return (double)Width;
            }

            return 0;
        }

        public override void AddedToEntity()
        {
            _transformComponent = Entity.GetComponent<TransformComponent>();
        }

        public void Draw(DrawingContext context)
        {
            context.DrawImage(_bitmapImage,
                new Rect(
                    new Point(_transformComponent.Position.X, _transformComponent.Position.Y), 
                    new Size((double)Width, (double)Height)
                )
            );
        }
    }
}