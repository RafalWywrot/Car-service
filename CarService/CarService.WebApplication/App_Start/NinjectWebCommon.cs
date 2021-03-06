﻿[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CarService.WebApplication.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(CarService.WebApplication.App_Start.NinjectWebCommon), "Stop")]

namespace CarService.WebApplication.App_Start
{
    using CarService.Repository;
    using CarService.Repository.Abstract;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using System;
    using System.Web;

    using Ninject.Extensions.Conventions;
    using NHibernate;
    using Microsoft.Owin.Security;
    using Microsoft.AspNet.Identity;
    using NHibernate.AspNet.Identity;
    using Ninject.Web.Mvc.FilterBindingSyntax;
    using System.Web.Mvc;
    
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                kernel.Bind<ISession>().ToMethod(x => x.Kernel.Get<IUnitOfWork>().Session);
                kernel.Bind<ApplicationUserManager>().ToSelf();
                kernel.Bind<ApplicationSignInManager>().ToSelf();
                kernel.Bind<IAuthenticationManager>().ToMethod(x => HttpContext.Current.GetOwinContext().Authentication);
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            
            kernel.Bind(x => x.FromAssembliesMatching("*").SelectAllClasses().Excluding<UnitOfWork>().BindDefaultInterface());
        }
    }
}