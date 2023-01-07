using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healox.PermissionServer.EntityFramework.Storage.Mappers;

public static class UserMappers
{
    internal static IMapper Mapper { get; }

    static UserMappers()
    {
        Mapper = new MapperConfiguration(cfg => {
            cfg.AddProfile<UserMapperProfile>();
            cfg.AddProfile<RoleMapperProfile>();
            cfg.AddProfile<PermissionMapperProfile>();
        }).CreateMapper();
    }

    /// <summary>
    /// Maps an entity to a model.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns></returns>
    public static Domain.Model.User ToModel(this Entities.User entity)
    {
        return Mapper.Map<Domain.Model.User>(entity);
    }

    /// <summary>
    /// Maps a model to an entity.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    //public static Entities.User ToEntity(this Domain.Model.User model)
    //{
    //    return Mapper.Map<Entities.User>(model);
    //}

}
