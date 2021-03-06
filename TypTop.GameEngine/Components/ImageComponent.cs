﻿using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TypTop.GameEngine.Components
{
    /// <summary>Used to render image on entity</summary>
    /// <seealso cref="TypTop.GameEngine.Component" />
    /// <seealso cref="TypTop.GameEngine.IDrawable" />
    public class ImageComponent : Component, IDrawable
    {
        private BitmapSource _bitmapImage;
        private BitmapImage _bitmapImageOriginal;
        private PositionComponent _positionComponent;


        /// <summary>  Width of the image</summary>
        /// <value>The width.</value>
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

        /// <summary>  Height of the image</summary>
        /// <value>The height.</value>
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


        /// <summary>  Rotation of the image</summary>
        /// <value>The rotation.</value>
        public double Rotation
        {
            get => _rotation;
            set
            {
                double newValue = value %= 360;
                double oldValue = _rotation;

                _rotation = newValue;

                if (newValue != oldValue)
                {
                    RotateImage();
                }
            }
        }
        private double _rotation = 0;

        /// <summary>  Indicating whether the image is hidden.</summary>
        /// <value>
        ///   <c>true</c> if hidden; otherwise, <c>false</c>.</value>
        public bool Hidden { get; set; }

        public ImageComponent(BitmapImage bitmapImage)
        {
            UpdateImage(bitmapImage);
        }

        /// <summary>Updates the image with a new bitmap.</summary>
        /// <param name="bitmapImage">The bitmap image.</param>
        public void UpdateImage(BitmapImage bitmapImage)
        {
            _bitmapImageOriginal = bitmapImage;
            RotateImage();
        }

        public override void AddedToEntity()
        {
            _positionComponent = Entity.GetComponent<PositionComponent>();
        }

        /// <summary>Draws the component.</summary>
        /// <param name="context">The context.</param>
        public void Draw(DrawingContext context)
        {
            if (_positionComponent.Y + Height < 0 ||
            _positionComponent.Y > Game.Height ||
            _positionComponent.X + Width < 0 ||
            _positionComponent.X > Game.Width
            ) return;

            context.DrawImage(
                _bitmapImage,
                new Rect(
                    new Point(_positionComponent.X, _positionComponent.Y),
                    new Size((double)Width, (double)Height)
                )
            );
        }

        private void RotateImage()
        {
            _bitmapImage = Rotation == 0 ? _bitmapImageOriginal : ComposeImage(_bitmapImageOriginal, Rotation);
        }

        private static BitmapSource ComposeImage(BitmapSource image, double rotationAngle)
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
