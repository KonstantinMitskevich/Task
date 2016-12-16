using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Interfaces;
using Ninject;
using BusinessLayer.Operations;

namespace Task.Util
{
    public class NinjectDependencyResolver : IDependencyResolver // using Ninject to bind dependencies
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
            kernel.Bind<IOperationInterface>().To<Operations>(); // bind IOperationInterface interface to Operations
        }
    }
}