using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BasicGameEngine.GameEngine.Components
{
    public class ImageComponent : Component, IDrawable, IResizable
    {
        private readonly BitmapImage _bitmapImage;
        private TransformComponent _transformComponent;
        
        public double? Width
        {
            get => _width;
            set
            {
                if (value > MaxWidth)
                {
                    value = MaxWidth;
                }

                if (value < 0)
                {
                    value = 0;
                }

                if (value > 100 && Entity.Game.Relative)
                {
                    value = 100;
                }

                _width = value;
            }
        }
        private double? _width;
        public double? Height
        {
            get => _height;
            set
            {
                if (value > MaxHeight)
                {
                    value = MaxHeight;
                }

                if (value < 0)
                {
                    value = 0;
                }

                if (value > 100 && Entity.Game.Relative)
                {
                    value = 100;
                }

                _height = value;
            }
        }
        private double? _height;

        public double? MaxWidth
        {
            get => _maxWidth;
            set
            {
                if (value < Width)
                {
                    value = Width;
                }

                if (value < 0)
                {
                    value = 0;
                }

                if (value > 100 && Entity.Game.Relative)
                {
                    value = 100;
                }

                _maxWidth = value;
            }
        }
        private double? _maxWidth;
        public double? MaxHeight
        {
            get => _maxHeight;
            set
            {
                if (value < Height)
                {
                    value = Height;
                }

                if (value < 0)
                {
                    value = 0;
                }

                if (value > 100 && Entity.Game.Relative)
                {
                    value = 100;
                }

                _maxHeight = value;
            }
        }
        private double? _maxHeight;

        public ImageComponent(BitmapImage bitmapImage)
        {
            _bitmapImage = bitmapImage;
        }

        public double GetWidth()
        {
            if (_bitmapImage != null)
            {
                double width = _bitmapImage.Width;
                if (Width == null)
                {
                    if (MaxWidth != null)
                    {
                        if (Entity.Game.Relative)
                        {
                            double tWidth = (double)MaxWidth * Entity.Game.Width;
                            width = width > tWidth ? tWidth : width;
                        }
                        else
                        {
                            width = width > (double)MaxWidth ? (double)MaxWidth : width;
                        }
                    }
                }
                else
                {
                    width = Entity.Game.Relative ? (double)Width * Entity.Game.Width : (double)Width;
                }

                return width;
            }

            return 0;
        }
        public double GetHeight()
        {
            if (_bitmapImage != null)
            {
                double height = _bitmapImage.Height;
                if (Height == null)
                {
                    if (MaxHeight != null)
                    {
                        if (Entity.Game.Relative)
                        {
                            double tHeight = (double)MaxHeight * Entity.Game.Height;
                            height = height > tHeight ? tHeight : height;
                        }
                        else
                        {
                            height = height > (double)MaxHeight ? (double)MaxHeight : height;
                        }
                    }
                }
                else
                {
                    height = Entity.Game.Relative ? (double)Height * Entity.Game.Height : (double)Height;
                }

                return height;
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
                    new Size(GetWidth(), GetHeight())
                )
            );
        }

        public void Resize()
        {
            if (Entity.Game.Relative)
            {
                _width = Width / Entity.Game.Width;
                _height = Height / Entity.Game.Height;
                _maxWidth = MaxWidth / Entity.Game.Width;
                _maxHeight = MaxHeight / Entity.Game.Height;
            }
            else
            {
                _width = Width / 100 * Entity.Game.Width;
                _height = Height / 100 * Entity.Game.Height;
                _maxWidth = MaxWidth / 100 * Entity.Game.Width;
                _maxHeight = MaxHeight / 100 * Entity.Game.Height;
            }
        }
    }
}