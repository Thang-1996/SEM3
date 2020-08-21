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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Get_Weather_Location
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        public async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var position = await LocationData.getPosition();
                var lat = position.Coordinate.Latitude;
                var lon = position.Coordinate.Longitude;
                APIManager.RootObject myWeather = await APIManager.GetWeather(lat, lon);
                string Icon = String.Format("Assets/Weather/{0}.png", myWeather.weather[0].icon);
                ResultImage.Source = new BitmapImage(new Uri(Icon,UriKind.Absolute));
                TempTextBlock.Text = ((double) myWeather.main.temp).ToString();
                DescriptionTextBlock.Text = myWeather.weather[0].description;
                LocationTextBlock.Text = myWeather.name;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
