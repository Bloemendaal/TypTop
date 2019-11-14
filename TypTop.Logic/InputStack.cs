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

    }
}
