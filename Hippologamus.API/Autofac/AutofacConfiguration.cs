using Autofac;
using Hippologamus.API.Service.Autofac;
using System.Linq;

namespace Hippologamus.API.Autofac
{
    public class AutofacConfiguration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new ServiceModule());

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("Manager"))
                .AsImplementedInterfaces();
        }
    }
}
