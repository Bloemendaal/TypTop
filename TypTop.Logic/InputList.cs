using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypTop.Logic
{
    class InputList : Input
    {
        public List<Word> Input;
        public InputList(List<Word> input)
        {
            Input = input;
        }


        //
        // Summary:
        //     When the InputMethod is set to list. Only the word with the highest typing progress will be focussed on. Interpeted as false when there is an equal typing progress.
        public bool FocusOnHighIndex = false;


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
            
        }

        

        public override event EventHandler<WordUpdateArgs> WordUpdate;
    }
}
