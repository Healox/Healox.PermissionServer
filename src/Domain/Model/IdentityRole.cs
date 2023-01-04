using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healox.PermissionServer.Domain.Model;

public partial class IdentityRole
{
    public Guid Id { get; set; }

    // if you leave the field as non-nullable, the compiler will complain that it is not initialized by the constructors.
    // (you can suppress that with null!)
    // then the field can be used without null check.
    // null! is used to assign null to non-nullable variables
    // If you don't use null! in such cases, you'll have to use an exclamation mark every single time you read the variable.
    // which would be a hassle without benefit.
    public string Name { get; set; } = null!;

    public Role? Role { get; set; }

}
