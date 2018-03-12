using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KingstonAPI.Models
{
    public partial class KingstonTestContext : DbContext
    {
        public KingstonTestContext(DbContextOptions<KingstonTestContext> options) : base(options) { }

        public virtual DbSet<CustomerList> CustomerList { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<OrderList> OrderList { get; set; }
        public virtual DbSet<ProductList> ProductList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerList>(entity =>
            {
                entity.HasKey(e => e.CId);

                entity.ToTable("customer_list");

                entity.Property(e => e.CId)
                    .HasColumnName("c_id")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.CAddress)
                    .IsRequired()
                    .HasColumnName("c_address")
                    .HasMaxLength(100);

                entity.Property(e => e.CCompanyName)
                    .IsRequired()
                    .HasColumnName("c_company_name")
                    .HasMaxLength(50);

                entity.Property(e => e.CContactName)
                    .IsRequired()
                    .HasColumnName("c_contact_name")
                    .HasMaxLength(50);

                entity.Property(e => e.CEmail)
                    .IsRequired()
                    .HasColumnName("c_email")
                    .HasMaxLength(50);

                entity.Property(e => e.CFax)
                    .HasColumnName("c_fax")
                    .HasMaxLength(50);

                entity.Property(e => e.CPhone)
                    .IsRequired()
                    .HasColumnName("c_phone")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OId, e.PId });

                entity.ToTable("order_detail");

                entity.Property(e => e.OId)
                    .HasColumnName("o_id")
                    .HasMaxLength(50);

                entity.Property(e => e.PId)
                    .HasColumnName("p_id")
                    .HasMaxLength(50);

                entity.Property(e => e.OrderNumber)
                    .HasColumnName("order_number")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.O)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.OId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_order_detail_order_list");

                entity.HasOne(d => d.P)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.PId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_order_detail_product_list");
            });

            modelBuilder.Entity<OrderList>(entity =>
            {
                entity.HasKey(e => e.OId);

                entity.ToTable("order_list");

                entity.Property(e => e.OId)
                    .HasColumnName("o_id")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.CId)
                    .IsRequired()
                    .HasColumnName("c_id")
                    .HasMaxLength(50);

                entity.Property(e => e.DeliveryDate)
                    .HasColumnName("delivery_date")
                    .HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.OrderDate)
                    .HasColumnName("order_date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.C)
                    .WithMany(p => p.OrderList)
                    .HasForeignKey(d => d.CId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_order_list_customer_list");
            });

            modelBuilder.Entity<ProductList>(entity =>
            {
                entity.HasKey(e => e.PId);

                entity.ToTable("product_list");

                entity.Property(e => e.PId)
                    .HasColumnName("p_id")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.PDescription)
                    .HasColumnName("p_description")
                    .HasMaxLength(500);

                entity.Property(e => e.PName)
                    .IsRequired()
                    .HasColumnName("p_name")
                    .HasMaxLength(100);

                entity.Property(e => e.PPrice)
                    .HasColumnName("p_price")
                    .HasColumnType("money");
            });
        }
    }
}
