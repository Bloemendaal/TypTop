using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldMap
{
    public class World
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int Index { get; private set; }

        public World(int id)
        {
            Id = id;

            /* from database
            
            Title = ;
            Description = ;
            Index = ;

            */
        }
    }
}
