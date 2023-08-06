namespace Users.Domain.ExtensionMethods
{
    public static class DateTimeExtension
    {
        public static DateTime? ToDateTime(this string value)
        {
            DateTime dt;
            if (!string.IsNullOrWhiteSpace(value))
               if( DateTime.TryParse(value, out dt))
                {
                    return dt;  
                }

            return null;
        }
    }
}
