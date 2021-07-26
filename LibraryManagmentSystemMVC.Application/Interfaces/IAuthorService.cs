using LibraryManagmentSystemMVC.Application.ViewModel.AuthorVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Application.Interfaces
{
    public interface IAuthorService
    {
        List<AuthorsForListVm> GetAllActiveAuthors();
        AuthorDetailVm GetAuthorDetail(int id);
        NewAuthorVm GetAuthorForEdit(int id);
        void UpdateAuthor(NewAuthorVm model);
        int AddAuthor(NewAuthorVm newAuthorVm);
        void DeleteAuthor(NewAuthorVm newAuthorVm);
    }
}
