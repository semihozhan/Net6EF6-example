using Kusys.Data.Abstract;
using Kusys.Data.Concreate;
using Kusys.Data.Concreate.Context;
using Kusys.Services.Abstract;
using Kusys.Services.Concreate;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kusys.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<KusysContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<IStudentService, StudentManager>();
            serviceCollection.AddScoped<IRoleService, RoleManager>();
            serviceCollection.AddScoped<ICourseService, CourseManager>();
            serviceCollection.AddScoped<IStudentCourseService, StudentCourseManager>();

            return serviceCollection;
        }
    }
}
