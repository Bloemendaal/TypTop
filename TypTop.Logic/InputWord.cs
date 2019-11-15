***REMOVED***
***REMOVED***
using System.Linq;
***REMOVED***
using System.Threading.Tasks;

namespace TypTop.Logic
***REMOVED***
    class InputWord : Input
    ***REMOVED***
        public Word Input;
        public InputWord(Word input)
        ***REMOVED***
            Input = input;
    ***REMOVED***

        
        public override void TextInput(char letter)
        ***REMOVED***
            int index = Input.Index;

            if (char.IsWhiteSpace(letter))
            ***REMOVED***
                Input = null;
                return;
        ***REMOVED***

            if (CheckWord(letter, Input))
            ***REMOVED***
                Input.Input.Push(letter);
        ***REMOVED***
            else
            ***REMOVED***
                if (OnKeyWrong == KeyWrong.reset)
                ***REMOVED***
                    Input.Input.Clear();
                    Input.Index = 0;
                    Input.Finished = false;
                    Input.Correct = null;
            ***REMOVED***

                if (OnKeyWrong == KeyWrong.remove)
                ***REMOVED***
                    Input = null;
            ***REMOVED***

                if (OnKeyWrong == KeyWrong.add)
                ***REMOVED***
                    Input.Input.Push(letter);
                    Input.Finished = false;
                    Input.Correct = false;
            ***REMOVED***

                if (OnKeyWrong == KeyWrong.none)
                ***REMOVED***
                    Input.Index = index;
            ***REMOVED***
        ***REMOVED***

            WordUpdate?.Invoke(this, new WordUpdateArgs()
            ***REMOVED***
                Words = new List<Word>(),
                PreviousChar = PreviousChar,
                CurrentChar = letter
        ***REMOVED***);

            base.TextInput(letter);
    ***REMOVED***
        public override void Backspace()
        ***REMOVED***
            Input?.Backspace();

            bool correct = true;
            for (int i = 0; i < Input.Input.Count; i++)
            ***REMOVED***
                if (!CheckWord(Input.Input.ElementAt(i), Input, i))
                ***REMOVED***
                    correct = false;
                    break;
            ***REMOVED***
        ***REMOVED***

            Input.Correct = correct;
    ***REMOVED***
        public override event EventHandler<WordUpdateArgs> WordUpdate;


***REMOVED***
***REMOVED***
