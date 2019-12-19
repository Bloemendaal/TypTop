using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using TypTop.VisualKeyboard;

namespace TypTop.VisualKeyboard
{
    public class KeyboardLayout
    {
        private readonly KeyFactory _keyFactory;
        private readonly Vector2 _position;
        public KeyStyle Style { get; set; }
        
        protected const int KeySpacing = 5;
        protected const int KeyWidth = 50;
        protected const int KeyHeight = 50;

        protected readonly HashSet<KeyboardKey> CustomStyledKeys = new HashSet<KeyboardKey>();
        protected readonly Dictionary<Key, KeyboardKey> Keys = new Dictionary<Key, KeyboardKey>();

        private static readonly Lazy<QwertyKeyboardLayout> LazyQwerty = new Lazy<QwertyKeyboardLayout>();
    

        //private static readonly Lazy<ColemakKeyboardLayout> LazyAzerty = new Lazy<ColemakKeyboardLayout>();
        private readonly RowBox _rowBox;
        //public static KeyboardLayout Azerty => LazyAzerty.Value;

        protected void NextRow()
        {
            _rowBox.NextRow();
        }
        
        protected void AddKey(Key key)
        {
            var keyboardKey = _keyFactory.CreateKey(key, Style);
            Point keyboardKeyPoint = _rowBox.GetPosition(keyboardKey.Size);
            keyboardKeyPoint.Y += _position.Y;
            keyboardKeyPoint.X += _position.X;
            keyboardKey.Point = keyboardKeyPoint;

            Keys.Add(key, keyboardKey);
        }

        public KeyboardLayout(KeyFactory keyFactory, Vector2 position)
        {
            _keyFactory = keyFactory;
            _position = position;
            _rowBox = new RowBox();
            Style = KeyStyle.Default;
        }

        public void InvalidateKeyStyle()
        {
            foreach (var changedKeyStyle in CustomStyledKeys)
            {
                changedKeyStyle.Style = Style;
            }
            CustomStyledKeys.Clear();
        }

        public void SetKeyStyle(Key key, KeyStyle keyStyle)
        {
            var keyboardKey = Keys[key];
            keyboardKey.Style = keyStyle;
            CustomStyledKeys.Add(keyboardKey);
        }

        public void Render(DrawingContext drawingContext)
        {
            foreach (KeyboardKey key in Keys.Values)
            {
                key.Render(drawingContext);
            }
        }
    }
}