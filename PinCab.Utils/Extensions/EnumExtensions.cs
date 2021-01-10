using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.Utils.Extensions
{
    public static class EnumExtensions
    {
        //https://stackoverflow.com/questions/2650080/how-to-get-c-sharp-enum-description-from-value
        public static string GetDescriptionAttr<T>(this T source) 
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }

        public static string GetEnumDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute),
                    false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        //https://stackoverflow.com/questions/4367723/get-enum-from-description-attribute
        public static T GetValueFromDescription<T>(this string description) where T : Enum
        {
            foreach (var field in typeof(T).GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }

            throw new ArgumentException("Not found.", nameof(description));
            // Or return default(T);
        }

        public static List<string> GetEnumDescriptionList<T>() //where T : System.Enum
        {
            var list = new List<string>();
            var values = Enum.GetValues(typeof(T));
            foreach (var val in values)
            {
                var desc = GetDescriptionAttr(val);
                list.Add(desc.ToString());
            }
            return list.OrderBy(c => c).ToList();
        }

        //public static Dictionary<int, string> EnumNamedValues<T>() where T : System.Enum
        //{
        //    var result = new Dictionary<int, string>();
        //    var values = Enum.GetValues(typeof(T));

        //    foreach (int item in values)
        //        result.Add(item, Enum.GetName(typeof(T), item));
        //    return result;
        //}
    }
}
