using Lab1.Vista;
using Microsoft.Azure.KeyVault.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lab1
{
    class Program
    {
        public static string _Arch = @"D:\Users\luisp\Downloads\datos.csv"; 
       public static void Main(string[] args)
       {
            var Inofrmacion = GetInfoFile();
            DeserealizacionJason(Inofrmacion);
            bool opcion = true;
            ArbolB<Persona> obj = new ArbolB<Persona>(2);
            while (opcion)
            {
                    Console.Clear();
                    Console.WriteLine("         Prueba de eficiencia Talent Hub");
                    Console.WriteLine("Seleccione una de las siguientes opciones para realizar ");
                    Console.WriteLine(" 1. Insertar registro de persona");
                    Console.WriteLine(" 2. Eliminar registro de persona por el nombre y DPI");
                    Console.WriteLine(" 3. Actualizar un registro de persona por nombre y DPI");
                    Console.WriteLine(" 4. Buscar regisrtos asociados a un nombre ");
                    
                    Persona obj2 = new Persona();
                    switch (int.Parse(Console.ReadLine()))
                    {
                        case 1:
                            Console.Clear();
                            //ArbolB<Persona> obj = new ArbolB<Persona>(2);
                            string nombreIngreso;
                            string Cumpleaños;
                            string Direccio;
                            Console.WriteLine("Personas info ingrese los datos o escriba Salir para terminar");
                            do
                            {
                                Console.WriteLine("Ingrese el nombre");
                                nombreIngreso = Console.ReadLine();
                                Console.WriteLine("Ingrese el DPI");
                                long DPI = long.Parse(Console.ReadLine());
                                Console.WriteLine("Ingrese fecha de cumpleaños mm/dd/yyy");
                                Cumpleaños = Console.ReadLine();
                                Console.WriteLine("Ingrese la direccion");
                                Direccio = Console.ReadLine();
                                obj2.Nombre = nombreIngreso;
                                obj2.Identificador = DPI;
                                obj2.Direccion = Direccio;
                                obj2.Cumpleaños = Cumpleaños;
                                Console.WriteLine("Se guardo el nombre " + obj2.Nombre + " Identificado con el DPI: " + obj2.Identificador + " Con fecha de cumpleaños " + obj2.Cumpleaños + " Y direccion: " + obj2.Direccion);
                                string PersonasJson = JsonSerializer.Serialize(obj2); //Serealizar a formato JSON 
                                File.WriteAllText(_Arch, PersonasJson); //Escribir al archivo
                                obj.Insertar(obj2);
                                Console.WriteLine(obj.raiz2.clave[0].Nombre);
                                System.Threading.Thread.Sleep(2000);
                                break;
                            } while (nombreIngreso != "Salir");
                        //var InfoPersonas = GetPersonas();
                        //Console.WriteLine("Personas info" + Inofrmacion);
                        //Console.WriteLine(PersonasJson);
                        //File.WriteAllText(_Arch, PersonasJson);
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("Escriba el DPI y nombre de la persona que quiere eliminar");
                            string NOMElim;
                            long DPIElim;
                            NOMElim = Console.ReadLine();
                            DPIElim = long.Parse(Console.ReadLine());
                            obj2.Nombre = NOMElim;
                            obj2.Identificador = DPIElim;

                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine("Escriba el DPI y nombre de la persona que quiere actualizar");

                            break;
                        case 4:
                            //ArbolB<Persona> obj6 = new ArbolB<Persona>();
                            Console.Clear();
                            Console.WriteLine("Escriba el nombre de la persona para buscar en el registro");
                            string Nombre;
                            Console.WriteLine("  Nombre a buscar en registros  ");
                            Nombre = Console.ReadLine();
                            obj2.Nombre = Nombre;
                            obj.Buscar(obj.raiz2,obj2); //Mandar los valores
                            //Console.WriteLine(obj.raiz2.clave[0].CompareTo(obj.raiz2.clave)); //Imprimir en pantalla
                            System.Threading.Thread.Sleep(5000);
                        // obj6.Buscar(obj6.Raiz, obj2);
                        //Console.WriteLine(obj6.Raiz);
                        break;
                        default:
                            Console.WriteLine("Ingrese una opcion valida");
                            System.Threading.Thread.Sleep(3000);
                            break;
                    }

                

            }
       }
        public static string GetInfoFile()
        {
            string DatosJson;
            using (var lineas = new StreamReader(@"D:\Users\luisp\Downloads\datos.csv"))
            {
                DatosJson = lineas.ReadToEnd();
            }
            return DatosJson;
        }
        public static void DeserealizacionJason(string GetIngoFile) 
        {
            //Console.WriteLine(GetIngoFile); 
        }
        

    }
}
