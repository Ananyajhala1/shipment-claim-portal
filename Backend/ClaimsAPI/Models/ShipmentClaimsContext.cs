using System;
using System.Collections.Generic;
using ClaimsAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClaimsAPI.Models;

public partial class ShipmentClaimsContext : DbContext
{
    public ShipmentClaimsContext()
    {
    }

    public ShipmentClaimsContext(DbContextOptions<ShipmentClaimsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Claim> Claims { get; set; }

    public virtual DbSet<ClaimDocument> ClaimDocuments { get; set; }

    public virtual DbSet<ClaimDocumentType> ClaimDocumentTypes { get; set; }

    public virtual DbSet<ClaimEmail> ClaimEmails { get; set; }

    public virtual DbSet<ClaimSetting> ClaimSettings { get; set; }

    public virtual DbSet<ClaimStatus> ClaimStatuses { get; set; }

    public virtual DbSet<ClaimSubStatus> ClaimSubStatuses { get; set; }

    public virtual DbSet<ClaimTask> ClaimTasks { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<CompanyType> CompanyTypes { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolePermission> RolePermissions { get; set; }

    public virtual DbSet<UserCredential> UserCredentials { get; set; }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<UserTemplate> UserTemplates { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("StudyConnection"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Claim>(entity =>
        {
            entity.HasKey(e => e.ClaimId).HasName("PK__Claims__EF2E139BEED6F785");

            entity.Property(e => e.ClaimId).ValueGeneratedNever();

            entity.HasOne(d => d.Carrier).WithMany(p => p.ClaimCarriers)
                .HasForeignKey(d => d.CarrierId)
                .HasConstraintName("FK__Claims__CarrierI__2334397B");

            entity.HasOne(d => d.Customer).WithMany(p => p.ClaimCustomers)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Claims__Customer__22401542");

            entity.HasOne(d => d.Insurance).WithMany(p => p.ClaimInsurances)
                .HasForeignKey(d => d.InsuranceId)
                .HasConstraintName("FK__Claims__Insuranc__24285DB4");
        });

        modelBuilder.Entity<ClaimDocument>(entity =>
        {
            entity.HasKey(e => e.DocId).HasName("PK__ClaimDoc__3EF188ADD5E2C10D");

            entity.Property(e => e.DocId).ValueGeneratedNever();

            entity.HasOne(d => d.Claim).WithMany(p => p.ClaimDocuments)
                .HasForeignKey(d => d.ClaimId)
                .HasConstraintName("FK__ClaimDocu__Claim__32767D0B");

            entity.HasOne(d => d.DocType).WithMany(p => p.ClaimDocuments)
                .HasForeignKey(d => d.DocTypeId)
                .HasConstraintName("FK__ClaimDocu__DocTy__336AA144");
        });

        modelBuilder.Entity<ClaimDocumentType>(entity =>
        {
            entity.HasKey(e => e.DocTypeId).HasName("PK__ClaimDoc__055E26A31B22F169");

            entity.Property(e => e.DocTypeId).ValueGeneratedNever();

            entity.HasOne(d => d.Company).WithMany(p => p.ClaimDocumentTypes)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__ClaimDocu__Compa__2F9A1060");
        });

        modelBuilder.Entity<ClaimEmail>(entity =>
        {
            entity.HasKey(e => e.EmailId).HasName("PK__ClaimEma__7ED91ACF6B40FC40");

            entity.ToTable("ClaimEmail");

            entity.Property(e => e.EmailId).HasMaxLength(100);

            entity.HasOne(d => d.From).WithMany(p => p.ClaimEmails)
                .HasForeignKey(d => d.FromId)
                .HasConstraintName("FK__ClaimEmai__FromI__40C49C62");

            entity.HasOne(d => d.Recepient).WithMany(p => p.ClaimEmails)
                .HasForeignKey(d => d.RecepientId)
                .HasConstraintName("FK__ClaimEmai__Recep__3FD07829");
        });

        modelBuilder.Entity<ClaimSetting>(entity =>
        {
            entity.HasKey(e => e.SettingsId).HasName("PK__ClaimSet__991B19FCA4542E3A");

            entity.Property(e => e.SettingsId).ValueGeneratedNever();

            entity.HasOne(d => d.Claim).WithMany(p => p.ClaimSettings)
                .HasForeignKey(d => d.ClaimId)
                .HasConstraintName("FK__ClaimSett__Claim__36470DEF");

            entity.HasOne(d => d.Company).WithMany(p => p.ClaimSettings)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__ClaimSett__Compa__373B3228");

            entity.HasOne(d => d.Doc).WithMany(p => p.ClaimSettings)
                .HasForeignKey(d => d.DocId)
                .HasConstraintName("FK__ClaimSett__DocId__382F5661");
        });

        modelBuilder.Entity<ClaimStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__ClaimSta__C8EE2063894A3CD7");

            entity.ToTable("ClaimStatus");

            entity.Property(e => e.StatusDesc).HasMaxLength(255);

            entity.HasOne(d => d.Claim).WithMany(p => p.ClaimStatuses)
                .HasForeignKey(d => d.ClaimId)
                .HasConstraintName("FK__ClaimStat__Claim__28ED12D1");
        });

        modelBuilder.Entity<ClaimSubStatus>(entity =>
        {
            entity.HasKey(e => e.SubStatusId).HasName("PK__ClaimSub__F306D2829ADFDBC9");

            entity.ToTable("ClaimSubStatus");

            entity.Property(e => e.SubStatusId).ValueGeneratedNever();

            entity.HasOne(d => d.Company).WithMany(p => p.ClaimSubStatuses)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__ClaimSubS__Compa__2CBDA3B5");

            entity.HasOne(d => d.Status).WithMany(p => p.ClaimSubStatuses)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__ClaimSubS__Statu__2BC97F7C");
        });

        modelBuilder.Entity<ClaimTask>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__ClaimTas__7C6949B112200E21");

            entity.ToTable("ClaimTask");

            entity.Property(e => e.TaskId).ValueGeneratedNever();
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Claim).WithMany(p => p.ClaimTasks)
                .HasForeignKey(d => d.ClaimId)
                .HasConstraintName("FK__ClaimTask__Claim__3CF40B7E");

            entity.HasOne(d => d.User).WithMany(p => p.ClaimTasks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__ClaimTask__UserI__3BFFE745");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__Company__2D971CACF743771C");

            entity.ToTable("Company");

            entity.Property(e => e.CompanyId).ValueGeneratedNever();
            entity.Property(e => e.CompanyName).HasMaxLength(100);
            entity.Property(e => e.ParentCompanyId).HasColumnName("parentCompanyID");

            entity.HasOne(d => d.ParentCompany).WithMany(p => p.InverseParentCompany)
                .HasForeignKey(d => d.ParentCompanyId)
                .HasConstraintName("fk_parentCompanyID");
        });

        modelBuilder.Entity<CompanyType>(entity =>
        {
            entity.HasKey(e => e.CompanyTypeId).HasName("PK__CompanyT__060198D8A1D4A768");

            entity.ToTable("CompanyType");

            entity.Property(e => e.CompanyType1)
                .HasMaxLength(100)
                .HasColumnName("CompanyType");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK__Contacts__5C66259B370A1B89");

            entity.Property(e => e.ContactId).ValueGeneratedNever();
            entity.Property(e => e.ContactName).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);

            entity.HasOne(d => d.Company).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_Contacts_Company");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Location__E7FEA497C6C5850D");

            entity.Property(e => e.LocationId).ValueGeneratedNever();
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.State).HasMaxLength(100);
            entity.Property(e => e.Zipcode).HasColumnName("ZIPCODE");

            entity.HasOne(d => d.Company).WithMany(p => p.Locations)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__Locations__Compa__0B5CAFEA");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.PermissionId).HasName("PK__Permissi__EFA6FB2FD4759282");

            entity.ToTable("Permission");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1A0584B742");

            entity.Property(e => e.RoleName).HasMaxLength(100);
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RolePerm__3214EC27F044DAC2");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.Permission).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.PermissionId)
                .HasConstraintName("FK__RolePermi__Permi__1A9EF37A");

            entity.HasOne(d => d.Role).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__RolePermi__RoleI__19AACF41");
        });

        modelBuilder.Entity<UserCredential>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserCred__1788CC4C9C544469");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.Password)
                .HasColumnType("text")
                .HasColumnName("password");
            entity.Property(e => e.UserName).HasMaxLength(100);

            entity.HasOne(d => d.User).WithOne(p => p.UserCredential)
                .HasForeignKey<UserCredential>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserCrede__UserI__00DF2177");
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserInfo__1788CC4C75AD87C3");

            entity.ToTable("UserInfo");

            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);

            entity.HasOne(d => d.Company).WithMany(p => p.UserInfos)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__UserInfo__Compan__7E02B4CC");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasNoKey();

            entity.HasOne(d => d.Role).WithMany()
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__UserRoles__RoleI__16CE6296");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserRoles__UserI__15DA3E5D");
        });

        modelBuilder.Entity<UserTemplate>(entity =>
        {
            entity.HasKey(e => e.TemplateId).HasName("PK__UserTemp__F87ADD27F05A8EF7");

            entity.Property(e => e.TemplateId).ValueGeneratedNever();
            entity.Property(e => e.TemplateName).HasMaxLength(100);
            entity.Property(e => e.TemplateType).HasMaxLength(10);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.UserTemplates)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserTempl__UserI__0880433F");
        });
        modelBuilder.HasSequence<int>("SalesOrderNumber", "SalesLT");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
