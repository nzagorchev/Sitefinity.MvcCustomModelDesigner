using SitefinityWebApp.NewsMvc;
using SitefinityWebApp.PropertyDescriptors;
using System;
using System.Collections.Generic;
using System.Web;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Frontend;
using Telerik.Sitefinity.Frontend.News.Mvc.Models;
using Telerik.Sitefinity.Services;

namespace SitefinityWebApp
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Bootstrapper.Bootstrapped += Bootstrapper_Bootstrapped;
        }

        protected void Bootstrapper_Bootstrapped(object sender, EventArgs e)
        {
			// ControllerSettingsPropertyDescriptorCustom
            ControllerSettingsPropertyDescriptorCustom.Install("Telerik.Sitefinity.Mvc.Proxy.MvcControllerProxy.Settings");
			ControllerSettingsPropertyDescriptorCustom.Install(string.Format("{0}.{1}", typeof(Telerik.Sitefinity.Mvc.Proxy.MvcProxyBase).FullName, "Settings"));
			ControllerSettingsPropertyDescriptorCustom.Install(string.Format("{0}.{1}", typeof(Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.MvcWidgetProxy).FullName, "Settings"));

            // MVC News Model
            FrontendModule.Current.DependencyResolver.Rebind<INewsModel>().To<NewsModelCustom>();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}