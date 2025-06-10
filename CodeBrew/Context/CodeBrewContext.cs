using System;
using System.Collections.Generic;
using CodeBrew.Model;
using Microsoft.EntityFrameworkCore;

namespace CodeBrew.Context;

public partial class CodeBrewContext : DbContext
{
    public CodeBrewContext()
    {
    }

    public CodeBrewContext(DbContextOptions<CodeBrewContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Coffeeshop> Coffeeshops { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<IngredientsInCoffeeshop> IngredientsInCoffeeshops { get; set; }

    public virtual DbSet<IngredientsInRecipe> IngredientsInRecipes { get; set; }

    public virtual DbSet<LoyaltyLevel> LoyaltyLevels { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<ManufacturersIngredient> ManufacturersIngredients { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductSize> ProductSizes { get; set; }

    public virtual DbSet<ProductsInOrder> ProductsInOrders { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<StaffPosition> StaffPositions { get; set; }

    public virtual DbSet<Supply> Supplies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=CodeBrew;Username=postgres;Password=1");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coffeeshop>(entity =>
        {
            entity.HasKey(e => e.CoffeeshopId).HasName("coffeeshop_pkey");

            entity.ToTable("coffeeshop");

            entity.Property(e => e.CoffeeshopId).HasColumnName("coffeeshop_id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("customer_pkey");

            entity.ToTable("customer");

            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.LoyaltyLevelId).HasColumnName("loyalty_level_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Points)
                .HasDefaultValue(0)
                .HasColumnName("points");

            entity.HasOne(d => d.LoyaltyLevel).WithMany(p => p.Customers)
                .HasForeignKey(d => d.LoyaltyLevelId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("customer_loyalty_level_id_fkey");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.DiscountId).HasName("discount_pkey");

            entity.ToTable("discount");

            entity.Property(e => e.DiscountId).HasColumnName("discount_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Percent)
                .HasPrecision(5, 2)
                .HasColumnName("percent");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("event__pkey");

            entity.ToTable("event_");

            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.CoffeeshopId).HasColumnName("coffeeshop_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EventDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("event_date");

            entity.HasOne(d => d.Coffeeshop).WithMany(p => p.Events)
                .HasForeignKey(d => d.CoffeeshopId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("event__coffeeshop_id_fkey");
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.IngredientId).HasName("ingredient_pkey");

            entity.ToTable("ingredient");

            entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<IngredientsInCoffeeshop>(entity =>
        {
            entity.HasKey(e => new { e.IngredientId, e.CoffeeshopId }).HasName("ingredients_in_coffeeshop_pkey");

            entity.ToTable("ingredients_in_coffeeshop");

            entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");
            entity.Property(e => e.CoffeeshopId).HasColumnName("coffeeshop_id");
            entity.Property(e => e.BestBeforeDate).HasColumnName("best_before_date");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Coffeeshop).WithMany(p => p.IngredientsInCoffeeshops)
                .HasForeignKey(d => d.CoffeeshopId)
                .HasConstraintName("ingredients_in_coffeeshop_coffeeshop_id_fkey");

            entity.HasOne(d => d.Ingredient).WithMany(p => p.IngredientsInCoffeeshops)
                .HasForeignKey(d => d.IngredientId)
                .HasConstraintName("ingredients_in_coffeeshop_ingredient_id_fkey");
        });

        modelBuilder.Entity<IngredientsInRecipe>(entity =>
        {
            entity.HasKey(e => new { e.RecipeId, e.IngredientId }).HasName("ingredients_in_recipe_pkey");

            entity.ToTable("ingredients_in_recipe");

            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");
            entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");
            entity.Property(e => e.Quantity)
                .HasMaxLength(50)
                .HasColumnName("quantity");

            entity.HasOne(d => d.Ingredient).WithMany(p => p.IngredientsInRecipes)
                .HasForeignKey(d => d.IngredientId)
                .HasConstraintName("ingredients_in_recipe_ingredient_id_fkey");

            entity.HasOne(d => d.Recipe).WithMany(p => p.IngredientsInRecipes)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("ingredients_in_recipe_recipe_id_fkey");
        });

        modelBuilder.Entity<LoyaltyLevel>(entity =>
        {
            entity.HasKey(e => e.LoyaltyLevelId).HasName("loyalty_level_pkey");

            entity.ToTable("loyalty_level");

            entity.Property(e => e.LoyaltyLevelId).HasColumnName("loyalty_level_id");
            entity.Property(e => e.CashbackPercent)
                .HasPrecision(5, 2)
                .HasColumnName("cashback_percent");
            entity.Property(e => e.RansomAmount)
                .HasPrecision(10, 2)
                .HasColumnName("ransom_amount");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.ManufacturerId).HasName("manufacturer_pkey");

            entity.ToTable("manufacturer");

            entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<ManufacturersIngredient>(entity =>
        {
            entity.HasKey(e => new { e.ManufacturerId, e.IngredientId }).HasName("manufacturers_ingredients_pkey");

            entity.ToTable("manufacturers_ingredients");

            entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");
            entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");

            entity.HasOne(d => d.Ingredient).WithMany(p => p.ManufacturersIngredients)
                .HasForeignKey(d => d.IngredientId)
                .HasConstraintName("manufacturers_ingredients_ingredient_id_fkey");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.ManufacturersIngredients)
                .HasForeignKey(d => d.ManufacturerId)
                .HasConstraintName("manufacturers_ingredients_manufacturer_id_fkey");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("order_pkey");

            entity.ToTable("order");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.CoffeeshopId).HasColumnName("coffeeshop_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("date");
            entity.Property(e => e.DiscountId).HasColumnName("discount_id");
            entity.Property(e => e.PointsUsed)
                .HasDefaultValue(0)
                .HasColumnName("points_used");
            entity.Property(e => e.StaffId).HasColumnName("staff_id");
            entity.Property(e => e.TotalAmount)
                .HasPrecision(10, 2)
                .HasColumnName("total_amount");

            entity.HasOne(d => d.Coffeeshop).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CoffeeshopId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("order_coffeeshop_id_fkey");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("order_customer_id_fkey");

            entity.HasOne(d => d.Discount).WithMany(p => p.Orders)
                .HasForeignKey(d => d.DiscountId)
                .HasConstraintName("order_discount_id_fkey");

            entity.HasOne(d => d.Staff).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("order_staff_id_fkey");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("product_pkey");

            entity.ToTable("product");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("product_category_id_fkey");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("product_category_pkey");

            entity.ToTable("product_category");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ProductSize>(entity =>
        {
            entity.HasKey(e => e.SizeId).HasName("product_size_pkey");

            entity.ToTable("product_size");

            entity.Property(e => e.SizeId).HasColumnName("size_id");
            entity.Property(e => e.PriceModifier)
                .HasPrecision(5, 2)
                .HasDefaultValueSql("1.0")
                .HasColumnName("price_modifier");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Size)
                .HasMaxLength(10)
                .HasColumnName("size");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductSizes)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("product_size_product_id_fkey");
        });

        modelBuilder.Entity<ProductsInOrder>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.SizeId, e.OrderId }).HasName("products_in_order_pkey");

            entity.ToTable("products_in_order");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.SizeId).HasColumnName("size_id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Order).WithMany(p => p.ProductsInOrders)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("products_in_order_order_id_fkey");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductsInOrders)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("products_in_order_product_id_fkey");

            entity.HasOne(d => d.Size).WithMany(p => p.ProductsInOrders)
                .HasForeignKey(d => d.SizeId)
                .HasConstraintName("products_in_order_size_id_fkey");
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.RecipeId).HasName("recipe_pkey");

            entity.ToTable("recipe");

            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.HasOne(d => d.Product).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("recipe_product_id_fkey");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("staff_pkey");

            entity.ToTable("staff");

            entity.HasIndex(e => e.Email, "staff_email_key").IsUnique();

            entity.Property(e => e.StaffId).HasColumnName("staff_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.PositionId).HasColumnName("position_id");

            entity.HasOne(d => d.Position).WithMany(p => p.Staff)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("staff_position_id_fkey");
        });

        modelBuilder.Entity<StaffPosition>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("staff_position_pkey");

            entity.ToTable("staff_position");

            entity.Property(e => e.PositionId).HasColumnName("position_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Supply>(entity =>
        {
            entity.HasKey(e => e.SupplyId).HasName("supply_pkey");

            entity.ToTable("supply");

            entity.Property(e => e.SupplyId).HasColumnName("supply_id");
            entity.Property(e => e.CoffeeshopId).HasColumnName("coffeeshop_id");
            entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");
            entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.SupplyDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("supply_date");

            entity.HasOne(d => d.Coffeeshop).WithMany(p => p.Supplies)
                .HasForeignKey(d => d.CoffeeshopId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("supply_coffeeshop_id_fkey");

            entity.HasOne(d => d.Ingredient).WithMany(p => p.Supplies)
                .HasForeignKey(d => d.IngredientId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("supply_ingredient_id_fkey");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Supplies)
                .HasForeignKey(d => d.ManufacturerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("supply_manufacturer_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
