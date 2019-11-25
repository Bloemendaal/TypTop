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

            var crate1 = new Crate("krat1", this);
            AddEntity(crate1);
            crate1.GetComponent<PositionComponent>().Position = new Vector2(200,200);

            var crate2 = new Crate("krat2", this);
            AddEntity(crate2);
            crate2.GetComponent<PositionComponent>().Position = new Vector2(400, 400);

            var crate3 = new Crate("krat3", this);
            AddEntity(crate3);
            crate3.GetComponent<PositionComponent>().Position = new Vector2(200, 400);

            var crate4 = new Crate("krat4", this);
            AddEntity(crate4);
            crate4.GetComponent<PositionComponent>().Position = new Vector2(400, 200);
        }
    }
}
