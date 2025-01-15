using Kreta.Backend.Context;
using Kreta.Backend.Repos;
using Kreta.Shared.Assamblers;
using Kreta.Shared.Assemblers;
using Microsoft.EntityFrameworkCore;

namespace Kreta.Backend.Extensions
{
    public static class KretaBackendExtensions
    {
        public static void AddBackend(this IServiceCollection services)
        {
            services.ConfigureCors();
            services.ConfigureInMemoryContext();
            services.ConfigureRepos();
            services.ConfigureAssamblers();
        }
        private static void ConfigureCors(this IServiceCollection services)
        {

            services.AddCors(option =>
                 option.AddPolicy(name: "KretaCors",
                     policy =>
                     {
                         policy.WithOrigins("https://localhost:7090/")
                         .AllowAnyHeader()
                         .AllowAnyMethod();
                     }
                 )
            );
        }

        private static void ConfigureInMemoryContext(this IServiceCollection services)
        {
            string dbNameKretaContext = "Kreta" + Guid.NewGuid();
            services.AddDbContext<KretaContext>
            (
                 options => options.UseInMemoryDatabase(databaseName: dbNameKretaContext),
                 ServiceLifetime.Scoped,
                 ServiceLifetime.Scoped
            );


            string dbNameInMemoryContext = "Kreta" + Guid.NewGuid();
            services.AddDbContext<KretaInMemoryContext>
            (
                 options => options.UseInMemoryDatabase(databaseName: dbNameInMemoryContext),
                 ServiceLifetime.Scoped,
                 ServiceLifetime.Scoped
            );
        }

        private static void ConfigureRepos(this IServiceCollection services) 
        { 
            services.AddScoped<IStudentRepo, StudentRepo<KretaInMemoryContext>>();
            services.AddScoped<ISubjectRepo, SubjectRepo<KretaInMemoryContext>>();

        }

        private static void ConfigureAssamblers(this IServiceCollection services)
        {
            services.AddScoped<StudentAssembler>();
            services.AddScoped<SubjectAssambler>();
        }
    }
}
