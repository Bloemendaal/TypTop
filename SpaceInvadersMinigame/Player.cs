using System;
using System.Numerics;
using System.Windows;
using System.Windows.Media.Imaging;
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;

namespace SpaceInvadersMinigame
{
    public class Player : Entity
    {
        public Player(Game game) : base("player", game)
        {
            AddComponent(new TransformComponent());
            AddComponent(new KeyboardMoveComponent());
            AddComponent(new CollisionComponent(new Size(150,150)));
            AddComponent(new ImageComponent(new BitmapImage(new Uri(@"player.png", UriKind.Relative))));
        }
    }
}