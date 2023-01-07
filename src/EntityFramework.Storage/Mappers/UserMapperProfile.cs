using AutoMapper;
using Healox.PermissionServer.Domain.Model;
using Healox.PermissionServer.EntityFramework.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healox.PermissionServer.EntityFramework.Storage.Mappers;

public class UserMapperProfile : Profile
{
	public UserMapperProfile()
	{
		CreateMap<Entities.User, Domain.Model.User>()
			.ForMember(u => u.Roles, x => x.MapFrom(y => y.UserRoles.Select(z => z.Role)));
	}
}
