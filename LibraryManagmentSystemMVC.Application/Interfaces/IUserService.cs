using LibraryManagmentSystemMVC.Application.ViewModel.UsersVm;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Application.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> AddUser(NewUserVm newUserVm);
        List<UserForListVm> GetUsers();
    }
}
