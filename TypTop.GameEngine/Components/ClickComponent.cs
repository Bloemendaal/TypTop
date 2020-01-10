using System;
using System.Windows;
using TypTop.GameEngine;

namespace TypTop.MinigameEngine
{
    /// <summary>Captures mouse clicks</summary>
    /// <seealso cref="TypTop.GameEngine.Component" />
    public class ClickComponent : Component
    {
        /// <summary>Click capture bounds</summary>
        /// <value>The bounds.</value>
        public Rect Bounds { get; }

        /// <summary>Occurs when [clicked].</summary>
        public event EventHandler Clicked;
       
        public ClickComponent(Rect bounds)
        {
            Bounds = bounds;
        }

        /// <summary>  Raises the click event.</summary>
        /// <param name="point">The point.</param>
        public void CaptureClick(Point point)
        {
            if (Bounds.Contains(point))
            {
                OnClicked();
            }
        }

        protected virtual void OnClicked()
        {
            Clicked?.Invoke(this, EventArgs.Empty);
        }
    }
}