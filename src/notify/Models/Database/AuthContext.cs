using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Notify.Models.Database;

public partial class AuthContext : DbContext
{
    public AuthContext()
    {
    }

    public AuthContext(DbContextOptions<AuthContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<RestrictedUserView> RestrictedUserViews { get; set; }
    public virtual DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("CONTACT_pkey");

            entity.ToTable("CONTACT");

            entity.Property(e => e.ContactId)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("contact_id");
            entity.Property(e => e.Data)
                .HasMaxLength(100)
                .HasColumnName("data");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .HasColumnName("type");
            entity.Property(e => e.UseInMsgSend)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("use_in_msg_send");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("CONTACT_user_id_fkey");
        });

        modelBuilder.Entity<RestrictedUserView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("RESTRICTED_USER_VIEW");

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
            entity.Property(e => e.UserId).HasColumnName("user_id");
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
