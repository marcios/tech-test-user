using System.Text;

namespace Users.Domain.ExtensionMethods
{
    public static class StringExtensions
    {
        public static string ToBase64(this string value)
        {
            if (string.IsNullOrEmpty(value)) return value;

            byte[] textoAsBytes = Encoding.ASCII.GetBytes(value);
            string convertedValue = System.Convert.ToBase64String(textoAsBytes);
            return convertedValue;
        }


    }
}
