using System;
using Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BL
{
    public partial class EaglesDatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public EaglesDatabaseContext()
        {
        }

        public EaglesDatabaseContext(DbContextOptions<EaglesDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbCustomer> TbCustomers { get; set; }
        public virtual DbSet<TbItemCategory> TbItemCategories { get; set; }
        public virtual DbSet<TbLogisticCompany> TbLogisticCompanies { get; set; }
        public virtual DbSet<TbSetting> TbSettings { get; set; }
        public virtual DbSet<TbTransactionAbdo> TbTransactionAbdos { get; set; }
        public virtual DbSet<TbTransactionTurkeyOne> TbTransactionTurkeyOnes { get; set; }
        public virtual DbSet<TbTransactionTurkeyTwo> TbTransactionTurkeyTwos { get; set; }
        public virtual DbSet<TbTurkeyOne> TbTurkeyOnes { get; set; }
        public virtual DbSet<TbTurkeyTwo> TbTurkeyTwos { get; set; }
        public virtual DbSet<TbWeightCategory> TbWeightCategories { get; set; }
        public virtual DbSet<TransactionLogisticCompany> TransactionLogisticCompanies { get; set; }

        public virtual DbSet<VwWeightPrice> VwWeightPrices { get; set; }
        

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //                optionsBuilder.UseSqlServer("Server=DESKTOP-262OT74;Database=EaglesDatabase;Trusted_Connection=True;");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<VwWeightPrice>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwWeightPrice");


            });

            modelBuilder.Entity<TbCustomer>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.ToTable("TbCustomer");

                entity.Property(e => e.CustomerId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AreaName).HasMaxLength(450);

                entity.Property(e => e.CityName).HasMaxLength(450);

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CustomerAddress).HasMaxLength(450);

                entity.Property(e => e.CustomerName).HasMaxLength(450);

                entity.Property(e => e.CustomerPhone).HasMaxLength(450);

                entity.Property(e => e.Notes).HasMaxLength(450);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbItemCategory>(entity =>
            {
                entity.HasKey(e => e.ItemCategoryId);

                entity.ToTable("TbItemCategory");

                entity.Property(e => e.ItemCategoryId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ItemCategoryName).HasMaxLength(450);

                entity.Property(e => e.Notes).HasMaxLength(450);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbLogisticCompany>(entity =>
            {
                entity.HasKey(e => e.LogisticCompanyId);

                entity.ToTable("TbLogisticCompany");

                entity.Property(e => e.LogisticCompanyId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LogisticCompanyName).HasMaxLength(450);

                entity.Property(e => e.Notes).HasMaxLength(450);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbSetting>(entity =>
            {
                entity.HasKey(e => e.SettingId);

                entity.ToTable("TbSetting");

                entity.Property(e => e.SettingId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Notes).HasMaxLength(450);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbTransactionAbdo>(entity =>
            {
                entity.HasKey(e => e.TransactionAbdoId);

                entity.ToTable("TbTransactionAbdo");

                entity.Property(e => e.TransactionAbdoId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.BasicCostEgp).HasColumnName("BasicCostEGP");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ItemImagePath).HasMaxLength(450);

                entity.Property(e => e.Notes).HasMaxLength(450);

                entity.Property(e => e.Size).HasMaxLength(450);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbTransactionTurkeyOne>(entity =>
            {
                entity.HasKey(e => e.TransactionTurkeyOneId);

                entity.ToTable("TbTransactionTurkeyOne");

                entity.Property(e => e.TransactionTurkeyOneId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.BasicCostEgp).HasColumnName("BasicCostEGP");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ItemImagePath).HasMaxLength(450);

                entity.Property(e => e.Notes).HasMaxLength(450);

                entity.Property(e => e.Size).HasMaxLength(450);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbTransactionTurkeyTwo>(entity =>
            {
                entity.HasKey(e => e.TransactionTurkeyTwoId);

                entity.ToTable("TbTransactionTurkeyTwo");

                entity.Property(e => e.TransactionTurkeyTwoId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.BasicCostEgp).HasColumnName("BasicCostEGP");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ItemImagePath).HasMaxLength(450);

                entity.Property(e => e.Notes).HasMaxLength(450);

                entity.Property(e => e.Size).HasMaxLength(450);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbTurkeyOne>(entity =>
            {
                entity.HasKey(e => e.TurkeyOneId);

                entity.ToTable("TbTurkeyOne");

                entity.Property(e => e.TurkeyOneId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Notes).HasMaxLength(450);

                entity.Property(e => e.TurkeyOneName).HasMaxLength(450);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbTurkeyTwo>(entity =>
            {
                entity.HasKey(e => e.TurkeyTwoId);

                entity.ToTable("TbTurkeyTwo");

                entity.Property(e => e.TurkeyTwoId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Notes).HasMaxLength(450);

                entity.Property(e => e.TurkeyTwoName).HasMaxLength(450);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbWeightCategory>(entity =>
            {
                entity.HasKey(e => e.WeightCategoryId);

                entity.ToTable("TbWeightCategory");

                entity.Property(e => e.WeightCategoryId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Notes).HasMaxLength(450);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.WeightCategoryName).HasMaxLength(450);
            });

            modelBuilder.Entity<TransactionLogisticCompany>(entity =>
            {
                entity.ToTable("TransactionLogisticCompany");

                entity.Property(e => e.TransactionLogisticCompanyId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.BasicCostEgp).HasColumnName("BasicCostEGP");

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ItemImagePath).HasMaxLength(450);

                entity.Property(e => e.Notes).HasMaxLength(450);

                entity.Property(e => e.Size).HasMaxLength(450);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
