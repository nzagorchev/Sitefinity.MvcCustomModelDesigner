using System;
using Telerik.Sitefinity.Mvc.Proxy;

namespace SitefinityWebApp.PropertyDescriptors
{
    public class DynamicPropertyDescriptorPreview : DynamicPropertyDescriptorCustom
    {
        public DynamicPropertyDescriptorPreview(string propertyName, IControllerSettings instance)
            : base(propertyName, instance)
        {
        }

        public override Type PropertyType
        {
            get
            {
                if (this.instance.Values.ContainsKey(this.propertyName))
                {
                    if (this.instance.Values[this.propertyName] != null)
                    {
                        return this.instance.Values[this.propertyName].GetType();
                    }
                }

                return base.PropertyType;
            }
        }
    }
}