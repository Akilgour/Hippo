using Autofac;
using Hippologamus.Data.Context;
using Hippologamus.Data.Factorys;

namespace Hippologamus.Data.Autofac
{
    public class HippologamusDataModule : Module
    {
        public HippologamusDataModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .WithParameter("context", new HippologamusContext( ))
                .WithParameter("retryPolicy", PollyFactory.CreateAsyncRetryPolicy())
                .AsImplementedInterfaces();
        }
    }
}