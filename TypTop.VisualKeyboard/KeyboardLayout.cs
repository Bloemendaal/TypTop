using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using TypTop.VisualKeyboard;

namespace TypTop.VisualKeyboard
{
    public class KeyboardLayout
    {
        public KeyStyle DefaultStyle { get; set; }
        protected const int KeySpacing = 5;
        protected const int KeyWidth = 50;
        protected const int KeyHeight = 50;

        protected readonly HashSet<KeyboardKey> CustomStyledKeys = new HashSet<KeyboardKey>();
        protected readonly Dictionary<Key, KeyboardKey> Keys = new Dictionary<Key, KeyboardKey>();


        private static readonly Lazy<QwertyKeyboardLayout> LazyQwerty = new Lazy<QwertyKeyboardLayout>();
        public static KeyboardLayout Qwerty => LazyQwerty.Value;

        private static readonly Lazy<AzertyKeyboardLayout> LazyAzerty = new Lazy<AzertyKeyboardLayout>();
        public static KeyboardLayout Azerty => LazyAzerty.Value;

        protected void AddNormalKey(Key key, int x, int y)
        {
            if (key < Key.A || key > Key.Z)
            {
                throw new InvalidEnumArgumentException("Only keys A-Z are allowed");
            }
            Keys.Add(key, new NormalKey(key, key.ToString(), new Point(x,y), DefaultStyle));
        }

        public KeyboardLayout()
        {
            DefaultStyle = KeyStyle.Default;
        }

        public void InvalidateKeyStyle()
        {
            foreach (var changedKeyStyle in CustomStyledKeys)
            {
                changedKeyStyle.Style = DefaultStyle;
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