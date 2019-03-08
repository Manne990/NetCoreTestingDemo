using Autofac;

namespace TestingDemo
{
    public static class IoC
    {
        public static IContainer Container { get; private set; }

        public static void Init()
        {
            var builder = new ContainerBuilder();

            //builder.RegisterType<EmployeeService>()?.As<IEmployeeService>()?.SingleInstance();

            Container = builder.Build();
        }
    }
}