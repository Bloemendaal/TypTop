using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TypTop.GameWindow
{
    public class GameWindow : Control
    {
        static GameWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GameWindow), new FrameworkPropertyMetadata(typeof(GameWindow)));
        }

        public void Start()
        {
            
        }

        public void Stop()
        {

        }
    }
}
