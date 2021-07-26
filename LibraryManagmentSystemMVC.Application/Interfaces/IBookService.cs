using LibraryManagmentSystemMVC.Application.ViewModel.BookVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Application.Interfaces
{
     public interface IBookService
    {
        List<BookForListVm> GetAllActiveBooksForList();
        int AddBook();
        BookDetailsVm BookDetails(int id);
    }
}
