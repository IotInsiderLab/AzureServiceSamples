using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Http;

namespace AzureServiceSamples.Web
{
    public class IoCConfiguration
    {
        public static void BuildContainer(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>();

            builder.RegisterModule<Module>();
            builder.RegisterModule<BlobStorage.Module>();
            builder.RegisterModule<Common.Module>();


            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()); 

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}