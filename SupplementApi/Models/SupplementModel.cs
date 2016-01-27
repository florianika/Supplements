namespace SupplementApi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SupplementModel : DbContext
    {
        public SupplementModel()
            : base("name=SupplementModel")
        {
        }

        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<IngredientCategory> IngredientCategories { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<ProductIngredient> ProductIngredients { get; set; }
        public virtual DbSet<SupplementForm> SupplementForms { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TargetGroup> TargetGroups { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<DietaryClaim> DietaryClaims { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Ingredient>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Ingredient>()
                .HasMany(e => e.PruductIngredients)
                .WithRequired(e => e.Ingredient)
                .HasForeignKey(e => e.IdIngredient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IngredientCategory>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<IngredientCategory>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<IngredientCategory>()
                .HasMany(e => e.Ingredients)
                .WithOptional(e => e.IngredientCategory)
                .HasForeignKey(e => e.CategoryId);

            modelBuilder.Entity<Producer>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Producer>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Producer>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<Producer>()
                .Property(e => e.Website)
                .IsUnicode(false);

            modelBuilder.Entity<Producer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Producer>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Producer1)
                .HasForeignKey(e => e.Producer);

            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.TypeId)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.SupplementFormId)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.TargetGroupId)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.PruductIngredients)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.IdProduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductType>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<ProductType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ProductType>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ProductType>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.ProductType)
                .HasForeignKey(e => e.TypeId);

            modelBuilder.Entity<SupplementForm>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<SupplementForm>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<SupplementForm>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<TargetGroup>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<TargetGroup>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<TargetGroup>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Unit>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Unit>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Unit>()
                .HasMany(e => e.PruductIngredients)
                .WithOptional(e => e.Unit1)
                .HasForeignKey(e => e.Unit);


            modelBuilder.Entity<DietaryClaim>()
              .Property(e => e.Id)
              .IsUnicode(false);

            modelBuilder.Entity<DietaryClaim>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<DietaryClaim>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<DietaryClaim>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.DietaryClaim)
                .HasForeignKey(e => e.DietaryClaimId);
        }
    }
}
