using System.Text.RegularExpressions;

namespace Users.Domain.ValueObjects
{
    public class Email
    {
        public Email(string address)
        {
            if (string.IsNullOrEmpty(address) || address.Length < 5)
                throw new Exception("E-mail não pode ser vazio ou menor que 5 caracteres");
            else if (address.Length > 255)
                throw new Exception("E-mail não pode ter mais de 255 caracteres");

            this.Address = address.ToLower().Trim();
            const string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

            if (!Regex.IsMatch(address, pattern))
                throw new Exception("E-mail inválido");
        }

        public string Address { get; }
        
    }
}
