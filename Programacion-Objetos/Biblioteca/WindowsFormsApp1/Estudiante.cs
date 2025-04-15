using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Estudiante
    {
        public int ID { get; set; }
        public string Matricula { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public int Id_Libro1 { get; set; }
        public int Id_Libro2{ get; set; }
        public int Id_Libro3 { get; set; }
        public bool Activo { get; set; }
    }
}
