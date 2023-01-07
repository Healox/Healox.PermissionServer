using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healox.PermissionServer.EntityFramework.Storage.Mappers;

public static class IdentityRoleMappers
{
    internal static IMapper Mapper { get; }

    static IdentityRoleMappers()
    {
        Mapper = new MapperConfiguration(cfg => {
            cfg.AddProfile<IdentityRoleMapperProfile>();
            cfg.AddProfile<RoleMapperProfile>();
            cfg.AddProfile<PermissionMapperProfile>();
        }).CreateMapper();
    }

    /// <summary>
    /// Maps an entity to a model.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns></returns>
    public static Domain.Model.IdentityRole ToModel(this Entities.IdentityRole entity)
    {
        return Mapper.Map<Domain.Model.IdentityRole>(entity);
    }

    /// <summary>
    /// Maps a model to an entity.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    //public static Entities.IdentityRole ToEntity(this Domain.Model.IdentityRole model)
    //{
    //    return Mapper.Map<Entities.IdentityRole>(model);
    //}

}
