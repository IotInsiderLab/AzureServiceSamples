using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace AzureServiceSamples.CosmosDb
{
    public class Module : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CosmosDbService>().As<ICosmosDbService>();
        }
    }
}
