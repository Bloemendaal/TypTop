using BasicGameEngine;
using System;
using System.Collections.Generic;
using System.Text;

namespace TavernMinigame
{
    public class SpeechBubble : Entity
    {
        public Customer Customer;
        public SpeechBubble(Customer customer, Game game) : base(game)
        {
            Customer = customer;
        }
    }
}
