using Konscious.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace TypTop.Gui
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        Dictionary<string, byte[]> accounts = new Dictionary<string, byte[]>();
        Dictionary<string, byte[]> salts = new Dictionary<string, byte[]>(); //ja dit is mega ranzig maar gaat weg zodra de database er is

        public LoginWindow()
        {
            InitializeComponent();

        }

        ///<summary>
        /// Attempt to log in with the given username and password.
        /// If successful open a MainWindow,
        /// else show an error message.
        /// </summary>
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (accounts.ContainsKey(UsernameBox.Text) && VerifyHash(PasswordBox.Password, salts[UsernameBox.Text], accounts[UsernameBox.Text]))
            {
                /* Set logged in account here
                 * (coming later)
                 */
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Onjuiste naam of wachtwoord.");
            }
        }

        ///<summary>
        /// Opens a dialog in which the user enters the username and password of a new account and adds it to the database if valid.
        /// </summary>
        private void NewAccountButton_Click(object sender, RoutedEventArgs e)
        {
            CreationUsernameBox.Text = UsernameBox.Text;
            CreationPasswordBox.Password = PasswordBox.Password;
            LoginCanvas.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creates a salt to be used in HashPassword and VerifyHash
        /// </summary>
        private byte[] CreateSalt()
        {
            var buffer = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);
            return buffer;
        }

        /// <summary>
        /// Generate a hash using Argon2id based on the password
        /// </summary>
        private byte[] HashPassword(string password, byte[] salt)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = 4,
                Iterations = 4,
                MemorySize = 1024 * 100
            };

            var r = argon2.GetBytes(1024);
            argon2.Dispose();
            return r;
        }

        /// <summary>
        /// Verify that an entered password matches the stored hash.
        /// </summary>
        private bool VerifyHash(string password, byte[] salt, byte[] hash)
        {
            var newHash = HashPassword(password, salt);
            return hash.SequenceEqual(newHash);
        }


        /// <summary>
        /// Store a new account in the database if the given values are valid.
        /// Valid being:
        /// -non-empty string for username and password
        /// -username not already in the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateAccountButton_Click(object sender, RoutedEventArgs e)
        {
            if (CreationUsernameBox.Text != "" && CreationPasswordBox.Password != "")
            {
                if (CreationPasswordBox.Password.Equals(CreationPasswordBoxConfirmation.Password))
                {
                    if (!accounts.ContainsKey(CreationUsernameBox.Text))
                    {
                        byte[] salt = CreateSalt();
                        accounts.Add(CreationUsernameBox.Text, HashPassword(CreationPasswordBox.Password, salt));
                        salts.Add(CreationUsernameBox.Text, salt);
                        LoginCanvas.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        MessageBox.Show("Deze gebruikersnaam is al in gebruik.");
                    }
                }
                else
                {
                    MessageBox.Show("Wachtwoord niet bevestigd.");
                }

            }
            else
            {
                MessageBox.Show("Vul een gebruikersnaam en wachtwoord in.");
            }
        }

        /// <summary>
        /// Go back to the loginscreen from the account creation screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            LoginCanvas.Visibility = Visibility.Visible;
        }

    }
}
