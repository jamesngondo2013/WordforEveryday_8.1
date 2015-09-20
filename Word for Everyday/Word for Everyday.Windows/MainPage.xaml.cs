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
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Loaded += MainPage_Loaded;
        }

        private void about_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(About));
        }

        private void message_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Messages));
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

        private void exit_Tapped(object sender, TappedRoutedEventArgs e)
        {
            App.Current.Exit();
        }

    }
}
