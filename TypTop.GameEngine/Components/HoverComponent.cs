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

    /// <summary>Used to capture mouse hover</summary>
    /// <seealso cref="TypTop.GameEngine.Component" />
    public class HoverComponent : Component
    {
        /// <summary>Hover capture bounds</summary>
        /// <value>The bounds.</value>
        public Rect Bounds { get; }

        /// <summary>Occurs when mouse hover over.</summary>
        public event EventHandler<HoverState> Hover;

        private bool _hover;

        public HoverComponent(Rect bounds)
        {
            Bounds = bounds;
        }

        /// <summary>  Raised the hover event.</summary>
        /// <param name="point">The point.</param>
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