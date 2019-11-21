using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BasicGameEngine.GameEngine.Components
***REMOVED***
    public class ImageComponent : Component, IDrawable
    ***REMOVED***
        private readonly BitmapImage _bitmapImage;
        private TransformComponent _transformComponent;

        public ImageComponent(BitmapImage bitmapImage)
        ***REMOVED***
            _bitmapImage = bitmapImage;
    ***REMOVED***

        public override void AddedToEntity()
        ***REMOVED***
            _transformComponent = Entity.GetComponent<TransformComponent>();
    ***REMOVED***

        public void Draw(DrawingContext context)
        ***REMOVED***
            context.DrawImage(_bitmapImage,
                new Rect(new Point(_transformComponent.Position.X, _transformComponent.Position.Y), 
                    new Size(_bitmapImage.Width, _bitmapImage.Height))
            );
    ***REMOVED***
***REMOVED***
***REMOVED***