using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.Utils.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Returns true if current object is equal to any of the items in objs[] or false if there are no matches.  (Safe if the object this method extends is null) (Do not use in Linq to SQL queries.)
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="objs"></param>
        /// <returns></returns>
        public static bool In<T>(this T obj, params T[] objs)
        {
            if (objs == null)
                return obj == null;

            foreach (T o in objs)
            {
                if (obj == null && o == null)
                    return true;
                else if (obj?.Equals(o) == true)
                    return true;
            }
            return false;
        }

        public static Object GetPropValue(this Object obj, String name)
        {
            foreach (String part in name.Split('.'))
            {
                if (obj == null) { return null; }

                Type type = obj.GetType();
                PropertyInfo info = type.GetProperty(part);
                if (info == null) { return null; }

                obj = info.GetValue(obj, null);
            }
            return obj;
        }

        public static T GetPropValue<T>(this Object obj, String name)
        {
            Object retval = GetPropValue(obj, name);
            if (retval == null) { return default(T); }

            // throws InvalidCastException if types are incompatible
            return (T)retval;
        }

        public static void SetPropValue(this Object obj, String name, object value)
        {
            PropertyInfo propertyInfo = obj.GetType().GetProperty(name);
            propertyInfo.SetValue(obj, Convert.ChangeType(value, propertyInfo.PropertyType), null);
        }
    }
}
