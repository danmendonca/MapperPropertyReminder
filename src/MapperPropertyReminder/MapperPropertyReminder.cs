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
                    return false;
                }

                try
                {
                    var instance = Activator.CreateInstance(property.PropertyType);

                    if (propValue.Equals(instance))
                    {
                        return false;
                    }
                }
                catch (MissingMethodException)
                {
                    continue;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            return true;
        }
    }
}