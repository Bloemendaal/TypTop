using System.Collections.Generic;
using TypTop.GameWindow;
using TypTop.JumpMinigame;
using TypTop.LevelScreen;
using TypTop.Logic;
using TypTop.MinigameEngine;
using TypTop.ScoreScreen;
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
            Minigame game;
            switch (level.World.Id)
            {
                case WorldId.Space:
                {
                    game = new SpaceGame(level);
                    break;
                }
                case WorldId.Tavern:
                {
                    game = new TavernGame(level);
                    break;
                }
                case WorldId.Jump:
                {
                    game = new JumpGame(level);
                    break;
                }
                default:
                    return;
            }

            game.OnFinished += (sender, args) =>
            {
                var scoreScreenGame = new ScoreScreenGame();
                scoreScreenGame.Closed += (o, e) => { LoadLevelMap(level.World); };
                _gameWindow.Start(scoreScreenGame, new Transition(1));
            };
            _gameWindow.Start(game, new Transition(1));
        }

       
    }
}