using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healox.PermissionServer.Domain.Model;

public partial class User
{
    public Guid Id { get; set; }

    public ICollection<Role> Roles { get; set; } = new List<Role>();
}
