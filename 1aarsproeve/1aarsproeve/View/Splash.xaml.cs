using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
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

namespace _1aarsproeve.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    partial class Splash : Page
    {
        internal Rect splashImageRect;
        private SplashScreen splash; 
        internal Frame rootFrame;

        public Splash(SplashScreen splashscreen)
        {
            InitializeComponent();

            splash = splashscreen;

            if (splash != null)
            {
                splashImageRect = splash.ImageLocation;
            }
            rootFrame = new Frame();
            RemoveExtendedSplash();
        }
        private async void RemoveExtendedSplash()
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            rootFrame.Navigate(typeof(Login));
            Window.Current.Content = rootFrame;
        }
    }
}