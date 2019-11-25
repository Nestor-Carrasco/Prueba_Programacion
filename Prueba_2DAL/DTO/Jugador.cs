using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaApp;

namespace Prueba_2DAL
{
    public enum Categoria
    {
        Avanzado = 'A',
        Basico = 'B',
        Intermedio = 'I',
        Principiante = 'P'
    }
    public enum Plataforma
    {
        Playstation = 1,
        Xbox = 2,
        Pc = 3,
        Arcade = 4,
        Nintendo = 5
    }

    public class Jugador
    {
        private string rut_jugador;
        private string nombre_jugador;
        private string fecha_registro;
        private char cod_categoria;
        private int cod_plataforma;
        private Categoria categorias;
        private Plataforma plataformas;
        private string fechaYMD;

        public string Rut_jugador { get => rut_jugador; set => rut_jugador = value; }
        public string Nombre_jugador { get => nombre_jugador; set => nombre_jugador = value; }
        public char Cod_categoria { get => cod_categoria; set => cod_categoria = value; }
        public int Cod_plataforma { get => cod_plataforma; set => cod_plataforma = value; }
        public Categoria Categorias { get => categorias; set => categorias = value; }
        public Plataforma Plataformas { get => plataformas; set => plataformas = value; }
        public string FechaYMD { get => fechaYMD; }
        public string Fecha_registro
        {
            get => fecha_registro;
            set
            {
                fecha_registro = value;
                fechaYMD = Funciones.FechaYMD(value);
            }
        }
    }
}
