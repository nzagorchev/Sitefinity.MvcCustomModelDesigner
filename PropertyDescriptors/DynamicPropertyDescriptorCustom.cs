using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.Mvc.Proxy;
using Telerik.Sitefinity.Mvc.Proxy.TypeDescription;

namespace SitefinityWebApp.PropertyDescriptors
{
    public class DynamicPropertyDescriptorCustom : DynamicPropertyDescriptor
    {
        public DynamicPropertyDescriptorCustom(string propertyName, IControllerSettings instance)
            : base(propertyName, instance)
        {
            if (instance != null)
            {
                this.instance = instance;
                this.propertyName = propertyName;
            }
        }

        public override PropertyDescriptorCollection GetChildProperties(object instance, Attribute[] filter)
        {
            if (this.propertyName == DynamicPropertyDescriptorCustom.ModelPropertyName)
            {
                // Use actual instance properties.
                var modelInstance = this.instance.Values[this.propertyName];
                // descriptor.GetChildProperties uses the TypeDescriptor.GetProperties underneath.
                return TypeDescriptor.GetProperties(modelInstance);
            }

            var @base = base.GetChildProperties(instance, filter);
            return @base;
        }

        protected IControllerSettings instance { get; set; }

        protected string propertyName { get; set; }

        internal static readonly string ModelPropertyName = "Model";
    }
}