using Autofac;
using Bit.Synchronizer.Application.Behaviours;
using MediatR;
using System.Reflection;

namespace Bit.Contract.Api
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            // request & notification handlers
            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });
            
            //builder.RegisterAssemblyTypes(typeof(AsociateContractSubscriptionCommand).GetTypeInfo().Assembly).AsImplementedInterfaces();
            //builder.RegisterAssemblyTypes(typeof(GetAllLicencesQuery).GetTypeInfo().Assembly).AsImplementedInterfaces();
            builder.RegisterGeneric(typeof(ValidationBehavior<,>)).As(typeof(IPipelineBehavior<,>));
        }
    }
}
