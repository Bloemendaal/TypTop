using System.Collections.Generic;
using TypTop.GameWindow;
using TypTop.LevelScreen;
using TypTop.Logic;
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
            
        }
    }
}