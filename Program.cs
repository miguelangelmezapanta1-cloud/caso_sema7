using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caso_sema7
{
    internal class Program
    {
        static int max = 100;
        static string[] nombres = new string[max];
        static double[] notas = new double[max];
        static int contador = 0;
        static public void Titulo ()
        
        {
            Console.WriteLine("**************************");
            Console.WriteLine("Sistema deGestion de notas");
            Console.WriteLine("**************************");
        }
        static public void Registrar_estudiante() 
        {
            Console.WriteLine("registro de estudiante nuevo:");
            if(contador >= 100)
            {
                Console.WriteLine("alcanzo la capacidad maxima");
                return;
            }
            Console.Write("ingresar nombre del estudiante");
            string nombre = Console.ReadLine();
            double nota;
            while (true)
            {
                Console.Write("ingresar nota[o-20]:");
                nota=double.Parse(Console.ReadLine());
                if (nota >=0 && nota <= 20)
                {
                    break;
                }
                Console.WriteLine("error, volver a ingresar la nota[0-20]:");
            }
            nombres[contador] = nombre;
            notas[contador] = nota;
            contador++;
            Console.WriteLine("registrocon exito...!!");
        }
        static public void buscar_estudiante()
        {

        }
    }
}
