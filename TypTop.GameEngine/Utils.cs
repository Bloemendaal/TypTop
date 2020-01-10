using System;
using System.Numerics;
using System.Windows;

namespace TypTop.GameEngine
{
    public static class Utils
    {
        /// <summary>Converts to point.</summary>
        /// <param name="vector2">The vector2.</param>
        /// <returns></returns>
        public static Point ToPoint(this Vector2 vector2)
        {
            return new Point(vector2.X, vector2.Y);
        }

        /// <summary>Converts to vector2.</summary>
        /// <param name="point">The point.</param>
        /// <returns></returns>
        public static Vector2 ToVector2(this Point point)
        {
            return new Vector2((float) point.X, (float) point.Y);
        }

        /// <summary>Gets aligned rectangle.</summary>
        /// <param name="index">The index.</param>
        /// <param name="total">The total.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="spacing">The spacing.</param>
        /// <param name="columnWidth">Width of the column.</param>
        /// <param name="columnHeight">Height of the column.</param>
        /// <returns></returns>
        public static Rect GetRectangle(int index, int total, int columns, float spacing, float columnWidth, float columnHeight)
        {
            columns = Math.Min(columns, total);

            float totalWidth = 1920f;
            float totalHeight = 1080f;

            int totalRows = (int)(total / (float)columns + 0.5f);
            int currentRowIndex = index / columns;
            int currentColumnIndex = index % columns;

            int totalColumnSpacerCount = columns - 1;
            int totalRowSpacerCount = totalRows - 1;

            float horizontalColumnOffset =
                (totalWidth - (columnWidth * columns + totalColumnSpacerCount * spacing)) / 2f;

            float verticalColumnOffset =
                (totalHeight - (columnHeight * totalRows + totalRowSpacerCount * spacing)) / 2f;

            float x = horizontalColumnOffset + (columnWidth * currentColumnIndex + spacing * currentColumnIndex);
            float y = verticalColumnOffset + (columnHeight * currentRowIndex + spacing * currentRowIndex);

            return new Rect(new Point(x, y), new Size(columnWidth, columnHeight));
        }
    }
}