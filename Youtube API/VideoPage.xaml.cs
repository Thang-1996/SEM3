using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using MyToolkit.Multimedia;
using Youtube_API.Models;
using YoutubeExtractor;
using Video = Youtube_API.Models.Video;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Youtube_API
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class VideoPage : Page
    {
        Video video;
        public VideoPage()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                if (NetworkInterface.GetIsNetworkAvailable())
                {
                    video = e.Parameter as Video;
                    YouTubeUri url = await MyToolkit.Multimedia.YouTube.GetVideoUriAsync(video.Id,YouTubeQuality.Quality1080P);
                    Player.Source = url.Uri;
                    Player.Play();
                }
                else
                {
                    MessageDialog message = new MessageDialog("you are not connect to internet");
                    await message.ShowAsync();
                    this.Frame.GoBack();
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            base.OnNavigatedTo(e);
        }

        private void btnHomePage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), new object());
        }
    }
}
