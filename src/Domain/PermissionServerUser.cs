using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healox.PermissionServer.Domain
{
    internal class PermissionServerUser
    {
        public Guid Id { get; set; }

        public virtual ICollection<PermissionServerIdentityRole> IdentityRoles { get; } = new List<PermissionServerIdentityRole>();
    }
}
