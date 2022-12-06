using System;
using System.Collections.Generic;
using System.Data;//importamos libreria para arreglos
using System.Data.SqlClient;//Importamos libreria
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        //SQLClient 
        public static ML.Result Add(ML.Usuario usuario)
        {

            ML.Result resultado = new ML.Result();
            try
            {

                using (SqlConnection context =new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "INSERT INTO [Usuario]([Nombre],[ApellidoPaterno],[ApellidoMaterno],[Email],[NumeroTelefono],[Genero])VALUES(@Nombre,@ApellidoPaterno,@ApellidoMaterno,@Email,@NumeroTelefono,@Genero)";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        context.Open(); //abrimos la BD

                        //Cremos los arreglos para almacenar los datos

                        SqlParameter[] collection= new SqlParameter[6];
                        collection[0] = new SqlParameter("Nombre",SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;

                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;

                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaterno;

                        collection[3] = new SqlParameter("Email", SqlDbType.VarChar);
                        collection[3].Value = usuario.Email;

                        collection[4] = new SqlParameter("NumeroTelefono", SqlDbType.VarChar);
                        collection[4].Value = usuario.Telefono;

                        collection[5] = new SqlParameter("Genero",SqlDbType.Char);
                        collection[5].Value = usuario.Sexo;

                        /*collection[6] = new SqlParameter("Imagen", SqlDbType.Image,photo.Length)*/ //.Value = photo;
                        //collection[6].Value = usuario.Imagen;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            resultado.Message = "Datos ingresados correctamente";
                        }
                    }
                }
                resultado.Correct=true;
            }
            catch (Exception ex)
            {
                resultado.Correct = false;
                resultado.Ex = ex;
                resultado.Message=("A ocurrido un erro en la conexion");

                throw;
            }
            return resultado;
        }
        public static ML.Result Delete(ML.Usuario usuario)
        {
            ML.Result resultado=new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "DELETE FROM [Usuario] WHERE IdUsuario=@IdUsuario";

                    using (SqlCommand cmd =new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        context.Open();

                        SqlParameter[] Collection = new SqlParameter[1];

                        Collection[0] = new SqlParameter("IdUsuario" ,SqlDbType.Int);
                        Collection[0].Value = usuario.IdUsuario;

                        cmd.Parameters.AddRange(Collection);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            resultado.Message = "Se elimino el usuario correctamente";
                        }
                    }
                }
                resultado.Correct = true;
            }
            catch (Exception ex)
            {
                resultado.Correct = false;
                resultado.Ex = ex;
                resultado.Message = "Error al ingresar datos o en la conexion";
                throw;

            }

            return resultado;
        }
        public static ML.Result UpdateN(ML.Usuario usuario)
        {
            ML.Result resultado = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "UPDATE [Usuario] SET [Nombre] = @Nombre,[ApellidoPaterno] = @ApellidoPaterno,[ApellidoMaterno] = @ApellidoMaterno,[Email] = @Email,[NumeroTelefono] = @NumeroTelefono,[Genero] = @Genero WHERE IdUsuario=@IdUsuario";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        context.Open(); //abrimos la BD

                        //Cremos los arreglos para almacenar los datos

                        SqlParameter[] collection = new SqlParameter[7];
                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = usuario.Nombre;

                        collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoPaterno;

                        collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[3].Value = usuario.ApellidoMaterno;

                        collection[4] = new SqlParameter("Email", SqlDbType.VarChar);
                        collection[4].Value = usuario.Email;

                        collection[5] = new SqlParameter("NumeroTelefono", SqlDbType.VarChar);
                        collection[5].Value = usuario.Telefono;

                        collection[6] = new SqlParameter("Genero", SqlDbType.Char);
                        collection[6].Value = usuario.Sexo;


                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            resultado.Message = "Se actualizo el usuario correctamente";
                        }
                    }
                }

                    resultado.Correct = true;
            }
            catch(Exception ex)
            {
                resultado.Correct = false;
                resultado.Ex = ex;
                resultado.Message = "Error al ingresar datos o en la conexion";
                throw;
            }

            return resultado;
        }
        public static ML.Result Select(ML.Usuario usuario)
        {
            ML.Result resultado = new ML.Result();

            try
            {
                using (SqlConnection context= new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "SELECT [IdUsuario],[Nombre],[ApellidoPaterno],[ApellidoMaterno],[Email],[NumeroTelefono],[Genero]FROM [Usuario]";

                    using (SqlCommand cmd=new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText=query;

                        context.Open();
                        using (SqlDataReader reader= cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                Console.WriteLine(String.Format("{0}, {1},{2}, {3},{4}, {5},{6}", 
                                    reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6]));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resultado.Correct = false;
                resultado.Ex = ex;
                resultado.Message = "Error al ingresar datos o en la conexion";
                throw;
            }

            return resultado;
            }

        
        //CREACIONES DE METODOS STORE PROCEDURE
        public static ML.Result GetAllSP()
        {
            ML.Result resultado = new ML.Result();

            try
            {
                using (SqlConnection context=new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "UsuarioGetAll";
                    using (SqlCommand cmd=new SqlCommand())
                    {
                        cmd.Connection=context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;
                        context.Open();
                        DataTable usuarioTable=new DataTable();

                        SqlDataAdapter sqlDataAdapter=new SqlDataAdapter(cmd);
                        sqlDataAdapter.Fill(usuarioTable);

                        if (usuarioTable.Rows.Count>0)
                        {
                            resultado.Objects=new List<object>();

                            foreach (DataRow row in usuarioTable.Rows)
                            {
                                ML.Usuario usuario = new ML.Usuario();

                                usuario.IdUsuario = int.Parse(row[0].ToString());
                                usuario.UserName=row[1].ToString();
                                usuario.Nombre=row[2].ToString();
                                usuario.ApellidoPaterno=row[3].ToString();
                                usuario.ApellidoMaterno=row[4].ToString();
                                usuario.Email=row[5].ToString();
                                usuario.Password=row[6].ToString(); 
                                //usuario.FechaNacimiento=DateTime.Parse(row[7].ToString());
                                usuario.Sexo = row[8].ToString();
                                usuario.Telefono=row[9].ToString();
                                usuario.Celular=row[10].ToString();
                                usuario.Curp=row[11].ToString();

                                usuario.Rol=new ML.Rol();//Instanciamos la clase rol
                                usuario.Rol.IdRol=byte.Parse(row[12].ToString());

                                usuario.Direccion = new ML.Direccion();
                                usuario.Direccion.Calle=row[13].ToString();
                                usuario.Direccion.NumeroInterior=row[14].ToString();
                                usuario.Direccion.NumeroExterior = row[15].ToString();

                                usuario.Direccion.Colonia = new ML.Colonia();
                                usuario.Direccion.Colonia.IdColonia=byte.Parse(row[16].ToString());
                                
                                resultado.Objects.Add(usuario);
                            }
                        }
                    }
                }
                resultado.Correct = true;
            }
            catch (Exception ex)
            {
                resultado.Correct = false;
                resultado.Ex = ex;
                resultado.Message = "Error al ingresar datos o en la conexion";
                throw;
            }

            return resultado;
        }
        public static ML.Result UsuarioGetById(int IdUsuario)
        {
            ML.Result resultado = new ML.Result();

            try
            {
                using (SqlConnection context=new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string querySp = "UsuarioGetById";

                    using (SqlCommand cmd=new SqlCommand())
                    {
                        cmd.Connection= context;
                        cmd.CommandText=querySp;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = IdUsuario;

                        cmd.Parameters.AddRange(collection);

                        DataTable usuarioTable = new DataTable();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                        sqlDataAdapter.Fill(usuarioTable);

                        if (usuarioTable.Rows.Count > 0)
                        {
                            DataRow row = usuarioTable.Rows[0];

                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario = int.Parse(row[0].ToString());
                            usuario.UserName = row[1].ToString();
                            usuario.Nombre = row[2].ToString();
                            usuario.ApellidoPaterno = row[3].ToString();
                            usuario.ApellidoMaterno = row[4].ToString();
                            usuario.Email = row[5].ToString();
                            usuario.Password = row[6].ToString();
                            usuario.FechaNacimiento=row[7].ToString();
                            usuario.Sexo = row[8].ToString();
                            usuario.Telefono = row[9].ToString();
                            usuario.Celular = row[10].ToString();
                            usuario.Curp = row[11].ToString();
                            usuario.Rol = new ML.Rol();//Instanciamos la clase rol
                            usuario.Rol.IdRol = byte.Parse(row[12].ToString());

                            //Se Guardan los datos en un tipo objeto
                            resultado.Object=usuario; // BOXING
                        }

                    }
                }
                resultado.Correct = true;
            }
            catch (Exception ex)
            {
                resultado.Correct = false;
                resultado.Ex = ex;
                resultado.Message = "A ocurrido un error";
                throw;
            }
            return resultado;
        }
        public static ML.Result AddSp(ML.Usuario usuario)
        {

            ML.Result resultado = new ML.Result();
            try
            {

                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string querySp = "UsuarioAdd";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = querySp;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open(); //abrimos la BD

                        //Cremos los arreglos para almacenar los datos

                        SqlParameter[] collection = new SqlParameter[12];
                        //String debe de ser igual que en la BD
                        collection[0] = new SqlParameter("UserName",SqlDbType.VarChar);
                        collection[0].Value = usuario.UserName;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = usuario.Nombre;

                        collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoPaterno;

                        collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[3].Value = usuario.ApellidoMaterno;

                        collection[4] = new SqlParameter("Email", SqlDbType.VarChar);
                        collection[4].Value = usuario.Email;

                        collection[5] = new SqlParameter("Password", SqlDbType.VarChar);
                        collection[5].Value = usuario.Password;

                        collection[6] = new SqlParameter("FechaNacimiento", SqlDbType.Date);
                        collection[6].Value = usuario.FechaNacimiento;

                        collection[7] = new SqlParameter("Sexo", SqlDbType.Char);
                        collection[7].Value = usuario.Sexo;

                        collection[8] = new SqlParameter("Telefono", SqlDbType.VarChar);
                        collection[8].Value = usuario.Telefono;

                        collection[9] = new SqlParameter("Celular", SqlDbType.VarChar);
                        collection[9].Value = usuario.Celular;

                        collection[10] = new SqlParameter("CURP", SqlDbType.VarChar);
                        collection[10].Value = usuario.Curp;

                        collection[11] = new SqlParameter("IdRol", SqlDbType.TinyInt);
                        collection[11].Value = usuario.Rol.IdRol;


                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            resultado.Message = ("Datos ingresados correctamente");
                        }
                    }
                }
                resultado.Correct = true;
            }
            catch (Exception ex)
            {
                resultado.Correct = false;
                resultado.Ex = ex;
                resultado.Message = ("A ocurrido un error en la conexion");
                throw;
            }
            return resultado;
        }
        public static ML.Result UpdateSp(ML.Usuario usuario)
        {
            ML.Result resultado=new ML.Result();

            try
            {
                using (SqlConnection context=new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string querySp= "UsuarioUpdate";

                    using (SqlCommand cmd=new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText=querySp;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[13];
                        //String debe de ser igual que en la BD
                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;

                        collection[1] = new SqlParameter("UserName", SqlDbType.VarChar);
                        collection[1].Value = usuario.UserName;

                        collection[2] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[2].Value = usuario.Nombre;

                        collection[3] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[3].Value = usuario.ApellidoPaterno;

                        collection[4] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[4].Value = usuario.ApellidoMaterno;

                        collection[5] = new SqlParameter("Email", SqlDbType.VarChar);
                        collection[5].Value = usuario.Email;

                        collection[6] = new SqlParameter("Password", SqlDbType.VarChar);
                        collection[6].Value = usuario.Password;

                        collection[7] = new SqlParameter("FechaNacimiento", SqlDbType.Date);
                        collection[7].Value = usuario.FechaNacimiento;

                        collection[8] = new SqlParameter("Sexo", SqlDbType.Char);
                        collection[8].Value = usuario.Sexo;

                        collection[9] = new SqlParameter("Telefono", SqlDbType.VarChar);
                        collection[9].Value = usuario.Telefono;

                        collection[10] = new SqlParameter("Celular", SqlDbType.VarChar);
                        collection[10].Value = usuario.Celular;

                        collection[11] = new SqlParameter("CURP", SqlDbType.VarChar);
                        collection[11].Value = usuario.Curp;

                        collection[12] = new SqlParameter("IdRol", SqlDbType.TinyInt);
                        collection[12].Value = usuario.Rol.IdRol;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            resultado.Message = "Datos actualizados correctamente";
                        }
                    }
                }
                resultado.Correct = true;
            }
            catch (Exception ex)
            {
                resultado.Correct = false;
                resultado.Ex = ex;
                resultado.Message = "Ocurrio un error";
                throw;
            }

            return resultado;
        }
        public static ML.Result DeleteSp(ML.Usuario usuario)
        {
            ML.Result resultado = new ML.Result();

            try
            {
                using (SqlConnection context=new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string querySp = "UsuarioDelete";

                    using (SqlCommand cmd=new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = querySp;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] Collection = new SqlParameter[1];

                        Collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        Collection[0].Value = usuario.IdUsuario;

                        cmd.Parameters.AddRange(Collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            resultado.Message = "Se a eliminado el dato correctamente";
                        }
                    }
                }

                resultado.Correct = true;
            }
            catch (Exception ex)
            {
                resultado.Correct = false;
                resultado.Ex = ex;
                resultado.Message = "Ocurrio un error";
                throw;
            }

            return resultado;
        }

        
        //ENTITY FRAMEWORK
        public static ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL_EF.EIgnacioProgramacionNCapasEntities context=new DL_EF.EIgnacioProgramacionNCapasEntities())
                {
                    int query = context.UsuarioAdd(usuario.UserName,usuario.Nombre,usuario.ApellidoPaterno,usuario.ApellidoMaterno,usuario.Email,usuario.Password,usuario.FechaNacimiento,usuario.Sexo,usuario.Telefono,usuario.Celular,usuario.Curp,usuario.Rol.IdRol,usuario.Imagen,usuario.Direccion.Calle,usuario.Direccion.NumeroInterior,usuario.Direccion.NumeroExterior,usuario.Direccion.Colonia.IdColonia);

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
                throw;
            }
            return result;
        }
        public static ML.Result UpdateEF(ML.Usuario usuario)
        {
            ML.Result result=new ML.Result();

            try
            {
                using (DL_EF.EIgnacioProgramacionNCapasEntities context = new DL_EF.EIgnacioProgramacionNCapasEntities())
                {
                    var query = context.UsuarioUpdate(usuario.IdUsuario, usuario.UserName, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email, usuario.Password, usuario.FechaNacimiento, usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.Curp, usuario.Rol.IdRol,usuario.Imagen,usuario.Direccion.Calle,usuario.Direccion.NumeroInterior,usuario.Direccion.NumeroExterior,usuario.Direccion.Colonia.IdColonia);

                    if (query > 0)
                    {
                        result.Message = "Se actualizaron los datos correctamente";
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
        public static ML.Result DeleteEF(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EIgnacioProgramacionNCapasEntities context = new DL_EF.EIgnacioProgramacionNCapasEntities())
                {
                    var query = context.UsuarioDelete(IdUsuario);
                    if (query>0)
                    {
                        result.Message = "Se elimino correctamente ";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct= false;
                result.Message = "Ocurrio un problema";
                result.Ex= ex;
                throw;
            }
            return result;
        }
        public static ML.Result GetAllEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL_EF.EIgnacioProgramacionNCapasEntities context = new DL_EF.EIgnacioProgramacionNCapasEntities())
                {
                    var query = context.UsuarioGetAll(usuario.Nombre, usuario.ApellidoPaterno, usuario.Rol.IdRol).ToList();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            usuario = new ML.Usuario();

                            usuario.IdUsuario = obj.IdUsuario;
                            usuario.UserName=obj.UserName;
                            usuario.Nombre = obj.Nombre;
                            usuario.ApellidoPaterno = obj.ApellidoPaterno;
                            usuario.ApellidoMaterno = obj.ApellidoMaterno;
                            usuario.Email = obj.Email;
                            usuario.Password=obj.Password;
                            usuario.FechaNacimiento = obj.FechaNacimiento.ToString("dd/MM/yyyy");
                            usuario.Sexo=obj.Sexo;
                            usuario.Telefono = obj.Telefono;
                            usuario.Celular=obj.Celular;
                            usuario.Curp = obj.CURP;

                            //ROL   
                            usuario.Rol = new ML.Rol(); //Inicializamos para pador acceder a las prop de rol
                            usuario.Rol.IdRol = (byte)obj.IdRol;
                            usuario.Rol.Nombre = obj.NombreRol;

                            //Imagen
                            usuario.Imagen = obj.Imagen;

                            //DIRECIONES
                            usuario.Direccion=new ML.Direccion();
                            usuario.Direccion.IdDireccion = obj.IdDireccion;
                            usuario.Direccion.Calle = obj.NombreDireccion;
                            usuario.Direccion.NumeroInterior = obj.NumeroInterior;
                            usuario.Direccion.NumeroExterior = obj.NumeroExterior;
                            
                            usuario.Direccion.Colonia=new ML.Colonia();
                            usuario.Direccion.Colonia.IdColonia = obj.IdColonia.Value;
                            usuario.Direccion.Colonia.Nombre = obj.NombreColonia;
                            usuario.Direccion.Colonia.CodigoPostal = obj.CodigoPostal;
                            
                            usuario.Direccion.Colonia.Municipio=new ML.Municipio();
                            usuario.Direccion.Colonia.Municipio.IdMunicipio = obj.IdMunicipio.Value;
                            usuario.Direccion.Colonia.Municipio.Nombre = obj.NombreMunicipio;

                            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            usuario.Direccion.Colonia.Municipio.Estado.IdEstado = obj.IdEstado.Value;
                            usuario.Direccion.Colonia.Municipio.Estado.Nombre = obj.NombreEstado;

                            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais=obj.IdPais.Value;
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre=obj.NombrePais;

                            result.Objects.Add(usuario);
                        }
                        //result.Message = ("Todos tus datos");
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct= false;
                result.Message = "Ocurrio un error ";
                result.Ex = ex;
                throw;
            }
            return result;
        }
        public static ML.Result GetAllByIdEF(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EIgnacioProgramacionNCapasEntities context=new DL_EF.EIgnacioProgramacionNCapasEntities())
                {
                    //var query = context.UsuarioGetById(IdUsuario).First();
                    //var query = context.UsuarioGetById(IdUsuario).FirstOrDefault();
                    //var query = context.UsuarioGetById(IdUsuario).Single();
                    var query = context.UsuarioGetById(IdUsuario).SingleOrDefault();
                    result.Objects = new List<object>();

                    if (query != null)
                    {

                        ML.Usuario usuario = new ML.Usuario();

                        usuario.IdUsuario = query.IdUsuario;
                        usuario.UserName = query.UserName;
                        usuario.Nombre = query.Nombre;
                        usuario.ApellidoPaterno = query.ApellidoPaterno;
                        usuario.ApellidoMaterno = query.ApellidoMaterno;
                        usuario.Email = query.Email;
                        usuario.Password = query.Password;
                        usuario.FechaNacimiento = query.FechaNacimiento.ToString("dd/MM/yyyy"); //"dd/MM/yyyy"
                        usuario.Sexo = query.Sexo;
                        usuario.Telefono = query.Telefono;
                        usuario.Celular = query.Celular;
                        usuario.Curp = query.CURP;
                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = query.IdRol.Value;
                        
                        usuario.Imagen = query.Imagen;

                        usuario.Direccion=new ML.Direccion();//Inicializamos 
                        usuario.Direccion.IdDireccion = query.IdDireccion;
                        usuario.Direccion.Calle = query.NombreDireccion;
                        usuario.Direccion.NumeroInterior = query.NumeroInterior;
                        usuario.Direccion.NumeroExterior = query.NumeroExterior;

                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.IdColonia = query.IdColonia.Value;
                        usuario.Direccion.Colonia.Nombre = query.NombreColonia;
                        usuario.Direccion.Colonia.CodigoPostal = query.CodigoPostal;

                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = query.IdMunicipio.Value;
                        usuario.Direccion.Colonia.Municipio.Nombre = query.NombreMunicipio;

                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = query.IdEstado.Value;
                        usuario.Direccion.Colonia.Municipio.Estado.Nombre = query.NombreEstado;

                        usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = query.IdPais.Value;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = query.NombrePais;

                        //se guardan en un objeto
                        result.Object=usuario;

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


        //LINQ
        public static ML.Result AddLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EIgnacioProgramacionNCapasEntities context=new DL_EF.EIgnacioProgramacionNCapasEntities())
                {
                    DL_EF.Usuario usuarioDL = new DL_EF.Usuario();

                    usuarioDL.UserName=usuario.UserName;
                    usuarioDL.Nombre = usuario.Nombre;
                    usuarioDL.ApellidoPaterno = usuario.ApellidoPaterno;
                    usuarioDL.ApellidoMaterno = usuario.ApellidoMaterno;
                    usuarioDL.Email=usuario.Email;
                    usuarioDL.Password=usuario.Password;
                    usuarioDL.FechaNacimiento = DateTime.Parse(usuario.FechaNacimiento);
                    usuarioDL.Sexo = usuario.Sexo;
                    usuarioDL.Telefono = usuario.Telefono;
                    usuarioDL.Celular = usuario.Celular;
                    usuarioDL.CURP = usuario.Curp;
                    usuarioDL.IdRol = usuario.Rol.IdRol;

                    context.Usuarios.Add(usuarioDL);
                    context.SaveChanges();

                    result.Message = "Se ingreso un nuevo dato";
                }
                result.Correct=true;    
            }

            catch (Exception ex)
            {
                result.Correct=false;
                result.Message = "Ocurrio un error";
                result.Ex = ex;
                throw;

            }
            return result;
        }
        public static ML.Result GetAllLINQ()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EIgnacioProgramacionNCapasEntities context= new DL_EF.EIgnacioProgramacionNCapasEntities())
                {
                    var query = (from usuarioLINQ in context.Usuarios
                                 select new
                                 {
                                     IdUsuario = usuarioLINQ.IdUsuario,
                                     UserName=usuarioLINQ.UserName,
                                     Nombre = usuarioLINQ.Nombre,
                                     ApellidoPaterno=usuarioLINQ.ApellidoPaterno,
                                     ApellidoMaterno=usuarioLINQ.ApellidoMaterno,
                                     Email=usuarioLINQ.Email,
                                     Password=usuarioLINQ.Password,
                                     FechaNacimiento=usuarioLINQ.FechaNacimiento,
                                     Sexo=usuarioLINQ.Sexo,
                                     Telefono = usuarioLINQ.Telefono,
                                     Celular=usuarioLINQ.Celular,
                                     Curp=usuarioLINQ.CURP,
                                     IdRol=usuarioLINQ.IdRol

                                 });
                    if (query != null && query.ToList().Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var row in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario = row.IdUsuario;
                            usuario.UserName = row.UserName;
                            usuario.Nombre = row.Nombre;
                            usuario.ApellidoPaterno = row.ApellidoPaterno;
                            usuario.ApellidoMaterno = row.ApellidoMaterno;
                            usuario.Email = row.Email;
                            usuario.Password = row.Password;
                            usuario.FechaNacimiento = row.FechaNacimiento.ToString();
                            usuario.Sexo = row.Sexo;
                            usuario.Telefono = row.Telefono;
                            usuario.Celular = row.Celular;
                            usuario.Curp = row.Curp;

                            usuario.Rol = new ML.Rol();//Instanciamos la clase rol
                            usuario.Rol.IdRol = row.IdRol.Value;

                            result.Objects.Add(usuario);//BOXING

                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct=false;
                result.Ex = ex;
                result.Message = "Ocurrio un erro";
                throw;
            }
            return result;
        }
        public static ML.Result GetAllByIdLINQ(int idUsuario)
        {
            ML.Result result =new ML.Result();

            try
            {
                using (DL_EF.EIgnacioProgramacionNCapasEntities context=new DL_EF.EIgnacioProgramacionNCapasEntities())
                {
                    var query = (from usuarioLINQ in context.Usuarios
                                 where usuarioLINQ.IdUsuario == idUsuario
                                 select new
                                 {
                                     IdUsuario = usuarioLINQ.IdUsuario,
                                     UserName = usuarioLINQ.UserName,
                                     Nombre = usuarioLINQ.Nombre,
                                     ApellidoPaterno = usuarioLINQ.ApellidoPaterno,
                                     ApellidoMaterno = usuarioLINQ.ApellidoMaterno,
                                     Email = usuarioLINQ.Email,
                                     Password = usuarioLINQ.Password,
                                     FechaNacimiento = usuarioLINQ.FechaNacimiento,
                                     Sexo = usuarioLINQ.Sexo,
                                     Telefono = usuarioLINQ.Telefono,
                                     Celular = usuarioLINQ.Celular,
                                     Curp = usuarioLINQ.CURP,
                                     IdRol = usuarioLINQ.IdRol
                                 }).SingleOrDefault();

                    if (query != null)
                    {

                        ML.Usuario usuario = new ML.Usuario();


                        usuario.IdUsuario = query.IdUsuario;
                        usuario.UserName = query.UserName;
                        usuario.Nombre = query.Nombre;
                        usuario.ApellidoPaterno = query.ApellidoPaterno;
                        usuario.ApellidoMaterno = query.ApellidoMaterno;
                        usuario.Email = query.Email;
                        usuario.Password = query.Password;
                        usuario.FechaNacimiento = query.FechaNacimiento.ToString();
                        usuario.Sexo = query.Sexo;
                        usuario.Telefono = query.Telefono;
                        usuario.Celular = query.Celular;
                        usuario.Curp = query.Curp;

                        usuario.Rol = new ML.Rol();//Instanciamos la clase rol
                        usuario.Rol.IdRol = query.IdRol.Value;

                        result.Object = usuario;
                    }
                }
                result.Correct=true;
            }
            catch (Exception ex)
            {
                result.Correct=false;
                result.Ex = ex;
                throw;
            }

            return result;
        }
        public static ML.Result DeleteLINQ(int idUsuario)
        {
            ML.Result result=new ML.Result();

            try
            {
                using (DL_EF.EIgnacioProgramacionNCapasEntities context=new DL_EF.EIgnacioProgramacionNCapasEntities())
                {
                    var query = (from row in context.Usuarios
                                 where row.IdUsuario == idUsuario
                                 select row).SingleOrDefault();


                    if (query != null)
                    {
                        context.Usuarios.Remove(query);
                        context.SaveChanges();
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
        public static ML.Result UpdateLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EIgnacioProgramacionNCapasEntities context=new DL_EF.EIgnacioProgramacionNCapasEntities())
                {
                    var query = (from row in context.Usuarios
                                 where row.IdUsuario == usuario.IdUsuario
                                 select row).SingleOrDefault();

                    if (query!=null)
                    {
                        query.UserName = usuario.UserName;
                        query.Nombre = usuario.Nombre;
                        query.ApellidoPaterno = usuario.ApellidoPaterno;
                        query.ApellidoMaterno = usuario.ApellidoMaterno;
                        query.Email=usuario.Email;
                        query.Password=usuario.Password;
                        query.FechaNacimiento = DateTime.Parse(usuario.FechaNacimiento);
                        query.Sexo = usuario.Sexo;
                        query.Telefono = usuario.Telefono;
                        query.Celular = usuario.Celular;
                        query.CURP = usuario.Curp;
                        query.IdRol = usuario.Rol.IdRol;

                        context.SaveChanges();

                        result.Message = "Se a modificado los datos";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = true;
                result.Message = "Ocurrio un error";
                result.Ex = ex;
                throw;
            }
            return result;
        }
    }
}
