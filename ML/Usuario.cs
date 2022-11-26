using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        //Creacion constructores
        public int IdUsuario { get; set; }
        public string UserName { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Curp { get; set; }

        public ML.Rol Rol { get; set; }//Propiedad de navegacion
        public ML.Direccion Direccion { get; set; }
        //public ML.Pais Pais { get; set; }

        //Creamos una lista de objetos para guardar los datos del result
        //ya que result tambien es una lista 
        public List<object> Usuarios { get; set; }


        //Agregar imagen
        public byte[] Imagen { get; set; }
    }
}
