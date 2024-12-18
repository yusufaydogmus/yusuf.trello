using Microsoft.EntityFrameworkCore;
using NpgsqlTypes;
using System;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using yusuf.trello.Boards;
using yusuf.trello.Cards;
using yusuf.trello.Lists;

namespace yusuf.trello.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class trelloDbContext :
    AbpDbContext<trelloDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */
    public DbSet<Board> Boards { get; set; }
    public DbSet<Liste> Lists { get; set; }
    public DbSet<Card> Cards { get; set; }
    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public trelloDbContext(DbContextOptions<trelloDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(trelloConsts.DbTablePrefix + "YourEntities", trelloConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});

        builder.Entity<Board>(b =>
        {
            b.ToTable(trelloConsts.DbTablePrefix + "Boards", trelloConsts.DbSchema);
            b.ConfigureByConvention();

            //properties

            b.Property(x => x.Name)
            .IsRequired()
            .HasColumnType(NpgsqlDbType.Varchar.ToString())
            .HasMaxLength(30);
        });

        builder.Entity<Liste>(b =>
        {
            b.ToTable(trelloConsts.DbTablePrefix + "Lists", trelloConsts.DbSchema);
            b.ConfigureByConvention();

            //properties

            b.Property(x=>x.Name)
            .IsRequired()
            .HasColumnType(NpgsqlDbType.Varchar.ToString())
            .HasMaxLength(30);

            b.Property(x => x.Position)
            .IsRequired()
            .HasColumnType(NpgsqlDbType.Integer.ToString());

            b.Property(x => x.BoardId)
            .IsRequired()
            .HasColumnType(NpgsqlDbType.Uuid.ToString());

            b.HasOne(x => x.Board)
                .WithMany(x => x.Listes)
                .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<Card>(b =>
        {
            b.ToTable(trelloConsts.DbTablePrefix + "Cards", trelloConsts.DbSchema);
            b.ConfigureByConvention();

            //properties

            b.Property(x=>x.Name)
            .IsRequired()
            .HasColumnType(NpgsqlDbType.Varchar.ToString()) 
            .HasMaxLength(30);

            b.Property(x=>x.Description)
            .HasColumnType (NpgsqlDbType.Varchar.ToString())
            .HasMaxLength(300);
            
            b.Property(x => x.Position)
           .IsRequired()
           .HasColumnType(NpgsqlDbType.Integer.ToString());


            b.Property(x => x.ListeId)
            .IsRequired()
            .HasColumnType(NpgsqlDbType.Uuid.ToString());

            b.HasOne(x=>x.Liste)
            .WithMany(x=>x.Cards)
            .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
