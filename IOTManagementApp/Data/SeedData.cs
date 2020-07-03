using IOTManagementApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOTManagementApp.Data
{
    public class SeedData
    {
        public static  IEnumerable<Device> devices = new List<Device>
            {
                new Device
                {
                    Id = 1,
                    Name = "IPhone 9",
                    Description = "A mobile phone",
                    IsConnected = false,
                    UserId = "c3fb0252-6f70-4b2d-9172-3392a49ea6ce"
                },
                 new Device
                {
                    Id = 2,
                    Name = "Samsung TV",
                    Description = "A Samsung TV",
                    IsConnected = true,
                      UserId = "c3fb0252-6f70-4b2d-9172-3392a49ea6ce"
                },
            };



        public static async Task IntializeAsync(IServiceProvider service)
        {
        /*    var options = service.GetRequiredService<DbContextOptions<ApplicationDbContext>>();
            using (var context = new ApplicationDbContext(options))
            {

                var userManager = service.GetRequiredService<UserManager<User>>();
                var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();

                var roleNames = new[] { "Admin" };

                await SeedRoles(roleManager, roleNames);

                var adminEmail = "admin@domain.com";
                var adminPassword = "BygMig123!";

                await SeedAdmin(userManager, roleManager, roleNames, adminEmail, adminPassword);
            }
            */  
        }

        private static async Task SeedRoles(RoleManager<IdentityRole> roleManager, string[] roleNames) {

            foreach (var name in roleNames) {
                if (await roleManager.RoleExistsAsync(name)) continue;
                
                var role = new IdentityRole { Name = name };
                var result = await roleManager.CreateAsync(role);

                if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));
            }
        }
    

            
        private static async Task SeedAdmin(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, string[] roleNames, string adminEmail, string adminPassword){
               
            var foundUser = await userManager.FindByEmailAsync(adminEmail);

                
            if (foundUser != null) return;

                
            var user = new User     
            {  
                UserName = adminEmail,
                Email = adminEmail
            };
                
            var addUserResult = await userManager.CreateAsync(user, adminPassword);
      
            if (!addUserResult.Succeeded) throw new Exception(string.Join("\n", addUserResult.Errors));

            var adminUser = await userManager.FindByNameAsync(adminEmail);

            foreach (var role in roleNames){    
                if (role == "Admin"){          
                    if (await userManager.IsInRoleAsync(adminUser, role)) continue;
                    
                    var addToRoleResult = await userManager.AddToRoleAsync(adminUser, role);

                    if (!addToRoleResult.Succeeded) throw new Exception(string.Join("\n", addToRoleResult.Errors));      
                }    
            }
            
        }     
    }

}
