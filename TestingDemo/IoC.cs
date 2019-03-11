using Autofac;
using TestingDemo.Repository;
using TestingDemo.Service;
using TestingDemo.ViewModel;

namespace TestingDemo
{
    public static class IoC
    {
        public static IContainer Container { get; private set; }

        public static void Init()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ProfileRepository>()?.As<IProfileRepository>()?.SingleInstance();
            builder.RegisterType<ProfileService>()?.As<IProfileService>()?.SingleInstance();
            builder.RegisterType<ShowProfileViewModel>()?.As<IShowProfileViewModel>()?.SingleInstance();

            Container = builder.Build();
        }
    }
}