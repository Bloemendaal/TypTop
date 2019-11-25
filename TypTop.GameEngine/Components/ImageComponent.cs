using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BasicGameEngine.GameEngine.Components
***REMOVED***
    public class ImageComponent : Component, IDrawable
    ***REMOVED***
        private readonly BitmapImage _bitmapImage;
        private PositionComponent _positionComponent;

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
                new Rect(new Point(_positionComponent.Position.X, _positionComponent.Position.Y), 
                    new Size(_bitmapImage.Width, _bitmapImage.Height))
            );
    ***REMOVED***
***REMOVED***
***REMOVED***