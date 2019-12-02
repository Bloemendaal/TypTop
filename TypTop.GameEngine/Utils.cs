using System.Numerics;
using System.Windows;

namespace TypTop.GameEngine
{
    public static class Utils
    {
        public static Point ToPoint(this Vector2 vector2)
        {
            return new Point(vector2.X, vector2.Y);
        }

        public static Vector2 ToVector2(this Point point)
        {
            return new Vector2((float) point.X, (float) point.Y);
        }
    }
}