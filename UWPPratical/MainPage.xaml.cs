using SQLite.Net.Attributes;
using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization.PhoneNumberFormatting;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPPratical
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string path;
        SQLite.Net.SQLiteConnection connect;
        public class Contact
        {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            public string name { get; set; }
            [Unique]
            public string phonenumber { get; set;}
       
        }
        public MainPage()
        {
            this.InitializeComponent();
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.sqlite");
            connect = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            connect.CreateTable<Contact>();
        }
        public void Add_Contact(object sender,RoutedEventArgs e)
        {
            try
            {
                var querry = connect.Insert(new Contact()
                {
                    name = Name.Text,
                    phonenumber = Phone.Text,
                });
            }
            catch(Exception ex)
            {

            }
        }

        private void Show_Contact(object sender, RoutedEventArgs e)
        {
            var querry2 = connect.Table<Contact>();
            string Name = "";
            string PhoneNumber = "";
            foreach (var q in querry2)
            {
                Name = Name + " " + q.name;
                PhoneNumber = PhoneNumber + " " + q.phonenumber;
            }
            Result.Text = "Name: " + Name + "\nPhoneNumber: " + PhoneNumber;
        }
        private void Search_Contact(object sender,RoutedEventArgs e)
        {
            string name = Name.Text;
            string phonenumber = Phone.Text; 
            var querry = connect.Query<Contact>("" +
                "Select * from Contact where name like ? and phonenumber like ?",name,phonenumber);
            string Name1 = "";
            string PhoneNumber1 = "";
            foreach (var q in querry)
            {
                Name1 = Name1 + " " + q.name;
                PhoneNumber1 = PhoneNumber1 + " " + q.phonenumber;
            }
            Result.Text = "Name: " + Name1 + "\nPhoneNumber: " + PhoneNumber1;
        }
    }
}
