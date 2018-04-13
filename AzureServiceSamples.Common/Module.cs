using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace AzureServiceSamples.Common
{
    public class Module : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConnectionStringService>().As<IConnectionStringService>();
        }
    }
}
