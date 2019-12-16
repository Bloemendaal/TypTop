using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TypTop.GameEngine.Components
{
    public class ImageComponent : Component, IDrawable
    {
        private BitmapSource _bitmapImage;
        private BitmapImage _bitmapImageOriginal;
        private double? _height;
        private PositionComponent _positionComponent;
        private double _rotation;
        private double? _width;

        public ImageComponent(BitmapImage bitmapImage)
        {
            UpdateImage(bitmapImage);
        }

        public double? Width
        {
            get
            {
                if (_bitmapImage != null)
                {
                    if (_width == null)
                    {
                        if (_height == null) return _bitmapImage.Width;

                        return _bitmapImage.Width * (double) _height / _bitmapImage.Height;
                    }

                    return (double) _width;
                }

                return null;
            }
            set
            {
                if (value != null && value < 0) value = 0;

                _width = value;
            }
        }

        public double? Height
        {
            get
            {
                if (_bitmapImage != null)
                {
                    if (_height == null)
                    {
                        if (_width == null) return _bitmapImage.Height;

                        return _bitmapImage.Height * (double) _width / _bitmapImage.Width;
                    }

                    return (double) _height;
                }

                return null;
            }
            set
            {
                if (value != null && value < 0) value = 0;

                _height = value;
            }
        }

        public double Rotation
        {
            get => _rotation;
            set
            {
                var newValue = value %= 360;
                var oldValue = _rotation;

                _rotation = newValue;

                if (newValue != oldValue) RotateImage();
            }
        }

        public bool Hidden { get; set; }

        public void Draw(DrawingContext context)
        {
            context.DrawImage(
                _bitmapImage,
                new Rect(
                    new Point(_positionComponent.Position.X, _positionComponent.Position.Y),
                    new Size((double) Width, (double) Height)
                )
            );
        }

        public void UpdateImage(BitmapImage bitmapImage)
        {
            _bitmapImageOriginal = bitmapImage;
            RotateImage();
        }

        public override void AddedToEntity()
        {
            _positionComponent = Entity.GetComponent<PositionComponent>();
        }

        private void RotateImage()
        {
            _bitmapImage = Rotation == 0 ? _bitmapImageOriginal : ComposeImage(_bitmapImageOriginal, Rotation);
        }

        private static BitmapSource ComposeImage(BitmapSource image, double rotationAngle)
        {
            var rotation = new RotateTransform(rotationAngle);
            var size = new Size(image.PixelWidth, image.PixelHeight);
            var center2 = new Vector(size.Width / 2, size.Height / 2);
            Size rotatedSize = rotation.TransformBounds(new Rect(size)).Size;
            var totalSize = new Size(
                Math.Max(size.Width, rotatedSize.Width),
                Math.Max(size.Height, rotatedSize.Height)
            );
            var center = new Point(totalSize.Width / 2, totalSize.Height / 2);

            rotation.CenterX = center.X;
            rotation.CenterY = center.Y;

            var dv = new DrawingVisual();

            using (DrawingContext dc = dv.RenderOpen())
            {
                dc.PushTransform(rotation);
                dc.DrawImage(image, new Rect(center - center2, size));
            }

            var rtb = new RenderTargetBitmap((int) totalSize.Width, (int) totalSize.Height, 96, 96,
                PixelFormats.Default);
            rtb.Render(dv);

            return rtb;
        }
    }
}