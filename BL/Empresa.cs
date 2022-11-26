using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empresa
    {
        //STORE PROCEDURE EMPRESA
        public static ML.Result Add(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();

            try
            {
                //agregamos el sqlconnnection importanto libreria
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string querySp = "EmpresaAdd";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = querySp;
                        cmd.CommandType = CommandType.StoredProcedure;
                        context.Open();

                        SqlParameter[] collection = new SqlParameter[4];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = empresa.Nombre;
                        collection[1] = new SqlParameter("Telefono", SqlDbType.VarChar);
                        collection[1].Value = empresa.Telefono;
                        collection[2] = new SqlParameter("Email", SqlDbType.VarChar);
                        collection[2].Value = empresa.Email;
                        collection[3] = new SqlParameter("DireccionWeb", SqlDbType.VarChar);
                        collection[3].Value = empresa.DireccionWeb;

                        cmd.Parameters.AddRange(collection);
                        int rowsAffected=cmd.ExecuteNonQuery();

                        if (rowsAffected>=1)
                        {
                            result.Message = "Se ingresaron los datos correctamente";
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error";
                throw;
            }
            return result;

        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context=new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string querSp = "EmpresaGetAll";

                    using (SqlCommand cmd =new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = querSp;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        //Traemos la tabala de sql
                        DataTable empresaTable = new DataTable();
                        //ADAPATAMOS NUESTRA TABLA A C#
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);  
                        //AGREGA LAS FILAS
                        sqlDataAdapter.Fill(empresaTable);

                        //CONDCION PARA SABER SI TRAE DATOS
                        if (empresaTable.Rows.Count>0)
                        {
                            //CREAMOS UNA LISTA PARA GUARDAR LOS DATOS
                            result.Objects = new List<object>();

                            //HACEMOS UN BUCLE
                            //DATAROW OBTINE Datos almacenados en una columna especificada.
                            foreach (DataRow row in empresaTable.Rows)
                            {
                                //INCIALIZAMOS NUESTRA CLASE EMPRESA DEL ML(PROPIEDADES)
                                ML.Empresa empresa= new ML.Empresa();

                                empresa.IdEmpresa = int.Parse(row[0].ToString());
                                empresa.Nombre = row[1].ToString();
                                empresa.Telefono = row[2].ToString();
                                empresa.Email = row[3].ToString();
                                empresa.DireccionWeb = row[4].ToString();

                                //GUARDAMOS LOS DATOS EN UN OBJETO
                                result.Objects.Add(empresa);
                            }
                        }

                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct=false;
                result.Ex = ex;
                result.Message = "Ocurrio un error";
                throw;
            }

            return result;
        }

        public static ML.Result GetById(int IdEmpresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context=new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string querySp = "EmpresaGetById";

                    using (SqlCommand cmd=new SqlCommand())
                    {
                        cmd.Connection= context;
                        cmd.CommandText = querySp;
                        cmd.CommandType= CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdEmpresa",SqlDbType.Int);
                        collection[0].Value= IdEmpresa;

                        cmd.Parameters.AddRange(collection);

                        DataTable empresTable = new DataTable();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                        sqlDataAdapter.Fill(empresTable);

                        if (empresTable.Rows.Count>0)
                        {
                            DataRow row = empresTable.Rows[0];

                            ML.Empresa empresa = new ML.Empresa();

                            empresa.IdEmpresa = int.Parse(row[0].ToString());
                            empresa.Nombre = row[1].ToString();
                            empresa.Telefono = row[2].ToString();
                            empresa.Email = row[3].ToString();
                            empresa.DireccionWeb = row[4].ToString();


                            result.Object= empresa;//BOXING

                        }
                    }
                }
                    result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error";
                throw;
            }


            return result;
        }

        //CREAMOS UN METODO DE NUESTRA CLASE RESULT PASAMOS POR PARAMETROS NUESTRAS PROPIEDADES 
        //DE LA CLASE EMPRESA
        public static ML.Result Update(ML.Empresa empresa)
        {
            //INSTACIAMOS NUESTRAS PROPIEDADES DEL RESULT
            ML.Result result= new ML.Result();

            try
            {
                //MANDAMOS A LLAMAR NUESTRA CONEXION
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    //HACEMOS EL QUERY DE NUESTRA BD COMO SE LLAMA EL STORED PROCEDURE
                    string querySp = "EmpresaUpdate";

                    //MANIPULAMOS LOS DATOS
                    using (SqlCommand cmd=new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = querySp;
                        //DECIMOS QUE SERA UN STORED PROCEDURE
                        cmd.CommandType = CommandType.StoredProcedure;
                        //ABRIMOS CONEXION
                        context.Open();

                        //CREAMOS NUESTRO ARREGLOS 
                        SqlParameter[] collection=new SqlParameter[5];
                        //ALMACENAMOS NUESTROS DATOS DE LA BD
                        collection[0] = new SqlParameter("IdEmpresa",SqlDbType.Int);
                        collection[0].Value = empresa.IdEmpresa;
                        collection[1]=new SqlParameter("Nombre",SqlDbType.VarChar);
                        collection[1].Value = empresa.Nombre;
                        collection[2]=new SqlParameter("Telefono",SqlDbType.VarChar);
                        collection[2].Value = empresa.Telefono;
                        collection[3] = new SqlParameter("Email",SqlDbType.VarChar);
                        collection[3].Value = empresa.Email;
                        collection[4] = new SqlParameter("DirecionWeb",SqlDbType.VarChar);
                        collection[4].Value = empresa.DireccionWeb;

                        //LOS GUARDAMOS
                        cmd.Parameters.AddRange(collection);

                        //CREAMOS UN VARIABLE AFECTAR LAS FILA
                        //Se puede utilizar ExecuteNonQuery para realizar operaciones de catálogo
                        //(por ejemplo, consultar la estructura de un BD o crear objetos de BD como tablas)
                        //o para cambiar la información de una BD ejecutando las instrucciones UPDATE, INSERT o DELETE.
                        int rowsAffected =cmd.ExecuteNonQuery();

                        //CONDCION PARA SABER SI SE AFECTO LA FILA
                        if (rowsAffected>=1)
                        {
                            result.Message = "Datos actualizados";
                        }
                    }
                }
                //VERIFICAMOS QUE LOS DATOS SEAN VERDADEROS
                    result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error";
                throw;
            }
            //RETORNAMOS NUESTROS EL RESULTADO
            return result;
        }

        public static ML.Result Delete(int IdEmpresa)
        {
            ML.Result result = new ML.Result();


            try
            {
                using (SqlConnection context=new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string querySp = "EmpresaDelete";

                    using (SqlCommand cmd=new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText=querySp;
                        cmd.CommandType = CommandType.StoredProcedure;
                        
                        context.Open();

                        SqlParameter[] collection=new SqlParameter[1];

                        collection[0]=new SqlParameter("IdEmpresa",SqlDbType.Int);
                        collection[0].Value = IdEmpresa;
                        //GUARDAMOS NUESTRA COLECION DE ARREGLOS
                        cmd.Parameters.AddRange(collection);

                        //CREAMOS UNA VARIABLE PARA SABER LAS FILAS AFECTADAS

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected>=1)
                        {
                            result.Message = "Se a eliminado los datos";
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

        //ENTITY FRAMEWORK

        public static ML.Result AddEF(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EIgnacioProgramacionNCapasEntities context=new DL_EF.EIgnacioProgramacionNCapasEntities())
                {
                    int query = context.EmpresaAdd(empresa.Nombre,empresa.Telefono,empresa.Email,empresa.DireccionWeb);
                    if (query>0)
                    {
                        result.Message = "Se ingresaron los datos correctamente";
                    }
                }
                result.Correct = true;
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Message = "Ocurrio un error";
                result.Ex = ex;
                throw;
            }

            return result;
        }

        public static ML.Result GetAllEF()
        {
            ML.Result result=new ML.Result();

            try
            {
                using (DL_EF.EIgnacioProgramacionNCapasEntities context=new DL_EF.EIgnacioProgramacionNCapasEntities())
                {
                    var query = context.EmpresaGetAll().ToList();
                    result.Objects = new List<object>();
                    if (query!=null)
                    {
                        foreach (var row in query)
                        {
                            ML.Empresa empresa = new ML.Empresa();
                            empresa.IdEmpresa = row.IdEmpresa;
                            empresa.Nombre = row.Nombre;
                            empresa.Telefono = row.Telefono;
                            empresa.Email = row.Email;
                            empresa.DireccionWeb = row.DireccionWeb;

                            result.Objects.Add(empresa);
                        }
                        result.Message = ("Todos tus datos");
                    }

                }
                    result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un problema";
                throw;
            }

            return result;
        }

        public static ML.Result GetByIdEF(int IdEmpresa)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EIgnacioProgramacionNCapasEntities context=new DL_EF.EIgnacioProgramacionNCapasEntities())
                {
                    var query = context.EmpresaGetById(IdEmpresa).SingleOrDefault();

                    if (query!=null)
                    {
                        ML.Empresa empresa = new ML.Empresa();

                        empresa.IdEmpresa=query.IdEmpresa;
                        empresa.Nombre = query.Nombre;
                        empresa.Telefono = query.Telefono;
                        empresa.Email = query.Email;
                        empresa.DireccionWeb = query.DireccionWeb;

                        result.Object = empresa;
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = "Ocurrio un problema";
                result.Ex = ex;
                throw;
            }
            return result;

        }

        public static ML.Result UpdateEF(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EIgnacioProgramacionNCapasEntities context=new DL_EF.EIgnacioProgramacionNCapasEntities())
                {
                    int query = context.EmpresaUpdate(empresa.IdEmpresa,empresa.Nombre,empresa.Telefono,empresa.Email,empresa.DireccionWeb);

                    if (query>0)
                    {
                        result.Message = "Se actualizaron los datos correctamente";
                    }
                }
                result.Correct = true;
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Message ="Ocurrio un error";
                result.Ex=ex;
                throw;
            }

            return result;
        }

        public static ML.Result DeleteEF(int IdEmpresa)
        {
            ML.Result result =new ML.Result();
            
            try
            {
                using (DL_EF.EIgnacioProgramacionNCapasEntities context=new DL_EF.EIgnacioProgramacionNCapasEntities())
                {
                    int query = context.EmpresaDelete(IdEmpresa);

                    if (query>0)
                    {
                        result.Message = "Se elimino correctamente";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un erro";
                throw;
            }
            return result;
        }

        //LINQ

        public static ML.Result AddLINQ(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EIgnacioProgramacionNCapasEntities context=new DL_EF.EIgnacioProgramacionNCapasEntities())
                {
                    DL_EF.Empresa empresaDL = new DL_EF.Empresa();

                    empresaDL.Nombre=empresa.Nombre;
                    empresaDL.Telefono = empresa.Telefono;
                    empresaDL.Email = empresa.Email;
                    empresaDL.DireccionWeb = empresa.DireccionWeb;

                    //Guarda instacia de DL_EF
                    context.Empresas.Add(empresaDL);
                    context.SaveChanges();

                    result.Message = "Se ingresaron los datos correctamente";
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct= false;
                result.Ex = ex;
                result.Message = "Ocurrio un errror";
                throw;
            }
            return result;
        }

        public static ML.Result GetAllLINQ()
        {
            ML.Result result = new ML.Result();


            try
            {
                using (DL_EF.EIgnacioProgramacionNCapasEntities context=new DL_EF.EIgnacioProgramacionNCapasEntities())
                {
                    var query = (from empresaLinq in context.Empresas
                                 select new
                                 {
                                     IdEmpresa = empresaLinq.IdEmpresa,
                                     Nombre=empresaLinq.Nombre,
                                     Telefono=empresaLinq.Telefono,
                                     Email=empresaLinq.Email,
                                     DireccionWeb=empresaLinq.DireccionWeb
                                 });
                    if (query!=null && query.ToList().Count>0)
                    {
                        result.Objects = new List<object>();

                        foreach (var row in query)
                        {
                            ML.Empresa empresa = new ML.Empresa();

                            empresa.IdEmpresa = row.IdEmpresa;
                            empresa.Nombre = row.Nombre;
                            empresa.Telefono = row.Telefono;
                            empresa.Email = row.Email;
                            empresa.DireccionWeb = row.DireccionWeb;

                            result.Objects.Add(empresa);//BOXING

                        }
                    }
                }
                result.Correct = true;
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Message = "Ocurrio un errror";
                result.Ex = ex;
                throw;
            }
            return result;
        }

        public static ML.Result GetAllByIdLINQ(int idEmpresa)
        {
            ML.Result result =new ML.Result();


            try
            {

                using (DL_EF.EIgnacioProgramacionNCapasEntities context = new DL_EF.EIgnacioProgramacionNCapasEntities())
                {
                    var query = (from empresaLinq in context.Empresas
                                 where empresaLinq.IdEmpresa == idEmpresa
                                 select new
                                 {
                                     IdEmpresa = empresaLinq.IdEmpresa,
                                     Nombre = empresaLinq.Nombre,
                                     Telefono = empresaLinq.Telefono,
                                     Email = empresaLinq.Email,
                                     DireccionWeb = empresaLinq.DireccionWeb
                                 }).SingleOrDefault();

                    if (query != null)
                    {

                            ML.Empresa empresa = new ML.Empresa();

                            empresa.IdEmpresa = query.IdEmpresa;
                            empresa.Nombre = query.Nombre;
                            empresa.Telefono = query.Telefono;
                            empresa.Email = query.Email;
                            empresa.DireccionWeb = query.DireccionWeb;

                            result.Object=empresa;
                    }
                }
                result.Correct = true;
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                throw;

            }
            return result;
        }

        public static ML.Result UpdateLINQ(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EIgnacioProgramacionNCapasEntities context=new DL_EF.EIgnacioProgramacionNCapasEntities())
                {
                    var query = (from row in context.Empresas
                                 where row.IdEmpresa == empresa.IdEmpresa
                                 select row).SingleOrDefault();

                    if (query!=null)
                    {
                        query.Nombre = empresa.Nombre;
                        query.Telefono = empresa.Telefono;
                        query.Email = empresa.Email;
                        query.DireccionWeb = empresa.DireccionWeb;

                        context.SaveChanges();

                        result.Message = "Se Actualizaron todos los datos";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = "Ocurrio un errro";
                result.Ex = ex;
                throw;
            }
            return result;
        }

        public static ML.Result DeleteLINQ(int idEmpresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EIgnacioProgramacionNCapasEntities context=new DL_EF.EIgnacioProgramacionNCapasEntities())
                {
                    var query = (from row in context.Empresas
                                 where row.IdEmpresa == idEmpresa
                                 select row).First();

                    context.Empresas.Remove(query);
                    context.SaveChanges();
                    result.Message = "Se elimino los datos correctamente";
                }
                result.Correct = true;
            }
            catch(Exception ex)
            {
                result.Ex = ex;
                result.Message = "Ocurrio un error";
                result.Correct= false;
                throw;
            }
            return result;
        }
    }
}
