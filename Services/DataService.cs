using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyBlog.Data;
using MyBlog.Enums;
using MyBlog.Models;

namespace MyBlog.Services
{
    public class DataService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<BlogUser> _userManager;

        public DataService(ApplicationDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<BlogUser> userManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task ManageDataAsync()
        {
            await _dbContext.Database.MigrateAsync();
            await SeedRolesAsync(_roleManager);
        }

        private async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            foreach (string roleName in Enum.GetNames(typeof(Roles)))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName.ToString()));
            }     
        }
    }
}
