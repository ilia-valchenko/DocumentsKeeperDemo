using DocumentsKeeperDemo.Core.Attributes;
using System;

namespace DocumentsKeeperDemo.Core.Extensions
{
    /// <summary>
    /// The text attribute extension.
    /// </summary>
    public static class TextAttributeExtension
    {
        /// <summary>
        /// Gets the string value.
        /// </summary>
        /// <returns>The string value.</returns>
        public static string ToStringValue(this Enum value)
        {
            TextAttribute[] attributes = (TextAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(TextAttribute), false);
            return ((attributes != null) && (attributes.Length > 0)) ? attributes[0].Value : value.ToString();
        }
    }
}
