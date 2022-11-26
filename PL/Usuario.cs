using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Usuario
    {
        /*
        public static void Add()
        {
            //Instaciamos el objeto
            ML.Usuario usuario = new ML.Usuario();

            //Pedimos datos
            Console.WriteLine("Ingresa tus datos");
            Console.WriteLine("Nombre");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("ApellidoPaterno");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("ApellidoMaterno");
            usuario.ApellidoMaterno= Console.ReadLine(); 
            Console.WriteLine("Correo electronico");
            usuario.Email= Console.ReadLine();
            Console.WriteLine("Numero Telefonico");
            usuario.Telefono = Console.ReadLine();
            Console.WriteLine("Genero ");
            usuario.Sexo = Console.ReadLine();

            //Guardamos los datos en el objeto
            
            ML.Result resultado = BL.Usuario.Add(usuario);

            if (resultado.Correct)
            {
                resultado.Message = "Mensaje" + resultado.Message;

            }
        }

        public static void Delete()
        {
            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("Elimina datos por tu ID");
            Console.WriteLine("Ingresa el ID para eliminar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());


            ML.Result resultado = BL.Usuario.Delete(usuario);

            if (resultado.Correct)
            {
                Console.WriteLine("Mensaje" + resultado.Message);

            }
        }

        public static void Update()
        {
            //Instanciar la clase usuario del proyecto para poder pedir sus datos
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingresa tus datos");
            Console.WriteLine("Ingresa el Id que se dea modificar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Nombre");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("ApellidoPaterno");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("ApellidoMaterno");
            usuario.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Correo electronico");
            usuario.Email = Console.ReadLine();
            Console.WriteLine("Numero Telefonico");
            usuario.Telefono = Console.ReadLine();
            Console.WriteLine("Genero ");
            usuario.Sexo = Console.ReadLine();

            //Guardamos los datos en el objeto

            ML.Result resultado = BL.Usuario.Update(usuario);

            if (resultado.Correct)
            {
                Console.WriteLine("Mensaje" + resultado.Message); 
            }
        }

        public static void Select()
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result resultado = BL.Usuario.Select(usuario);
        }

        */
        public static void GetAll()
        {
            //ML.Result resultado = BL.Usuario.GetAllSP();
            //ML.Result resultado = BL.Usuario.GetAllEF();
            ML.Result resultado = BL.Usuario.GetAllLINQ();
            if (resultado.Correct)
            {
                foreach (ML.Usuario usuario in resultado.Objects)
                {
                    Console.WriteLine("El ID es: "+usuario.IdUsuario);
                    Console.WriteLine("El UserName es:"+usuario.UserName);
                    Console.WriteLine("El nombres es: "+ usuario.Nombre);
                    Console.WriteLine("El apellido paterno es: "+usuario.ApellidoPaterno);
                    Console.WriteLine("El apellido materno es: "+usuario.ApellidoMaterno);
                    Console.WriteLine("El email es: "+usuario.Email);
                    Console.WriteLine("El password es: "+usuario.Password);
                    Console.WriteLine("La fecha de nacimiento es: "+usuario.FechaNacimiento);
                    Console.WriteLine("El genero es: "+usuario.Sexo);
                    Console.WriteLine("El telefono es: "+usuario.Telefono);
                    Console.WriteLine("El celular es: "+usuario.Celular);
                    Console.WriteLine("El CURP es: "+usuario.Curp);
                    Console.WriteLine("El rol es: "+usuario.Rol.IdRol);
                    Console.WriteLine("-----------------------------------");
                }
                Console.WriteLine(resultado.Message);
            }
        }

        public static void GetById()
        {
            ML.Usuario usuario = new ML.Usuario(); //Instancia

            Console.WriteLine("Por favor ingrese el id del alumno");
            Console.WriteLine("IdAlumno: ");
            usuario.IdUsuario = int.Parse(Console.ReadLine());
            //ML.Result resultado = BL.Usuario.UsuarioGetById(usuario.IdUsuario);
            //ML.Result result = BL.Usuario.GetAllById(usuario.IdUsuario);
            ML.Result result = BL.Usuario.GetAllByIdLINQ(usuario.IdUsuario);
            //Simpre debe de tener un true en el PL
            if (result.Correct)
            {
                usuario = (ML.Usuario)result.Object; //UNBOXING

                Console.WriteLine("El ID es: " + usuario.IdUsuario);
                Console.WriteLine("El UserName es:" + usuario.UserName);
                Console.WriteLine("El nombres es: " + usuario.Nombre);
                Console.WriteLine("El apellido paterno es: " + usuario.ApellidoPaterno);
                Console.WriteLine("El apellido materno es: " + usuario.ApellidoMaterno);
                Console.WriteLine("El email es: " + usuario.Email);
                Console.WriteLine("El password es: " + usuario.Password);
                Console.WriteLine("La fecha de nacimiento es: " + usuario.FechaNacimiento);
                Console.WriteLine("El genero es: " + usuario.Sexo);
                Console.WriteLine("El telefono es: " + usuario.Telefono);
                Console.WriteLine("El celular es: " + usuario.Celular);
                Console.WriteLine("El CURP es: " + usuario.Curp);
                Console.WriteLine("El rol es: " + usuario.Rol.IdRol);
                Console.WriteLine("-----------------------------------");
            }

        }

        public static void Add()
        {
            ML.Usuario usuario=new ML.Usuario();

            Console.WriteLine("Ingresa tus datos");
            Console.WriteLine("Ingresa tu Username");
            usuario.UserName = Console.ReadLine();
            Console.WriteLine("Ingresa tu Nombre");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Ingresa tu ApellidoPaterno");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Ingresa tu ApellidoMaterno");
            usuario.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Ingresa tu Email");
            usuario.Email = Console.ReadLine();
            Console.WriteLine("Ingresa tu password");
            usuario.Password= Console.ReadLine();
            Console.WriteLine("Ingresa tu Fecha de nacimiento (dd-mm-yyyy)");
            usuario.FechaNacimiento =Console.ReadLine();
            Console.WriteLine("Ingresa tu Genero (M-F)");
            usuario.Sexo = Console.ReadLine();
            Console.WriteLine("Ingresa tu telefono");
            usuario.Telefono = Console.ReadLine();
            Console.WriteLine("Ingresa tu celular");
            usuario.Celular = Console.ReadLine();
            Console.WriteLine("Ingresa tu CURP");
            usuario.Curp = Console.ReadLine();

            Console.WriteLine("Ingresa el IdRol");
            usuario.Rol=new ML.Rol();
            usuario.Rol.IdRol = byte.Parse(Console.ReadLine());


            //ML.Result resultado = BL.Usuario.AddSp(usuario);
            //ML.Result result = BL.Usuario.AddEF(usuario);
            ML.Result result = BL.Usuario.AddLINQ(usuario);
            if (result.Correct)
            {
                Console.WriteLine(result.Message);
            }
        }

        public static void Update()
        {
            ML.Usuario usuario=new ML.Usuario();

            Console.WriteLine("Ingresa tus datos");
            Console.WriteLine("Ingressa el ID que deseas modificar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa tu Username");
            usuario.UserName = Console.ReadLine();
            Console.WriteLine("Ingresa tu Nombre");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Ingresa tu ApellidoPaterno");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Ingresa tu ApellidoMaterno");
            usuario.ApellidoMaterno = Console.ReadLine();
            Console.WriteLine("Ingresa tu Email");
            usuario.Email = Console.ReadLine();
            Console.WriteLine("Ingresa tu password");
            usuario.Password = Console.ReadLine();
            Console.WriteLine("Ingresa tu Fecha de nacimiento (dd-mm-yyyy)");
            usuario.FechaNacimiento = Console.ReadLine();
            Console.WriteLine("Ingresa tu Genero (M-F)");
            usuario.Sexo = Console.ReadLine();
            Console.WriteLine("Ingresa tu telefono");
            usuario.Telefono = Console.ReadLine();
            Console.WriteLine("Ingresa tu celular");
            usuario.Celular = Console.ReadLine();
            Console.WriteLine("Ingresa tu CURP");
            usuario.Curp = Console.ReadLine();
            Console.WriteLine("Ingresa el IdRol");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = byte.Parse(Console.ReadLine());
            //ML.Result result = BL.Usuario.UpdateEF(usuario);
            //ML.Result resultado = BL.Usuario.UpdateSp(usuario);
            ML.Result result = BL.Usuario.UpdateLINQ(usuario);
            if (result.Correct)
            {
                Console.WriteLine(result.Message);
            }
        }

        public static void Delete()
        {

            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingresa el ID que seas eliminar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());


            //ML.Result result = BL.Usuario.DeleteSp(usuario);
            //ML.Result result = BL.Usuario.DeleteEF(usuario.IdUsuario);
            ML.Result result = BL.Usuario.DeleteLINQ(usuario.IdUsuario);

            if (result.Correct)
            {
                Console.WriteLine(/*"Mensaje" +*/ result.Message);

            }
        }

    }
}
