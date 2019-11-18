using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;
using System.Linq;

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
            CreateAccountDialog dialog = new CreateAccountDialog();
            if (dialog.ShowDialog() == true)
            {

                if (!dialog.Cancelled)
                {
                    if (!accounts.ContainsKey(dialog.UsernameTextBox.Text))
                    {
                        byte[] salt = CreateSalt();
                        accounts.Add(dialog.Username, HashPassword(dialog.Password, salt));
                        salts.Add(dialog.Username, salt);
                    }
                    else
                    {
                        MessageBox.Show("Deze gebruikersnaam is al in gebruik.");
                    }

                }
            }
        }

        /// <summary>
        /// Creates a salt to be used in HashPassword and VerifyHash
        /// </summary>
        /// <returns></returns>
        private byte[] CreateSalt()
        {
            var buffer = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);
            return buffer;
        }

        /// <summary>
        /// Generate a hash using Argon2id
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
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
            string converted = Encoding.UTF8.GetString(r, 0, r.Length);
            MessageBox.Show(converted);
            argon2.Dispose();
            return r;
        }

        /// <summary>
        /// Verify if an entered password equals the stored password.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        private bool VerifyHash(string password, byte[] salt, byte[] hash)
        {
            var newHash = HashPassword(password, salt);
            return hash.SequenceEqual(newHash);
        }

        /// <summary>
        /// Continue to MainWindow without setting a logged in account.
        /// </summary>
        private void NoAccountButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
