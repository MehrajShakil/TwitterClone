using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Domain.Constants;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Persistence.SeedData
{
    public static class SeedData
    {
        public static Role[] Roles() 
        {
            return new Role[]
            {
                new Role(Guid.NewGuid()) { Name = RoleNames.Admin },
                new Role(Guid.NewGuid()) { Name = RoleNames.Moderator },
                new Role(Guid.NewGuid()) { Name = RoleNames.User },
            };
        }

        public static Permission[] Permissions()
        {
            return new Permission[]
            {
                new Permission(Guid.NewGuid()) { Name = PermissionNames.UsersRead },
                new Permission(Guid.NewGuid()) { Name = PermissionNames.UsersDelete },
                new Permission(Guid.NewGuid()) { Name = PermissionNames.RolesManage },
            };
        }

        public static RolePermission[] RolePermissions()
        {
            return new RolePermission[] 
            {
                // Admin: everything
                new RolePermission(Guid.NewGuid()) { RoleId = Guid.NewGuid(), PermissionId = Guid.NewGuid() },
                new RolePermission(Guid.NewGuid()){ RoleId = Guid.NewGuid(), PermissionId = Guid.NewGuid() },
                new RolePermission(Guid.NewGuid()) { RoleId = Guid.NewGuid(), PermissionId = Guid.NewGuid() },

                // Moderator: read and delete users
                new RolePermission(Guid.NewGuid()) { RoleId = Guid.NewGuid(), PermissionId = Guid.NewGuid() },
                new RolePermission(Guid.NewGuid()) { RoleId = Guid.NewGuid(), PermissionId = Guid.NewGuid() }
            };
        }
    }
}
