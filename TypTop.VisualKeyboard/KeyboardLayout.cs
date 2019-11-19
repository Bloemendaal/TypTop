***REMOVED***
***REMOVED***
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using TypTop.VisualKeyboard;

namespace TypTop.VisualKeyboard
***REMOVED***
    public class KeyboardLayout
    ***REMOVED***
        private readonly KeyFactory _keyFactory;
        public KeyStyle Style ***REMOVED*** get; set; ***REMOVED***
        
        protected const int KeySpacing = 5;
        protected const int KeyWidth = 50;
        protected const int KeyHeight = 50;

        protected readonly HashSet<KeyboardKey> CustomStyledKeys = new HashSet<KeyboardKey>();
        protected readonly Dictionary<Key, KeyboardKey> Keys = new Dictionary<Key, KeyboardKey>();


        private static readonly Lazy<QwertyKeyboardLayout> LazyQwerty = new Lazy<QwertyKeyboardLayout>();
        public static KeyboardLayout Qwerty => LazyQwerty.Value;

        private static readonly Lazy<ColemakKeyboardLayout> LazyAzerty = new Lazy<ColemakKeyboardLayout>();
        private readonly RowBox _rowBox;
        public static KeyboardLayout Azerty => LazyAzerty.Value;

        protected void NextRow()
        ***REMOVED***
            _rowBox.NextRow();
    ***REMOVED***
        
        protected void AddKey(Key key)
        ***REMOVED***
            var keyboardKey = _keyFactory.CreateKey(key, Style);
            keyboardKey.Point = _rowBox.GetPosition(keyboardKey.Size);

            Keys.Add(key, keyboardKey);
    ***REMOVED***

        public KeyboardLayout(KeyFactory keyFactory)
        ***REMOVED***
            _keyFactory = keyFactory;
            _rowBox = new RowBox();
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