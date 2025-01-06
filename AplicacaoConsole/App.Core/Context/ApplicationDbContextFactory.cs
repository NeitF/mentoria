using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace App.Core.Context;

// public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
// {
//     public ApplicationDbContext CreateDbContext(string[] args)
//     {
//         var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
//         optionsBuilder.UseSqlite("Data Source=myLibrary.db");
//
//         return new ApplicationDbContext(optionsBuilder.Options);
//     }
// }