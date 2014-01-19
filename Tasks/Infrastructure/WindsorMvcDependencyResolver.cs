using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Castle.Windsor;

namespace Tasks.Infrastructure
{
    public class WindsorMvcDependencyResolver : IDependencyResolver
    {
        private readonly IWindsorContainer container;

        public WindsorMvcDependencyResolver(IWindsorContainer container)
        {
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            object service = null;
            if (container.Kernel.HasComponent(serviceType))
                service = container.Resolve(serviceType);

            return service;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            IEnumerable<object> services = new object[] { };
            if (container.Kernel.HasComponent(serviceType))
                services = container.ResolveAll(serviceType).Cast<object>();

            return services;
        }
    }
}