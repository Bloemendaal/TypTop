using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BasicGameEngine.GameEngine.Components
***REMOVED***
    public class ImageComponent : Component, IDrawable
    ***REMOVED***
        private readonly BitmapImage _bitmapImage;
        private TransformComponent _transformComponent;
        
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

                        return _bitmapImage.Width * _bitmapImage.Height / (double)_height;
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

                        return _bitmapImage.Height * _bitmapImage.Width / (double)_width;
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

        public double GetHeight()
        ***REMOVED***
            if (_bitmapImage != null)
            ***REMOVED***
                if (Height == null)
                ***REMOVED***
                    if (Width == null)
                    ***REMOVED***
                        return _bitmapImage.Height;
                ***REMOVED***

                    return _bitmapImage.Height * _bitmapImage.Width / (double)Width;
            ***REMOVED***

                return (double)Width;
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
                    new Size((double)Width, (double)Height)
                )
            );
    ***REMOVED***
***REMOVED***
***REMOVED***