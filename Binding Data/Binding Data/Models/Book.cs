using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binding_Data.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string CoverImage { get; set; }
    }
    public class BookManager
    {
        public static List<Book> GetBooks()
        {
            var books = new List<Book>();
            books.Add(new Book { BookID = 1, Title = "Vulpate", Author = "Futurum", CoverImage = "Assets/1.png" });
            books.Add(new Book { BookID = 2, Title = "Mazim", Author = "Sequiter Que", CoverImage = "Assets/2.png" });
            books.Add(new Book { BookID = 3, Title = "Elit", Author = "Tempor", CoverImage = "Assets/3.png" });
            books.Add(new Book { BookID = 4, Title = "Etiam", Author = "Option", CoverImage = "Assets/4.png" });
            books.Add(new Book { BookID = 5, Title = "Feugait Eros Libez", Author = "Accumsan", CoverImage = "Assets/5.png" });
            books.Add(new Book { BookID = 6, Title = "Nonummy Erat", Author = "Legunt Xaeplus", CoverImage = "Assets/6.png" });
            books.Add(new Book { BookID = 7, Title = "Nostrud", Author = "Eleifend", CoverImage = "Assets/7.png" });
            books.Add(new Book { BookID = 8, Title = "Per Modo", Author = "Vero Tation", CoverImage = "Assets/8.png" });
            books.Add(new Book { BookID = 9, Title = "Suscipit Ad", Author = "Jack Tation", CoverImage = "Assets/9.png" });
            books.Add(new Book { BookID = 10, Title = "Decima", Author = "Tuffy Tibbles", CoverImage = "Assets/10.png" });
            books.Add(new Book { BookID = 11, Title = "Erat", Author = "Volopat", CoverImage = "Assets/11.png" });
            books.Add(new Book { BookID = 12, Title = "Consequat", Author = "Est Possim", CoverImage = "Assets/12.png" });
            books.Add(new Book { BookID = 13, Title = "Aliquip", Author = "Magna", CoverImage = "Assets/13.png" });
            return books;
        }
    }
}
