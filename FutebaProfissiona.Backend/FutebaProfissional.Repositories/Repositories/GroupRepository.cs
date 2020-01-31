using FutebaProfissional.Repositories.Abstractions;
using FutebaProfissional.Repositories.Context;
using FutebaProfissional.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FutebaProfissional.Repositories.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly FutebaDbContext _futebaDbContext;

        public GroupRepository(FutebaDbContext futebaDbContext)
        {
            _futebaDbContext = futebaDbContext;
        }

        public IList<Group> GetAll()
        {
            return _futebaDbContext.Set<Group>().ToList();
        }

        public Group GetById(Guid id)
        {
            return _futebaDbContext.Groups.Where(g => g.Id == id).FirstOrDefault();
        }
    }
}
