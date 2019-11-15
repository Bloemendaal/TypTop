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
            List<Word> wordlist = FocusOnHighIndex ? Input.Where(i => i.Index >= Input.Max(j => j.Index)).ToList() : Input;

            if (wordlist?.Count > 0)
            {
                foreach (Word input in wordlist)
                {
                    int index = input.Index;

                    if (char.IsWhiteSpace(letter))
                    {
                        Input?.Remove(input);
                        return;
                    }

                    if (input != null)
                    {
                        if (CheckWord(letter, input))
                        {
                            input?.Input.Push(letter);
                        }
                        else
                        {
                            if (OnKeyWrong == KeyWrong.reset)
                            {
                                input.Input.Clear();
                                input.Index = 0;
                                input.Finished = false;
                                input.Correct = null;
                            }

                            if (OnKeyWrong == KeyWrong.remove)
                            {
                                Input?.Remove(input);
                            }

                            if (OnKeyWrong == KeyWrong.add)
                            {
                                input.Input.Push(letter);
                                input.Finished = false;
                                input.Correct = false;
                            }

                            if (OnKeyWrong == KeyWrong.none)
                            {
                                input.Index = index;
                            }
                        }
                    }
                }

                WordUpdate?.Invoke(this, new WordUpdateArgs()
                {
                    Words = new List<Word>(),
                    PreviousChar = PreviousChar,
                    CurrentChar = letter
                });
            }

            base.TextInput(letter);
        }
        public override void Backspace()
        {
            List<Word> wordlist = FocusOnHighIndex ? Input.Where(i => i.Index >= Input.Max(j => j.Index)).ToList() : Input;

            if (wordlist?.Count > 0)
            {
                foreach (Word input in wordlist)
                {
                    input?.Backspace();

                    bool correct = true;
                    for (int i = 0; i < input.Input.Count; i++)
                    {
                        if (!CheckWord(input.Input.ElementAt(i), input, i))
                        {
                            correct = false;
                            break;
                        }
                    }

                    input.Correct = correct;
                }
            }

        }
        public override event EventHandler<WordUpdateArgs> WordUpdate;
    }
}
