using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using WU15.AlltOchMer.Data.Model.Entities;

namespace WU15.AlltOchMer.Data
{
    

    public class AlltOchMerDataContext : DbContext
    {
        public AlltOchMerDataContext() {}
        
        public AlltOchMerDataContext(string connectionString) : base(connectionString) { }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryName> CategoryNames { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<PriceList> PriceLists { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductListView> ProductList { get; set; }
        public virtual DbSet<ProductDescription> ProductDescriptions { get; set; }
        public virtual DbSet<ProductPriceList> ProductPriceLists { get; set; }
        public virtual DbSet<SaleTax> SaleTaxes { get; set; }
        public virtual DbSet<ShoppingBasket> ShoppingBaskets { get; set; }
        public virtual DbSet<ShoppingBasketProduct> ShoppingBasketProducts { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Category1)
                .WithOptional(e => e.Category2)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.CategoryNames)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithMany(e => e.Categories)
                .Map(m => m.ToTable("ProductCategory").MapLeftKey("CategoryId").MapRightKey("ProductId"));

            modelBuilder.Entity<Country>()
                .Property(e => e.CountryCode)
                .IsFixedLength();

            modelBuilder.Entity<Country>()
                .HasMany(e => e.SaleTaxes)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Currency>()
                .Property(e => e.CurrencyValue)
                .HasPrecision(5, 4);

            modelBuilder.Entity<Language>()
                .HasMany(e => e.CategoryNames)
                .WithRequired(e => e.Language)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Language>()
                .HasMany(e => e.ProductDescriptions)
                .WithRequired(e => e.Language)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PriceList>()
                .HasMany(e => e.ProductPriceLists)
                .WithRequired(e => e.PriceList)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductDescriptions)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductPriceLists)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ShoppingBasketProducts)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.SaleTaxes)
                .WithMany(e => e.Products)
                .Map(m => m.ToTable("ProductSaleTax").MapLeftKey("ProductId").MapRightKey("SaleTaxId"));

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Suppliers)
                .WithMany(e => e.Products)
                .Map(m => m.ToTable("ProductSupplier").MapLeftKey("ProductId").MapRightKey("SupplierId"));

            modelBuilder.Entity<ProductPriceList>()
                .Property(e => e.Price)
                .HasPrecision(7, 0);

            modelBuilder.Entity<SaleTax>()
                .Property(e => e.SalesTaxValue)
                .HasPrecision(4, 2);

            modelBuilder.Entity<ShoppingBasket>()
                .HasMany(e => e.ShoppingBasketProducts)
                .WithRequired(e => e.ShoppingBasket)
                .WillCascadeOnDelete(false);
        }
    }
}
