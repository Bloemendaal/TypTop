using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TypTop.Gui
{
    /// <summary>
    /// Interaction logic for CreateAccountDialog.xaml
    /// </summary>
    public partial class CreateAccountDialog : Window
    {
        public bool Cancelled = false;

        public string Username
        {
            get { return UsernameTextBox.Text; }
            set { UsernameTextBox.Text = value; }
        }

        public string Password
        {
            get { return PasswordTextBox.Password; }
            set { PasswordTextBox.Password = value; }
        }
        public CreateAccountDialog()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Cancelled = true;
            DialogResult = true;
        }
    }
}
