using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_2App
{
    class Menu
    {
        public static char MenuPrincipal(int PosX, int PosY)
        {
            char op;
            Console.Title = "Gestion AppGamers";
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.SetCursorPosition(PosX, PosY);
            Console.Write("********** Menu Principal **********");
            Console.SetCursorPosition(PosX, PosY + 1);
            Console.Write("Agregar Jugador      [1]");
            Console.SetCursorPosition(PosX, PosY + 2);
            Console.Write("Modificar Jugador    [2]");
            Console.SetCursorPosition(PosX, PosY + 3);
            Console.Write("Eliminar Jugador     [3]");
            Console.SetCursorPosition(PosX, PosY + 4);
            Console.Write("Listar Jugadores     [4]");
            Console.SetCursorPosition(PosX, PosY + 5);
            Console.Write("Salir                [0]");
            Console.SetCursorPosition(PosX, PosY + 6);
            Console.Write("Ingrese Opcion       [ ]");

            do
            {
                Console.SetCursorPosition(PosX + 22, PosY + 6);
                op = Console.ReadKey().KeyChar;
            } while (op != '1' && op != '2' && op != '3' && op != '4' && op != '0');
            return (op);
        }
    }
}
