using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using MyTwit.DAL.Interfaces;
using MyTwit.DAL.Repositories;
using DAL.Interfaces;
using DAL.Repositories;

namespace MyTwit.Util
{
    public class NinjectDependencyResolver: IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<ITwitRepository>().To<TwitRepository>();
        }
    }
}