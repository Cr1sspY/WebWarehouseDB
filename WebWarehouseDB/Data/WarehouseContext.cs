using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebWarehouseDB.Models;

#nullable disable

namespace WebWarehouseDB.Data
{
    public partial class WarehouseContext : DbContext
    {
        public WarehouseContext()
        {
        }

        public WarehouseContext(DbContextOptions<WarehouseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Warehouse.db; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("Customer_ID");

                entity.Property(e => e.Address).HasColumnType("STRING");

                entity.Property(e => e.ConsumedProduct1Id)
                    .HasColumnType("INT")
                    .HasColumnName("Consumed_Product_1_ID");

                entity.Property(e => e.ConsumedProduct2Id)
                    .HasColumnType("INT")
                    .HasColumnName("Consumed_Product_2_ID");

                entity.Property(e => e.ConsumedProduct3Id)
                    .HasColumnType("INT")
                    .HasColumnName("Consumed_Product_3_ID");

                entity.Property(e => e.Name).HasColumnType("STRING");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("STRING")
                    .HasColumnName("Phone_Number");

                entity.HasOne(d => d.ConsumedProduct1)
                    .WithMany(p => p.CustomerConsumedProduct1s)
                    .HasForeignKey(d => d.ConsumedProduct1Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ConsumedProduct2)
                    .WithMany(p => p.CustomerConsumedProduct2s)
                    .HasForeignKey(d => d.ConsumedProduct2Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ConsumedProduct3)
                    .WithMany(p => p.CustomerConsumedProduct3s)
                    .HasForeignKey(d => d.ConsumedProduct3Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("Employee_ID");

                entity.Property(e => e.Address).HasColumnType("STRING");

                entity.Property(e => e.Age).HasColumnType("STRING");

                entity.Property(e => e.FullName)
                    .HasColumnType("STRING")
                    .HasColumnName("Full_Name");

                entity.Property(e => e.PassportInformation)
                    .HasColumnType("STRING")
                    .HasColumnName("Passport_Information");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("STRING")
                    .HasColumnName("Phone_Number");

                entity.Property(e => e.PositionId)
                    .HasColumnType("INT")
                    .HasColumnName("Position_ID");

                entity.Property(e => e.Sex).HasColumnType("STRING");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("Position");

                entity.Property(e => e.PositionId)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("Position_ID");

                entity.Property(e => e.Duties).HasColumnType("STRING");

                entity.Property(e => e.Name).HasColumnType("STRING");

                entity.Property(e => e.Requests).HasColumnType("STRING");

                entity.Property(e => e.Salary).HasColumnType("INT");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("Product_ID");

                entity.Property(e => e.Manufacturer).HasColumnType("STRING");

                entity.Property(e => e.Name).HasColumnType("STRING");

                entity.Property(e => e.Package).HasColumnType("STRING");

                entity.Property(e => e.ShelfLife)
                    .HasColumnType("DATETIME")
                    .HasColumnName("Shelf_Life");

                entity.Property(e => e.StorageConditions)
                    .HasColumnType("STRING")
                    .HasColumnName("Storage_Conditions");

                entity.Property(e => e.TypeId)
                    .HasColumnType("INT")
                    .HasColumnName("Type_ID");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.ToTable("Product_Type");

                entity.Property(e => e.TypeId)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("Type_ID");

                entity.Property(e => e.Description).HasColumnType("STRING");

                entity.Property(e => e.Feature).HasColumnType("STRING");

                entity.Property(e => e.Name).HasColumnType("STRING");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.ToTable("Provider");

                entity.Property(e => e.ProviderId)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("Provider_ID");

                entity.Property(e => e.Address).HasColumnType("STRING");

                entity.Property(e => e.Name).HasColumnType("STRING");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("STRING")
                    .HasColumnName("Phone_Number");

                entity.Property(e => e.SuppliedProduct1Id)
                    .HasColumnType("INT")
                    .HasColumnName("Supplied_Product_1_ID");

                entity.Property(e => e.SuppliedProduct2Id)
                    .HasColumnType("INT")
                    .HasColumnName("Supplied_Product_2_ID");

                entity.Property(e => e.SuppliedProduct3Id)
                    .HasColumnType("INT")
                    .HasColumnName("Supplied_Product_3_ID");

                entity.HasOne(d => d.SuppliedProduct1)
                    .WithMany(p => p.ProviderSuppliedProduct1s)
                    .HasForeignKey(d => d.SuppliedProduct1Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.SuppliedProduct2)
                    .WithMany(p => p.ProviderSuppliedProduct2s)
                    .HasForeignKey(d => d.SuppliedProduct2Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.SuppliedProduct3)
                    .WithMany(p => p.ProviderSuppliedProduct3s)
                    .HasForeignKey(d => d.SuppliedProduct3Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.ToTable("Warehouse");

                entity.Property(e => e.WarehouseId)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("Warehouse_ID");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("INT")
                    .HasColumnName("Customer_ID");

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("INT")
                    .HasColumnName("Employee_ID");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("DATETIME")
                    .HasColumnName("Order_Date");

                entity.Property(e => e.Price).HasColumnType("INT");

                entity.Property(e => e.ProductId)
                    .HasColumnType("INT")
                    .HasColumnName("Product_ID");

                entity.Property(e => e.ProviderId)
                    .HasColumnType("INT")
                    .HasColumnName("Provider_ID");

                entity.Property(e => e.ShipmentDate)
                    .HasColumnType("DATETIME")
                    .HasColumnName("Shipment_Date");

                entity.Property(e => e.SupplyDate)
                    .HasColumnType("DATETIME")
                    .HasColumnName("Supply_Date");

                entity.Property(e => e.TypeOfDelivery)
                    .HasColumnType("STRING")
                    .HasColumnName("Type_of_Delivery");

                entity.Property(e => e.Volume).HasColumnType("INT");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Warehouses)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Warehouses)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Warehouses)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.Warehouses)
                    .HasForeignKey(d => d.ProviderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
