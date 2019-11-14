***REMOVED***
***REMOVED***
using System.Linq;
***REMOVED***
using System.Threading.Tasks;

namespace TypTop.Logic
***REMOVED***
    class InputStack : Input
    ***REMOVED***
        public Stack<Word> Input;
        public InputStack(Stack<Word> input)
        ***REMOVED***
            Input = input;
    ***REMOVED***


        public override void TextInput(char letter)
        ***REMOVED***
            WordUpdate?.Invoke(this, new WordUpdateArgs()
            ***REMOVED***
                Words = new List<Word>(),
                PreviousChar = PreviousChar,
                CurrentChar = letter
        ***REMOVED***);

            base.TextInput(letter);
    ***REMOVED***
        public override event EventHandler<WordUpdateArgs> WordUpdate;
***REMOVED***
***REMOVED***
