using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healox.PermissionServer.EntityFramework.Storage.Mappers;

public class PermissionMapperProfile : Profile
{
	public PermissionMapperProfile()
	{
		CreateMap<Entities.Permission, Domain.Model.Permission>();
	}
}
