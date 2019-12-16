using System.Collections.Generic;
using TypTop.GameWindow;
using TypTop.LevelScreen;
using TypTop.Logic;
using TypTop.SpaceMinigame;
using TypTop.TavernMinigame;
using TypTop.WorldScreen;

namespace TypTop.GameGui
{
    public class GameLoader : IGameLoader
    {
        private readonly GameWindow.GameWindow _gameWindow;
        private readonly IList<World> _worlds;

        public GameLoader(GameWindow.GameWindow gameWindow, IList<World> worlds)
        {
            _gameWindow = gameWindow;
            _worlds = worlds;
        }

        public void LoadWorldMap()
        {
            var worldScreenGame = new WorldScreenGame(_worlds, this);
            _gameWindow.Start(worldScreenGame, new Transition(2));
        }

        public void LoadLevelMap(World world)
        {
            var levelScreen = new LevelScreenGame(world, this);
            _gameWindow.Start(levelScreen, new Transition(2));
        }

        public void LoadMinigame(Level level)
        {
            switch (level.World.Id)
            {
                case WorldId.Space:
                {
                    var spaceGame = new SpaceGame(level);
                    spaceGame.OnFinished += (sender, args) => { LoadLevelMap(level.World); };
                    _gameWindow.Start(spaceGame, new Transition(1));
                    break;
                }
                case WorldId.Tavern:
                {
                    var tavernGame = new TavernGame(level);
                    tavernGame.OnFinished += (sender, args) => { LoadLevelMap(level.World); };
                    _gameWindow.Start(tavernGame, new Transition(1));
                    break;
                }
            }
        }
    }
}