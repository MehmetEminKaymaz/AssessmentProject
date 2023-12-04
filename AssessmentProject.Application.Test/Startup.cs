
using AssessmentProject.Application.Store.Commands;
using AssessmentProject.Application.Store.Handler;
using AssessmentProject.Application.User.Commands;
using AssessmentProject.Application.User.Handler;
using AssessmentProject.Application.User.Queries;
using AssessmentProject.Data;
using AssessmentProject.Data.Domain;
using Microsoft.EntityFrameworkCore;
using NUnit.Extension.DependencyInjection;
using NUnit.Extension.DependencyInjection.Abstractions;
using NUnit.Extension.DependencyInjection.Unity;
using Unity;

[assembly: NUnitTypeInjectionFactory(typeof(UnityInjectionFactory))]//Tell the extension that we will be using the Microsoft Unity Injection factory;
[assembly: NUnitTypeDiscoverer(typeof(IocRegistrarTypeDiscoverer))]//this tells the extension to scan for the implementation(concrete classes)
namespace AssessmentProject.Application.Test
{
    public class Startup : RegistrarBase<IUnityContainer>
    {
        protected override void RegisterInternal(IUnityContainer container)
        {
            container.RegisterType<DbContext, DataContext>();
            container.RegisterType<CreateStoreCommandHandler, CreateStoreCommandHandler>();
            container.RegisterType<CreateStoreCommand, CreateStoreCommand>();
            container.RegisterType<StoreRepository, StoreRepository>();
            container.RegisterType<DeleteStoreCommandHandler, DeleteStoreCommandHandler>();
            container.RegisterType<DeleteStoreCommand, DeleteStoreCommand>();
            container.RegisterType<UpdateStoreCommandHandler, UpdateStoreCommandHandler>();
            container.RegisterType<UpdateStoreCommand, UpdateStoreCommand>();
            container.RegisterType<GetStoreQueryHandler, GetStoreQueryHandler>();
            container.RegisterType<GetUserQuery, GetUserQuery>();
            container.RegisterType<CreateUserCommand, CreateUserCommand>();
            container.RegisterType<CreateUserCommandHandler, CreateUserCommandHandler>();
        }
    }
}
