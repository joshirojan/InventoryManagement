using InventoryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection.Emit;

namespace InventoryManagement.Data
{
    public class ApiDbContext:DbContext
    {
        public ApiDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new List<Category>
            {
                new Category { Id = 1, Name = "Laptop" },
                new Category { Id = 2, Name = "Desktop" },
                 new Category { Id = 3, Name = "Accessories" },
                  new Category { Id = 4, Name = "Printers" },
                   new Category { Id = 5, Name = "Storage" },
                    new Category { Id = 6, Name = "Monitors" },
                      new Category { Id = 7, Name = "Networking" },
                          new Category { Id = 8, Name = "Components" }

            });
            modelBuilder.Entity<Product>().HasData(new List<Product>
            {
                new Product { Id = 1, Name = "Dell Laptop", Description = "Powerful laptop from Dell with great performance.", CategoryId = 1,ImageUrl="https://www.informationq.com/wp-content/uploads/2013/11/Dell-Inspiron-15-3521-15.6-inch-Laptop-Black01.jpg"},
                new Product { Id = 2, Name = "Mac PC" , Description = "High-end desktop computer from Apple.", CategoryId = 2,ImageUrl="https://images.unsplash.com/photo-1517059224940-d4af9eec41b7?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1000&q=80"},
                  new Product { Id = 3, Name = "Mouse and Keyboard Combo", Description = "Wireless mouse and keyboard combo for convenience.", CategoryId = 3,ImageUrl="https://img.freepik.com/free-vector/print_53876-43658.jpg?t=st=1696176612~exp=1696177212~hmac=92132b1b0cd9692963f9fc6eb1fb61cae00ce7af4161822c24a8429a6fb083c0"},
                new Product { Id = 4, Name = "HP Printer" , Description = "Versatile printer from HP for all your printing needs.", CategoryId = 4,ImageUrl="https://images.unsplash.com/photo-1612815154858-60aa4c59eaa6?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8aHAlMjBwcmludGVyfGVufDB8fDB8fHww&w=1000&q=80"},
                  new Product { Id = 5, Name = "External Hard Drive", Description = "Large-capacity external hard drive for storage.", CategoryId = 5,ImageUrl="https://media.istockphoto.com/id/496402410/photo/external-hard-drive-for-backup.jpg?s=612x612&w=0&k=20&c=Ul6uXVrMdFEmIC7xH_f54tWfYQSExa1_j70eP-5fuyM="},
                new Product { Id = 6, Name = "Gaming Monitor" , Description = "High-refresh-rate gaming monitor for a smooth gaming experience.", CategoryId = 6,ImageUrl="https://img.freepik.com/free-photo/view-computer-monitor-display_23-2150757434.jpg"},
                  new Product { Id = 7, Name = "Wireless Router", Description = "Fast and reliable wireless router for home networking.", CategoryId = 7,ImageUrl="https://img.freepik.com/premium-vector/vector-wireless-router-free-wifi-zone-concept-modern-flat-illustration_660702-331.jpg?w=2000"},
                new Product { Id = 8, Name = "External SSD" , Description = "Portable external SSD for quick data access on the go.", CategoryId = 5,ImageUrl="https://i5.walmartimages.com/asr/3daa0c60-384f-4d78-a135-04d74cf70e09.133b2adf608c606c41dd16e3f4afb4fd.jpeg?odnHeight=2000&odnWidth=2000&odnBg=FFFFFF"},
                 new Product { Id = 9, Name = "USB Flash Drive" , Description = "Compact USB flash drive with ample storage capacity.", CategoryId = 8,ImageUrl="https://cdn.pixabay.com/photo/2015/07/20/19/50/usb-853230_1280.png"},
                  new Product { Id = 10, Name = "Graphics Card" , Description = "High-performance graphics card for gaming and content creation.", CategoryId = 8,ImageUrl="https://images.pexels.com/photos/6341789/pexels-photo-6341789.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"}
            });

            modelBuilder.Entity<Role>().HasData(new List<Role>
            {
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "User" },

            });

            modelBuilder.Entity<User>().HasData(new List<User>
            {
                new User { Id = 1, FullName = "Ram Doe",Email="ram.doe@example.com",PasswordHash="123456",RoleId=1 },
                new User { Id = 2, FullName = "Shyam Doe",Email="shyam.doe@example.com",PasswordHash="123456",RoleId=2 },

            });

        }
    }
}
