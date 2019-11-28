using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldMap
{
    public class WorldScreen
    {
        public int User { get; private set; }
        public int World { get; private set; }
        public List<World> Worlds { get; private set; }
        public List<Level> Levels { get; private set; }
        public List<UserLevel> UserLevels { get; private set; }

        public WorldScreen(World world, User user)
        {
            // initialize properties
            User = user.Id;
            World = world.Id;
            Worlds = new List<World>();
            Levels = new List<Level>();
            UserLevels = new List<UserLevel>();

            // load worlds
            /* from database
            
            foreach ( //world record in database )
                Worlds.Add(new World( //world id from database ))

            */

            // load levels
            /* from database
            
            foreach ( //level record in database where level.world matches current world )
                Levels.Add(new Level( //level id from database ))

            */

            // load UserLevels
            /* from database
            
            foreach ( //userlevel record in database )
                UserLevels.Add(new UserLevel( //user from database, //level from database ))

            */
        }
    }
}
