# Sitefinity.MvcCustomModelDesigner
Sitefinity extension that provides functionality to set properties of a custom Model directly from the Widget Designer.

To inject a custom Model to a widget Controller follow:
[http://docs.sitefinity.com/feather-extend-the-navigation-widget-model](http://docs.sitefinity.com/feather-extend-the-navigation-widget-model "Extend widget model")

### Default behavior
The designer uses the ControlPropertyService to read/write the widget properties. It uses the Controller properties and the inner properties of the Model property. However, the Model property in the Controller is the **model Interface type**.

The Designer uses the Model property and resolves it using Property Descriptors. It gets the property type, which is the interface of the model (in this sample case INewsModel). Using the interface type, it generates the properties and passes them to the designer.
This is why the properties from the custom model do not appear and cannot be modified OTB from the Designer.

### Behavior using this sample
This sample overrides the default Property Descriptors. This way the **actual Model type** (in this sample case NewsModelCustom) is used to generate the properties passed to the designer.
This way the custom Model properties can also be set using the Default designer.

### Installation:
1. Copy the PropertyDescriptors folder in your application.
2. Register the ControllerSettingsPropertyDescriptorCustom in the Global Application class as shown.

### Sample:
1. Copy the NewsMvc folder in your application.
2. Use the News Views from the package folder.
3. Register the NewsModelCustom in the Global Application class as shown.