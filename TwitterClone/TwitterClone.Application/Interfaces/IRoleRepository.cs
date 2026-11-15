using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface IRoleRepository
    {
        Role? GetRoleByName(string name);
        List<Role> GetRoles();
        void AddRolePermission(RolePermission rolePermission);
    }
}
