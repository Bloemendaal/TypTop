using Konscious.Security.Cryptography;
using System;
***REMOVED***
using System.Linq;
using System.Security.Cryptography;
***REMOVED***
using System.Windows;
using System.Windows.Controls;

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
        /// Changes view to window in which the user enters the username and password of a new account and adds it to the database if valid.
        /// </summary>
        private void NewAccountButton_Click(object sender, RoutedEventArgs e)
        ***REMOVED***
            CreationUsernameBox.Text = UsernameBox.Text;
            CreationPasswordBox.Password = PasswordBox.Password;
            LoginCanvas.Visibility = Visibility.Hidden;
    ***REMOVED***

        /// <summary>
        /// Creates a salt to be used in HashPassword and VerifyHash
        /// </summary>
        private byte[] CreateSalt()
        ***REMOVED***
            var buffer = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);
            return buffer;
    ***REMOVED***

        /// <summary>
        /// Generate a hash using Argon2id based on the password
        /// </summary>
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
            argon2.Dispose();
            return r;
    ***REMOVED***

        /// <summary>
        /// Verify that an entered password matches the stored hash.
        /// </summary>
        private bool VerifyHash(string password, byte[] salt, byte[] hash)
        ***REMOVED***
            var newHash = HashPassword(password, salt);
            return hash.SequenceEqual(newHash);
    ***REMOVED***


        /// <summary>
        /// Store a new account in the database if the given values are valid.
        /// Valid being:
        /// -non-empty string for username and password
        /// -username not already in the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateAccountButton_Click(object sender, RoutedEventArgs e)
        ***REMOVED***
            if (CreationUsernameBox.Text != "" && CreationPasswordBox.Password != "")
            ***REMOVED***
                using (var db = new Database.Context())
                ***REMOVED***
                    if (CreationPasswordBox.Password.Equals(CreationPasswordBoxConfirmation.Password))
                    ***REMOVED***
                        if (!db.User.Where(user => user.Username.Equals(CreationUsernameBox.Text)).Any())
                        ***REMOVED***
                            byte[] saltBytes = CreateSalt();
                            string salt = Encoding.ASCII.GetString(saltBytes);

                            db.Add(new Database.User
                            ***REMOVED***
                                UserId = 0,
                                Username = CreationUsernameBox.Text,
                                Password = CreationPasswordBox.Password,
                                Salt = salt,
                                Teacher = (bool)AccountTypeCheckbox.IsChecked
                        ***REMOVED***);
                            db.SaveChanges();

                            
                            LoginCanvas.Visibility = Visibility.Visible;
                    ***REMOVED***
                        else
                        ***REMOVED***
                            MessageBox.Show("Deze gebruikersnaam is al in gebruik.");
                    ***REMOVED***
                ***REMOVED***
                    else
                    ***REMOVED***
                        MessageBox.Show("Wachtwoord niet bevestigd.");
                ***REMOVED***

            ***REMOVED***
        ***REMOVED***
            else
            ***REMOVED***
                MessageBox.Show("Vul een gebruikersnaam en wachtwoord in.");
        ***REMOVED***
    ***REMOVED***

        /// <summary>
        /// Go back to the loginscreen from the account creation screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        ***REMOVED***
            LoginCanvas.Visibility = Visibility.Visible;
    ***REMOVED***

***REMOVED***
***REMOVED***
