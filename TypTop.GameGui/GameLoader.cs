﻿using System;
using System.Collections.Generic;
using System.Media;
using TypTop.GameEngine;
using TypTop.GameWindow;
using TypTop.JumpMinigame;
using TypTop.LevelScreen;
using TypTop.Logic;
using TypTop.MinigameEngine;
using TypTop.ScoreScreen;
using TypTop.SpaceMinigame;
using TypTop.TavernMinigame;
using TypTop.Tutorial;
using TypTop.WorldScreen;

namespace TypTop.GameGui
{
    /// <summary>
    /// Null object, only used for fade when game closes.
    /// </summary>
    public class ExitGame : Game
    {
    }

    /// <summary>Used for loading game screens</summary>
    /// <seealso cref="TypTop.Logic.IGameLoader" />
    public class GameLoader : IGameLoader
    {
        private readonly GameWindow.GameWindow _gameWindow;
        private readonly IList<World> _worlds;

        /// <summary>Initializes a new instance of the <see cref="GameLoader"/> class.</summary>
        /// <param name="gameWindow">The game window.</param>
        /// <param name="worlds">The worlds.</param>
        public GameLoader(GameWindow.GameWindow gameWindow, IList<World> worlds)
        {
            _gameWindow = gameWindow;
            _worlds = worlds;
        }

        /// <summary>Loads the world map.</summary>
        public void LoadWorldMap()
        {
            var worldScreenGame = new WorldScreenGame(_worlds, this);
            _gameWindow.Start(worldScreenGame, new Transition(1));
            worldScreenGame.Exit += WorldScreenGameOnExit;
        }

        private void WorldScreenGameOnExit(object sender, EventArgs e)
        {
            var transition = new Transition(1f);
            transition.FadeIn += (o, args) => Environment.Exit(0);
            _gameWindow.Start(new ExitGame(), transition);
        }

        /// <summary>Loads the level map.</summary>
        /// <param name="world">The world.</param>
        public void LoadLevelMap(World world)
        {
            var levelScreen = new LevelScreenGame(world, this);
            _gameWindow.Start(levelScreen, new Transition(1));
        }

        /// <summary>Loads the specified minigame.</summary>
        /// <param name="level">The level.</param>
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
                if (args.ESCPressed)
                {
                    LoadLevelMap(level.World);
                    return;
                }
                var scoreScreenGame = new ScoreScreenGame(args);
                scoreScreenGame.Closed += (o, e) => { LoadLevelMap(level.World); };
                _gameWindow.Start(scoreScreenGame, new Transition(1));
            };

            var tutorialGameScreen = new TutorialGameScreen(level.WordProvider);
            tutorialGameScreen.Back += (sender, args) =>
            {
                LoadLevelMap(level.World);
            };
            tutorialGameScreen.Play += (sender, args) =>
            {
                _gameWindow.Start(game, new Transition(1));
            };

            _gameWindow.Start(tutorialGameScreen, new Transition(1f));
        }

       
    }
}