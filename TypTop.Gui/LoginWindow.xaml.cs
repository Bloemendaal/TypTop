﻿***REMOVED***
using System.Windows;
using System.Windows.Controls;
using System.Security.Cryptography;
***REMOVED***
using Konscious.Security.Cryptography;
using System.Linq;

namespace TypTop.Gui
***REMOVED***
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    ***REMOVED***
        Dictionary<string, byte[]> accounts = new Dictionary<string, byte[]>();
        Dictionary<string, byte[]> salts = new Dictionary<string, byte[]>(); //ja dit is mega ranzig maar gaat weg zodra de database er is

        public LoginWindow()
        ***REMOVED***
            InitializeComponent();

    ***REMOVED***

        ///<summary>
        /// Attempt to log in with the given username and password.
        /// If successful open a MainWindow,
        /// else show an error message.
        /// </summary>
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        ***REMOVED***
            if (accounts.ContainsKey(UsernameBox.Text) && VerifyHash(PasswordBox.Password, salts[UsernameBox.Text], accounts[UsernameBox.Text]))
            ***REMOVED***
                /* Set logged in account here
                 * (coming later)
                 */
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
       ***REMOVED***
            else
            ***REMOVED***
                MessageBox.Show("Onjuiste naam of wachtwoord.");
        ***REMOVED***
    ***REMOVED***

        ///<summary>
        /// Opens a dialog in which the user enters the username and password of a new account and adds it to the database if valid.
        /// </summary>
        private void NewAccountButton_Click(object sender, RoutedEventArgs e)
        ***REMOVED***
            CreateAccountDialog dialog = new CreateAccountDialog();
            if (dialog.ShowDialog() == true)
            ***REMOVED***

                if (!dialog.Cancelled)
                ***REMOVED***
                    if (!accounts.ContainsKey(dialog.UsernameTextBox.Text))
                    ***REMOVED***
                        byte[] salt = CreateSalt();
                        accounts.Add(dialog.Username, HashPassword(dialog.Password, salt));
                        salts.Add(dialog.Username, salt);
                ***REMOVED***
                    else
                    ***REMOVED***
                        MessageBox.Show("Deze gebruikersnaam is al in gebruik.");
                ***REMOVED***

            ***REMOVED***
        ***REMOVED***
    ***REMOVED***

        /// <summary>
        /// Creates a salt to be used in HashPassword and VerifyHash
        /// </summary>
        /// <returns></returns>
        private byte[] CreateSalt()
        ***REMOVED***
            var buffer = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);
            return buffer;
    ***REMOVED***

        /// <summary>
        /// Generate a hash using Argon2id
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        private byte[] HashPassword(string password, byte[] salt)
        ***REMOVED***
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            ***REMOVED***
                Salt = salt,
                DegreeOfParallelism = 4,
                Iterations = 4,
                MemorySize = 1024 * 100
        ***REMOVED***;
            
            var r = argon2.GetBytes(1024);
            string converted = Encoding.UTF8.GetString(r, 0, r.Length);
            MessageBox.Show(converted);
            argon2.Dispose();
            return r;
    ***REMOVED***

        /// <summary>
        /// Verify if an entered password equals the stored password.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        private bool VerifyHash(string password, byte[] salt, byte[] hash)
        ***REMOVED***
            var newHash = HashPassword(password, salt);
            return hash.SequenceEqual(newHash);
    ***REMOVED***

        /// <summary>
        /// Continue to MainWindow without setting a logged in account.
        /// </summary>
        private void NoAccountButton_Click(object sender, RoutedEventArgs e)
        ***REMOVED***
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
    ***REMOVED***
***REMOVED***
***REMOVED***
