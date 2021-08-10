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
        Task<IdentityResult> AddRole(NewRoleVm newRoleVm);
        Task<IdentityResult> AddUser(NewUserVm newUserVm);
        Task ChangeUserRoles(string id, List<string> roles);
        Task<IdentityResult> EditUser(NewUserVm newUserVm);
        List<RoleForListVm> GetRoles();
        NewUserVm GetUserById(string id);
        List<UserForListVm> GetUsers();
        Task ResetPassword(NewUserVm newUserVm);
    }
}
