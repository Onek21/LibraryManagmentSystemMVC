using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryManagmentSystemMVC.Application.Interfaces;
using LibraryManagmentSystemMVC.Application.ViewModel.UsersVm;
using LibraryManagmentSystemMVC.Domain.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public List<UserForListVm> GetUsers()
        {
            var users = _userManager.Users.ProjectTo<UserForListVm>(_mapper.ConfigurationProvider).ToList();
            return users;
        }

        public async Task<IdentityResult> AddUser(NewUserVm newUserVm)
        {
            var user = _mapper.Map<ApplicationUser>(newUserVm);
            var result = await _userManager.CreateAsync(user, newUserVm.Password);
            return result;
        }

        public List<RoleForListVm> GetRoles()
        {
            var roles = _roleManager.Roles.ProjectTo<RoleForListVm>(_mapper.ConfigurationProvider).ToList();
            return roles;
        }

        public async Task<IdentityResult> AddRole(NewRoleVm newRoleVm)
        {
            var role = _mapper.Map<IdentityRole>(newRoleVm);
            var result = await _roleManager.CreateAsync(role);
            return result;
        }

        public async Task<IdentityResult> EditUser(NewUserVm userToEdit)
        {
            var currentUser = await _userManager.FindByIdAsync(userToEdit.Id);
            CheckChangesInUserToEdit(currentUser, userToEdit);
            var result = await _userManager.UpdateAsync(currentUser);
            return result;
        }
        private void CheckChangesInUserToEdit(ApplicationUser currentUser, NewUserVm userToEdit)
        {
            if(currentUser.Email != userToEdit.Email)
            {
                currentUser.Email = userToEdit.Email;
            }
            if (currentUser.FirstName != userToEdit.FirstName)
            {
                currentUser.FirstName = userToEdit.FirstName;
            }
            if (currentUser.LastName != userToEdit.LastName)
            {
                currentUser.LastName = userToEdit.LastName;
            }
            if(userToEdit.IsLockout == true)
            {
                currentUser.LockoutEnd = DateTimeOffset.MaxValue;
            }
            else
            {
                currentUser.LockoutEnd = null;
            }
        }
        public async Task<IdentityResult> ResetPasword(NewUserVm newUser)
        {
            var user = await _userManager.FindByIdAsync(newUser.Id);
            await _userManager.RemovePasswordAsync(user);
            return await _userManager.AddPasswordAsync(user, newUser.Password);

        }

        private async Task<IdentityResult> AddRolesToUser(ApplicationUser user, List<string> roles)
        {
            return await _userManager.AddToRolesAsync(user, roles);
        }

        private async Task<IdentityResult> RemoveRolesFromUser(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user); 
            return await _userManager.RemoveFromRolesAsync(user, roles);
            
        }

        public async Task<IdentityResult> ChangeUserRoles(string id, List<string> roles)
        {
            var user = await _userManager.FindByIdAsync(id);
            await RemoveRolesFromUser(user);
            return await AddRolesToUser(user, roles);

        }
        
        public NewUserVm GetUserById(string id)
        {
            var user = _userManager.FindByIdAsync(id).Result;
            var userVm = _mapper.Map<NewUserVm>(user);
            userVm.UserRoles = GetRolesByUser(user.Id).ToList();
            userVm.Roles = GetRoles();
            return userVm;
        }

        private IQueryable<string> GetRolesByUser(string id)
        {
            var user = _userManager.FindByIdAsync(id).Result;
            var roles = _userManager.GetRolesAsync(user).Result.AsQueryable();
            return roles;
        }

        public async Task ResetPassword(NewUserVm newUserVm)
        {
            var user = await _userManager.FindByIdAsync(newUserVm.Id);
            await _userManager.RemovePasswordAsync(user);
            await _userManager.AddPasswordAsync(user, newUserVm.Password);
        }
    }
}
