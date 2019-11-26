using System.Numerics;
using System.Windows;

namespace BasicGameEngine
***REMOVED***
    public static class Utils
    ***REMOVED***
        public static Point ToPoint(this Vector2 vector2)
        ***REMOVED***
            return new Point(vector2.X, vector2.Y);
    ***REMOVED***

        public static Vector2 ToVector2(this Point point)
        ***REMOVED***
            return new Vector2((float) point.X, (float) point.Y);
    ***REMOVED***
***REMOVED***
***REMOVED***