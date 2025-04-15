using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Necesario
using System.Xml.Linq;

namespace LINQ{
    class Program{
        static void Main(string[] args){
            //Creamos un documento de XML mas completo

            XDocument documento = new XDocument(

                new XDeclaration("1.0", "utf-8", "yes"), //Declaracion del documento
                new XComment("Listado de alumnos"), //Un comentario
                new XProcessingInstruction("xml-stylesheet", "href='MyStyles.css title='Compact' type='text/css'"),

                new XElement("Alumnos", //Lleva namespace {http://nicosio.com}
                    new XElement("Ana", new XAttribute("ID", "10100"),
                        new XElement("Curso", "Administracion"),
                        new XElement("Promedio", "10")
                        ), //Fin de Ana

                    new XElement("Luis", new XAttribute("ID", "25350"),
                        new XElement("Curso", "Programacion"),
                        new XElement("Promedio", "9.5")
                        ) //Fin de Luis
                    ) //Fin de alumnos

                ); //Fin de documento


            //Mostramos el documento
            Console.WriteLine(documento);

            //Guardamos en disco
            documento.Save("alumnos.xml");

        }
    }
}