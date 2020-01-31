using FutebaProfissional.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FutebaProfissional.Repositories.Abstractions
{
    public interface IGroupRepository : IRepository<Group>
    {
        public Group GetById(Guid id);
        public IList<Group> GetAll();
    }
}
