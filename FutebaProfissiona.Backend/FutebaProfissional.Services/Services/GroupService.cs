using AutoMapper;
using FutebaProfissional.Domain;
using FutebaProfissional.Repositories.Abstractions;
using FutebaProfissional.Repositories.Models;
using FutebaProfissional.Services.Abstractions;
using System;
using System.Collections.Generic;

namespace FutebaProfissional.Services
{
    public class GroupService : IGroupService
    {
        private readonly IMapper _mapper;
        private readonly IGroupRepository _repository;
        public GroupService(IMapper mapper, IGroupRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public IList<GroupViewModel> GetAll()
        {
            IList<Group> modelList = _repository.GetAll();
            return _mapper.Map<IList<GroupViewModel>>(modelList);
        }

        public GroupViewModel GetById(Guid id)
        {
            return _mapper.Map<GroupViewModel>(_repository.GetById(id));
        }
    }
}
