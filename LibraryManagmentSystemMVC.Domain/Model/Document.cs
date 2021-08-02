using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Domain.Model
{
    public class Document
    {
        public int Id { get; set; }
        public string DocumentNumber { get; set; }
        public int Quantity { get; set; }
        public int Type { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }

    }
}
