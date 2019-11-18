using System.Windows.Input;

namespace TypTop.VisualKeyboard
{
    public class AzertyKeyboardLayout : KeyboardLayout
    {
        public AzertyKeyboardLayout() :base(new KeyFactory())
        {
            AddKey(Key.A);
            AddKey(Key.Z);
            AddKey(Key.E);
            AddKey(Key.R);
            AddKey(Key.T);
            AddKey(Key.Y);
            AddKey(Key.U);
            AddKey(Key.I);
            AddKey(Key.O);
            AddKey(Key.P);

            NextRow();

            AddKey(Key.Q);
            AddKey(Key.S);
            AddKey(Key.D);
            AddKey(Key.F);
            AddKey(Key.G);
            AddKey(Key.H);
            AddKey(Key.J);
            AddKey(Key.K);
            AddKey(Key.L);
            AddKey(Key.M);

            NextRow();

            AddKey(Key.W);
            AddKey(Key.X);
            AddKey(Key.C);
            AddKey(Key.V);
            AddKey(Key.B);
            AddKey(Key.N);
        }
    }
}