using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Autofac;
using garpunkal.EntityFrameworkSandbox.Business;
using garpunkal.EntityFrameworkSandbox.Business.Interfaces;
using garpunkal.EntityFrameworkSandbox.Data;

namespace garpunkal.EntityFrameworkSandbox.Web.Modules
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .Register(c => new EntityFrameworkSandboxDbContext())
                .AsSelf()
                .As<DbContext>()
                .InstancePerRequest();

            builder
                .RegisterType<DeveloperService>()
                .As<IDeveloperService>()
                .AsSelf()
                .InstancePerRequest();
        }
    }
}