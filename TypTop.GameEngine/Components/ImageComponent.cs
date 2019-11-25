﻿using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BasicGameEngine.GameEngine.Components
***REMOVED***
    public class ImageComponent : Component, IDrawable
    ***REMOVED***
        private readonly BitmapImage _bitmapImage;
        private PositionComponent _positionComponent;

        public double? Width
        ***REMOVED***
            get ***REMOVED***
                if (_bitmapImage != null)
                ***REMOVED***
                    if (_width == null)
                    ***REMOVED***
                        if (_height == null)
                        ***REMOVED***
                            return _bitmapImage.Width;
                    ***REMOVED***

                        return _bitmapImage.Width * (double)_height / _bitmapImage.Height;
                ***REMOVED***

                    return (double)_width;
            ***REMOVED***

                return null;
        ***REMOVED***
            set
            ***REMOVED***
                if (value != null && value < 0)
                ***REMOVED***
                    value = 0;
            ***REMOVED***

                _width = value;
        ***REMOVED***
    ***REMOVED***
        private double? _width;
        public double? Height
        ***REMOVED***
            get
            ***REMOVED***
                if (_bitmapImage != null)
                ***REMOVED***
                    if (_height == null)
                    ***REMOVED***
                        if (_width == null)
                        ***REMOVED***
                            return _bitmapImage.Height;
                    ***REMOVED***

                        return _bitmapImage.Height * (double)_width / _bitmapImage.Width;
                ***REMOVED***

                    return (double)_height;
            ***REMOVED***

                return null;
        ***REMOVED***
            set
            ***REMOVED***
                if (value != null && value < 0)
                ***REMOVED***
                    value = 0;
            ***REMOVED***

                _height = value;
        ***REMOVED***
    ***REMOVED***
        private double? _height;

        public ImageComponent(BitmapImage bitmapImage)
        ***REMOVED***
            _bitmapImage = bitmapImage;
    ***REMOVED***

        public override void AddedToEntity()
        ***REMOVED***
            _positionComponent = Entity.GetComponent<PositionComponent>();
    ***REMOVED***

        public void Draw(DrawingContext context)
        ***REMOVED***
            context.DrawImage(_bitmapImage,
                new Rect(
                    new Point(_positionComponent.Position.X, _positionComponent.Position.Y),
                    new Size((double)Width, (double)Height)
                )
            );
    ***REMOVED***
***REMOVED***
***REMOVED***
