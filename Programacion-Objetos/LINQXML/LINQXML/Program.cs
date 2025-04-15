using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

//Necesario
using System.Xml.Linq;

namespace LinQ{
    class Program
    {
        static void Main(string[] args)
        {

            var escuela = new XElement("Escuela",
                                        new XElement("Ciencias",
                                        new XElement("Materia", "Matematicas"),
                                        new XElement("Materia", "Fisica")
                                        ),
                                    new XElement("Artes",
                                        new XElement("Materia", "Historial del arte"),
                                        new XElement("Practica", "Pintura")
                                        )
                                    );

            Console.WriteLine(escuela);

            Console.WriteLine("---------------------------------------------");

            //Nodes regresa a los hijos
            foreach (XNode nodo in escuela.Nodes())
                Console.WriteLine(nodo.ToString());

            Console.WriteLine("---------------------------------------------");

            //Elements regresa a los hijos de los nodos de tipo XElement
            foreach (XElement elemento in escuela.Elements())
                Console.WriteLine(elemento.Name + "=" + elemento.Value);

            Console.WriteLine("---------------------------------------------");

            //FirstNode nos regresa el primer nodo
            Console.WriteLine(escuela.FirstNode);

            //Encontramos el padre el primer nodo
            Console.WriteLine(escuela.FirstNode.Parent.Name);

            Console.WriteLine("---------------------------------------------");

            //LastNode nos regresa el ultimo nodo

            Console.WriteLine(escuela.LastNode.Parent.Name);

            Console.WriteLine("---------------------------------------------");

            //Obtiene todos los elementos del donde se encuentre Fisia
            //IEnumerable<string> materias = from curso in escuela.Elements()
        }
    }
}