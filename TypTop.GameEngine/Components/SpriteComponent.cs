using System.Numerics;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BasicGameEngine.GameEngine.Components
{
    class TransformComponent : IUpdateable
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Rect Bounding { get; set; }

        public void Update(float deltaTime)
        {
            // Update position
            Position += Position + Velocity * deltaTime;

            // 
        }
    }

    class ImageComponent : Component, IDrawable
    {
        public ImageComponent(BitmapImage bitmapImage)
        {
            
        }

        public override void AddedToEntity()
        {
            
        }

        public void Draw(DrawingContext context)
        {
            
        }
    }
}