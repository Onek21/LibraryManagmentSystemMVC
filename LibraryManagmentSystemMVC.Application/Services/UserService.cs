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
    }
}
