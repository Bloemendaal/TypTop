﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Security.Cryptography;
using System.Text;

namespace TypTop.Gui
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        Dictionary<string, string> accounts = new Dictionary<string, string>();
        public LoginWindow()
        {
            InitializeComponent();
        }

        ///<summary>
        /// Attempt to log in with the given username and password.
        /// If succesfull open a MainWindow,
        /// else show an error message.
        /// </summary>
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (accounts.ContainsKey(UsernameBox.Text) && accounts[UsernameBox.Text] == ComputeSha256Hash(PasswordBox.Password))
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
                        accounts.Add(dialog.Username, ComputeSha256Hash(dialog.Password));
                    }
                    else
                    {
                        MessageBox.Show("Deze gebruikersnaam is al in gebruik.");
                    }

                }
            }
        }

        /// <summary>
        /// Generates a SHA256 hash of the specified string.
        /// </summary>
        /// <param name="rawData"> A string to be hashed</param>
        /// <returns>A string containing a SHA256 hash.</returns>
        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
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
