using PA.CampeonatoXadrez;
using PA.CampeonatoXadrez.CrossCutting.IOC;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WebActivatorEx;

[assembly: PostApplicationStartMethod(typeof(SimpleInjectorInitializer), "Initialize")]
namespace PA.CampeonatoXadrez
{
    public class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Chamada dos módulos do Simple Injector
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
        private static void InitializeContainer(SimpleInjector.Container container)
        {
            BootStrapper.RegisterServices(container);
        }
    }
}