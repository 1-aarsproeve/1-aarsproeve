using System.Globalization;
using Windows.UI;
using Windows.UI.Popups;
using _1aarsproeve.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Provider;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace _1aarsproeve.View
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class Vagtplan : Page
    {

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        public Vagtplan()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
        }

        /// <summary>
        /// Populates the page with content passed during navigation. Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session. The state will be null the first time a page is visited.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="Common.NavigationHelper.LoadState"/>
        /// and <see cref="Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        public void ClearSelected(ListView lv, ListView lv2, ListView lv3, ListView lv4, ListView lv5, ListView lv6, ListView lv7)
        {
            if (lv.SelectedIndex > -1)
            {
                lv2.SelectedIndex = -1;
                lv3.SelectedIndex = -1;
                lv4.SelectedIndex = -1;
                lv5.SelectedIndex = -1;
                lv6.SelectedIndex = -1;
                lv7.SelectedIndex = -1;
            }
        }
        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearSelected(listView,listView2,listView3,listView4,listView5,listView6,listView7);
        }

        private void listView2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearSelected(listView2, listView, listView3, listView4, listView5, listView6, listView7);
        }

        private void listView3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearSelected(listView3, listView2, listView, listView4, listView5, listView6, listView7);
        }

        private void listView4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearSelected(listView4, listView2, listView3, listView, listView5, listView6, listView7);
        }

        private void listView5_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearSelected(listView5, listView2, listView3, listView4, listView, listView6, listView7);
        }

        private void listView6_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearSelected(listView6, listView2, listView3, listView4, listView5, listView, listView7);
        }

        private void listView7_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearSelected(listView7, listView2, listView3, listView4, listView5, listView6, listView);
        }
    }
}
