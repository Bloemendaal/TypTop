using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TypTop.GameEngine.Components
{
    public class ImageComponent : Component, IDrawable
    {
        private BitmapImage _bitmapImage;
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

        public double Rotation
        {
            get => _rotation;
            set
            {
                _rotation = value % 360;
            }
        }
        private double _rotation = 0;

        public bool Hidden { get; set; }

        public ImageComponent(BitmapImage bitmapImage)
        {
            _bitmapImage = bitmapImage;
        }

        public void UpdateImage(BitmapImage bitmapImage)
        {
            _bitmapImage = bitmapImage;
        }

        public override void AddedToEntity()
        {
            _positionComponent = Entity.GetComponent<PositionComponent>();
        }

        public void Draw(DrawingContext context)
        {
            context.DrawImage(
                Rotation == 0 ? _bitmapImage : ComposeImage(_bitmapImage, Rotation),
                new Rect(
                    new Point(_positionComponent.Position.X, _positionComponent.Position.Y),
                    new Size((double)Width, (double)Height)
                )
            );
        }

        private BitmapSource ComposeImage(BitmapSource image, double rotationAngle)
        {
            RotateTransform rotation = new RotateTransform(rotationAngle);
            Size size = new Size(image.PixelWidth, image.PixelHeight);
            Vector center2 = new Vector(size.Width / 2, size.Height / 2);
            Size rotatedSize = rotation.TransformBounds(new Rect(size)).Size;
            Size totalSize = new Size(
                Math.Max(size.Width, rotatedSize.Width),
                Math.Max(size.Height, rotatedSize.Height)
            );
            Point center = new Point(totalSize.Width / 2, totalSize.Height / 2);

            rotation.CenterX = center.X;
            rotation.CenterY = center.Y;

            DrawingVisual dv = new DrawingVisual();

            using (DrawingContext dc = dv.RenderOpen())
            {
                dc.PushTransform(rotation);
                dc.DrawImage(image, new Rect(center - center2, size));
            }

            RenderTargetBitmap rtb = new RenderTargetBitmap((int)totalSize.Width, (int)totalSize.Height, 96, 96, PixelFormats.Default);
            rtb.Render(dv);

            return rtb;
        }
    }
}
