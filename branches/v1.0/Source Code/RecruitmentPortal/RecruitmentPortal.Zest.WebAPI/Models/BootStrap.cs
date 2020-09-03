using Autofac;
using RecruitmentLineManager.Zest.WebAPI.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace RecruitmentLineManager.Zest.WebAPI.Models
{
    public class BootStrap
    {

        public static ContainerBuilder BuildContainer()
        {
            var builder = new ContainerBuilder();

            //builder.RegisterType<RecruitmentLineManagerEntities>().As<RecruitmentLineManagerEntities>().InstancePerDependency();
            //builder.RegisterGeneric(typeof(Repository<>)).AsSelf();
            ////Register Assembly which ends with service
            //builder.RegisterAssemblyTypes(typeof(UserRepository).Assembly)
            //      .Where(t => t.Name.EndsWith("Repository"))
            //        .AsImplementedInterfaces().InstancePerRequest();

            return builder;
        }
    }

    public class Bootstrapper
    {

        public static void Run()
        {
            //Configure AutoFac  
            AutofacConfig.Initialize(GlobalConfiguration.Configuration, BootStrap.BuildContainer());
        }

    }
}