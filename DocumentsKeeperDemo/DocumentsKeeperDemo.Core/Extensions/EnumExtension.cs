using DocumentsKeeperDemo.Core.Attributes;
using System;
using System.Linq;
using System.Reflection;

namespace DocumentsKeeperDemo.Core.Extensions
{
    /// <summary>
    /// The enum extension class.
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// Converts the string value to corresponding enum value.
        /// </summary>
        /// <typeparam name="T">The enum.</typeparam>
        /// <param name="textAttributeStringValue">The string value</param>
        /// <returns>
        /// Returns the value from enum.
        /// </returns>
        public static T FromTextAttributeStringToEnumValue<T>(this string textAttributeStringValue) where T: struct, IConvertible
        {
            MemberInfo[] memberInfos = typeof(T).GetMembers(BindingFlags.Public | BindingFlags.Static);
            
            foreach(var item in memberInfos)
            {
                if(item.GetCustomAttributes().Any())
                {
                    var customAttribute = item.GetCustomAttributes(typeof(TextAttribute), false).First();
                    var textAttribute = ((TextAttribute)customAttribute);

                    if (textAttribute.Value == textAttributeStringValue)
                    {
                        var enumValue = (T)Enum.Parse(typeof(T), item.Name);
                        return enumValue;
                    }
                }
            }

            return default(T);
        }
    }
}