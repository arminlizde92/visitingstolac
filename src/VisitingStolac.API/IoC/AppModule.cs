using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VisitingStolac.BLL.Abstractions.Repositories;
using VisitingStolac.BLL.Abstractions.UOW;
using VisitingStolac.BLL.EF.Repositories;
using VisitingStolac.BLL.EF.UOW;
using VisitingStolac.DAL.Context;

namespace VisitingStolac.API.IoC
{
    /// <summary>
    /// Registering modules
    /// </summary>
    public class AppModule : Module
    {
        /// <summary> private readonly instance of <see cref="IConfiguration"/> </summary>
        private readonly IConfiguration _config;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config">instance of <see cref="IConfiguration"/></param>
        public AppModule(IConfiguration config) => _config = config;

        /// <summary>
        /// Registering types
        /// </summary>
        /// <param name="containerBuilder">instance of <see cref="ContainerBuilder"/></param>
        protected override void Load(ContainerBuilder containerBuilder)
        {
            // gets connection string
            string connectionString = _config.GetConnectionString("VisitingStolacDbContext");

            // configuring settings
            var optionsBuilder = new DbContextOptionsBuilder<VisitingStolacDbContext>();
            optionsBuilder.UseSqlServer(connectionString, opt => opt.CommandTimeout(60));

            containerBuilder.RegisterType<VisitingStolacDbContext>()
                .AsSelf()
                .WithParameter("options", optionsBuilder.Options)
                .InstancePerLifetimeScope()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

            containerBuilder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

            containerBuilder.RegisterType<MediaRepository>()
                .As<IMediaRepository>()
                .InstancePerLifetimeScope()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

            containerBuilder.RegisterType<ContactRepository>()
                .As<IContactRepository>()
                .InstancePerLifetimeScope()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

            containerBuilder.RegisterType<AdministratorRepository>()
                .As<IAdministratorRepository>()
                .InstancePerLifetimeScope()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

            containerBuilder.RegisterType<ContributionRepository>()
                .As<IContributionRepository>()
                .InstancePerLifetimeScope()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

            containerBuilder.RegisterType<PostRepository>()
                .As<IPostRepository>()
                .InstancePerLifetimeScope()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

            containerBuilder.RegisterType<SubscriberRepository>()
                .As<ISubscriberRepository>()
                .InstancePerLifetimeScope()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

            containerBuilder.RegisterType<ContactRepository>()
                .As<IContactRepository>()
                .InstancePerLifetimeScope()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
        }
    }
}
