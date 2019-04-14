namespace DocumentsKeeperDemo.Core.Extensions
{
    public static class StringExtension
    {
        public static string RemoveSpaces(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }

            return str.Replace(" ", string.Empty);
        }
    }
}