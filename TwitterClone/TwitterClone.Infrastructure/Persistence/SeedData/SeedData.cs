using System;
using TwitterClone.Domain.Constants;

namespace TwitterClone.Infrastructure.Persistence.SeedData
{
    // Seed data must be deterministic: fixed IDs and a fixed CreatedAt.
    // Guid.NewGuid() or DateTime.UtcNow here makes foreign keys point at rows
    // that don't exist and makes EF regenerate the seed in every migration.
    // Anonymous objects are used because BaseEntity.CreatedAt has a private setter.
    public static class SeedData
    {
        private static readonly DateTime SeedCreatedAt = new DateTime(2026, 11, 23, 0, 0, 0, DateTimeKind.Utc);

        // Roles
        public static readonly Guid AdminRoleId = new Guid("dc85b434-de09-44e5-9ed1-5886e21421ae");
        public static readonly Guid ModeratorRoleId = new Guid("784c2c7c-f2a0-4050-b3f7-0b20e21d46e3");
        public static readonly Guid UserRoleId = new Guid("b6bbbcd6-0705-4373-bd09-d7df25cca2df");

        // Permissions
        public static readonly Guid UsersReadPermissionId = new Guid("9f073bd3-26f4-45a7-92bc-3acac0bfe715");
        public static readonly Guid UsersDeletePermissionId = new Guid("3150d14e-1881-4b28-a637-85b070c77f07");
        public static readonly Guid RolesManagePermissionId = new Guid("3f4a3310-b7e6-4680-94da-9f37833b4113");

        public static object[] Roles()
        {
            return new object[]
            {
                new { Id = AdminRoleId, Name = RoleNames.Admin, CreatedAt = SeedCreatedAt, CreatedBy = Guid.Empty },
                new { Id = ModeratorRoleId, Name = RoleNames.Moderator, CreatedAt = SeedCreatedAt, CreatedBy = Guid.Empty },
                new { Id = UserRoleId, Name = RoleNames.User, CreatedAt = SeedCreatedAt, CreatedBy = Guid.Empty },
            };
        }

        public static object[] Permissions()
        {
            return new object[]
            {
                new { Id = UsersReadPermissionId, Name = PermissionNames.UsersRead, CreatedAt = SeedCreatedAt, CreatedBy = Guid.Empty },
                new { Id = UsersDeletePermissionId, Name = PermissionNames.UsersDelete, CreatedAt = SeedCreatedAt, CreatedBy = Guid.Empty },
                new { Id = RolesManagePermissionId, Name = PermissionNames.RolesManage, CreatedAt = SeedCreatedAt, CreatedBy = Guid.Empty },
            };
        }

        public static object[] RolePermissions()
        {
            return new object[]
            {
                // Admin: everything
                new { Id = new Guid("0985ea89-e859-421c-ac32-d25ae956464e"), RoleId = AdminRoleId, PermissionId = UsersReadPermissionId, CreatedAt = SeedCreatedAt, CreatedBy = Guid.Empty },
                new { Id = new Guid("1401901b-3fe6-4e3f-9854-9c31338de432"), RoleId = AdminRoleId, PermissionId = UsersDeletePermissionId, CreatedAt = SeedCreatedAt, CreatedBy = Guid.Empty },
                new { Id = new Guid("3850ecbd-8ed0-4f76-a437-e566fd5ed490"), RoleId = AdminRoleId, PermissionId = RolesManagePermissionId, CreatedAt = SeedCreatedAt, CreatedBy = Guid.Empty },

                // Moderator: read and delete users
                new { Id = new Guid("9f09f2e7-1255-4c97-8a05-3369f1b6290f"), RoleId = ModeratorRoleId, PermissionId = UsersReadPermissionId, CreatedAt = SeedCreatedAt, CreatedBy = Guid.Empty },
                new { Id = new Guid("dbf270d8-faf9-4f66-a180-72f543824190"), RoleId = ModeratorRoleId, PermissionId = UsersDeletePermissionId, CreatedAt = SeedCreatedAt, CreatedBy = Guid.Empty },
            };
        }
    }
}
