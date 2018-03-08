using System;

namespace DocumentsKeeperDemo.Core.Attributes
{
    /// <summary>
    /// The text attribute.
    /// </summary>
    public sealed class TextAttribute : Attribute
    {
        /// <summary>
        /// The text value.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextAttribute"/> class.
        /// </summary>
        /// <param name="value">The text value.</param>
        public TextAttribute(string value)
        {
            this.Value = value;
        }
    }
}
