// <auto-generated />
using System;
using Healox.PermissionServer.EntityFramework.Storage.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Healox.PermissionServer.EntityFramework.Storage.SqlServer.Migrations.PermissionServerDb
{
    [DbContext(typeof(PermissionServerDbContext))]
    [Migration("20230107153318_PermissionServer")]
    partial class PermissionServer
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Healox.PermissionServer.EntityFramework.Storage.Entities.IdentityRole", b =>
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

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("XPKIdentityRoles");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"), false);

                    b.HasIndex("RoleId");

                    b.HasIndex(new[] { "Name" }, "XAKIdentityRoles_Name")
                        .IsUnique();

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex(new[] { "Name" }, "XAKIdentityRoles_Name"));

                    b.ToTable("IdentityRoles", (string)null);
                });

            modelBuilder.Entity("Healox.PermissionServer.EntityFramework.Storage.Entities.Permission", b =>
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

                    b.ToTable("Permissions", (string)null);
                });

            modelBuilder.Entity("Healox.PermissionServer.EntityFramework.Storage.Entities.Role", b =>
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

                    b.Property<Guid?>("ParentRoleId")
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

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("Healox.PermissionServer.EntityFramework.Storage.Entities.RolePermission", b =>
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

                    b.ToTable("RolePermissions", (string)null);
                });

            modelBuilder.Entity("Healox.PermissionServer.EntityFramework.Storage.Entities.User", b =>
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

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Healox.PermissionServer.EntityFramework.Storage.Entities.UserRole", b =>
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

                    b.ToTable("UserRoles", (string)null);
                });

            modelBuilder.Entity("Healox.PermissionServer.EntityFramework.Storage.Entities.IdentityRole", b =>
                {
                    b.HasOne("Healox.PermissionServer.EntityFramework.Storage.Entities.Role", "Role")
                        .WithMany("IdentityRoles")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("Roles_IdentityRoles");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Healox.PermissionServer.EntityFramework.Storage.Entities.Role", b =>
                {
                    b.HasOne("Healox.PermissionServer.EntityFramework.Storage.Entities.Role", "ParentRole")
                        .WithMany("ChildRoles")
                        .HasForeignKey("ParentRoleId")
                        .HasConstraintName("Roles_Roles");

                    b.Navigation("ParentRole");
                });

            modelBuilder.Entity("Healox.PermissionServer.EntityFramework.Storage.Entities.RolePermission", b =>
                {
                    b.HasOne("Healox.PermissionServer.EntityFramework.Storage.Entities.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .IsRequired()
                        .HasConstraintName("Permissions_RolePermissions");

                    b.HasOne("Healox.PermissionServer.EntityFramework.Storage.Entities.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Roles_RolePermissions");

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Healox.PermissionServer.EntityFramework.Storage.Entities.UserRole", b =>
                {
                    b.HasOne("Healox.PermissionServer.EntityFramework.Storage.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("Roles_UserRoles");

                    b.HasOne("Healox.PermissionServer.EntityFramework.Storage.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Users_UserRoles");

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Healox.PermissionServer.EntityFramework.Storage.Entities.Permission", b =>
                {
                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("Healox.PermissionServer.EntityFramework.Storage.Entities.Role", b =>
                {
                    b.Navigation("ChildRoles");

                    b.Navigation("IdentityRoles");

                    b.Navigation("RolePermissions");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Healox.PermissionServer.EntityFramework.Storage.Entities.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
