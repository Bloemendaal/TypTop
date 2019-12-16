using System;
using System.Collections.Generic;
using System.Linq;

namespace TypTop.Logic
{
    public class InputList : Input
    {
        /// <summary>
        ///     When the InputMethod is set to list. Only the word with the highest typing progress will be focussed on. Interpeted
        ///     as false when there is an equal typing progress.
        /// </summary>
        public bool FocusOnHighIndex = false;

        public List<Word> Input;

        public InputList(List<Word> input)
        {
            Input = input;
        }


        public override void TextInput(char letter)
        {
            var wordlist = FocusOnHighIndex
                ? new List<Word>(Input.Where(i => i.Index >= Input.Max(j => j.Index)))
                : Input;

            if (wordlist?.Count > 0)
            {
                foreach (Word input in wordlist)
                {
                    var index = input.Index;

                    if (input != null)
                    {
                        if (CheckWord(letter, input))
                        {
                            input?.Input.Push(letter);
                        }
                        else
                        {
                            if (OnKeyWrong == KeyWrong.Reset)
                            {
                                input.Input.Clear();
                                input.Index = 0;
                                input.Finished = false;
                                input.Correct = null;
                            }

                            if (OnKeyWrong == KeyWrong.Remove) Input?.Remove(input);

                            if (OnKeyWrong == KeyWrong.Add)
                            {
                                input.Input.Push(letter);
                                input.Finished = false;
                                input.Correct = false;
                            }

                            if (OnKeyWrong == KeyWrong.None) input.Index = index;
                        }
                    }
                }

                WordUpdate?.Invoke(this, new WordUpdateArgs
                {
                    Words = new List<Word>(),
                    PreviousChar = PreviousChar,
                    CurrentChar = letter
                });

                if (RemoveOnFinished) Input = Input.Where(e => !e.Finished).ToList();
            }

            base.TextInput(letter);
        }

        public override void Backspace()
        {
            var wordlist = FocusOnHighIndex ? Input.Where(i => i.Index >= Input.Max(j => j.Index)).ToList() : Input;

            if (wordlist?.Count > 0)
                foreach (Word input in wordlist)
                {
                    input?.Backspace();

                    var correct = true;
                    for (var i = 0; i < input.Input.Count; i++)
                        if (!CheckWord(input.Input.ElementAt(i), input, i))
                        {
                            correct = false;
                            break;
                        }

                    input.Correct = correct;
                }
        }

        public override event EventHandler<WordUpdateArgs> WordUpdate;
    }
}