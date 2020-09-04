using PaperProject.Models;
using SQLite.Net;
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
        string path;
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
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.sqlite");
            connect = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            connect.CreateTable<Page>();
        }
        public async void Page_Loaded(object sender, RoutedEventArgs e)
        {
        /*    await ApplicationData.Current.LocalFolder.CreateFileAsync("sqliteSample.db", CreationCollisionOption.OpenIfExists);
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "sqliteSample.db");*/
            
            try
            {
                Home.IsSelected = true;
            }
            catch(Exception ex)
            {

            }
        }
        private void Add_Page(object sender, RoutedEventArgs e)
        {
            try
            {
                var page = connect.Insert(new Page()
                {
                    date = DateResult.Text,
                    image = ImageResult.Source.ToString(),
                    title = TitleResult.Text,
                    description = ContentResult1.Text,
                });
            }catch(Exception ex)
            {
         
            }
        }
        private async void ListBox_SelectionChanged(object sender,SelectionChangedEventArgs e)
        {
            if (Home.IsSelected)
            {
                RootObject myPage = await Paper.GetPaper();
                string image = String.Format(myPage.image);
                ImageResult.Source = new BitmapImage(new Uri(image, UriKind.Absolute));
                DateResult.Text = myPage.date;
                TitleResult.Text = myPage.title;
                string description = myPage.content.description;
                ContentResult1.Text = description;
                TitleTextBlock.Text = "Home";
                ImageResult.Visibility = Visibility.Visible;
                DateResult.Visibility = Visibility.Visible;
                TitleResult.Visibility = Visibility.Visible;
                ContentResult1.Visibility = Visibility.Visible;
                Button.Visibility = Visibility.Visible;
                Button2.Visibility = Visibility.Collapsed;
                LinkBookMark.Visibility = Visibility.Collapsed;
            }
            else if (Bookmark.IsSelected)
            {
                var querry = connect.Table<Page>();
                string link = "";
                foreach (var q in querry)
                {
                    link = "BookMark: " + q.title;
                }
                LinkBookMark.Text = link;
                LinkBookMark.Visibility = Visibility.Visible;
                ImageResult.Visibility = Visibility.Collapsed;
                DateResult.Visibility = Visibility.Collapsed;
                TitleResult.Visibility = Visibility.Collapsed;
                ContentResult1.Visibility = Visibility.Collapsed;
                Button.Visibility = Visibility.Collapsed;
                Button2.Visibility = Visibility.Visible;
                TitleTextBlock.Text = "Bookmark";
            }
        }
        private void HamburgerButton_Click(object sender,RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }
        private void BookMark_Click(object sender,RoutedEventArgs e)
        {
            Home.IsSelected = true;
        }
    }
}
