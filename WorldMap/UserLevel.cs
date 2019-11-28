using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldMap
{
    public class UserLevel
    {
        public int User { get; private set; }
        public int Level { get; private set; }
        public int Score { get; private set; }
        public int Stars { get; private set; }

        public UserLevel(User user, Level level)
        {
            User = user.Id;
            Level = level.Id;

            /* from database

            Score = ;
            Stars = ;

            */
        }
    }
}
