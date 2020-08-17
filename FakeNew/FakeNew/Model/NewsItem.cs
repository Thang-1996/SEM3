using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeNew.Model
{
    public class NewsItem
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Headline { get; set; }
        public string Subhead { get; set; }
        public string DateLine { get; set; }
        public string Image { get; set; }
    }
    public class NewManager
    {
        public static List<NewsItem> getNewsItems()
        {
            var items = new List<NewsItem>();
            items.Add(new NewsItem() { Id = 1, Category = "Financial", Headline = "Lorem Ipsum", Subhead = "doro sit amet", DateLine = "Nunc tristique nec", Image = "Assets/Financial.png" });
            items.Add(new NewsItem() { Id = 2, Category = "Financial", Headline = "Etiam ac felis viverra", Subhead = "doro sit amet", DateLine = "Nunc tristique nec", Image = "Assets/Financial2.png" });
            items.Add(new NewsItem() { Id = 3, Category = "Financial", Headline = "Interger sed turpis erat", Subhead = "doro sit amet", DateLine = "Nunc tristique nec", Image = "Assets/Financia3.png" });
            items.Add(new NewsItem() { Id = 4, Category = "Financial", Headline = "Proin sem neque", Subhead = "doro sit amet", DateLine = "Nunc tristique nec", Image = "Assets/Financial4.png" });
            items.Add(new NewsItem() { Id = 5, Category = "Financial", Headline = "Mauris bibendum non leo vitea tempor", Subhead = "doro sit amet", DateLine = "Nunc tristique nec", Image = "Assets/Financial5.png" });
            items.Add(new NewsItem() { Id = 6, Category = "Food", Headline = "Mauris bibendum non leo vitea tempor", Subhead = "doro sit amet", DateLine = "Nunc tristique nec", Image = "Assets/Food1.png" });
            items.Add(new NewsItem() { Id = 7, Category = "Food", Headline = "Mauris bibendum non leo vitea tempor", Subhead = "doro sit amet", DateLine = "Nunc tristique nec", Image = "Assets/Food2.png" });
            items.Add(new NewsItem() { Id = 8, Category = "Food", Headline = "Mauris bibendum non leo vitea tempor", Subhead = "doro sit amet", DateLine = "Nunc tristique nec", Image = "Assets/Food3.png" });
            items.Add(new NewsItem() { Id = 9, Category = "Food", Headline = "Mauris bibendum non leo vitea tempor", Subhead = "doro sit amet", DateLine = "Nunc tristique nec", Image = "Assets/Food4.png" });
            items.Add(new NewsItem() { Id = 10, Category = "Food", Headline = "Mauris bibendum non leo vitea tempor", Subhead = "doro sit amet", DateLine = "Nunc tristique nec", Image = "Assets/Food5.png" });
            return items;
        }
        public static void GetNews(string category, ObservableCollection<NewsItem> newsItems)
        {
            var allItems = getNewsItems();
            var filteredNewsItems = allItems.Where(p => p.Category == category).ToList();
            newsItems.Clear();
            filteredNewsItems.ForEach(p => newsItems.Add(p));
        }
    }
}

