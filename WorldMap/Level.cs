using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldMap
{
    public class Level
    {
        public int Id { get; private set; }
        public int World { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int[] StarScores { get; private set; }
        public int Index { get; private set; }

        public Level(int id)
        {
            Id = id;

            /* from database
            
            Title = ;
            Description = ;
            StarScores = new int[3] { , ,  };
            Index = ;

            */
        }
    }
}
