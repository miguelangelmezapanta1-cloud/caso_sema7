using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            Console.WriteLine("Sistema de Gestion de notas");
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
                Console.Write("ingresar nota[0 - 20]:");
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
            Console.WriteLine("******Buscar estudiante******");
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados");
                return;
            }
            Console.Write("Ingresar nombre a buscar");
            string nom_buscar = Console.ReadLine().ToLower();
            bool encontrado = false;
            for (int i = 0; i < contador; i++)
            {
                if (nombres[i].ToLower() == nom_buscar)
                {
                    Console.Write("Estudiante encontrado:");
                    Console.Write(nombres[i] + " tiene " + notas[i]);
                    encontrado = true;
                    break;
                }
                if (!encontrado)
                    Console.Write("Estudiante no encontrado...");
            }
        }
        static public void Modificar_nota()
        {
            Console.Write("********Modificar Nota********");
            if (contador == 0)
            {
               Console.Write("No hay estudiante registrados");
               return;
            }
            Console.Write("Ingresar nombre del estudiante");
            string nom_buscar = Console.ReadLine().ToLower();
            for (int i = 0; i < contador; i++)
            {
                if (nombres[i].ToLower() == nom_buscar)
                {
                    Console.WriteLine(nombres[i] + " tiene " + notas[i]);
                    while (true)
                    {
                        Console.WriteLine("ingrese la nueva nota");
                        int nueva_nota = int.Parse(Console.ReadLine());
                        if (nueva_nota >= 0 && nueva_nota <= 20)
                        {
                            notas[i] = nueva_nota;
                            Console.WriteLine("nota modificada correctamente");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("nota fuera de rango [0 - 20]");
                        }
                    }  
                }
            }
            Console.WriteLine("estudiante no encontrado....");
        }
        static public void Mostrar()
        {
            Console.WriteLine("********Listado General********");
            if (contador==0)
            {
                Console.WriteLine("No hay estudiante registrado");
                return;
            }
            for(int i = 0; i < contador; i++)
            {
                Console.Write("\tNombre \t\tNotas");
                Console.Write("\t" + nombres[i] + "\t\t "+ notas[i]);
                return;
            }
        }
        static public void burbuja()
        {
            Console.WriteLine("*********ordenamiento ascendente***********");
            double temp_nota;
            string temp_nombre;

            for (int i = 0; i < contador - 1; i++)
            {
                for (int j = 0; j < contador - 1 - i; j++)
                {
                    if (notas[j] > notas[j + 1])
                    {
                        temp_nota = notas[j];
                        notas[j] = notas[j + 1];
                        notas[j + 1] = temp_nota;
                         temp_nombre = nombres[j];
                        nombres[j] = nombres[j + 1];
                        nombres[j + 1] = temp_nombre;
                    }
                }
            }
        }
        static public void Seleccion_desc()
        {
            for (int i = 0; i < contador - 1; i++)
            {
                int mayor = i;
                for (int j = i + 1; j < contador; j++)
                {
                    if (notas[j] > notas[mayor])
                    {
                        mayor = j;
                    }
                }
                double temp = notas[i];
                notas[i] = notas[mayor];
                notas[mayor] = temp;
                string temp_nombre = nombres[i];
                nombres[i] = nombres[mayor];
                nombres[mayor] = temp_nombre;
            } 
        }
        static public void nota_max()
        {
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados");
                return;
            }

            int mayor = 0;

            for (int i = 1; i < contador; i++)
            {
                if (notas[i] > notas[mayor])
                {
                    mayor = i;
                }
            }
            Console.WriteLine("******** Nota máxima ********");
            Console.WriteLine("Estudiante: " + nombres[mayor]);
            Console.WriteLine("Nota: " + notas[mayor]);
        }

        static void Main(string[]args)
        {
            Titulo();
            int opc = 0;
            while (opc!=7)
            {
                Console.WriteLine("********************************");
                Console.WriteLine("[1] Registrar estudiante");
                Console.WriteLine("[2] Buscar estudiante");
                Console.WriteLine("[3] Modificar nota");
                Console.WriteLine("[4] Mostrar lista sin orden");
                Console.WriteLine("[5] Ordenar con burburja");
                Console.WriteLine("[6] Ordenar con seleccion");
                Console.WriteLine("[7] salir");
                Console.WriteLine("ingresar una opcion");
                opc = int.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        Registrar_estudiante();
                        break;
                    case 2:
                        buscar_estudiante();
                        break;
                    case 3:
                        Modificar_nota();
                        break;
                    case 4:
                        Mostrar();
                        break;
                    case 5:
                        burbuja();
                        break;
                    case 6:
                        Seleccion_desc();
                        break;
                    case 7:
                        Console.WriteLine("gracias por usar el sistema");
                        break;
                    default:
                        Console.WriteLine("opcion incorrecta");
                        break;
                }
            }
        }
    }
}
