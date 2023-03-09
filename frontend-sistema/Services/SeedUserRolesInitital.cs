using frontend_sistema.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace frontend_sistema.Services
{
    public class SeedUserRolesInitital : ISeedUserRoleInitial
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRolesInitital(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SeedRoles()
        {
            if (!_roleManager.RoleExistsAsync("Usuario").Result)
            {
                IdentityRole role = new();
                role.Name = "Usuario";
                role.NormalizedName = "USUARIO";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
        }

        public void SeedUsers()
        {
            if(_userManager.FindByEmailAsync("peterson").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "peterson";
                user.Email = "peterson";
                user.NormalizedUserName = "PETERSON";
                user.NormalizedEmail = "PETERSON";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "123456").Result;

                if (result.Succeeded && _roleManager.RoleExistsAsync("Admin").Result)
                {
                    _userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}
