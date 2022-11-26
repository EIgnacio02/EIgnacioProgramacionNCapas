using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient; //IMMPORTAMOS LIBRERIA
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Empresa
    {
        public static void Add()
        {
            ML.Empresa empresa=new ML.Empresa();

            Console.WriteLine("Ingresa los datos");
            Console.WriteLine("Ingresa tu nombre: ");
            empresa.Nombre = Console.ReadLine();
            Console.WriteLine("Ingresa el telefono: ");
            empresa.Telefono= Console.ReadLine();
            Console.WriteLine("Ingresa el gmail: ");
            empresa.Email= Console.ReadLine();
            Console.WriteLine("Ingresa Direccion web");
            empresa.DireccionWeb= Console.ReadLine();

            //ML.Result result=BL.Empresa.Add(empresa);
            ML.Result result = BL.Empresa.AddEF(empresa);
            //ML.Result result=BL.Empresa.AddLINQ(empresa);

            if (result.Correct)
            {
                Console.WriteLine(result.Message);
            }
        }

        public static void GetAll()
        {
            //ML.Result result = BL.Empresa.GetAll();
            //ML.Result result = BL.Empresa.GetAllEF();
            ML.Result result = BL.Empresa.GetAllLINQ();

            if (result.Correct)
            {
                foreach (ML.Empresa empresa in result.Objects)
                {
                    Console.WriteLine("ID: "+empresa.IdEmpresa);
                    Console.WriteLine("Nombre: "+empresa.Nombre);
                    Console.WriteLine("Telefono: "+empresa.Telefono);
                    Console.WriteLine("Email: "+empresa.Email);
                    Console.WriteLine("Direccion Web"+empresa.DireccionWeb);
                    Console.WriteLine("-----------------------------------");
                }
            }
        }

        public static void GetById()
        {
            ML.Empresa empresa = new ML.Empresa();

            Console.WriteLine("Ingresa el ID que deseas ver");
            empresa.IdEmpresa = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Empresa.GetById(empresa.IdEmpresa);
            //ML.Result result = BL.Empresa.GetByIdEF(empresa.IdEmpresa);
            ML.Result result = BL.Empresa.GetAllByIdLINQ(empresa.IdEmpresa);

            if (result.Correct)
            {
                empresa = (ML.Empresa)result.Object;//UNBOXING

                Console.WriteLine("ID: " + empresa.IdEmpresa);
                Console.WriteLine("Nombre: " + empresa.Nombre);
                Console.WriteLine("Telefono: " + empresa.Telefono);
                Console.WriteLine("Email: " + empresa.Email);
                Console.WriteLine("Direccion Web" + empresa.DireccionWeb);
            }
       }

        public static void Update()
        {
            //INSTANCIAMOS LA CLASE EMPRESA DEL ML(PROPIEDADES)
            ML.Empresa empresa = new ML.Empresa();

            Console.WriteLine("Ingresa los datos");
            //PEDIMOS DATOS
            Console.WriteLine("Ingresa el ID que seas modificar");
            //TRAEMOS DATOS 
            empresa.IdEmpresa = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa tu nombre: ");
            empresa.Nombre = Console.ReadLine();
            Console.WriteLine("Ingresa el telefono: ");
            empresa.Telefono = Console.ReadLine();
            Console.WriteLine("Ingresa el email: ");
            empresa.Email = Console.ReadLine();
            Console.WriteLine("Ingresa Direccion web");
            empresa.DireccionWeb = Console.ReadLine();

            //INSTANCIAMOS NUESTROS RESULT PERO CON LLAMANDO A NUESTROS DATOS DEL BL
            //ML.Result result = BL.Empresa.Update(empresa);
            //ML.Result result = BL.Empresa.UpdateEF(empresa);
            ML.Result result = BL.Empresa.UpdateLINQ(empresa);
            if (result.Correct)
            {
                Console.WriteLine(result.Message);
            }
        }

        public static void Delete()
        {
            ML.Empresa empresa = new ML.Empresa();
            Console.WriteLine("Ingresa el ID que seas eliminar");
            empresa.IdEmpresa=int.Parse(Console.ReadLine());

            //ML.Result result=BL.Empresa.Delete(empresa.IdEmpresa);
            //ML.Result result = BL.Empresa.DeleteEF(empresa.IdEmpresa);
            ML.Result result = BL.Empresa.DeleteLINQ(empresa.IdEmpresa);
            if (result.Correct)
            {
                Console.WriteLine(/*"Mensaje" +*/ result.Message);
            }

        }
    }
}
