using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Domain.Entities
{
    public class Role : BaseEntity
    {
        public Role(Guid id) : base(id)
        {
        }

        public required string Name { get; set; }

        public List<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public List<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}
