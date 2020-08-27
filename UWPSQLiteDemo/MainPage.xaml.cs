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
using SQLite.Net;
using SQLite.Net.Attributes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPSQLiteDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    { 
        string path;
        public class Customer
        {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            public string Name { get; set; }
            public string Age { get; set; }
        }
        SQLite.Net.SQLiteConnection conn;
        public MainPage()
        {
            this.InitializeComponent();
             path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.sqlite");
             conn =
                new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
             conn.CreateTable<Customer>();
       /*     conn.Insert(new Customer()
            {
                Name = textBox.Text,
                Age = textBox1.Text,
            });
            var querry = conn.Table<Customer>();
            string id = "";
            string name = "";
            string age = "";
            foreach (var message in querry)
            {
                id = id + " " + message.Id;
                name = name + " " + message.Name;
                age = age + " " + message.Age;
            }*/
        }

        private void Retrieve_Click(object sender, RoutedEventArgs e)
        {
            var querry = conn.Table<Customer>();
            string id = "";
            string name = "";
            string age = "";
            foreach (var message in querry)
            {
                id = id + " " + message.Id;
                name = name + " " + message.Name;
                age = age + " " + message.Age;
            }

            textBlock2.Text = "ID:" + id + "\nName:" + name + "\nAge:" + age;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var s = conn.Insert(new Customer()
            {
                Name = textBox.Text,
                Age = textBox1.Text,
            });
        }
    }
}
