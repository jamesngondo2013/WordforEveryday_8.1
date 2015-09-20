using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Word_for_Everyday
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Messages : Page
    {
        public Messages()
        {
            this.InitializeComponent();

            Loaded += MainPage_Loaded;
            // var msgReply = MessageBox.Show("Welcome to Word for Everyday. If you are reading this today, I assume you are in need of inspiration or are looking for some inspiring scriptures to send to someone in need. I pray that you find what you are looking for.", "Word For Everyday", MessageBoxButton.OK);

            Random rand = new Random();
            int random = rand.Next(1, 300);
            XDocument LoadData = XDocument.Load("Message2.xml"); //xml file name
            var SearchData = from c in LoadData.Descendants("Messg")//xml tags
                             where c.Attribute("Day").Value == random.ToString()
                             select new InspirationalMsg()
                             {

                                 InspMessage = c.Attribute("InspMessage").Value,

                             };

            displayMsg.ItemsSource = SearchData;
            displayMsg.Visibility = Visibility.Visible;
        }

        public class InspirationalMsg
        {
            string day;
            string msg;
            int id;

            public string Day
            {
                get { return day; }
                set { day = value; }
            }

            public string InspMessage
            {
                get { return msg; }
                set { msg = value; }
            }

            public int Id
            {
                get { return id; }
                set { id = value; }
            }

        }

        private void Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.GoBack();
            //Frame.Navigate(typeof(MainPage));
        }


        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            Window.Current.SizeChanged += Current_SizeChanged;
        }
        void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            if (Windows.UI.ViewManagement.ApplicationView.Value == Windows.UI.ViewManagement.ApplicationViewState.Snapped)
            {
                grdSnap.Visibility = Visibility.Visible;
                grdMain.Visibility = Visibility.Collapsed;
                grdPotrate.Visibility = Visibility.Collapsed;
                grdEnd.Visibility = Visibility.Collapsed;
            }
            else if (Windows.UI.ViewManagement.ApplicationView.Value == Windows.UI.ViewManagement.ApplicationViewState.Filled || Windows.UI.ViewManagement.ApplicationView.Value == Windows.UI.ViewManagement.ApplicationViewState.FullScreenLandscape)
            {
                grdSnap.Visibility = Visibility.Collapsed;
                grdMain.Visibility = Visibility.Visible;
                grdPotrate.Visibility = Visibility.Collapsed;
            }
            else if (Windows.UI.ViewManagement.ApplicationView.Value == Windows.UI.ViewManagement.ApplicationViewState.FullScreenPortrait)
            {
                grdSnap.Visibility = Visibility.Collapsed;
                grdMain.Visibility = Visibility.Collapsed;
                grdPotrate.Visibility = Visibility.Visible;
                grdEnd.Visibility = Visibility.Collapsed;
            }
        }

        private void btnExit_Tapped(object sender, TappedRoutedEventArgs e)
        {
            App.Current.Exit();
        }





    }
}
