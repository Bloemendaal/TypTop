<a name='assembly'></a>
# TypTop.LoginGui

## Contents

- [App](#T-TypTop-LoginGui-App 'TypTop.LoginGui.App')
  - [InitializeComponent()](#M-TypTop-LoginGui-App-InitializeComponent 'TypTop.LoginGui.App.InitializeComponent')
  - [Main()](#M-TypTop-LoginGui-App-Main 'TypTop.LoginGui.App.Main')
- [LoginWindow](#T-TypTop-Gui-LoginWindow 'TypTop.Gui.LoginWindow')
  - [BackButton_Click(sender,e)](#M-TypTop-Gui-LoginWindow-BackButton_Click-System-Object,System-Windows-RoutedEventArgs- 'TypTop.Gui.LoginWindow.BackButton_Click(System.Object,System.Windows.RoutedEventArgs)')
  - [BackToLogin()](#M-TypTop-Gui-LoginWindow-BackToLogin 'TypTop.Gui.LoginWindow.BackToLogin')
  - [CreateAccountButton_Click(sender,e)](#M-TypTop-Gui-LoginWindow-CreateAccountButton_Click-System-Object,System-Windows-RoutedEventArgs- 'TypTop.Gui.LoginWindow.CreateAccountButton_Click(System.Object,System.Windows.RoutedEventArgs)')
  - [InitializeComponent()](#M-TypTop-Gui-LoginWindow-InitializeComponent 'TypTop.Gui.LoginWindow.InitializeComponent')
  - [LoginButton_Click()](#M-TypTop-Gui-LoginWindow-LoginButton_Click-System-Object,System-Windows-RoutedEventArgs- 'TypTop.Gui.LoginWindow.LoginButton_Click(System.Object,System.Windows.RoutedEventArgs)')
  - [NewAccountButton_Click()](#M-TypTop-Gui-LoginWindow-NewAccountButton_Click-System-Object,System-Windows-RoutedEventArgs- 'TypTop.Gui.LoginWindow.NewAccountButton_Click(System.Object,System.Windows.RoutedEventArgs)')
- [PasswordHasher](#T-TypTop-LoginGui-PasswordHasher 'TypTop.LoginGui.PasswordHasher')
  - [CreateSalt()](#M-TypTop-LoginGui-PasswordHasher-CreateSalt 'TypTop.LoginGui.PasswordHasher.CreateSalt')
  - [HashPassword()](#M-TypTop-LoginGui-PasswordHasher-HashPassword-System-String,System-Byte[]- 'TypTop.LoginGui.PasswordHasher.HashPassword(System.String,System.Byte[])')
  - [VerifyHash()](#M-TypTop-LoginGui-PasswordHasher-VerifyHash-System-String,System-Byte[],System-Byte[]- 'TypTop.LoginGui.PasswordHasher.VerifyHash(System.String,System.Byte[],System.Byte[])')

<a name='T-TypTop-LoginGui-App'></a>
## App `type`

##### Namespace

TypTop.LoginGui

##### Summary

Interaction logic for App.xaml

<a name='M-TypTop-LoginGui-App-InitializeComponent'></a>
### InitializeComponent() `method`

##### Summary

InitializeComponent

##### Parameters

This method has no parameters.

<a name='M-TypTop-LoginGui-App-Main'></a>
### Main() `method`

##### Summary

Application Entry Point.

##### Parameters

This method has no parameters.

<a name='T-TypTop-Gui-LoginWindow'></a>
## LoginWindow `type`

##### Namespace

TypTop.Gui

##### Summary

Interaction logic for LoginWindow.xaml

<a name='M-TypTop-Gui-LoginWindow-BackButton_Click-System-Object,System-Windows-RoutedEventArgs-'></a>
### BackButton_Click(sender,e) `method`

##### Summary

Go back to the loginscreen from the account creation screen

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |
| e | [System.Windows.RoutedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.RoutedEventArgs 'System.Windows.RoutedEventArgs') |  |

<a name='M-TypTop-Gui-LoginWindow-BackToLogin'></a>
### BackToLogin() `method`

##### Summary

Go back to the loginscreen

##### Parameters

This method has no parameters.

<a name='M-TypTop-Gui-LoginWindow-CreateAccountButton_Click-System-Object,System-Windows-RoutedEventArgs-'></a>
### CreateAccountButton_Click(sender,e) `method`

##### Summary

Store a new account in the database if the given values are valid.
Valid being:
-non-empty string for username and password
-username not already in the database

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |
| e | [System.Windows.RoutedEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.RoutedEventArgs 'System.Windows.RoutedEventArgs') |  |

<a name='M-TypTop-Gui-LoginWindow-InitializeComponent'></a>
### InitializeComponent() `method`

##### Summary

InitializeComponent

##### Parameters

This method has no parameters.

<a name='M-TypTop-Gui-LoginWindow-LoginButton_Click-System-Object,System-Windows-RoutedEventArgs-'></a>
### LoginButton_Click() `method`

##### Summary

Attempt to log in with the given username and password.
 If successful open a GameGUI.MainWindow,
 else show an error message.

##### Parameters

This method has no parameters.

<a name='M-TypTop-Gui-LoginWindow-NewAccountButton_Click-System-Object,System-Windows-RoutedEventArgs-'></a>
### NewAccountButton_Click() `method`

##### Summary

Changes view to window in which the user enters the username and password of a new account and adds it to the database if valid.

##### Parameters

This method has no parameters.

<a name='T-TypTop-LoginGui-PasswordHasher'></a>
## PasswordHasher `type`

##### Namespace

TypTop.LoginGui

<a name='M-TypTop-LoginGui-PasswordHasher-CreateSalt'></a>
### CreateSalt() `method`

##### Summary

Creates a salt to be used in HashPassword and VerifyHash

##### Parameters

This method has no parameters.

<a name='M-TypTop-LoginGui-PasswordHasher-HashPassword-System-String,System-Byte[]-'></a>
### HashPassword() `method`

##### Summary

Generate a hash using Argon2id based on the password

##### Parameters

This method has no parameters.

<a name='M-TypTop-LoginGui-PasswordHasher-VerifyHash-System-String,System-Byte[],System-Byte[]-'></a>
### VerifyHash() `method`

##### Summary

Verify that an entered password matches the stored hash.

##### Parameters

This method has no parameters.
