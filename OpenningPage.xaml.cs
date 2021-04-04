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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace JobApplicationProj3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OpenningPage : Page
    {
        private int playerChooserCount = 1;
        public OpenningPage()
        {
            this.InitializeComponent();
        }


        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage),this.playerChooserCount);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
        }

        private void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            switch(args.VirtualKey)
            {
                case Windows.System.VirtualKey.Left:
                    if(this.playerChooserCount==1)
                    {
                        this.playerChooserCount = 3;
                    }
                    else
                    {
                        this.playerChooserCount--;
                    }
                    switch(this.playerChooserCount)
                    {
                        case 1:
                            this.playerChooser.Source = new BitmapImage(new Uri("ms-appx:///Assets/C1/CDown/CDown2.png"));
                            break;
                        case 2:
                            this.playerChooser.Source = new BitmapImage(new Uri("ms-appx:///Assets/C2/CDown/CDown2.png"));
                            break;
                        case 3:
                            this.playerChooser.Source = new BitmapImage(new Uri("ms-appx:///Assets/C3/CDown/CDown2.png"));
                            break;
                    }
                    break;
                case Windows.System.VirtualKey.Right:
                    if (this.playerChooserCount == 3)
                    {
                        this.playerChooserCount = 1;
                    }
                    else
                    {
                        this.playerChooserCount++;
                    }
                    switch (this.playerChooserCount)
                    {
                        case 1:
                            this.playerChooser.Source = new BitmapImage(new Uri("ms-appx:///Assets/C1/CDown/CDown2.png"));
                            break;
                        case 2:
                            this.playerChooser.Source = new BitmapImage(new Uri("ms-appx:///Assets/C2/CDown/CDown2.png"));
                            break;
                        case 3:
                            this.playerChooser.Source = new BitmapImage(new Uri("ms-appx:///Assets/C3/CDown/CDown2.png"));
                            break;
                    }
                    break;
            }
        }
    }
}
