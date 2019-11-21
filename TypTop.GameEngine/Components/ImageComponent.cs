using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BasicGameEngine.GameEngine.Components
{
    public class ImageComponent : Component, IDrawable
    {
        private readonly BitmapImage _bitmapImage;
        private TransformComponent _transformComponent;

        public ImageComponent(BitmapImage bitmapImage)
        {
            _bitmapImage = bitmapImage;
        }

        public override void AddedToEntity()
        {
            _transformComponent = Entity.GetComponent<TransformComponent>();
        }

        public void Draw(DrawingContext context)
        {
            context.DrawImage(_bitmapImage,
                new Rect(new Point(_transformComponent.Position.X, _transformComponent.Position.Y), 
                    new Size(_bitmapImage.Width, _bitmapImage.Height))
            );
        }
    }
}