using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureServiceSamples.BlobStorage
{
    public class Module : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BlobStorageService>().As<IBlobStorageService>();
        }
    }
}
