using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using BGame.Models.UserModels;
namespace BGame.Models
{
    public class IdentitySeedData
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "Secret123$";
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            RoleManager<IdentityRole> RoleManager = app.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();
            UserManager<User> userManager = app.ApplicationServices.GetRequiredService<UserManager<User>>();
            // creating the roles 
            string[] roleNames = { "Adm", "Gen"};
            IdentityResult roleResult;
            foreach (var role in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(role);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(role));
                }
            }
            

            User admin = await userManager.FindByIdAsync(adminUser);
            if (admin == null)
            {
                admin = new User() {
                    UserName = adminUser,
                    Name = adminUser,
                    Password = adminPassword,
                    Email = "abcdef@email.com",
                    UserID = 1,
                    ProfileLink = "http://www.thaboschool.ac.th/ac_db/admin/images/adminlogin.jpg",
                };
                var result = await userManager.CreateAsync(admin);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(admin,adminPassword);
                    await userManager.AddToRoleAsync(admin,roleNames[0]);
                }
            }
            User general = await userManager.FindByIdAsync("General");
            if (general == null)
            {
                general = new User() {
                    UserID = 2,
                    UserName = "General",
                    Email = "123456@email.com",
                    Name = "General",
                    Password = "General123$",
                    ProfileLink = "http://bpic.588ku.com/element_pic/00/98/95/9156f3586f7c8c6.jpg",
                };
                var result =await userManager.CreateAsync(general);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(general, "General123$");
                    await userManager.AddToRoleAsync(general, roleNames[1]);
                }
            }
        }
    }
}
