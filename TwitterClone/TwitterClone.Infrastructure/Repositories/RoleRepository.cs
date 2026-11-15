using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly TwitterCloneDbContext _context;

        public RoleRepository(
            TwitterCloneDbContext context)
        {
            _context = context;
        }

        public void AddRolePermission(RolePermission rolePermission)
        {
            _context.RolePermissions.Add(rolePermission);
            _context.SaveChanges();
        }

        public Role? GetRoleByName(string name)
        {
            return _context.Roles.SingleOrDefault(r => r.Name == name);
        }

        public List<Role> GetRoles()
        {
            return _context.Roles.ToList();
        }
    }
}
