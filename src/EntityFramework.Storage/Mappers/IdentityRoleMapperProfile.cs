using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healox.PermissionServer.EntityFramework.Storage.Mappers;

internal class IdentityRoleMapperProfile : Profile
{
	public IdentityRoleMapperProfile()
	{
		CreateMap<Entities.IdentityRole, Domain.Model.IdentityRole>();
	}
}
