using System.Windows.Input;

namespace TypTop.VisualKeyboard
{
    public class ColemakKeyboardLayout : KeyboardLayout
    {
        public ColemakKeyboardLayout() :base(new KeyFactory())
        {
            AddKey(Key.OemTilde);

            AddKey(Key.D1);
            AddKey(Key.D2);
            AddKey(Key.D3);
            AddKey(Key.D4);
            AddKey(Key.D5);
            AddKey(Key.D6);
            AddKey(Key.D7);
            AddKey(Key.D8);
            AddKey(Key.D9);
            AddKey(Key.D0);

            AddKey(Key.OemMinus);
            AddKey(Key.OemPlus);

            AddKey(Key.Back);


            NextRow();

            AddKey(Key.Tab);

            AddKey(Key.Q);
            AddKey(Key.W);
            AddKey(Key.F);
            AddKey(Key.P);
            AddKey(Key.G);
            AddKey(Key.J);
            AddKey(Key.L);
            AddKey(Key.U);
            AddKey(Key.Y);
            AddKey(Key.OemSemicolon);

            AddKey(Key.OemOpenBrackets);
            AddKey(Key.OemCloseBrackets);
            AddKey(Key.OemPipe);

            NextRow();

            AddKey(Key.CapsLock);

            AddKey(Key.A);
            AddKey(Key.R);
            AddKey(Key.S);
            AddKey(Key.T);
            AddKey(Key.D);
            AddKey(Key.H);
            AddKey(Key.N);
            AddKey(Key.E);
            AddKey(Key.I);
            AddKey(Key.O);

            AddKey(Key.OemQuotes);
            AddKey(Key.Enter);

            NextRow();

            AddKey(Key.LeftShift);

            AddKey(Key.Z);
            AddKey(Key.X);
            AddKey(Key.C);
            AddKey(Key.V);
            AddKey(Key.B);
            AddKey(Key.K);
            AddKey(Key.M);

            AddKey(Key.OemComma);
            AddKey(Key.OemPeriod);
            AddKey(Key.OemQuestion);

            AddKey(Key.RightShift);
        }
    }
}