using PaperProject.Models;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using static PaperProject.Models.Paper;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PaperProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        SQLite.Net.SQLiteConnection connect;
        public class Page
        {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            public string image { get; set; }
            public string date { get; set; }
            public string description { get; set; }
            public string title { get; set; }
        }
        public MainPage()
        {
            this.InitializeComponent();
             /*string path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path,"db.sqlite");
          // string path = "ms-appdata:///local/db1.sqlite";
            connect = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            connect.CreateTable<Page>();*/
        }
        public async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, "db.sqlite");

            //  string path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.sqlite");
            // string path = "ms-appdata:///local/db1.sqlite";
            connect = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            connect.CreateTable<Page>();
            try
            {
                RootObject myPage = await Paper.GetPaper();
                string image = String.Format(myPage.image);
                ImageResult.Source = new BitmapImage(new Uri(image, UriKind.Absolute));
                DateResult.Text = myPage.date;
                TitleResult.Text = myPage.title;
                string description = myPage.content.description;
                ContentResult1.Text = description;

            }
            catch(Exception ex)
            {

            }
        }
        private void Add_Page(object sender, RoutedEventArgs e)
        {
            var page = connect.Insert(new Page()
            {
                date = DateResult.Text,
                image = ImageResult.Source.ToString(),
                title = TitleResult.Text ,
                description = ContentResult1.Text ,
            });

        }
    }
}
