using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetTest.Services.Implementation.Installer
{
    public class MapperInstaller : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(this.ThisAssembly)
                .Where(t => t.Name.EndsWith("Mapping"))
                    .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
