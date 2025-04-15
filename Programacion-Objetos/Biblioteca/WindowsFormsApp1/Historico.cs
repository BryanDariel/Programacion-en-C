using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Historico
    {
        public int ID { get; set; }
        public string ID_Estudiante { get; set; }
        public int ID_Libro { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public DateTime FechaEntregado { get; set; }
    }
}
