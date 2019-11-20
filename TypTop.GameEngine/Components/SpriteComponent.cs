using System.Numerics;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BasicGameEngine.GameEngine.Components
***REMOVED***
    class TransformComponent : IUpdateable
    ***REMOVED***
        public Vector2 Position ***REMOVED*** get; set; ***REMOVED***
        public Vector2 Velocity ***REMOVED*** get; set; ***REMOVED***
        public Rect Bounding ***REMOVED*** get; set; ***REMOVED***

        public void Update(float deltaTime)
        ***REMOVED***
            // Update position
            Position += Position + Velocity * deltaTime;

            // 
    ***REMOVED***
***REMOVED***

    class ImageComponent : Component, IDrawable
    ***REMOVED***
        public ImageComponent(BitmapImage bitmapImage)
        ***REMOVED***
            
    ***REMOVED***

        public override void AddedToEntity()
        ***REMOVED***
            
    ***REMOVED***

        public void Draw(DrawingContext context)
        ***REMOVED***
            
    ***REMOVED***
***REMOVED***
***REMOVED***