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
            List<Word> wordlist = FocusOnHighIndex ? Input.Where(i => i.Index >= Input.Max(j => j.Index)).ToList() : Input;

            if (wordlist?.Count > 0)
            ***REMOVED***
                foreach (Word input in wordlist)
                ***REMOVED***
                    int index = input.Index;

                    if (char.IsWhiteSpace(letter))
                    ***REMOVED***
                        Input?.Remove(input);
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
                                Input?.Remove(input);
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
            ***REMOVED***

                WordUpdate?.Invoke(this, new WordUpdateArgs()
                ***REMOVED***
                    Words = new List<Word>(),
                    PreviousChar = PreviousChar,
                    CurrentChar = letter
            ***REMOVED***);
        ***REMOVED***

            base.TextInput(letter);
    ***REMOVED***
        public override void Backspace()
        ***REMOVED***
            List<Word> wordlist = FocusOnHighIndex ? Input.Where(i => i.Index >= Input.Max(j => j.Index)).ToList() : Input;

            if (wordlist?.Count > 0)
            ***REMOVED***
                foreach (Word input in wordlist)
                ***REMOVED***
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
        ***REMOVED***

    ***REMOVED***
        public override event EventHandler<WordUpdateArgs> WordUpdate;
***REMOVED***
***REMOVED***
