using System;
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

        public static Rect GetRectangle(int index, int total, int columns, float spacing, float columnWidth,
            float columnHeight)
        {
            columns = Math.Min(columns, total);

            var totalWidth = 1920f;
            var totalHeight = 1080f;

            var totalRows = (int) (total / (float) columns + 0.5f);
            var currentRowIndex = index / columns;
            var currentColumnIndex = index % columns;

            var totalColumnSpacerCount = columns - 1;
            var totalRowSpacerCount = totalRows - 1;

            var horizontalColumnOffset =
                (totalWidth - (columnWidth * columns + totalColumnSpacerCount * spacing)) / 2f;

            var verticalColumnOffset =
                (totalHeight - (columnHeight * totalRows + totalRowSpacerCount * spacing)) / 2f;

            var x = horizontalColumnOffset + (columnWidth * currentColumnIndex + spacing * currentColumnIndex);
            var y = verticalColumnOffset + (columnHeight * currentRowIndex + spacing * currentRowIndex);

            return new Rect(new Point(x, y), new Size(columnWidth, columnHeight));
        }
    }
}