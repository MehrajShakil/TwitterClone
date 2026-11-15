using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Domain.Entities
{
    public class Permission : BaseEntity
    {
        public Permission(Guid id) : base(id)
        {
        }

        public required string Name { get; set; }

        public List<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}
