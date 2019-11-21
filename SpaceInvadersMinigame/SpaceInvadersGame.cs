using System.Numerics;
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;

namespace SpaceInvadersMinigame
***REMOVED***
    public class SpaceInvadersGame : Game
    ***REMOVED***
        public SpaceInvadersGame()
        ***REMOVED***
            AddEntity(new Player(this));

            var crate = new Crate(this);
            AddEntity(crate);
            crate.GetComponent<TransformComponent>().Position = new Vector2(200,200);
    ***REMOVED***
***REMOVED***
***REMOVED***
