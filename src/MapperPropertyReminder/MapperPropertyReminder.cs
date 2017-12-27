namespace MapperPropertyReminder
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public static class MapperReminder
    {
        public static bool AllPropertiesSet(object myObject)
        {
            Type myType = myObject.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            foreach (PropertyInfo property in props)
            {
                object propValue = property.GetValue(myObject, null);

                if (propValue == null)
                {
                    throw new Exception($"{myType.Name}.{property.Name} is not set");
                }

                try
                {
                    var instance = Activator.CreateInstance(property.PropertyType);

                    if (propValue.Equals(instance))
                    {
                        throw new Exception($"{myType.Name}.{property.Name} has default value");
                    }
                }
                catch (MissingMethodException)
                {
                    continue;
                }
                catch (Exception e)
                {
                    throw new Exception($"{myType.Name}.{property.Name} could not be validated", e);
                }
            }

            return true;
        }
    }
}
