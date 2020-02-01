using FutebaProfissional.Repositories.Context;
using FutebaProfissional.Repositories.Models;
using Microsoft.AspNetCore.Identity;
using System;

namespace FutebaProfissional.Security
{
    public class IdentityInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityInitializer(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            if (_context.Database.EnsureCreated())
            {
                if (!_roleManager.RoleExistsAsync(Roles.ADMIN_MASTER).Result)
                {
                    var resultado = _roleManager.CreateAsync(
                        new IdentityRole(Roles.ADMIN_MASTER)).Result;
                    if (!resultado.Succeeded)
                    {
                        throw new Exception(
                            $"Erro durante a criação da role {Roles.ADMIN_MASTER}.");
                    }
                }

                CreateUser(
                    new ApplicationUser()
                    {
                        UserName = "MasterAdmin",
                        Email = "masteradmin@futebaprofissional.com.br",
                        EmailConfirmed = true
                    }, "3jsnkka&8$3fga58!", Roles.ADMIN_MASTER);
            }
        }
        private void CreateUser(
            ApplicationUser user,
            string password,
            string initialRole = null)
        {
            if (_userManager.FindByNameAsync(user.UserName).Result == null)
            {
                var resultado = _userManager
                    .CreateAsync(user, password).Result;

                if (resultado.Succeeded &&
                    !String.IsNullOrWhiteSpace(initialRole))
                {
                    _userManager.AddToRoleAsync(user, initialRole).Wait();
                }
            }
        }
    }
}