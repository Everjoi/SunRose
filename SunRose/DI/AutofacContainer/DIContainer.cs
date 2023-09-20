using Autofac;
using SunRose.Controllers;
using SunRose.Services.Implementation;
using SunRose.Services.Interfaces;

namespace SunRose.DI.AutofacContainer
{
    public class DIContainer : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<MessageService>().As<IMessageService>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<HomeController>().InstancePerLifetimeScope();
        }
    }
}
