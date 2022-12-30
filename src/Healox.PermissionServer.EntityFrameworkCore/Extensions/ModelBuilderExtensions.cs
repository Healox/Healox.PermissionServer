using Healox.PermissionServer.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healox.PermissionServer.EntityFrameworkCore.Options;

namespace Healox.PermissionServer.EntityFrameworkCore.Extensions
{
    public static class ModelBuilderExtensions
    {
        private static EntityTypeBuilder<TEntity> ToTable<TEntity>(this EntityTypeBuilder<TEntity> entityTypeBuilder, TableConfiguration configuration)
    where TEntity : class
        {
            return string.IsNullOrWhiteSpace(configuration.Schema) ? entityTypeBuilder.ToTable(configuration.Name) : entityTypeBuilder.ToTable(configuration.Name, configuration.Schema);
        }

        public static void ConfigurePermissionServerContext(this ModelBuilder modelBuilder, PermissionServerStoreOptions storeOptions)
        {
            if (!string.IsNullOrWhiteSpace(storeOptions.DefaultSchema)) modelBuilder.HasDefaultSchema(storeOptions.DefaultSchema);

            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("XPKIdentityRoles")
                    .IsClustered(false);

                entity.HasIndex(e => e.Name, "XAKIdentityRoles_Name")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.ConcurrencyStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Description).IsUnicode(false);
                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("XPKPermissions")
                    .IsClustered(false);

                entity.HasIndex(e => e.Name, "XAKPermissions_Name")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.ConcurrencyStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Description).IsUnicode(false);
                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("XPKRoles")
                    .IsClustered(false);

                entity.HasIndex(e => e.Name, "XAKRoles_Name")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.ConcurrencyStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Description).IsUnicode(false);
                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsUnicode(false);
                entity.Property(e => e.ParentRoleId).HasDefaultValueSql("(CONVERT([uniqueidentifier],'00000000-0000-0000-0000-000000000000'))");

                entity.HasOne(d => d.ParentRole).WithMany(p => p.InverseParentRole)
                    .HasForeignKey(d => d.ParentRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Roles_Roles");
            });

            modelBuilder.Entity<RoleMap>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("XPKRoleMaps")
                    .IsClustered(false);

                entity.HasIndex(e => e.IdentityRoleId, "XAKRoleMaps_IdentityRoleId").IsUnique();

                entity.HasIndex(e => new { e.IdentityRoleId, e.RoleId }, "XAKRoleMaps_IdentityRoleId_RoleId").IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.ConcurrencyStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.IdentityRole).WithOne(p => p.RoleMap)
                    .HasForeignKey<RoleMap>(d => d.IdentityRoleId)
                    .HasConstraintName("IdentityRoles_RoleMaps");

                entity.HasOne(d => d.Role).WithMany(p => p.RoleMaps)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Roles_RoleMaps");
            });

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("XPKRolePermissions")
                    .IsClustered(false);

                entity.HasIndex(e => new { e.RoleId, e.PermissionId }, "XAKRolePermissions_RoleId_PermissionId")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.ConcurrencyStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Permission).WithMany(p => p.RolePermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Permissions_RolePermissions");

                entity.HasOne(d => d.Role).WithMany(p => p.RolePermissions)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("Roles_RolePermissions");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("XPKUsers")
                    .IsClustered(false);

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.ConcurrencyStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();
                entity.Property(e => e.Notes).IsUnicode(false);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("XPKUserRoles")
                    .IsClustered(false);

                entity.HasIndex(e => new { e.UserId, e.RoleId }, "XAKUserRoles_UserId_RoleId")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.ConcurrencyStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Roles_UserRoles");

                entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("Users_UserRoles");
            });
        }
    }
}
