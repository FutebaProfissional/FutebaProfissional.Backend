using FutebaProfissional.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace FutebaProfissional.Services.Abstractions
{
    public interface IGroupService
    {
        public GroupViewModel GetById(Guid id);
        public IList<GroupViewModel> GetAll();
    }
}
