using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Castle.MicroKernel;
using IDependencyResolver = System.Web.Http.Dependencies.IDependencyResolver;

namespace Tasks.Infrastructure
{
    public sealed class WindsorHttpDependencyResolver : IDependencyResolver
    {
        private readonly IKernel container;

        public WindsorHttpDependencyResolver(IKernel container)
        {
            this.container = container;
        }

        public IDependencyScope BeginScope()
        {
            return new WindsorDependencyScope(container);
        }

        public object GetService(Type serviceType)
        {
            return container.HasComponent(serviceType)
                       ? container.Resolve(serviceType)
                       : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return container.ResolveAll(serviceType).Cast<object>();
        }

        public void Dispose()
        {
        }
    }
}