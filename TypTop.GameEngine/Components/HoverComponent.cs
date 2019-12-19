using System;
using System.Windows;
using TypTop.GameEngine;

namespace TypTop.MinigameEngine
{
    public enum HoverState
    {
        Enter,
        Leave
    }


    public class HoverComponent : Component
    {
        public Rect Bounds { get; }

        public event EventHandler<HoverState> Hover;

        private bool _hover;

        public HoverComponent(Rect bounds)
        {
            Bounds = bounds;
        }

        public void CaptureHover(Point point)
        {
            if (Bounds.Contains(point))
            {
                if (_hover)
                {
                    return;
                }
                _hover = true;
                Hover?.Invoke(this, HoverState.Enter);
            }
            else
            {
                if (_hover == true)
                {
                    Hover?.Invoke(this, HoverState.Leave);
                    _hover = false;
                }
            }
        }
    }
}