using FutebaProfissional.Repositories.Abstractions;
using FutebaProfissional.Repositories.Repositories;
using FutebaProfissional.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FutebaProfissional.Services.IoC
{
    public class RegisterIoC
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IGroupRepository, GroupRepository>();
        }
    }
}
