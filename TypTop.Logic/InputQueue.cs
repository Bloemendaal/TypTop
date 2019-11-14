using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypTop.Logic
{
    class InputQueue : Input
    {
        public Queue<Word> Input;
        public InputQueue(Queue<Word> input)
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
        public override event EventHandler<WordUpdateArgs> WordUpdate;
    }
}
