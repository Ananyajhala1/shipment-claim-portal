using System;
using System.Collections.Generic;
using ClaimsAPI.Models.Entites;
using Microsoft.EntityFrameworkCore;
// using ClaimsAPI.Models.Entites;

namespace ClaimsAPI.Models;

public partial class ShipmentClaimsContext : DbContext
{


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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:jayuni.database.windows.net,1433;Initial Catalog=Study;Persist Security Info=False;User ID=IIITV2022;Password=IlikeCricket###123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Claim>(entity =>
        {
            entity.HasKey(e => e.ClaimId).HasName("PK__Claims__EF2E139BC45298C0");

            entity.HasOne(d => d.Carrier).WithMany(p => p.ClaimCarriers)
                .HasForeignKey(d => d.CarrierId)
                .HasConstraintName("FK__Claims__CarrierI__0FEC5ADD");

            entity.HasOne(d => d.Customer).WithMany(p => p.ClaimCustomers)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Claims__Customer__0EF836A4");

            entity.HasOne(d => d.Insurance).WithMany(p => p.ClaimInsurances)
                .HasForeignKey(d => d.InsuranceId)
                .HasConstraintName("FK__Claims__Insuranc__10E07F16");
        });

        modelBuilder.Entity<ClaimDocument>(entity =>
        {
            entity.HasKey(e => e.DocId).HasName("PK__ClaimDoc__3EF188ADE3F3DAE2");

            entity.HasOne(d => d.Claim).WithMany(p => p.ClaimDocuments)
                .HasForeignKey(d => d.ClaimId)
                .HasConstraintName("FK__ClaimDocu__Claim__1D4655FB");

            entity.HasOne(d => d.DocType).WithMany(p => p.ClaimDocuments)
                .HasForeignKey(d => d.DocTypeId)
                .HasConstraintName("FK__ClaimDocu__DocTy__1E3A7A34");
        });

        modelBuilder.Entity<ClaimDocumentType>(entity =>
        {
            entity.HasKey(e => e.DocTypeId).HasName("PK__ClaimDoc__055E26A3041878F5");

            entity.Property(e => e.DoctypeDes).IsUnicode(false);

            entity.HasOne(d => d.Company).WithMany(p => p.ClaimDocumentTypes)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__ClaimDocu__Compa__1A69E950");
        });

        modelBuilder.Entity<ClaimEmail>(entity =>
        {
            entity.HasKey(e => e.EmailId).HasName("PK__ClaimEma__7ED91ACF9BE338F1");

            entity.ToTable("ClaimEmail");

            entity.Property(e => e.EmailId)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Body).IsUnicode(false);
            entity.Property(e => e.Subject).IsUnicode(false);

            entity.HasOne(d => d.From).WithMany(p => p.ClaimEmails)
                .HasForeignKey(d => d.FromId)
                .HasConstraintName("FK__ClaimEmai__FromI__2B947552");

            entity.HasOne(d => d.Recepient).WithMany(p => p.ClaimEmails)
                .HasForeignKey(d => d.RecepientId)
                .HasConstraintName("FK__ClaimEmai__Recep__2AA05119");
        });

        modelBuilder.Entity<ClaimSetting>(entity =>
        {
            entity.HasKey(e => e.SettingsId).HasName("PK__ClaimSet__991B19FC61FB7DB0");

            entity.HasOne(d => d.Claim).WithMany(p => p.ClaimSettings)
                .HasForeignKey(d => d.ClaimId)
                .HasConstraintName("FK__ClaimSett__Claim__2116E6DF");

            entity.HasOne(d => d.Company).WithMany(p => p.ClaimSettings)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__ClaimSett__Compa__220B0B18");

            entity.HasOne(d => d.Doc).WithMany(p => p.ClaimSettings)
                .HasForeignKey(d => d.DocId)
                .HasConstraintName("FK__ClaimSett__DocId__22FF2F51");
        });

        modelBuilder.Entity<ClaimStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__ClaimSta__C8EE2063BE4479EA");

            entity.ToTable("ClaimStatus");

            entity.Property(e => e.StatusDesc)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Claim).WithMany(p => p.ClaimStatuses)
                .HasForeignKey(d => d.ClaimId)
                .HasConstraintName("FK__ClaimStat__Claim__13BCEBC1");
        });

        modelBuilder.Entity<ClaimSubStatus>(entity =>
        {
            entity.HasKey(e => e.SubStatusId).HasName("PK__ClaimSub__F306D28216080510");

            entity.ToTable("ClaimSubStatus");

            entity.HasOne(d => d.Company).WithMany(p => p.ClaimSubStatuses)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__ClaimSubS__Compa__178D7CA5");

            entity.HasOne(d => d.Status).WithMany(p => p.ClaimSubStatuses)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__ClaimSubS__Statu__1699586C");
        });

        modelBuilder.Entity<ClaimTask>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__ClaimTas__7C6949B14ACA7EED");

            entity.ToTable("ClaimTask");

            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TaskDes).IsUnicode(false);

            entity.HasOne(d => d.Claim).WithMany(p => p.ClaimTasks)
                .HasForeignKey(d => d.ClaimId)
                .HasConstraintName("FK__ClaimTask__Claim__27C3E46E");

            entity.HasOne(d => d.User).WithMany(p => p.ClaimTasks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__ClaimTask__UserI__26CFC035");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__Company__2D971CAC15491A97");

            entity.ToTable("Company");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ParentCompanyId).HasColumnName("parentCompanyID");

            entity.HasOne(d => d.ParentCompany).WithMany(p => p.InverseParentCompany)
                .HasForeignKey(d => d.ParentCompanyId)
                .HasConstraintName("fk_parentCompanyID");
        });

        modelBuilder.Entity<CompanyType>(entity =>
        {
            entity.HasKey(e => e.CompanyTypeId).HasName("PK__CompanyT__060198D855F5B71E");

            entity.ToTable("CompanyType");

            entity.Property(e => e.CompanyType1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CompanyType");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK__Contacts__5C66259BC93147DC");

            entity.Property(e => e.ContactName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Company).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_Contacts_Company");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Location__E7FEA497501874EC");

            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Zipcode).HasColumnName("ZIPCODE");

            entity.HasOne(d => d.Company).WithMany(p => p.Locations)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__Locations__Compa__7EC1CEDB");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.PermissionId).HasName("PK__Permissi__EFA6FB2FDDDC52F1");

            entity.ToTable("Permission");

            entity.Property(e => e.PermissionDescription).IsUnicode(false);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1AE9D0DA68");

            entity.Property(e => e.RoleName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RolePerm__3214EC27287C1EDC");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.Permission).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.PermissionId)
                .HasConstraintName("FK__RolePermi__Permi__093F5D4E");

            entity.HasOne(d => d.Role).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__RolePermi__RoleI__084B3915");
        });

        modelBuilder.Entity<UserCredential>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserCred__1788CC4CA42541C8");

            entity.Property(e => e.UserId).ValueGeneratedOnAdd();
            entity.Property(e => e.Password)
                .HasColumnType("text")
                .HasColumnName("password");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithOne(p => p.UserCredential)
                .HasForeignKey<UserCredential>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserCrede__UserI__7814D14C");
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserInfo__1788CC4CF81A949A");

            entity.ToTable("UserInfo");

            entity.Property(e => e.ContactNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Company).WithMany(p => p.UserInfos)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__UserInfo__Compan__753864A1");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserRoles__RoleI__038683F8");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserRoles__UserI__02925FBF");
        });

        modelBuilder.Entity<UserTemplate>(entity =>
        {
            entity.HasKey(e => e.TemplateId).HasName("PK__UserTemp__F87ADD27576ABDF3");

            entity.Property(e => e.TemplateContent).IsUnicode(false);
            entity.Property(e => e.TemplateName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TemplateType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.UserTemplates)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserTempl__UserI__7BE56230");
        });
        modelBuilder.HasSequence<int>("SalesOrderNumber", "SalesLT");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
