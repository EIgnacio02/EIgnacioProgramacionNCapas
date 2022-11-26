using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Ingresa la opcion que deseas realizar");
            Console.WriteLine("1. Mostrar");
            Console.WriteLine("2. Agregar");
            Console.WriteLine("3. Eliminar");
            Console.WriteLine("4. Actualizar");
            Console.WriteLine("5. Busqueda por ID");
            int numero=int.Parse(Console.ReadLine());

            switch (numero)
            {
                case 1:
                    Console.WriteLine("Tus datos son");
                    Usuario.GetAll();

                    //Empresa.GetAll();

                    break;
                case 2:
                    Console.WriteLine("Ingresaste la opcion agregar");
                    //Usuario.Add();

                    Empresa.Add();
                    break;
                case 3:
                    Console.WriteLine("Ingresaste la opcion eliminar");
                    //Usuario.Delete();
                    //Usuario.DeleteSp();
                    Empresa.Delete();
                    break;
                case 4:
                    Console.WriteLine("Ingresaste la opcion modificar");
                    //Usuario.Update();
                    //Usuario.UpdateSp();
                    Empresa.Update();
                    break;
                case 5:
                    Console.WriteLine("Busca por ID");
                    //Usuario.Update();
                    Usuario.GetById();
                    //Empresa.GetById();
                    break;
                default:
                    break;
            }
        }
    }
}
