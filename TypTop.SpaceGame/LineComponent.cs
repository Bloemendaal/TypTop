***REMOVED***
***REMOVED***
using System.Windows;
***REMOVED***
using System.Windows.Media;
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;

namespace TypTop.SpaceGame
***REMOVED***
    public class LineComponent : Component, IDrawable
    ***REMOVED***
        private PositionComponent pc;
        public void Draw(DrawingContext context)
        ***REMOVED***
            Pen pen = new Pen(Brushes.YellowGreen, 5);
            
            DashStyle dash_style1 = new DashStyle(
                new double[] ***REMOVED*** 5, 5 ***REMOVED***, 0);
            pen.DashStyle = dash_style1;
            
            Point point1 = new Point(0, 950);
            Point point2 = new Point(1920, 950);
            context.DrawLine(pen, point1, point2);
            
    ***REMOVED***
        public override void AddedToEntity()
        ***REMOVED***
            pc = Entity.GetComponent<PositionComponent>();
    ***REMOVED***
***REMOVED***
***REMOVED***
