***REMOVED***
***REMOVED***
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using TypTop.VisualKeyboard;

namespace TypTop.VisualKeyboard
***REMOVED***
    public class KeyFactory
    ***REMOVED***
        public KeyboardKey CreateKey(Key key, Point point, KeyStyle style)
        ***REMOVED***
            if (key >= Key.A && key <= Key.Z)
            ***REMOVED***
                return CreateSingleLetterKey(key,new Rect(point, new Size(50,50)), style);
        ***REMOVED***

            if (key == Key.Space)
            ***REMOVED***
                return new BlankKey(Key.Space, new Rect(point, new Size(300,50)), style);
        ***REMOVED***

            throw new InvalidEnumArgumentException();
    ***REMOVED***

        private KeyboardKey CreateTextKey(Key key, string text ,Rect rect, KeyStyle style)
        ***REMOVED***
            var textPrintDrawer = new TextPrintDrawer(text, style);
            var keyboardKey = new PrintedKey(key, rect, style, textPrintDrawer);
            keyboardKey.StyleChanged += (o, e) => ***REMOVED*** textPrintDrawer.Style = e.KeyStyle; ***REMOVED***;
            return keyboardKey;
    ***REMOVED***

        private KeyboardKey CreateSingleLetterKey(Key key,Rect rect, KeyStyle style)
        ***REMOVED***
            return CreateTextKey(key,key.ToString(), rect,style);
    ***REMOVED***
***REMOVED***

    public class KeyboardLayout
    ***REMOVED***
        public KeyStyle Style ***REMOVED*** get; set; ***REMOVED***

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
        ***REMOVED***
            Keys.Add(key, _keyFactory.CreateKey(key, new Point(x,y), Style));
    ***REMOVED***

        public KeyboardLayout()
        ***REMOVED***
            Style = KeyStyle.Default;
    ***REMOVED***

        public void InvalidateKeyStyle()
        ***REMOVED***
            foreach (var changedKeyStyle in CustomStyledKeys)
            ***REMOVED***
                changedKeyStyle.Style = Style;
        ***REMOVED***
            CustomStyledKeys.Clear();
    ***REMOVED***

        public void SetKeyStyle(Key key, KeyStyle keyStyle)
        ***REMOVED***
            var keyboardKey = Keys[key];
            keyboardKey.Style = keyStyle;
            CustomStyledKeys.Add(keyboardKey);
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