using System;
using System.Collections.Generic;

namespace Healox.PermissionServer.EntityFramework.Storage.Entities;

public partial class Role
{
    public Guid Id { get; set; }

    // if you leave the field as non-nullable, the compiler will complain that it is not initialized by the constructors.
    // (you can suppress that with null!)
    // then the field can be used without null check.
    // null! is used to assign null to non-nullable variables
    // If you don't use null! in such cases, you'll have to use an exclamation mark every single time you read the variable.
    // which would be a hassle without benefit.
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public Guid? ParentRoleId { get; set; }

    public byte[]? ConcurrencyStamp { get; set; }

    public virtual ICollection<IdentityRole> IdentityRoles { get; } = new List<IdentityRole>();

    public virtual ICollection<Role> ChildRoles { get; } = new List<Role>();

    public virtual Role? ParentRole { get; set; }

    public virtual ICollection<RolePermission> RolePermissions { get; } = new List<RolePermission>();

    public virtual ICollection<UserRole> UserRoles { get; } = new List<UserRole>();
}
