using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {
        public static ML.Result GetAllEF()
        {
            ML.Result result =new ML.Result();
            try
            {
                using (DL_EF.EIgnacioProgramacionNCapasEntities context=new DL_EF.EIgnacioProgramacionNCapasEntities())
                {
                    var query =context.RolGetAll().ToList();

                    if (query!=null)
                    {
                        //GETALL se guarda en una lista ya que son varios objetos los que se
                        //van a guardar 
                        result.Objects = new List<object>();

                        //Creamos un foreach para recorrer las listas
                        foreach (var row in query)
                        {
                            ML.Rol rol = new ML.Rol();
                            rol.IdRol = row.IdRol;
                            rol.Nombre = row.Nombre;

                            result.Objects.Add(rol);
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.Correct = false;
                result.Message = "Ocurrio un error";
                throw;
            }

            return result;
        }
    }
}
