using AutoMapper;
using LibraryManagmentSystemMVC.Application.Mapping;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Application.ViewModel.UsersVm
{
    public class NewRoleVm : IMapFrom<IdentityRole>
    {
        public string Id { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewRoleVm, IdentityRole>().ReverseMap();
        }
    }



}
