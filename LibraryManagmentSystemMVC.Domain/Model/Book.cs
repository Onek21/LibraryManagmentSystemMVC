using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Domain.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PublishingHouse { get; set; }
        public DateTime RealseDate { get; set; }
        public int Quanity { get; set; }
        public int QuantityOnState { get; set; }
        public bool IsActive { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }
        public ICollection<BookGenre> BookGeners { get; set; }
    }
}
