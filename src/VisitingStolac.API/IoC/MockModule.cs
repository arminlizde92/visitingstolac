using Autofac;
using VisitingStolac.BLL.Abstractions.Repositories;
using VisitingStolac.BLL.Abstractions.UOW;
using VisitingStolac.BLL.Mock.Repositories;
using VisitingStolac.BLL.Mock.UOW;

namespace VisitingStolac.API.IoC
{
    /// <summary>
    /// Mock module, used for testing purposes
    /// </summary>
    public class MockModule : Module
    {
        /// <summary>
        /// Registering mock types
        /// </summary>
        /// <param name="containerBuilder">instance of <see cref="ContainerBuilder"/></param>
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<UnitOfWorkMock>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

            containerBuilder.RegisterType<MediaRepositoryMock>()
                .As<IMediaRepository>()
                .InstancePerLifetimeScope()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

            containerBuilder.RegisterType<SubscriberRepositoryMock>()
                .As<ISubscriberRepository>()
                .InstancePerLifetimeScope()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);


            containerBuilder.RegisterType<PostRepositoryMock>()
                .As<IPostRepository>()
                .InstancePerLifetimeScope()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
        }
    }
}
