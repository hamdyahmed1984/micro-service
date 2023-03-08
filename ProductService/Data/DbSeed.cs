using Microsoft.EntityFrameworkCore;
using ProductService.Models;

namespace ProductService.Data;

public static class DbSeed
{
   public static void SeedData(IApplicationBuilder app, bool isProduction)
   {
        using(var serviceScope = app.ApplicationServices.CreateScope())            
        {
            SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProduction);
        }
   }

   private static void SeedData(AppDbContext context, bool isProduction)
   {
        if(isProduction)
        {
            Console.WriteLine("---> migrating DB");
            try
            {
                context.Database.Migrate();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"--> Error during migrating the DB: {ex.Message}");
            }
        }
        if(context.Products.Any())
            Console.WriteLine("DB already has its seed data");
        else
        {
            Console.WriteLine("Seeding data...");
            context.Products.AddRange(
                new Product() { Name = "Okavango", Type = "Car", Price = 92000, Quantity = 1 },
                new Product() { Name= "Note 10 Plus", Type = "Mobile", Price = 3000, Quantity = 3}
            );
            context.SaveChanges();
        }
   }
}