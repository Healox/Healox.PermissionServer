using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healox.PermissionServer.Domain;

internal class PermissionServerRole
{
    public string Name { get; set; } = null!;

    public IEnumerable<PermissionServerPermission> Permissions { get; set; } = new List<PermissionServerPermission>();
}
