using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BasicGameEngine.GameEngine.Components
{
    public class ImageComponent : Component, IDrawable
    {
        private readonly BitmapImage _bitmapImage;
        private PositionComponent _positionComponent;

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
                new Rect(new Point(_positionComponent.Position.X, _positionComponent.Position.Y), 
                    new Size(_bitmapImage.Width, _bitmapImage.Height))
            );
        }
    }
}