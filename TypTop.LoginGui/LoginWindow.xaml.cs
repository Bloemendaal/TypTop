using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TypTop.LoginGui;
using TypTop.Repository;


namespace TypTop.Gui
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {


        public LoginWindow()
        {
            InitializeComponent();
            UsernameBox.Focus();
        }

        ///<summary>
        /// Attempt to log in with the given username and password.
        /// If successful open a GameGUI.MainWindow,
        /// else show an error message.
        /// </summary>
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

            using var unitOfWork = new UnitOfWork(new TypTop.Shared.ContextFactory().CreateDbContext(null));

            if (PasswordBox.Password != "" && unitOfWork.Users.GetWhere(u => u.Username.Equals(UsernameBox.Text)).Any())
            {
                byte[] salt = unitOfWork.Users.GetSalt(UsernameBox.Text);
                byte[] hash = unitOfWork.Users.GetPasswordHash(UsernameBox.Text);

                if (PasswordHasher.VerifyHash(PasswordBox.Password, salt, hash))
                {
                    /* Set logged in account here
                    * (coming later)
                    */
                    GameGui.MainWindow mainWindow = new GameGui.MainWindow();
                    mainWindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Onjuiste naam of wachtwoord.");
                }

            }
            else
            {
                MessageBox.Show("Onjuiste naam of wachtwoord.");
            }
        }

        ///<summary>
        /// Changes view to window in which the user enters the username and password of a new account and adds it to the database if valid.
        /// </summary>
        private void NewAccountButton_Click(object sender, RoutedEventArgs e)
        {
            CreationUsernameBox.Text = UsernameBox.Text;
            CreationPasswordBox.Password = PasswordBox.Password;
            CreationPasswordBoxConfirmation.Password = "";

            AccountCreationCanvas.Visibility = Visibility.Visible;
            CreationUsernameBox.Focus();
            LoginCanvas.Visibility = Visibility.Hidden;
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
                if (CreationPasswordBox.Password.Length >= 8)
                {
                    if (CreationPasswordBox.Password.Equals(CreationPasswordBoxConfirmation.Password))
                    {
                        using (var unitOfWork = new UnitOfWork(new TypTop.Shared.ContextFactory().CreateDbContext(null)))
                        {
                            if (!unitOfWork.Users.GetWhere(u => u.Username.Equals(CreationUsernameBox.Text)).Any())
                            {
                                byte[] salt = PasswordHasher.CreateSalt();

                                unitOfWork.Users.Add(new Database.User
                                {
                                    UserId = 0,
                                    Username = CreationUsernameBox.Text,
                                    Password = Convert.ToBase64String(PasswordHasher.HashPassword(CreationPasswordBox.Password, salt)),
                                    Salt = Convert.ToBase64String(salt),
                                    Teacher = (bool)AccountTypeCheckbox.IsChecked
                                });
                                unitOfWork.Complete();

                                BackToLogin();
                            }
                            else
                            {
                                MessageBox.Show("Deze gebruikersnaam is al in gebruik.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wachtwoord niet bevestigd.");
                    }
                }
                else
                {
                    MessageBox.Show("Je wachtwoord moet minimaal 8 tekens lang zijn.");
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
            BackToLogin();
        }

        /// <summary>
        /// Go back to the loginscreen
        /// </summary>
        private void BackToLogin()
        {
            UsernameBox.Text = "";
            PasswordBox.Password = "";

            LoginCanvas.Visibility = Visibility.Visible;
            UsernameBox.Focus();
            AccountCreationCanvas.Visibility = Visibility.Hidden;
        }
    }
}
