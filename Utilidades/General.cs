using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Utilidades
{
    public class General
    {
        public static bool ValidarSoloLetras(string texto)
        {
           
            return Regex.IsMatch(texto, "^[a-zA-Z ]+$");
        }

        public static string FormatearNombre(string nombre)
        {
            string[] palabras = nombre.Split(' ');

            for (int i = 0; i < palabras.Length; i++)
            {
                if (!string.IsNullOrEmpty(palabras[i]))
                {
                    palabras[i] = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(palabras[i].ToLower());
                }
            }

            return string.Join(" ", palabras);
        }
        public static object ValidarEnteros(object PosibleEntero, int TipoEntero = 32)
        {
            try
            {
                switch (TipoEntero)
                {
                    case 16:
                        return Convert.ToInt16(PosibleEntero);
                    case 32:
                        return Convert.ToInt32(PosibleEntero);
                    case 64:
                        return Convert.ToInt64(PosibleEntero);
                    default:
                        return 0;
                }
            }
            catch
            {
                return 0;
            }
        }
        public static object ValidarDecimal(object PosibleDecimal)
        {
            try { return (decimal)PosibleDecimal; } catch { return 0; }
        }
        public static bool validarComplejidadPassword(string password, short LongitudMinima = 8)
        {
            int Mayusculas = 0;
            int Minisculas = 0;
            int Numeros = 0;

            for (int i = 0; i <= password.Length - 1; i++)
            {
                if (char.IsUpper(password[i]))
                {
                    Mayusculas += 1;
                }
                else if (char.IsLetter(password[i]))
                {
                    Minisculas += 1;
                }
                else if (char.IsDigit(password[i]))
                {
                    Numeros += 1;
                }

            }
            return password.Length >= LongitudMinima && Mayusculas >= 1 && Minisculas >= 1 && Numeros >= 1;

        }
        public static bool CorreoEsValido(string correo)
        {
            string patron = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(patron);
            return regex.IsMatch(correo);
        }

        public static bool ValidarSinEspacios(string texto)
        {
            return !texto.Contains(" ");
        }
    }
}

