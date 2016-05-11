using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Telerik.Sitefinity.Mvc.Proxy;
using Telerik.Sitefinity.Mvc.Proxy.TypeDescription;

namespace SitefinityWebApp.PropertyDescriptors.Converters
{
    public class ControllerSettingsTypeConverterCustom : ControllerSettingsTypeConverter
    {
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            IDynamicMetaObjectProvider dynamicMetaObjectProvider = value as IDynamicMetaObjectProvider;
            if (dynamicMetaObjectProvider == null)
            {
                return new PropertyDescriptorCollection(new PropertyDescriptor[0]);
            }

            DynamicMetaObject metaObject = dynamicMetaObjectProvider.GetMetaObject(Expression.Constant(value));
            IEnumerable<string> dynamicMemberNames = metaObject.GetDynamicMemberNames();
            List<PropertyDescriptor> propertyDescriptors = new List<PropertyDescriptor>();
            foreach (string dynamicMemberName in dynamicMemberNames)
            {
                if (this.excludedProperties.Contains(dynamicMemberName))
                {
                    continue;
                }

                if (dynamicMemberName == DynamicPropertyDescriptorCustom.ModelPropertyName)
                {
                    propertyDescriptors.Add(new DynamicPropertyDescriptorCustom(dynamicMemberName, (ControllerSettings)dynamicMetaObjectProvider));
                    continue;
                }

                propertyDescriptors.Add(new DynamicPropertyDescriptor(dynamicMemberName, (ControllerSettings)dynamicMetaObjectProvider));
            }

            return new PropertyDescriptorCollection(propertyDescriptors.ToArray());
        }

        private string[] excludedProperties = new string[] 
        {
            "ActionInvoker",
            "ControllerContext",
            "HttpContext",
            "ModelState",
            "Request",
            "Response",
            "RouteData",
            "Server",
            "Session",
            "TempData",
            "TempDataProvider",
            "Url",
            "User",
            "ValidateRequest",
            "ValueProvider",
            "ViewBag",
            "ViewData",
            "ViewEngineCollection",
            "Profile",
            "AsyncManager",
            "Resolver"
        };
    }
}