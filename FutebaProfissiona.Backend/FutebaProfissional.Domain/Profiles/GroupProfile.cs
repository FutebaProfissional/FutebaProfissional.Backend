using AutoMapper;
using FutebaProfissional.Repositories.Models;
using System.Collections.Generic;

namespace FutebaProfissional.Domain.Profiles
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {
            CreateMap<Group, GroupViewModel>();
            CreateMap<GroupViewModel, Group>();
            //CreateMap<IList<Group>, IList<GroupViewModel>>();
            //CreateMap<IList<GroupViewModel>, IList<Group>>();
        }
    }
}
