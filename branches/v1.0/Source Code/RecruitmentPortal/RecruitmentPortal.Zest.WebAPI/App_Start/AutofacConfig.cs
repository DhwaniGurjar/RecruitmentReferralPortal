using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace RecruitmentLineManager.Zest.WebAPI.App_Start
{
    public class AutofacConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config, ContainerBuilder builder)
        {
            Initialize(config, RegisterServices(builder));


            ////Register your Web API controllers.  
            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //builder.RegisterGeneric(typeof(Repository<>)).AsSelf();
            ////Register Assembly which ends with service
            //builder.RegisterAssemblyTypes(typeof(UserRepository).Assembly)
            //      .Where(t => t.Name.EndsWith("Repository"))
            //        .AsImplementedInterfaces().InstancePerRequest();

            //builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();

            ////Set the dependency resolver to be Autofac.  
            //Container = builder.Build();

            //config.DependencyResolver = new AutofacWebApiDependencyResolver(Container);

        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //builder.RegisterGeneric(typeof(Repository<>)).AsSelf();
            ////Register Assembly which ends with service
            //builder.RegisterAssemblyTypes(typeof(UserRepository).Assembly)
            //      .Where(t => t.Name.EndsWith("Repository"))
            //        .AsImplementedInterfaces().InstancePerRequest();

            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();

            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); //Set the MVC DependencyResolver
            //GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container); //Set the WebApi DependencyResolver

            return Container;
        }
    }
}