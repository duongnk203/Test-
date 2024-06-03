using Microsoft.EntityFrameworkCore;

namespace PetStoreProject.Models;

public partial class PetStoreDBContext : DbContext
{
	public PetStoreDBContext()
	{
	}

	public PetStoreDBContext(DbContextOptions<PetStoreDBContext> options)
		: base(options)
	{
	}

	public virtual DbSet<Account> Accounts { get; set; }

	public virtual DbSet<Admin> Admins { get; set; }

	public virtual DbSet<Attribute> Attributes { get; set; }

	public virtual DbSet<Brand> Brands { get; set; }

	public virtual DbSet<CartItem> CartItems { get; set; }

	public virtual DbSet<Category> Categories { get; set; }

	public virtual DbSet<Customer> Customers { get; set; }

	public virtual DbSet<Employee> Employees { get; set; }

	public virtual DbSet<FavouriteList> FavouriteLists { get; set; }

	public virtual DbSet<Feature> Features { get; set; }

	public virtual DbSet<Feedback> Feedbacks { get; set; }

	public virtual DbSet<Image> Images { get; set; }

	public virtual DbSet<News> News { get; set; }

	public virtual DbSet<Product> Products { get; set; }

	public virtual DbSet<ProductCategory> ProductCategories { get; set; }

	public virtual DbSet<ProductOption> ProductOptions { get; set; }

	public virtual DbSet<Role> Roles { get; set; }

	public virtual DbSet<Service> Services { get; set; }

	public virtual DbSet<ServiceOption> ServiceOptions { get; set; }

	public virtual DbSet<Size> Sizes { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		=> optionsBuilder.UseSqlServer("name=PetStoreDBContext");

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Account>(entity =>
		{
			entity.Property(e => e.Email).IsFixedLength();
			entity.Property(e => e.Password).IsFixedLength();

			entity.HasMany(d => d.Roles).WithMany(p => p.Emails)
				.UsingEntity<Dictionary<string, object>>(
					"AccountRole",
					r => r.HasOne<Role>().WithMany()
						.HasForeignKey("RoleId")
						.OnDelete(DeleteBehavior.ClientSetNull)
						.HasConstraintName("FK_AccountRole_Role"),
					l => l.HasOne<Account>().WithMany()
						.HasForeignKey("Email")
						.OnDelete(DeleteBehavior.ClientSetNull)
						.HasConstraintName("FK_AccountRole_Account"),
					j =>
					{
						j.HasKey("Email", "RoleId");
						j.ToTable("AccountRole");
						j.IndexerProperty<string>("Email")
							.HasMaxLength(100)
							.IsFixedLength();
					});
		});

		modelBuilder.Entity<Admin>(entity =>
		{
			entity.Property(e => e.Address).IsFixedLength();
			entity.Property(e => e.Email).IsFixedLength();
			entity.Property(e => e.FullName).IsFixedLength();
			entity.Property(e => e.Phone).IsFixedLength();

			entity.HasOne(d => d.EmailNavigation).WithMany(p => p.Admins)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_Admin_Account");
		});

		modelBuilder.Entity<Attribute>(entity =>
		{
			entity.Property(e => e.AttributeId).ValueGeneratedNever();
			entity.Property(e => e.Name).IsFixedLength();
			entity.Property(e => e.Type).IsFixedLength();
		});

		modelBuilder.Entity<Brand>(entity =>
		{
			entity.HasKey(e => e.BrandId).HasName("PK_Brand_1");

			entity.Property(e => e.BrandId).ValueGeneratedNever();
			entity.Property(e => e.Name).IsFixedLength();
		});

		modelBuilder.Entity<CartItem>(entity =>
		{
			entity.Property(e => e.CartItemId).ValueGeneratedNever();

			entity.HasOne(d => d.Customer).WithMany(p => p.CartItems)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_CartItem_Customer");
		});

		modelBuilder.Entity<Category>(entity =>
		{
			entity.Property(e => e.CategoryId).ValueGeneratedNever();
		});

		modelBuilder.Entity<Customer>(entity =>
		{
			entity.Property(e => e.Address).IsFixedLength();
			entity.Property(e => e.Email).IsFixedLength();
			entity.Property(e => e.FullName).IsFixedLength();
			entity.Property(e => e.Phone).IsFixedLength();

			entity.HasOne(d => d.EmailNavigation).WithMany(p => p.Customers)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_Customer_Account");
		});

		modelBuilder.Entity<Employee>(entity =>
		{
			entity.Property(e => e.Address).IsFixedLength();
			entity.Property(e => e.Email).IsFixedLength();
			entity.Property(e => e.FullName).IsFixedLength();
			entity.Property(e => e.Phone).IsFixedLength();

			entity.HasOne(d => d.EmailNavigation).WithMany(p => p.Employees)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_Employee_Account");
		});

		modelBuilder.Entity<FavouriteList>(entity =>
		{
			entity.HasOne(d => d.Customer).WithMany(p => p.FavouriteLists)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_FavouriteList_Customer");
		});

		modelBuilder.Entity<Feature>(entity =>
		{
			entity.Property(e => e.FeatureId).ValueGeneratedNever();
			entity.Property(e => e.Url).IsFixedLength();
		});

		modelBuilder.Entity<Image>(entity =>
		{
			entity.Property(e => e.ImageId).ValueGeneratedNever();
			entity.Property(e => e.ImageUrl).IsFixedLength();
		});

		modelBuilder.Entity<News>(entity =>
		{
			entity.Property(e => e.NewsId).ValueGeneratedNever();
		});

		modelBuilder.Entity<Product>(entity =>
		{
			entity.Property(e => e.ProductId).ValueGeneratedNever();
			entity.Property(e => e.Name).IsFixedLength();
		});

		modelBuilder.Entity<ProductCategory>(entity =>
		{
			entity.Property(e => e.ProductCateId).ValueGeneratedNever();
			entity.Property(e => e.Name).IsFixedLength();

			entity.HasOne(d => d.Category).WithMany(p => p.ProductCategories)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_ProductCategory_Category");
		});

		modelBuilder.Entity<ProductOption>(entity =>
		{
			entity.Property(e => e.ProductOptionId).ValueGeneratedNever();

			entity.HasOne(d => d.Attribute).WithMany(p => p.ProductOptions).HasConstraintName("FK_ProductOption_Attribute");

			entity.HasOne(d => d.Image).WithMany(p => p.ProductOptions)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_ProductOption_Image1");

			entity.HasOne(d => d.Size).WithMany(p => p.ProductOptions).HasConstraintName("FK_ProductOption_Size");
		});

		modelBuilder.Entity<Role>(entity =>
		{
			entity.Property(e => e.RoleId).ValueGeneratedNever();
			entity.Property(e => e.Name).IsFixedLength();

			entity.HasMany(d => d.Features).WithMany(p => p.Roles)
				.UsingEntity<Dictionary<string, object>>(
					"RoleFeature",
					r => r.HasOne<Feature>().WithMany()
						.HasForeignKey("FeatureId")
						.OnDelete(DeleteBehavior.ClientSetNull)
						.HasConstraintName("FK_RoleFeature_Feature"),
					l => l.HasOne<Role>().WithMany()
						.HasForeignKey("RoleId")
						.OnDelete(DeleteBehavior.ClientSetNull)
						.HasConstraintName("FK_RoleFeature_Role"),
					j =>
					{
						j.HasKey("RoleId", "FeatureId");
						j.ToTable("RoleFeature");
					});
		});

		modelBuilder.Entity<Service>(entity =>
		{
			entity.Property(e => e.ServiceId).ValueGeneratedNever();
			entity.Property(e => e.Name).IsFixedLength();
		});

		modelBuilder.Entity<ServiceOption>(entity =>
		{
			entity.Property(e => e.PetType).IsFixedLength();

			entity.HasOne(d => d.Service).WithMany(p => p.ServiceOptions)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_ServiceOption_Service");
		});

		modelBuilder.Entity<Size>(entity =>
		{
			entity.HasKey(e => e.SizeId).HasName("PK_Size_1");

			entity.Property(e => e.SizeId).ValueGeneratedNever();
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
