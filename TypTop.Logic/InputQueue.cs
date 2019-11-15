***REMOVED***
***REMOVED***
using System.Linq;
***REMOVED***
using System.Threading.Tasks;

namespace TypTop.Logic
***REMOVED***
    class InputQueue : Input
    ***REMOVED***
        public Queue<Word> Input;
        public InputQueue(Queue<Word> input)
        ***REMOVED***
            Input = input;
    ***REMOVED***


        public override void TextInput(char letter)
        ***REMOVED***
            Word input = Input?.Peek();
            int index = input.Index;

            if (char.IsWhiteSpace(letter))
            ***REMOVED***
                Input?.Dequeue();
                return;
        ***REMOVED***

            if (input != null)
            ***REMOVED***
                if (CheckWord(letter, input))
                ***REMOVED***
                    input?.Input.Push(letter);
            ***REMOVED***
                else
                ***REMOVED***
                    if (OnKeyWrong == KeyWrong.reset)
                    ***REMOVED***
                        input.Input.Clear();
                        input.Index = 0;
                        input.Finished = false;
                        input.Correct = null;
                ***REMOVED***

                    if (OnKeyWrong == KeyWrong.remove)
                    ***REMOVED***
                        Input?.Dequeue();
                ***REMOVED***

                    if (OnKeyWrong == KeyWrong.add)
                    ***REMOVED***
                        input.Input.Push(letter);
                        input.Finished = false;
                        input.Correct = false;
                ***REMOVED***

                    if (OnKeyWrong == KeyWrong.none)
                    ***REMOVED***
                        input.Index = index;
                ***REMOVED***
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
            Word input = Input?.Peek();
            input?.Backspace();

            bool correct = true;
            for (int i = 0; i < input.Input.Count; i++)
            ***REMOVED***
                if (!CheckWord(input.Input.ElementAt(i), input, i))
                ***REMOVED***
                    correct = false;
                    break;
            ***REMOVED***
        ***REMOVED***

            input.Correct = correct;
    ***REMOVED***
        public override event EventHandler<WordUpdateArgs> WordUpdate;
***REMOVED***
***REMOVED***
