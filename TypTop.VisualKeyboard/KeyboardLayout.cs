***REMOVED***
***REMOVED***
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using TypTop.VisualKeyboard;

namespace TypTop.VisualKeyboard
***REMOVED***
    public class KeyboardLayout
    ***REMOVED***
        public KeyStyle DefaultStyle ***REMOVED*** get; set; ***REMOVED***
        protected const int KeySpacing = 5;
        protected const int KeyWidth = 50;
        protected const int KeyHeight = 50;

        protected readonly HashSet<KeyboardKey> HighlightedKeys = new HashSet<KeyboardKey>();
        protected readonly Dictionary<Key, KeyboardKey> Keys = new Dictionary<Key, KeyboardKey>();


        private static readonly Lazy<QwertyKeyboardLayout> LazyQwerty = new Lazy<QwertyKeyboardLayout>();
        public static KeyboardLayout Qwerty => LazyQwerty.Value;

        private static readonly Lazy<AzertyKeyboardLayout> LazyAzerty = new Lazy<AzertyKeyboardLayout>();
        public static KeyboardLayout Azerty => LazyAzerty.Value;

        protected void AddNormalKey(Key key, int x, int y)
        ***REMOVED***
            if (key < Key.A || key > Key.Z)
            ***REMOVED***
                throw new InvalidEnumArgumentException("Only keys A-Z are allowed");
        ***REMOVED***
            Keys.Add(key, new NormalKey(key, key.ToString(), new Point(x,y), DefaultStyle));
    ***REMOVED***

        public KeyboardLayout()
        ***REMOVED***
            DefaultStyle = KeyStyle.Default;
    ***REMOVED***

        public void InvalidateKeyStyle()
        ***REMOVED***
            foreach (var changedKeyStyle in HighlightedKeys)
            ***REMOVED***
                changedKeyStyle.Style = DefaultStyle;
        ***REMOVED***
            HighlightedKeys.Clear();
    ***REMOVED***

        public void SetKeyStyle(Key key, KeyStyle keyStyle)
        ***REMOVED***
            Keys[key].Style = keyStyle;
    ***REMOVED***

        public void Render(DrawingContext drawingContext)
        ***REMOVED***
            foreach (KeyboardKey key in Keys.Values)
            ***REMOVED***
                key.Render(drawingContext);
        ***REMOVED***
    ***REMOVED***
***REMOVED***
***REMOVED***