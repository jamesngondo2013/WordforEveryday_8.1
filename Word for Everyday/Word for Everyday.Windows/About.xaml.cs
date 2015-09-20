using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class About : Page
    {
        public About()
        {
            this.InitializeComponent();
            aboutUs();
        }
        public void aboutUs()
        {
            textAbout.Text = "Are you searching for inspiring words to give expression to your thoughts? Why not let God's Word communicate the encouraging message for you? This App is a collection of bible based inspirational messages which will uplift your spirit with messages and quotes from the Bible. " + "Please, read your message today, be inspired and then  share it with friends or " +
            "Remember, God has blessed us so that we become a blessing to somebody else today. Stay blessed.";

        }

        private void Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
           
        }

        private void btnExit_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
