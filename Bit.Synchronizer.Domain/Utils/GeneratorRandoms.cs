using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Domain.Utils
{
    public class GeneratorRandoms
    {
        private static Random random = new Random();

        /// <summary>
        /// Genera cantidad de caracteres aleatorios
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Genera cantidad de numeros aleatorios
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string RandomStringOfNumber(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Genera codigo de contrato
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GeneratedCode()
        {
            return $"{RandomStringOfNumber(8)}-{RandomString(4)}-{RandomString(4)}";
        }
    }
}
