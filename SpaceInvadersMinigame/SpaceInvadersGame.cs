using System.Numerics;
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;

namespace SpaceInvadersMinigame
{
    public class SpaceInvadersGame : Game
    {
        public SpaceInvadersGame()
        {
            AddEntity(new Player(this));

            var crate = new Crate(this);
            AddEntity(crate);
            crate.GetComponent<TransformComponent>().Position = new Vector2(200,200);
        }
    }
}
