using SideBarNavigation.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SideBarNavigation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private HomeUc homeUc;
        private List<NotificationContentClass> notifications;


        public MainWindow()
        {
            try
            {
                InitializeComponent();

                homeUc = new HomeUc();
                mainPageContentControl.Content = homeUc;
                notifications = new List<NotificationContentClass>();
                notifications.Add(new NotificationContentClass()
                {
                    NotificationContent = "First Notification",
                    NotificationTime = "16:07"
                });
                notifications.Add(new NotificationContentClass()
                {
                    NotificationContent = "Second Notification",
                    NotificationTime = "16:10"
                });
                notifications.Add(new NotificationContentClass()
                {
                    NotificationContent = "Third Notification",
                    NotificationTime = "16:30"
                });
                notifications.Add(new NotificationContentClass()
                {
                    NotificationContent = "Fourth Notification",
                    NotificationTime = "16:50"
                });
                notifications.Add(new NotificationContentClass()
                {
                    NotificationContent = "Fifth Notification",
                    NotificationTime = "17:18"
                });
                notificationListBox.ItemsSource = notifications;
                

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Created : {0} ", ex.Message);
            }
        }


        /// <summary>
        /// Logic - To close the Side Bar Navigation Drawer and chnage the icon to drawer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeLbl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                closeLbl.Visibility = Visibility.Collapsed;
                myAppIconSidebar.Visibility = Visibility.Collapsed;
                drawerIconSidebar.Visibility = Visibility.Visible;
                var closeAnimation = (Storyboard)FindResource("CloseAnimation");
                closeAnimation.Begin();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Created : {0} ", ex.Message);
            }
        }


        /// <summary>
        /// Logic - TO open the Side Bar Navigation Drawer and chnage the icon of drawer to app icon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drawerIconSidebar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                drawerIconSidebar.Visibility = Visibility.Collapsed;
                myAppIconSidebar.Visibility = Visibility.Visible;
                closeLbl.Visibility = Visibility.Visible;
                var openAnimation = (Storyboard)FindResource("OpenAnimation");
                openAnimation.Begin();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Created : {0} ", ex.Message);
            }
        }


        /// <summary>
        /// Logic - Change the content of main window based on itemselection and to get the details of selected item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sideNavigationListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sideNavigationListBox.SelectedItem is ListBoxItem selectedItem)
                {
                    // Determine which page to load based on the selected item
                    switch (selectedItem.Tag.ToString())
                    {
                        case "Home":
                            LoadHomeUserControl();
                            break;
                        case "GameStore":
                            LoadGameStoreUserControl();
                            break;
                        case "MyGames":
                            LoadMyGamesUserControl();
                            break;
                        case "Downloads":
                            LoadDownloadsUserControl(); 
                            break;
                        case "Community":
                            LoadCommunityUserControl(); 
                            break;
                        case "MyLibrary":
                            LoadMyLibraryUserControl(); 
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Created : {0} ", ex.Message);
            }
        }

        private void aboutStack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                sideNavigationListBox.SelectedItem = null;
                LoadAboutUserControl();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Created : {0} ", ex.Message);
            }
        }

        private void settingsStack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                sideNavigationListBox.SelectedItem = null;
                LoadSettingsUserControl();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Created : {0} ", ex.Message);
            }
        }


        #region Functions of loading the different user controls as per item selection in main content

        private void LoadHomeUserControl() 
        {
            try
            {
                mainPageContentControl.Content = homeUc;
                var gridRednderTranslate = (Storyboard)FindResource("ContentGridTranslate");
                gridRednderTranslate.Begin();

                var contentOpenAnimation = (Storyboard)FindResource("ContentOpenAnimation");
                contentOpenAnimation.Begin();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Created : {0} ", ex.Message);
            }
        }

        private void LoadGameStoreUserControl() 
        {
            try
            {
                mainPageContentControl.Content = new GameStoreUc();
                var gridRednderTranslate = (Storyboard)FindResource("ContentGridTranslate");
                gridRednderTranslate.Begin();

                var contentOpenAnimation = (Storyboard)FindResource("ContentOpenAnimation");
                contentOpenAnimation.Begin();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Created : {0} ", ex.Message);
            }
        }

        private void LoadMyGamesUserControl() 
        {
            try
            {
                mainPageContentControl.Content = new MyGamesUc();

                var gridRednderTranslate = (Storyboard)FindResource("ContentGridTranslate");
                gridRednderTranslate.Begin();

                var contentOpenAnimation = (Storyboard)FindResource("ContentOpenAnimation");
                contentOpenAnimation.Begin();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Created : {0} ", ex.Message);
            }
        }

        private void LoadDownloadsUserControl() 
        {
            try
            {
                mainPageContentControl.Content = new DownloadsUc();

                var gridRednderTranslate = (Storyboard)FindResource("ContentGridTranslate");
                gridRednderTranslate.Begin();

                var contentOpenAnimation = (Storyboard)FindResource("ContentOpenAnimation");
                contentOpenAnimation.Begin();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Created : {0} ", ex.Message);
            }
        }

        private void LoadCommunityUserControl()
        {
            try
            {
                mainPageContentControl.Content = new CommunityUc();

                var gridRednderTranslate = (Storyboard)FindResource("ContentGridTranslate");
                gridRednderTranslate.Begin();

                var contentOpenAnimation = (Storyboard)FindResource("ContentOpenAnimation");
                contentOpenAnimation.Begin();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Created : {0} ", ex.Message);
            }
        }

        private void LoadMyLibraryUserControl() 
        {
            try
            {
                mainPageContentControl.Content = new MyLibraryUc();

                var gridRednderTranslate = (Storyboard)FindResource("ContentGridTranslate");
                gridRednderTranslate.Begin();

                var contentOpenAnimation = (Storyboard)FindResource("ContentOpenAnimation");
                contentOpenAnimation.Begin();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Created : {0} ", ex.Message);
            }
        }

        private void LoadAboutUserControl()
        {
            try
            {
                mainPageContentControl.Content = new AboutUc();

                var gridRednderTranslate = (Storyboard)FindResource("ContentGridTranslate");
                gridRednderTranslate.Begin();

                var contentOpenAnimation = (Storyboard)FindResource("ContentOpenAnimation");
                contentOpenAnimation.Begin();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Created : {0} ", ex.Message);
            }
        }

        private void LoadSettingsUserControl()
        {
            try
            {
                mainPageContentControl.Content = new SettingsUc();

                var gridRednderTranslate = (Storyboard)FindResource("ContentGridTranslate");
                gridRednderTranslate.Begin();

                var contentOpenAnimation = (Storyboard)FindResource("ContentOpenAnimation");
                contentOpenAnimation.Begin();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Created : {0} ", ex.Message);
            }
        }


        #endregion


        /// <summary>
        /// Logic - To close the Notification Panel and show the main area of the application ,
        /// when user clicks anywhere in the application except notification panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotificationGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var notificationCloseAnimation = (Storyboard)FindResource("NotificationCloseAnimation");
                notificationCloseAnimation.Begin();

                notificationListBox.SelectedItem = null;
                
                NotificationGrid.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Created : {0} ", ex.Message);
            }
        }


        /// <summary>
        /// Logic - To open the notifiction panel and fade out the remaining area of the application,
        /// When user click on the notification image in the header of the application window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notificationImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                NotificationGrid.Visibility = Visibility.Visible;

                var notificatioOpenAnimation = (Storyboard)FindResource("NotificationOpenAnimation");
                notificatioOpenAnimation.Begin();

                notificationListBox.SelectedItem = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Created : {0} ", ex.Message);
            }
        }
    }

    /// <summary>
    /// Class for binding the data of the notification panel 
    /// </summary>
    public class NotificationContentClass
    {
        public string NotificationContent { get; set; }
        public string NotificationTime { get; set; }
    }
}
