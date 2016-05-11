using SitefinityWebApp.PropertyDescriptors.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Mvc.Proxy.TypeDescription;
using Telerik.Sitefinity.Pages;
using Telerik.Microsoft.Practices.Unity;

namespace SitefinityWebApp.PropertyDescriptors
{
    public class ControllerSettingsPropertyDescriptorCustom : ControllerSettingsPropertyDescriptor
    {
        public ControllerSettingsPropertyDescriptorCustom(PropertyInfo propertyInfo)
            : base(propertyInfo)
        {

        }

        public override TypeConverter Converter
        {
            get
            {
                return new ControllerSettingsTypeConverterCustom();
            }
        }

        public static void Install(string controlPropertyDescriptorName)
        {
            ObjectFactory.Container.RegisterType<IControlPropertyDescriptor, ControllerSettingsPropertyDescriptorCustom>(controlPropertyDescriptorName);
        }
    }
}