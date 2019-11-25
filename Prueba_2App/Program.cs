using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_2App
{
    class Program
    {
        static void Main(string[] args)
        {

            char op, op2;
            JugadorAdmin jug = new JugadorAdmin();
            do
            {
                op = Menu.MenuPrincipal(5, 5);

                switch (op)
                {
                    case '1':
                        jug.LeerJugador();
                        break;
                    case '2':
                        jug.Update();
                        break;
                    case '3':
                        jug.Delete();
                        break;
                    case '4':
                        jug.GetAll();
                        break;
                    case '0':
                        Console.WriteLine("Hasta la vista");
                        break;

                }
            } while (op != '0');

        }
    }
}
