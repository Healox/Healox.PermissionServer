using System;
using System.Collections.Generic;

namespace Healox.PermissionServer.EntityFramework.Storage.Entities;

public partial class User
{
    public Guid Id { get; set; }

    public string? Notes { get; set; }

    public byte[]? ConcurrencyStamp { get; set; }

    public virtual ICollection<UserRole> UserRoles { get; } = new List<UserRole>();
}
