using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace BibliotecaApp
{
    public class ConexionBD
    {
        static MySqlConnection Conex =
               new MySqlConnection("Server=localhost;Database=gamers_bd;Uid=root;PWD=''");
        MySqlCommand Comando = new MySqlCommand("", Conex);
        MySqlDataReader Rec;

        public void AbrirConexion()
        {
            try
            {
                if (Conex.State == ConnectionState.Closed)
                {
                    Conex.Open();
                    //Console.WriteLine("Conexion existosa");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error de conexion: " + ex.Message);
            }
        }
        public void CerrarConexion()
        {
            try
            {
                if (Conex.State == ConnectionState.Open)
                {
                    Conex.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error de desconexion: " + ex.Message);
            }
        }
        public int EjecutarIUD(string CadSql)
        {
            int fila = 0;
            try
            {
                AbrirConexion();
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = CadSql;
                fila = Comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
            return (fila);
        }
        public MySqlDataReader EjecutarConsulta(string CadSql)
        {
            Rec = null;
            try
            {
                AbrirConexion();
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = CadSql;
                Rec = Comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error consulta: " + ex.Message);
            }
            return (Rec);
        }

    }

}
