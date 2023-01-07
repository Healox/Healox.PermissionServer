using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healox.PermissionServer.EntityFramework.Storage.Mappers;

public class RoleMapperProfile : Profile
{
	public RoleMapperProfile()
	{
		CreateMap<Entities.Role, Domain.Model.Role>()
			.ForMember(r => r.Permissions, p => p.MapFrom(r => r.RolePermissions.Select(rp => rp.Permission)));
	}
}
