using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaApp;
using Prueba_2DAL;



namespace Prueba_2App
{
    public class JugadorAdmin
    {
        private bool cargada = false;
        string categoria, plataforma, rutAux;
        Funciones funciones = new Funciones();
        public void LeerJugador()
        {

            Jugador jug = new Jugador();
            JugadorDAL jugador = new JugadorDAL();
            Console.Clear();

            Console.SetCursorPosition(5, 5);
            Console.Write("*** Registro de Jugador ***");
            Console.SetCursorPosition(5, 6);
            Console.Write("Rut Jugador           : ");
            Console.SetCursorPosition(5, 7);
            Console.Write("Nombre Jugador        : ");
            Console.SetCursorPosition(5, 8);
            Console.Write("Fecha Registro        : ");
            Console.SetCursorPosition(5, 9);
            Console.Write("Categoria             : ");
            Console.SetCursorPosition(5, 10);
            Console.Write("Plataforma            : ");

            var valido = false;
            do
            {

                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(29, 6);
                //  jug.Rut_jugador = Console.ReadLine();
                rutAux = Console.ReadLine();
                if (funciones.validarRut(rutAux) == false)
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(5, 15);
                    Console.Write("El Rut no es válido");
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Funciones.BorrarContenido(29, 6, rutAux.Length);

                    valido = false;
                }
                // 8.647.835-8
                else if (rutAux.Length <= 12 && rutAux.Length >= 8)
                {

                    valido = true;
                    jug.Rut_jugador = rutAux;
                }
            }
            while (valido == false);

            // Validación Nombres
            do
            {
                Console.SetCursorPosition(29, 7);
                jug.Nombre_jugador = Console.ReadLine();
                if (!Funciones.ValidarNombre(jug.Nombre_jugador))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(5, 15);
                    Console.Write("El nombre solo puede contener Letras");
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Funciones.BorrarContenido(29, 7, jug.Nombre_jugador.Length);
                }

            } while (!Funciones.ValidarNombre(jug.Nombre_jugador));



            // Validación Fecha
            var fecha = "";
            do
            {

                Console.SetCursorPosition(29, 8);
                fecha = Console.ReadLine();

                if (Funciones.ValidarFechaMayor(fecha))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(5, 15);
                    Console.Write("Error, La fecha Ingresada no debe ser mayor a 30/06/2019");
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Funciones.BorrarContenido(29, 8, fecha.Length);
                }
                jug.Fecha_registro = fecha;
            } while (Funciones.ValidarFechaMayor(fecha));







            // Ingreso y validación de la Categoria
            do
            {
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(29, 9);
                categoria = Console.ReadLine();
                if (!Enum.IsDefined(typeof(Categoria), categoria))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(5, 15);
                    Console.Write("La Categoria no es válida");
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Funciones.BorrarContenido(29, 9, categoria.Length);

                }
            } while (!Enum.IsDefined(typeof(Categoria), categoria)); //funciona con el nombre, no con el valor
            // Ingreso y validación de la Plataforma
            do
            {
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(29, 10);
                plataforma = Console.ReadLine();
                if (!Enum.IsDefined(typeof(Plataforma), plataforma))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(5, 15);
                    Console.Write("La Plataforma no es válida");
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Funciones.BorrarContenido(29, 10, plataforma.Length);

                }
            } while (!Enum.IsDefined(typeof(Plataforma), plataforma)); //funciona con el nombre, no con el valor
            Funciones.BorrarContenido(5, 15, 40);

            try
            {
                jug.Categorias = (Categoria)Enum.Parse(typeof(Categoria), categoria);
                jug.Plataformas = (Plataforma)Enum.Parse(typeof(Plataforma), plataforma);
                jugador.ADD(jug);
                Console.SetCursorPosition(5, 28);
                Console.Write("Presione una tecla para continuar........");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine(jug.ToString());
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }

        }

        public void Delete()
        {
            string rut, respuesta;
            Jugador jug;
            JugadorDAL jugDAL = new JugadorDAL();
            Console.Clear();
            do
            {
                Console.Write("Ingrese rut del jugador a eliminar: ");
                rut = Console.ReadLine();
            } while (rut.Trim().Length == 0);
            jug = jugDAL.findJugador(rut);
            if (jug != null)
            {
                Console.WriteLine(jug.ToString());
                do
                {
                    Console.Write("¿Eliminar Jugador? (si/no): ");
                    respuesta = Console.ReadLine();
                } while (!respuesta.ToLower().Equals("si") && !respuesta.ToLower().Equals("no"));
                if (respuesta.Equals("si"))
                {
                    if (jugDAL.Delete(rut) > 0)
                    {
                        Console.WriteLine("Jugador eliminado");
                    }
                    else
                    {
                        Console.WriteLine("Error al eliminar Jugador");
                    }
                }
            }
            else
            {
                Console.WriteLine("Jugador no encontrado");
            }
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }


        public void GetAll()
        {
            JugadorDAL jugDAL = new JugadorDAL();
            if (cargada == false)
            {
                cargada = true;
                JugadorDAL.jugadores.Clear();
                ConexionBD CDB = new ConexionBD();
                MySqlDataReader Rec = null;
                string cadSql;
                Jugador jug;
                cadSql = "SELECT j.rut_jugador , j.nombre_jugador, j.fecha_registro, c.des_categoria, p.des_plataforma  " +
                "FROM jugador j INNER JOIN categoria c ON j.cod_categoria = c.cod_categoria INNER JOIN plataforma p ON j.cod_plataforma = p.cod_plataforma " + ";";
                Rec = CDB.EjecutarConsulta(cadSql);
                while (Rec.Read())
                {
                    jug = new Jugador();
                    jug.Rut_jugador = Rec["rut_jugador"].ToString();
                    jug.Nombre_jugador = Rec["nombre_jugador"].ToString();
                    jug.Fecha_registro = Rec["fecha_registro"].ToString();
                    jug.Categorias = (Categoria)Enum.Parse(typeof(Categoria), Rec["des_categoria"].ToString());
                    jug.Plataformas = (Plataforma)Enum.Parse(typeof(Plataforma), Rec["des_plataforma"].ToString());
                    JugadorDAL.jugadores.Add(jug);
                }
                CDB.CerrarConexion();
            }
            Console.Clear();
            Console.WriteLine("Número   Rut Nombre  Fecha Ingreso   Categoria   Plataforma");
            var n = 1;
            foreach (Jugador jug in JugadorDAL.jugadores)
            {

                Console.WriteLine("{0}  {1} {2} {3} {4} {5}",
                    n, jug.Rut_jugador, jug.Nombre_jugador, jug.Fecha_registro, jug.Categorias, jug.Plataformas);
                n++;
            }
            Console.WriteLine("\n\nPresione una tecla para continuar....");
            Console.ReadKey();

        }

        public void Update()
        {
            Jugador jug;
            Jugador jugNuevo = new Jugador();
            string rut;
            string sector, fecha;
            JugadorDAL jugDAL = new JugadorDAL();

            Console.Clear();
            do
            {
                Console.Write("Ingrese rut de jugador a actualizar: ");
                rut = Console.ReadLine();
            } while (rut.Trim().Length == 0);
            jug = jugDAL.findJugador(rut);
            if (jug != null)
            {
                Console.SetCursorPosition(5, 5);
                Console.Write("***Datos Actuales Jugador***");
                Console.SetCursorPosition(5, 6);
                Console.Write("Rut Jugador       : " + jug.Rut_jugador);
                Console.SetCursorPosition(5, 7);
                Console.Write("Nombre Jugador    : " + jug.Nombre_jugador);
                Console.SetCursorPosition(5, 8);
                Console.Write("Fecha Registro    : " + jug.Fecha_registro);
                Console.SetCursorPosition(5, 9);
                Console.Write("Categoria         : " + jug.Categorias);
                Console.SetCursorPosition(5, 10);
                Console.Write("Plataforma        : " + jug.Plataformas);

                Console.SetCursorPosition(5, 23);
                Console.Write("*** Presione Enter si no quiere Modificar un Dato ***");
                Console.SetCursorPosition(5, 13);
                Console.Write("*** Nuevos Datos Jugador ***");
                Console.SetCursorPosition(5, 14);
                Console.Write("Nombre Jugador   : ");
                Console.SetCursorPosition(5, 15);
                Console.Write("Fecha Registro   : ");
                Console.SetCursorPosition(5, 16);
                Console.Write("Categoria        : ");
                Console.SetCursorPosition(5, 17);
                Console.Write("Plataforma       : ");


                Console.SetCursorPosition(24, 14);
                jugNuevo.Nombre_jugador = Console.ReadLine();
                if (jugNuevo.Nombre_jugador.Trim().Equals(""))
                {
                    jugNuevo.Nombre_jugador = jug.Nombre_jugador;
                    Console.SetCursorPosition(24, 14);
                    Console.Write(jug.Nombre_jugador);
                }
                Console.SetCursorPosition(24, 15);
                jugNuevo.Fecha_registro = Console.ReadLine();
                if (jugNuevo.Fecha_registro.Trim().Equals(""))
                {
                    var fechaAux = Funciones.FechaYMD(jugNuevo.Fecha_registro);
                    jugNuevo.Fecha_registro = fechaAux;

                    Console.SetCursorPosition(24, 15);
                    Console.Write(jugNuevo.Fecha_registro);
                }

                do
                {

                    Console.SetCursorPosition(24, 16);
                    categoria = Console.ReadLine();

                    if (categoria.Trim().Equals(""))
                    {
                        jugNuevo.Categorias = jug.Categorias;
                        categoria = "Basico";
                    }
                    else
                    {
                        if (!Enum.IsDefined(typeof(Categoria), categoria))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(5, 24);
                            Console.Write("El Categoria no es válido");
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Funciones.BorrarContenido(24, 16, categoria.Length);

                        }
                    }
                } while (!Enum.IsDefined(typeof(Categoria), categoria)); //funciona con el nombre, no con el valor

                do
                {

                    Console.SetCursorPosition(24, 17);
                    plataforma = Console.ReadLine();

                    if (plataforma.Trim().Equals(""))
                    {
                        jugNuevo.Plataformas = jug.Plataformas;
                        plataforma = "PC";
                    }
                    else
                    {
                        if (!Enum.IsDefined(typeof(Plataforma), plataforma))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(5, 24);
                            Console.Write("La Plataforma no es válida");
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Funciones.BorrarContenido(24, 17, plataforma.Length);

                        }
                    }
                } while (!Enum.IsDefined(typeof(Plataforma), plataforma)); //funciona con el nombre, no con el valor
                Funciones.BorrarContenido(5, 24, 40);
                try
                {
                    jugNuevo.Categorias = (Categoria)Enum.Parse(typeof(Categoria), categoria);
                    jugNuevo.Plataformas = (Plataforma)Enum.Parse(typeof(Plataforma), plataforma);
                    Console.SetCursorPosition(5, 24);
                    jugNuevo.Rut_jugador = jug.Rut_jugador;
                    if (jugDAL.Update(jugNuevo) > 0)
                    {

                        Console.Write("Jugador Modificado Exitosamente........");
                    }
                    else
                    {
                        Console.Write("Jugador no Modificado");
                    }
                    Console.SetCursorPosition(5, 25);
                    Console.Write("Presione una tecla para continuar........");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine(jug.ToString());
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }
            }
            else
            {
                Console.SetCursorPosition(10, 5);
                Console.Write("No existe el Jugador");
            }
            Console.ReadKey();
        }
    }
}
