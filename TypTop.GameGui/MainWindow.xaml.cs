using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;
using BasicGameEngine;
using BasicGameEngine.GameEngine.Components;
using Microsoft.Extensions.Configuration;
using TypTop.Logic;

namespace TypTop.GameGui
{
    public class Settings
    {
        public static Settings Instance;

        public static void Initialize()
        {
            var devEnvironmentVariable = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
            var isDevelopment = string.IsNullOrEmpty(devEnvironmentVariable) ||
                                devEnvironmentVariable.ToLower() == "development";

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json",
                    optional: false,
                    reloadOnChange: true)
                .AddUserSecrets<MainWindow>();
            IConfigurationRoot configurationRoot = builder.Build();
            Instance = new Settings(configurationRoot);
        }

        private readonly IConfigurationRoot _configurationRoot;

        private Settings(IConfigurationRoot configurationRoot)
        {
            _configurationRoot = configurationRoot;
        }

        public string DatabaseConnectionString =>
            _configurationRoot.GetSection("Database").GetValue<string>("ConnectionString");
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            try
            {
                Settings.Initialize();
            }
            catch(FileNotFoundException fileNotFoundException)
            {
                MessageBox.Show(fileNotFoundException.Message);
            }
            
            InitializeComponent();
            PreviewTextInput += OnPreviewTextInput;
            GameWindow.Start(new SpaceGame.SpaceGame());
        }

        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            GameWindow.OnTextInput(e);
        }
    }
}
