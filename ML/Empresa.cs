using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Empresa //DATOS COMPLEJOS 
    {
        //PROPIEDADES DE LA EMPRESA
        public int IdEmpresa { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string DireccionWeb { get; set; }

        //CREAMOS UNA PROPIEDAD LIST PARA EL MVC GUARDAR EN NUESTRO CONTROLLER 
        public List<Object> Empresas { get; set; }
    }
}
