using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SideBarNavigation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            SplashScreenWindow splashScreenWindow = new SplashScreenWindow();
            MainWindow mainWindow = new MainWindow();
            splashScreenWindow.Show();

            Task.Run(() =>
            {
                // Simulate a delay
                System.Threading.Thread.Sleep(3000);

                // After the delay, close the splash screen and show the main window
                Dispatcher.Invoke(() =>
                {
                    splashScreenWindow.Close();
                    mainWindow.Show();

                });
            });
        }

    }
}
