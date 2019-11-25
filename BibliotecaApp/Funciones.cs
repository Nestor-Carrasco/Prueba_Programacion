using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BibliotecaApp
{
    public class Funciones
    {
        public static string FechaYMD(string fechaDMY)
        {
            //se recibe una fecha en formato dd-mm-yyyy
            //para evitar problemas, reemplazamos el / por -
            string fecha = fechaDMY.Replace('/', '-');
            string[] arrFecha = fecha.Split('-');
            return (arrFecha[2] + "-" + arrFecha[1] + "-" + arrFecha[0]);
        }
        public static void BorrarContenido(int PosX, int PosY, int cantidad)
        {
            string cadena = "";
            for (int i = 0; i < cantidad; i++)
            {
                cadena = cadena + " ";
            }
            Console.SetCursorPosition(PosX, PosY);
            Console.Write(cadena);
        }

        public bool validarRut(string rut)
        {

            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception)
            {
            }
            return validacion;
        }

        public static bool ValidarNombre(string input)
        {
            return Regex.IsMatch(input, "^[a-zA-Z]+$");
        }

        public static Boolean ValidarFechaMayor(string fechaDMY)
        {
            string fecha;
            fecha = fechaDMY.Replace('/', '-');

            string[] arrFecha = fecha.Split('-');
            if (int.Parse(arrFecha[2]) > 2019 || int.Parse(arrFecha[1]) > 6 || int.Parse(arrFecha[0]) > 30)
            {
                return true;
            }
            return false;
        }
    }
}
