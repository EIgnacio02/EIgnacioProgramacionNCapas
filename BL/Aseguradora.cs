using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Aseguradora
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EIgnacioProgramacionNCapasEntities context=new DL_EF.EIgnacioProgramacionNCapasEntities())
                {
                    var query = context.AseguradoraGetAll().ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Aseguradora aseguradora = new ML.Aseguradora();

                            aseguradora.IdAseguradora = obj.IdAseguradora;
                            aseguradora.Nombre = obj.Nombre;
                            aseguradora.FechaCreacion = obj.FechaCreacion.ToString();
                            aseguradora.FechaModificacion = obj.FechaModificacion.ToString();
                            aseguradora.Usuario = new ML.Usuario();
                            aseguradora.Usuario.IdUsuario = (int)obj.IdUsuario;
                            result.Objects.Add(aseguradora);
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
            }

            return result;
        }


        public static ML.Result Add(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EIgnacioProgramacionNCapasEntities context= new DL_EF.EIgnacioProgramacionNCapasEntities())
                {
                    var query = context.AseguradoraAdd(aseguradora.Nombre,aseguradora.Usuario.IdUsuario);

                    if (query>0)
                    {
                        result.Message = "Se ingresaron los datos correctamente";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un problema";
            }
            return result;
        }

        public static ML.Result GetById(int IdAseguradora)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EIgnacioProgramacionNCapasEntities context=new DL_EF.EIgnacioProgramacionNCapasEntities())
                {
                    var query = context.AseguradoraGetById(IdAseguradora).SingleOrDefault();
                    result.Objects = new List<object>();

                    if (query!=null)
                    {
                        ML.Aseguradora aseguradora = new ML.Aseguradora();
                        aseguradora.IdAseguradora = query.IdAseguradora;
                        aseguradora.Nombre = query.Nombre;
                        aseguradora.FechaCreacion = query.FechaCreacion.ToString();
                        aseguradora.FechaModificacion = query.FechaModificacion.ToString();
                        aseguradora.Usuario = new ML.Usuario();
                        aseguradora.Usuario.IdUsuario = (int)query.IdUsuario;
                        result.Objects.Add(aseguradora);
                    }
                }
                result.Correct=true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error";
            }
            return result;
        }


        public static ML.Result Update(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EIgnacioProgramacionNCapasEntities context =new DL_EF.EIgnacioProgramacionNCapasEntities())
                {
                    var query = context.AseguradoraUpdate(aseguradora.IdAseguradora, aseguradora.Nombre, aseguradora.Usuario.IdUsuario);
                    
                    if (query>0)
                    {
                        result.Message = "Se actualizaron los datos correctamente";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un problema";
            }

            return result;
        }

        public static ML.Result Delete(int IdAseguradora)
        {
            ML.Result result=new ML.Result();

            try
            {
                using (DL_EF.EIgnacioProgramacionNCapasEntities context=new DL_EF.EIgnacioProgramacionNCapasEntities())
                {
                    var query = context.AseguradoraDelete(IdAseguradora);

                    if (query>0)
                    {
                        result.Message = "Se elimino correctamente ";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = "Ocurrio un problema";
                result.Ex = ex;
            }
            return result;
        }
    }
}
