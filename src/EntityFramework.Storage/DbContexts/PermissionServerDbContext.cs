using System;
using System.Collections.Generic;
using Healox.PermissionServer.EntityFramework.Storage.Entities;
using Healox.PermissionServer.EntityFramework.Storage.Extensions;
using Healox.PermissionServer.EntityFramework.Storage.Interfaces;
using Healox.PermissionServer.EntityFramework.Storage.Options;
using Microsoft.EntityFrameworkCore;


namespace Healox.PermissionServer.EntityFramework.Storage.DbContexts
{
    public /*partial*/ class PermissionServerDbContext : PermissionServerDbContext<PermissionServerDbContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionServerDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="storeOptions">The store options.</param>
        /// <exception cref="ArgumentNullException">storeOptions</exception>
        public PermissionServerDbContext(DbContextOptions<PermissionServerDbContext> options, PermissionServerStoreOptions storeOptions)
            : base(options, storeOptions)
        {
        }
    }

    public /*partial*/ class PermissionServerDbContext<TContext> : DbContext, IPermissionServerDbContext
         where TContext : DbContext, IPermissionServerDbContext
    {
        private readonly PermissionServerStoreOptions storeOptions;

        public PermissionServerDbContext(DbContextOptions<TContext> options, PermissionServerStoreOptions storeOptions)
        : base(options)
        {
            this.storeOptions = storeOptions ?? throw new ArgumentNullException(nameof(storeOptions));
        }

        //public PermissionServerDbContext()
        //{
        //}

        //public PermissionServerDbContext(DbContextOptions<PermissionServerDbContext> options)
        //    : base(options)
        //{
        //}

        public virtual DbSet<IdentityRole> IdentityRoles { get; set; }

        public virtual DbSet<Permission> Permissions { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<RolePermission> RolePermissions { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<UserRole> UserRoles { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//            => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=PermissionServerDb;Trusted_Connection=SSPI;TrustServerCertificate=true");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigurePermissionServerContext(storeOptions);

            //OnModelCreatingPartial(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}