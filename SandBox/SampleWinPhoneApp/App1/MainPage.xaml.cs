using System;
using System.Windows;
using Windows.UI.Popups;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private async void Multiplication_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog dialog = new MessageDialog(ValueOfx.Text + "*" + ValueOfy.Text + "=" +
                (double.Parse(ValueOfx.Text) * double.Parse(ValueOfy.Text)).ToString());
            await dialog.ShowAsync();
        }

        private async void Devision_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog dialog = null;
            if (double.Parse(ValueOfy.Text) != 0.0)
            {
                dialog = new MessageDialog(ValueOfx.Text + "/" + ValueOfy.Text + "=" +
                   (double.Parse(ValueOfx.Text) / double.Parse(ValueOfy.Text)).ToString());
            }
            else
            {
                dialog = new MessageDialog("Нельзя делить на 0!");
            }
            await dialog.ShowAsync();
        }

        private async void Subtraction_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog dialog = new MessageDialog(ValueOfx.Text + "-" + ValueOfy.Text + "=" +
                (double.Parse(ValueOfx.Text) - double.Parse(ValueOfy.Text)).ToString());
            await dialog.ShowAsync();
        }

        private async void Summ_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog dialog = new MessageDialog(ValueOfx.Text + "+" + ValueOfy.Text + "=" +
               (double.Parse(ValueOfx.Text) + double.Parse(ValueOfy.Text)).ToString());
            await dialog.ShowAsync();
        }

    }
}
