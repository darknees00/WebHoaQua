using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebHoaqua.Models
{
    public partial class FruitShopContext : DbContext
    {
        public FruitShopContext()
        {
        }

        public FruitShopContext(DbContextOptions<FruitShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<DetailExportBill> DetailExportBills { get; set; } = null!;
        public virtual DbSet<DetailImportBill> DetailImportBills { get; set; } = null!;
        public virtual DbSet<ExportBill> ExportBills { get; set; } = null!;
        public virtual DbSet<ImportBill> ImportBills { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetai> OrderDetais { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Staff> Staff { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<Suplier> Supliers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Database=DESKTOP-G107ADQ;Database=FruitShop;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.ToTable("Account");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CateId);

                entity.ToTable("Category");

                entity.Property(e => e.CateId).HasColumnName("cate_id");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .HasColumnName("category_name");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(50)
                    .HasColumnName("customer_name");

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .HasColumnName("phone");

                entity.Property(e => e.State).HasColumnName("state");
            });

            modelBuilder.Entity<DetailExportBill>(entity =>
            {
                entity.HasKey(e => new { e.ExportId, e.ProductId });

                entity.ToTable("Detail_ExportBill");

                entity.Property(e => e.ExportId).HasColumnName("export_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.TotalPrice).HasColumnName("total_price");

                entity.HasOne(d => d.Export)
                    .WithMany(p => p.DetailExportBills)
                    .HasForeignKey(d => d.ExportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Detail_ExportBill_ExportBill");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.DetailExportBills)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Detail_ExportBill_Product");
            });

            modelBuilder.Entity<DetailImportBill>(entity =>
            {
                entity.HasKey(e => new { e.ImportId, e.ProductId });

                entity.ToTable("Detail_ImportBill");

                entity.Property(e => e.ImportId).HasColumnName("import_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.PriceAitem).HasColumnName("priceAitem");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.TotalPrice).HasColumnName("total_price");

                entity.HasOne(d => d.Import)
                    .WithMany(p => p.DetailImportBills)
                    .HasForeignKey(d => d.ImportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Detail_ImportBill_ImportBill");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.DetailImportBills)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Detail_ImportBill_Product");
            });

            modelBuilder.Entity<ExportBill>(entity =>
            {
                entity.ToTable("ExportBill");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.ExportDate)
                    .HasColumnType("datetime")
                    .HasColumnName("export_date");

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.StaffId)
                    .HasMaxLength(50)
                    .HasColumnName("staff_id");

                entity.Property(e => e.TotalPrice).HasColumnName("total_price");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ExportBills)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_ExportBill_Customer");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.ExportBills)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK_ExportBill_Account");
            });

            modelBuilder.Entity<ImportBill>(entity =>
            {
                entity.ToTable("ImportBill");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ImportDate)
                    .HasColumnType("datetime")
                    .HasColumnName("import_date");

                entity.Property(e => e.StaffId)
                    .HasMaxLength(50)
                    .HasColumnName("staff_id");

                entity.Property(e => e.SuplierId).HasColumnName("suplier_id");

                entity.Property(e => e.TotalPrice).HasColumnName("total_price");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.ImportBills)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK_ImportBill_Account");

                entity.HasOne(d => d.Suplier)
                    .WithMany(p => p.ImportBills)
                    .HasForeignKey(d => d.SuplierId)
                    .HasConstraintName("FK_ImportBill_Suplier");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ngaytao)
                    .HasColumnType("datetime")
                    .HasColumnName("ngaytao");

                entity.Property(e => e.Statuc).HasColumnName("statuc");

                entity.Property(e => e.Ten)
                    .HasMaxLength(100)
                    .HasColumnName("ten");

                entity.Property(e => e.UsersId)
                    .HasMaxLength(50)
                    .HasColumnName("users_id");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UsersId)
                    .HasConstraintName("FK__orders__users_id__656C112C");
            });

            modelBuilder.Entity<OrderDetai>(entity =>
            {
                entity.ToTable("orderDetais");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.SanphamId).HasColumnName("sanpham_id");

                entity.Property(e => e.Soluong).HasColumnName("soluong");

                entity.Property(e => e.Tongtien).HasColumnName("tongtien");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetais)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__orderDeta__order__6383C8BA");

                entity.HasOne(d => d.Sanpham)
                    .WithMany(p => p.OrderDetais)
                    .HasForeignKey(d => d.SanphamId)
                    .HasConstraintName("FK__orderDeta__sanph__3D5E1FD2");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Image)
                    .HasMaxLength(500)
                    .HasColumnName("image");

                entity.Property(e => e.PriceImport).HasColumnName("price_import");

                entity.Property(e => e.PriceSale).HasColumnName("price_sale");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(500)
                    .HasColumnName("product_name");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Product_Category");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_Product_Status");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("dateOfBirth");

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .HasColumnName("gender");

                entity.Property(e => e.Note)
                    .HasMaxLength(50)
                    .HasColumnName("note");

                entity.Property(e => e.StaffId)
                    .HasMaxLength(50)
                    .HasColumnName("staff_id");

                entity.Property(e => e.StaffName)
                    .HasMaxLength(50)
                    .HasColumnName("staff_name");

                entity.HasOne(d => d.StaffNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Staff_Account");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(50)
                    .HasColumnName("status_name");
            });

            modelBuilder.Entity<Suplier>(entity =>
            {
                entity.ToTable("Suplier");

                entity.Property(e => e.SuplierId).HasColumnName("suplier_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .HasColumnName("phone");

                entity.Property(e => e.SuplierName)
                    .HasMaxLength(50)
                    .HasColumnName("suplier_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
