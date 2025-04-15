using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Libro
    {
        public int ID { get; set; }
        public int ID_Libro { get; set; }
        public string Titulo { get; set; }
        public string Categoria { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public bool Prestado { get; set; }
        
    }
}
