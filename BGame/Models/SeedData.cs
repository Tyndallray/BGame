using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
namespace BGame.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            BGameDbContext context = app.ApplicationServices.GetRequiredService<BGameDbContext>();
            context.Database.Migrate();
            if (!context.GameItems.Any())
            {
                context.GameItems.AddRange(
                new GameItem
                {
                    Name = "Catan",
                    Image="~/images/Catan.jpg",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. ",
                    Price = 50.00f,
                    Players= 6,
                },
                new GameItem
                {
                    Name = "Dixit",
                    Image = "~/images/Dixit.jpg",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s ",
                    Price = 35.99f,
                    Players=6,
                },
                new GameItem
                {
                    Name = "Expedition",
                    Image="~/images/Expedition.jpg",
                    Description = " and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Price = 120.50f,
                    Players = 10,
                });
            }
            context.SaveChanges();
        }
    }
}
