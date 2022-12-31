﻿// <auto-generated />
using System;
using Healox.PermissionServer.EntityFramework.Storage.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Healox.PermissionServer.EntityFramework.Storage.SqlServer.Migrations.PermissionServerDb
{
    [DbContext(typeof(PermissionServerDbContext))]
    partial class PermissionServerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Healox.PermissionServer.Domain.Model.IdentityRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<byte[]>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Description")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id")
                        .HasName("XPKIdentityRoles");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"), false);

                    b.HasIndex(new[] { "Name" }, "XAKIdentityRoles_Name")
                        .IsUnique();

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex(new[] { "Name" }, "XAKIdentityRoles_Name"));

                    b.ToTable("IdentityRoles");
                });

            modelBuilder.Entity("Healox.PermissionServer.Domain.Model.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<byte[]>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Description")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id")
                        .HasName("XPKPermissions");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"), false);

                    b.HasIndex(new[] { "Name" }, "XAKPermissions_Name")
                        .IsUnique();

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex(new[] { "Name" }, "XAKPermissions_Name"));

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("Healox.PermissionServer.Domain.Model.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<byte[]>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Description")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("varchar(256)");

                    b.Property<Guid>("ParentRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(CONVERT([uniqueidentifier],'00000000-0000-0000-0000-000000000000'))");

                    b.HasKey("Id")
                        .HasName("XPKRoles");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"), false);

                    b.HasIndex("ParentRoleId");

                    b.HasIndex(new[] { "Name" }, "XAKRoles_Name")
                        .IsUnique();

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex(new[] { "Name" }, "XAKRoles_Name"));

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Healox.PermissionServer.Domain.Model.RoleMap", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<byte[]>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<Guid>("IdentityRoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("XPKRoleMaps");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"), false);

                    b.HasIndex("RoleId");

                    b.HasIndex(new[] { "IdentityRoleId" }, "XAKRoleMaps_IdentityRoleId")
                        .IsUnique();

                    b.HasIndex(new[] { "IdentityRoleId", "RoleId" }, "XAKRoleMaps_IdentityRoleId_RoleId")
                        .IsUnique();

                    b.ToTable("RoleMaps");
                });

            modelBuilder.Entity("Healox.PermissionServer.Domain.Model.RolePermission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<byte[]>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("XPKRolePermissions");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"), false);

                    b.HasIndex("PermissionId");

                    b.HasIndex(new[] { "RoleId", "PermissionId" }, "XAKRolePermissions_RoleId_PermissionId")
                        .IsUnique();

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex(new[] { "RoleId", "PermissionId" }, "XAKRolePermissions_RoleId_PermissionId"));

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("Healox.PermissionServer.Domain.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Notes")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.HasKey("Id")
                        .HasName("XPKUsers");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"), false);

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Healox.PermissionServer.Domain.Model.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<byte[]>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("XPKUserRoles");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"), false);

                    b.HasIndex("RoleId");

                    b.HasIndex(new[] { "UserId", "RoleId" }, "XAKUserRoles_UserId_RoleId")
                        .IsUnique();

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex(new[] { "UserId", "RoleId" }, "XAKUserRoles_UserId_RoleId"));

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Healox.PermissionServer.Domain.Model.Role", b =>
                {
                    b.HasOne("Healox.PermissionServer.Domain.Model.Role", "ParentRole")
                        .WithMany("InverseParentRole")
                        .HasForeignKey("ParentRoleId")
                        .IsRequired()
                        .HasConstraintName("Roles_Roles");

                    b.Navigation("ParentRole");
                });

            modelBuilder.Entity("Healox.PermissionServer.Domain.Model.RoleMap", b =>
                {
                    b.HasOne("Healox.PermissionServer.Domain.Model.IdentityRole", "IdentityRole")
                        .WithOne("RoleMap")
                        .HasForeignKey("Healox.PermissionServer.Domain.Model.RoleMap", "IdentityRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("IdentityRoles_RoleMaps");

                    b.HasOne("Healox.PermissionServer.Domain.Model.Role", "Role")
                        .WithMany("RoleMaps")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("Roles_RoleMaps");

                    b.Navigation("IdentityRole");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Healox.PermissionServer.Domain.Model.RolePermission", b =>
                {
                    b.HasOne("Healox.PermissionServer.Domain.Model.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .IsRequired()
                        .HasConstraintName("Permissions_RolePermissions");

                    b.HasOne("Healox.PermissionServer.Domain.Model.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Roles_RolePermissions");

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Healox.PermissionServer.Domain.Model.UserRole", b =>
                {
                    b.HasOne("Healox.PermissionServer.Domain.Model.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("Roles_UserRoles");

                    b.HasOne("Healox.PermissionServer.Domain.Model.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Users_UserRoles");

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Healox.PermissionServer.Domain.Model.IdentityRole", b =>
                {
                    b.Navigation("RoleMap");
                });

            modelBuilder.Entity("Healox.PermissionServer.Domain.Model.Permission", b =>
                {
                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("Healox.PermissionServer.Domain.Model.Role", b =>
                {
                    b.Navigation("InverseParentRole");

                    b.Navigation("RoleMaps");

                    b.Navigation("RolePermissions");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Healox.PermissionServer.Domain.Model.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
