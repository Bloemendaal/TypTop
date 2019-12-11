using System;
using System.Windows;
using TypTop.GameEngine;

namespace TypTop.MinigameEngine
{
    public class ClickComponent : Component
    {
        public Rect Bounds { get; }

        public event EventHandler Clicked;
       
        public ClickComponent(Rect bounds)
        {
            Bounds = bounds;
        }

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