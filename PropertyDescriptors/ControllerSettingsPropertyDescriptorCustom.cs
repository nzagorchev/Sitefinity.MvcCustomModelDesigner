using SitefinityWebApp.PropertyDescriptors.Converters;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using Telerik.Microsoft.Practices.Unity;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Mvc.Proxy;
using Telerik.Sitefinity.Mvc.Proxy.TypeDescription;
using Telerik.Sitefinity.Pages;
using Telerik.Sitefinity.Pages.Model;

namespace SitefinityWebApp.PropertyDescriptors
{
    public class ControllerSettingsPropertyDescriptorCustom : ControllerSettingsPropertyDescriptor, IControlPropertyDescriptor
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

        public virtual new PropertyDescriptorCollection GetChildProperties(ControlProperty data)
        {
            PropertyDescriptorCollection properties = null;
            var controllerNameProperty = data.Control.Properties.Where(p => p.Name == "ControllerName").FirstOrDefault();
            if (controllerNameProperty != null)
            {
                Controller controllerInstanceFromName = this.GetControllerInstanceFromName(controllerNameProperty.Value);
                ControllerSettings controllerSettings = new ControllerSettings(controllerInstanceFromName);

                properties = base.GetChildProperties(data); // TypeDescriptor.GetProperties(controllerSettings);
                // get the properties for the component via instance
                for (int i = 0; i < properties.Count; i++)
                {
                    PropertyDescriptor prop = properties[i];
                    if (controllerSettings.Values.ContainsKey(prop.Name))
                    {
                        var actualProp = controllerSettings.Values[prop.Name];
                        if (actualProp != null && prop.PropertyType.FullName != actualProp.GetType().FullName)
                        {
                            prop = new DynamicPropertyDescriptorPreview(prop.Name, controllerSettings);
                            properties.RemoveAt(i);
                            properties.Add(prop);
                        }
                    }

                }
            }

            return properties;
        }

        private Controller GetControllerInstanceFromName(string controllerName)
        {
            if (string.IsNullOrEmpty(controllerName))
            {
                return null;
            }
            return (Controller)ObjectFactory.Resolve<ISitefinityControllerFactory>().CreateController(new RequestContext(), controllerName);
        }

        public static void Install(string controlPropertyDescriptorName)
        {
            ObjectFactory.Container.RegisterType<IControlPropertyDescriptor, ControllerSettingsPropertyDescriptorCustom>(controlPropertyDescriptorName);
        }
    }
}