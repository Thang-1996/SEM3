using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.WindowManagement;
using DataBinding_Example.Models;

namespace DataBinding_Example.ViewModels
{
    public class MainPageViewModel
    {
        public MainPageViewModel()
        {
            for (int i = 0; i < 100; i++)
            {
                var item = new Models.TodoItem()
                {
                    Title = string.Format("Task Title {0}",i)
                };
                this.Items.Add(item);
            } ;
        }
        public ObservableCollection<Models.TodoItem> Items { get; private set; } = new ObservableCollection<Models.TodoItem>();
    }
}
