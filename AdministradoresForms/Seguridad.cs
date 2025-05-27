using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECOT_PROYECT.AdministradoresForms
{
    using System.Security.Cryptography;
    using System.Text;

    public static class Seguridad
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        public static bool VerificarPassword(string input, string hashAlmacenado)
        {
            return HashPassword(input) == hashAlmacenado;
        }
    }

}
