***REMOVED***
***REMOVED***
using System.Linq;
***REMOVED***
using System.Threading.Tasks;

namespace TypTop.Logic
***REMOVED***
    class InputList : Input
    ***REMOVED***
        public List<Word> Input;
        public InputList(List<Word> input)
        ***REMOVED***
            Input = input;
    ***REMOVED***


        //
        // Summary:
        //     When the InputMethod is set to list. Only the word with the highest typing progress will be focussed on. Interpeted as false when there is an equal typing progress.
        public bool FocusOnHighIndex = false;


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
        public override void Backspace()
        ***REMOVED***
            
    ***REMOVED***

        

        public override event EventHandler<WordUpdateArgs> WordUpdate;
***REMOVED***
***REMOVED***
