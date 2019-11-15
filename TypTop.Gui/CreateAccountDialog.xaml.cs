***REMOVED***
***REMOVED***
***REMOVED***
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TypTop.Gui
***REMOVED***
    /// <summary>
    /// Interaction logic for CreateAccountDialog.xaml
    /// </summary>
    public partial class CreateAccountDialog : Window
    ***REMOVED***
        public bool Cancelled = false;

        public string Username
        ***REMOVED***
            get ***REMOVED*** return UsernameTextBox.Text; ***REMOVED***
            set ***REMOVED*** UsernameTextBox.Text = value; ***REMOVED***
    ***REMOVED***

        public string Password
        ***REMOVED***
            get ***REMOVED*** return PasswordTextBox.Password; ***REMOVED***
            set ***REMOVED*** PasswordTextBox.Password = value; ***REMOVED***
    ***REMOVED***
        public CreateAccountDialog()
        ***REMOVED***
            InitializeComponent();
    ***REMOVED***

        private void OkButton_Click(object sender, RoutedEventArgs e)
        ***REMOVED***
            DialogResult = true;
    ***REMOVED***

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        ***REMOVED***
            Cancelled = true;
            DialogResult = true;
    ***REMOVED***
***REMOVED***
***REMOVED***
