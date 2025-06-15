using Microsoft.EntityFrameworkCore;

namespace ECommercePlatform.Data
{
    public class ECommercePlatformContext : DbContext
    {
        public ECommercePlatformContext(DbContextOptions<ECommercePlatformContext> options) : base(options) { }

        public DbSet<ECommercePlatform.Models.User> Users { get; set; }
        public DbSet<ECommercePlatform.Models.Customer> Customers { get; set; }
        public DbSet<ECommercePlatform.Models.Vendor> Vendors { get; set; }
        public DbSet<ECommercePlatform.Models.Admin> Admins { get; set; }
        public DbSet<ECommercePlatform.Models.Driver> Drivers { get; set; }
        public DbSet<ECommercePlatform.Models.Product> Products { get; set; }
        public DbSet<ECommercePlatform.Models.Order> Orders { get; set; }
        public DbSet<ECommercePlatform.Models.OrderItem> OrderItems { get; set; }
        public DbSet<ECommercePlatform.Models.Payment> Payments { get; set; }
        public DbSet<ECommercePlatform.Models.Shipment> Shipments { get; set; }
        public DbSet<ECommercePlatform.Models.Receiver> Receivers { get; set; }
        public DbSet<ECommercePlatform.Models.Address> Addresses { get; set; }
        public DbSet<ECommercePlatform.Models.City> Cities { get; set; }
        public DbSet<ECommercePlatform.Models.Currency> Currencies { get; set; }
        public DbSet<ECommercePlatform.Models.ExchangeRate> ExchangeRates { get; set; }
        public DbSet<ECommercePlatform.Models.MultiCurrencyPrice> MultiCurrencyPrices { get; set; }
        public DbSet<ECommercePlatform.Models.CurrencyConversion> CurrencyConversions { get; set; }
        public DbSet<ECommercePlatform.Models.PackageRequest> PackageRequests { get; set; }
        public DbSet<ECommercePlatform.Models.ConsolidatedPackage> ConsolidatedPackages { get; set; }
        public DbSet<ECommercePlatform.Models.CustomsDeclaration> CustomsDeclarations { get; set; }
        public DbSet<ECommercePlatform.Models.Coupon> Coupons { get; set; }
        public DbSet<ECommercePlatform.Models.Offer> Offers { get; set; }
        public DbSet<ECommercePlatform.Models.CouponUsage> CouponUsages { get; set; }
        public DbSet<ECommercePlatform.Models.CustomerOffer> CustomerOffers { get; set; }
        public DbSet<ECommercePlatform.Models.Notification> Notifications { get; set; }
        public DbSet<ECommercePlatform.Models.Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ECommercePlatform.Models.Customer>()
                .HasOne<ECommercePlatform.Models.User>()
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ECommercePlatform.Models.Vendor>()
                .HasOne<ECommercePlatform.Models.User>()
                .WithMany()
                .HasForeignKey(v => v.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ECommercePlatform.Models.Admin>()
                .HasOne<ECommercePlatform.Models.User>()
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ECommercePlatform.Models.Driver>()
                .HasOne<ECommercePlatform.Models.User>()
                .WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ECommercePlatform.Models.ExchangeRate>()
                .HasOne(e => e.FromCurrencyNavigation)
                .WithMany(c => c.FromExchangeRates)
                .HasForeignKey(e => e.FromCurrency)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ECommercePlatform.Models.ExchangeRate>()
                .HasOne(e => e.ToCurrencyNavigation)
                .WithMany(c => c.ToExchangeRates)
                .HasForeignKey(e => e.ToCurrency)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ECommercePlatform.Models.Shipment>()
                .HasOne(s => s.OriginCity)
                .WithMany()
                .HasForeignKey(s => s.OriginCityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ECommercePlatform.Models.Shipment>()
                .HasOne(s => s.DestinationCity)
                .WithMany()
                .HasForeignKey(s => s.DestinationCityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ECommercePlatform.Models.User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<ECommercePlatform.Models.Coupon>()
                .HasIndex(c => c.Code)
                .IsUnique();

            modelBuilder.Entity<ECommercePlatform.Models.Currency>()
                .HasKey(c => c.CurrencyCode);

            modelBuilder.Entity<ECommercePlatform.Models.Product>()
                .Property(p => p.BasePrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ECommercePlatform.Models.Order>()
                .Property(o => o.TotalAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ECommercePlatform.Models.Payment>()
                .Property(p => p.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ECommercePlatform.Models.User>()
                .Property(e => e.UserId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ECommercePlatform.Models.Order>()
                .HasIndex(o => o.CreatedDate);

            modelBuilder.Entity<ECommercePlatform.Models.Product>()
                .HasIndex(p => p.Category);

            modelBuilder.Entity<ECommercePlatform.Models.Shipment>()
                .HasIndex(s => s.TrackingNumber)
                .IsUnique();

            modelBuilder.Entity<ECommercePlatform.Models.Order>()
                .HasMany(o => o.Items)
                .WithOne(oi => oi.Order)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ECommercePlatform.Models.Product>()
                .HasMany(p => p.Prices)
                .WithOne(mcp => mcp.Product)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
