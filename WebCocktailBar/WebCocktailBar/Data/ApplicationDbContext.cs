using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebCocktailBar.Domain;
using WebCocktailBar.Models.Product;
using WebShopDemo.Models.Product;
using WebCocktailBar.Models.Order;
using WebCocktailBar.Models.Client;
using WebCocktailBar.Models.SignatureProduct;

namespace WebCocktailBar.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Taste> Tastes { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<SignatureProduct> SignatureProducts { get; set; }

        public DbSet<WebCocktailBar.Models.Product.ProductCreateVM> ProductCreateVM { get; set; }

        public DbSet<WebCocktailBar.Models.Product.ProductIndexVM> ProductIndexVM { get; set; }

        public DbSet<WebShopDemo.Models.Product.ProductEditVM> ProductEditVM { get; set; }

        public DbSet<WebCocktailBar.Models.Product.ProductDetailsVM> ProductDetailsVM { get; set; }

        public DbSet<WebCocktailBar.Models.Product.ProductDeleteVM> ProductDeleteVM { get; set; }

        public DbSet<WebCocktailBar.Models.Order.OrderIndexVM> OrderIndexVM { get; set; }

        public DbSet<WebCocktailBar.Models.Order.OrderConfirmVM> OrderConfirmVM { get; set; }

        public DbSet<WebCocktailBar.Models.Client.ClientIndexVM> ClientIndexVM { get; set; }

        public DbSet<WebCocktailBar.Models.Client.ClientDeleteVM> ClientDeleteVM { get; set; }

        public DbSet<WebCocktailBar.Models.SignatureProduct.SignatureProductIndexVM> SignatureProductIndexVM { get; set; }

        public DbSet<WebCocktailBar.Models.SignatureProduct.SignatureProductCreateVM> SignatureProductCreateVM { get; set; }

    }
}
