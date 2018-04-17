using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace AzureServiceSamples.TableStorage
{
    public class Module : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TableStorageService>().As<ITableStorageService>();
            builder.RegisterType<AutoMapperProfile>().As<AutoMapper.Profile>();
        }
    }
}
