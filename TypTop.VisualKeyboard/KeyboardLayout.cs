using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using TypTop.VisualKeyboard;

namespace TypTop.VisualKeyboard
{
    public class KeyFactory
    {
        public KeyboardKey CreateKey(Key key, Point point, KeyStyle style)
        {
            if (key >= Key.A && key <= Key.Z)
            {
                return CreateSingleLetterKey(key,new Rect(point, new Size(50,50)), style);
            }

            if (key == Key.Space)
            {
                return new BlankKey(Key.Space, new Rect(point, new Size(300,50)), style);
            }

            throw new InvalidEnumArgumentException();
        }

        private KeyboardKey CreateTextKey(Key key, string text ,Rect rect, KeyStyle style)
        {
            var textPrintDrawer = new TextPrintDrawer(text, style);
            var keyboardKey = new PrintedKey(key, rect, style, textPrintDrawer);
            keyboardKey.StyleChanged += (o, e) => { textPrintDrawer.Style = e.KeyStyle; };
            return keyboardKey;
        }

        private KeyboardKey CreateSingleLetterKey(Key key,Rect rect, KeyStyle style)
        {
            return CreateTextKey(key,key.ToString(), rect,style);
        }
    }

    public class KeyboardLayout
    {
        public KeyStyle Style { get; set; }

        protected const int KeySpacing = 5;
        protected const int KeyWidth = 50;
        protected const int KeyHeight = 50;

        protected readonly HashSet<KeyboardKey> CustomStyledKeys = new HashSet<KeyboardKey>();
        protected readonly Dictionary<Key, KeyboardKey> Keys = new Dictionary<Key, KeyboardKey>();

        private readonly KeyFactory _keyFactory = new KeyFactory();

        private static readonly Lazy<QwertyKeyboardLayout> LazyQwerty = new Lazy<QwertyKeyboardLayout>();
        public static KeyboardLayout Qwerty => LazyQwerty.Value;

        private static readonly Lazy<AzertyKeyboardLayout> LazyAzerty = new Lazy<AzertyKeyboardLayout>();
        public static KeyboardLayout Azerty => LazyAzerty.Value;

        protected void AddKey(Key key, int x, int y)
        {
            Keys.Add(key, _keyFactory.CreateKey(key, new Point(x,y), Style));
        }

        public KeyboardLayout()
        {
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