using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Auth.Models.ORM;

public partial class AuthContext : DbContext
{
    public AuthContext()
    {
    }

    public AuthContext(DbContextOptions<AuthContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Auth> Auths { get; set; }

    public virtual DbSet<Picture> Pictures { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<Auth>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("AUTH_pkey");

            entity.ToTable("AUTH");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("id");
            entity.Property(e => e.Cookie)
                .HasMaxLength(255)
                .HasColumnName("cookie");
            entity.Property(e => e.Device)
                .HasMaxLength(255)
                .HasColumnName("device");
            entity.Property(e => e.Expire)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("expire");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .HasColumnName("type");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Auths)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("AUTH_user_id_fkey");
        });

        modelBuilder.Entity<Picture>(entity =>
        {
            entity.HasKey(e => e.PicId).HasName("PICTURE_pkey");

            entity.ToTable("PICTURE");

            entity.Property(e => e.PicId)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("pic_id");
            entity.Property(e => e.IsAvatar)
                .HasDefaultValueSql("false")
                .HasColumnName("is_avatar");
            entity.Property(e => e.Path)
                .HasMaxLength(255)
                .HasColumnName("path");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Pictures)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("PICTURE_user_id_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("USER_pkey");

            entity.ToTable("USER");

            entity.Property(e => e.UserId)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("user_id");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.Lastname)
                .HasMaxLength(35)
                .HasColumnName("lastname");
            entity.Property(e => e.Middlename)
                .HasMaxLength(35)
                .HasColumnName("middlename");
            entity.Property(e => e.Name)
                .HasMaxLength(35)
                .HasColumnName("name");
            entity.Property(e => e.NickName)
                .HasMaxLength(35)
                .HasColumnName("nick_name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
