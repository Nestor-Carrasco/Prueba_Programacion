using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaApp;
using Prueba_2DAL;
using MySql.Data.MySqlClient;

namespace Prueba_2DAL
{
    public class JugadorDAL
    {
        public static List<Jugador> jugadores = new List<Jugador>();
        public void ADD(Jugador jugador)
        {
            string CadSql;
            ConexionBD CDB = new ConexionBD();
            var categoriaX = "";
            var categoriaAux = jugador.Categorias.ToString();
            if (categoriaAux.Equals("Avanzado"))
            {
                categoriaX = "A";
            }
            else if (categoriaAux.Equals("Basico"))
            {
                categoriaX = "B";
            }
            else if (categoriaAux.Equals("Intermedio"))
            {
                categoriaX = "I";
            }
            else if (categoriaAux.Equals("Principiante"))
            {
                categoriaX = "P";
            }
            CadSql = "Insert into jugador (rut_jugador, nombre_jugador, fecha_registro, cod_categoria, cod_plataforma) values('" + jugador.Rut_jugador + "','" + jugador.Nombre_jugador + "','" + jugador.FechaYMD + "','" + categoriaX + "','" + jugador.Plataformas.GetHashCode() + "');";
            if (CDB.EjecutarIUD(CadSql) > 0)
            {
                Console.WriteLine("Jugador guardado Correctamente...");
                jugadores.Add(jugador);
            }
            else
            {
                Console.WriteLine("Error al crear jugador");
            }

        }

        public int Update(Jugador jugador)
        {
            var categoriaX = "";
            var categoriaAux = jugador.Categorias.ToString();
            if (categoriaAux.Equals("Avanzado"))
            {
                categoriaX = "A";
            }
            else if (categoriaAux.Equals("Basico"))
            {
                categoriaX = "B";
            }
            else if (categoriaAux.Equals("Intermedio"))
            {
                categoriaX = "I";
            }
            else if (categoriaAux.Equals("Principiante"))
            {
                categoriaX = "P";
            }

            var fechaAUX = Funciones.FechaYMD(jugador.Fecha_registro);

            int fila = 0;
            string CadSQL;
            ConexionBD CBD = new ConexionBD();
            CadSQL = "Update jugador set nombre_jugador= '" + jugador.Nombre_jugador
                + "'," + "fecha_registro='" + fechaAUX + "'," + "cod_categoria= '"
                + categoriaX + "'," + "cod_plataforma= '" + jugador.Plataformas.GetHashCode() + "' Where rut_jugador= '" + jugador.Rut_jugador + "';";
            fila = CBD.EjecutarIUD(CadSQL);
            return (fila);
        }

        public int Delete(string rut)
        {
            int fila = 0;
            ConexionBD CDB = new ConexionBD();
            string CadSql;
            CadSql = "Delete from jugador where rut_jugador='" + rut + "';";
            fila = CDB.EjecutarIUD(CadSql);
            return (fila);
        }

        public Jugador findJugador(string rut)
        {
            MySqlDataReader Rec;
            ConexionBD CDB = new ConexionBD();
            Jugador jugador;
            string CadSql;
            CadSql = "SELECT j.rut_jugador , j.nombre_jugador, j.fecha_registro, c.des_categoria, p.des_plataforma " +
                "FROM jugador j INNER JOIN categoria c ON j.cod_categoria = c.cod_categoria INNER JOIN plataforma p ON j.cod_plataforma = p.cod_plataforma " +
                "WHERE j.rut_jugador='" + rut + "';";
            Rec = CDB.EjecutarConsulta(CadSql);
            if (Rec.Read())
            {
                jugador = new Jugador();
                jugador.Rut_jugador = Rec["rut_jugador"].ToString();
                jugador.Nombre_jugador = Rec["nombre_jugador"].ToString();
                jugador.Fecha_registro = (Rec["fecha_registro"].ToString());
                Convert.ToDateTime(jugador.Fecha_registro);
                jugador.Categorias = (Categoria)Enum.Parse(typeof(Categoria), Rec["des_categoria"].ToString());
                jugador.Plataformas = (Plataforma)Enum.Parse(typeof(Plataforma), Rec["des_plataforma"].ToString());
            }
            else
            {
                jugador = null;
            }
            CDB.CerrarConexion();
            return (jugador);

        }
    }
}
