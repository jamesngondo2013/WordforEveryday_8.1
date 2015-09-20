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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

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

            //var msgReply = MessageBox.Show("Welcome to Word for Everyday. If you are reading this today, I assume you are in need of inspiration or are looking for some inspiring scriptures to send to someone in need. I pray that you find what you are looking for.", "Word For Everyday", MessageBoxButton.OK);

            Random rand = new Random();
            int random = rand.Next(1, 9);
            XDocument LoadData = XDocument.Load("Message3.xml"); //xml file name
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

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }

        private void facebook_Tapped(object sender, TappedRoutedEventArgs e)
        {
            string myMessage = "";
            if (displayMsg.Items.Count > 0)
            {
                var value = (InspirationalMsg)displayMsg.Items.ElementAt(0);
                myMessage = value.InspMessage;
            }
           
        }

        private void mail_Tapped(object sender, TappedRoutedEventArgs e)
        {
            string myMessage = "";
            if (displayMsg.Items.Count > 0)
            {
                var value = (InspirationalMsg)displayMsg.Items.ElementAt(0);
                myMessage = value.InspMessage;
            }
            
        }

        private void back_Tapped(object sender, TappedRoutedEventArgs e)
        {
            App.Current.Exit();
        }
    }
}
