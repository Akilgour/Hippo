using Autofac;
using Hippologamus.Data.Autofac;

namespace Hippologamus.API.Service.Autofac
{
    public class ServiceModule : Module
    {
        public ServiceModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new HippologamusDataModule());

            //"ThisAssembly" means "any types in the same assembly as the module"
            builder.RegisterAssemblyTypes(ThisAssembly)
                 .Where(t => t.Name.EndsWith("Service"))
                 .AsImplementedInterfaces();
        }
    }
}