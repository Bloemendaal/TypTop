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

    }
}
