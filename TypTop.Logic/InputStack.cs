using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypTop.Logic
{
    class InputStack : Input
    {
        public Stack<Word> Input;
        public InputStack(Stack<Word> input)
        {
            Input = input;
        }


        public override void TextInput(char letter)
        {
            WordUpdate?.Invoke(this, new WordUpdateArgs()
            {
                Words = new List<Word>(),
                PreviousChar = PreviousChar,
                CurrentChar = letter
            });

            base.TextInput(letter);
        }

        public override void Backspace()
        {
            throw new NotImplementedException();
        }

        public override event EventHandler<WordUpdateArgs> WordUpdate;
    }
}
