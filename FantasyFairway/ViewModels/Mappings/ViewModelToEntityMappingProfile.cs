using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FantasyFairway.Models;
using Microsoft.AspNetCore.Identity;

namespace FantasyFairway.ViewModels.Mappings
{
    public class ViewModelToEntityMappingProfile : Profile
    {
        public ViewModelToEntityMappingProfile()
        {
            CreateMap<RegistrationViewModel, IdentityUser>()
                .ForMember(au => au.UserName, map => map.MapFrom(vm => vm.Username))
                .ForMember(au => au.Email, map => map.MapFrom(vm => vm.Email))
                .ForMember(au => au.Id, map=> map.MapFrom(vm => vm.Email))
                .ForAllOtherMembers(option => option.Ignore());
            
            CreateMap<ProfileUpateViewModel, AppUser>()
                .ForMember(au => au.FullName, map => map.MapFrom(vm => vm.FirstName + " " + vm.LastName))
                .ForAllMembers(option=> option.Ignore());
        }
    }
}
