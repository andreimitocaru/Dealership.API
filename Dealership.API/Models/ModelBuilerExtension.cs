using Microsoft.EntityFrameworkCore;

namespace Dealership.API.Models
{
    public static class ModelBuilerExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "SUV" },
                new Category { Id = 2, Name = "Sedan" });

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, CategoryId = 2, Brand = "Skoda", CarModel = "Octavia", AcquisitionDate = 2011, IsAvailable = true },
                new Product { Id = 2, CategoryId = 2, Brand = "Skoda", CarModel = "Fabia", AcquisitionDate = 2013, IsAvailable = true },
                new Product { Id = 3, CategoryId = 1, Brand = "Skoda", CarModel = "Kodiaq", AcquisitionDate = 2020, IsAvailable = true },
                new Product { Id = 4, CategoryId = 2, Brand = "Audi", CarModel = "A4", AcquisitionDate = 2017, IsAvailable = true },
                new Product { Id = 5, CategoryId = 1, Brand = "Audi", CarModel = "Q5", AcquisitionDate = 2013, IsAvailable = true },
                new Product { Id = 6, CategoryId = 1, Brand = "BMW", CarModel = "X6", AcquisitionDate = 2022, IsAvailable = true },
                new Product { Id = 7, CategoryId = 2, Brand = "BMW", CarModel = "Seria 7", AcquisitionDate = 2019, IsAvailable = true },
                new Product { Id = 8, CategoryId = 2, Brand = "Dacia", CarModel = "Logan", AcquisitionDate = 2019, IsAvailable = false },
                new Product { Id = 9, CategoryId = 1, Brand = "Dacia", CarModel = "Duster", AcquisitionDate = 2021, IsAvailable = false });

            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, Name = "Constantin" },
                new Customer { CustomerId = 2, Name = "Test" });
        }
    }
}
