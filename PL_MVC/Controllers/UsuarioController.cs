using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario(); //Instanciamos para poder usar los datos usuario
            //Guardamos los datos del metodos que queremos llamar  en el objeto
            ML.Result result = BL.Usuario.GetAllEF(usuario);

            
            if (result.Correct)
            {
                //Guaramos la lista result en la lista de usario(ML)
                usuario.Usuarios = result.Objects; 
            }
            else
            {
                ViewBag.Message = "Ocurrio un error";
            }
            return View(usuario); //Guardamos los datos en la vista 
        }

        [HttpPost]
        public ActionResult GetAll(ML.Usuario usuario)
        {
            //Guardamos los datos del metodos que queremos llamar  en el objeto
            //ML.Result result = BL.Usuario.GetAll(usuario);

            /* ML.Usuario usuario = new ML.Usuario();*/ //Instanciamos para poder usar los datos usuario
            ML.Result resultRol = BL.Rol.GetAllEF();
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();
            usuario.Rol = new ML.Rol();

            if (result.Correct)
            {
                //Guaramos la lista result en la lista de usario(ML)
                usuario.Usuarios = result.Objects;
                usuario.Rol.Roles = resultRol.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error";
            }
            return View(usuario); //Guardamos los datos en la vista 
        }


        [HttpGet] //MUESTRA LAS VISTAS
        public ActionResult Form(int? IdUsuario)
        {
            
            ML.Result resultRol=BL.Rol.GetAllEF(); //Para poder trar los drop down list
            ML.Result resultPais = BL.Pais.GetAll(); //Para poder trar los drop down list

            //Se inicializar para trar los datos complejos
            ML.Usuario usuario = new ML.Usuario();

            usuario.Rol = new ML.Rol();

            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia=new ML.Colonia();
            usuario.Direccion.Colonia.Municipio=new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            usuario.Direccion.Colonia.Municipio.Estado.Pais=new ML.Pais();
            //usuario.Pais = new ML.Pais();

            //Si el ID no trae nada nos manda al form limipio para agregar (cuando le damos al boton + (agregar))
            if (IdUsuario == null)
            {
                //Se inicializa para poder usar las propiedades del ROLES y PAISES de la LIST (ML)
                usuario.Rol.Roles = resultRol.Objects;
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
                //usuario.Pais.Paises = resultPais.Objects;
                return View(usuario);
            }
            else
            {
                //GETBYID
                ML.Result result = BL.Usuario.GetAllByIdEF(IdUsuario.Value);

                if (result.Correct)
                {

                    usuario = (ML.Usuario)result.Object; //UNBOXING

                    //Se inicializa para poder usar las propiedades del ROLES y PAISES de la LIST (ML)
                    usuario.Rol.Roles = resultRol.Objects;
                    usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;

                    //Es para mostrar el drop down list
                    //Se crea metodo BL Estado que va a trar por el IdPais
                    ML.Result resultEstados = BL.Estado.GetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais);
                    usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstados.Objects;

                    ML.Result resultMunicipio = BL.Municipio.GetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
                    usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipio.Objects;
                    
                    ML.Result resultColonia = BL.Colonia.GetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio);
                    usuario.Direccion.Colonia.Colonias = resultColonia.Objects;

                    //return View(usuario);
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al consultar los datos del usuario";
                }
                return View(usuario);
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            //AGREGAR
            if (usuario.IdUsuario==0)
            {
                HttpPostedFileBase file = Request.Files["ImagenData"];

                if (file.ContentLength > 0)
                {
                    /*usuario.Imagen = ConvertToBytes(file);*/ //Metodo;
                }

                result = BL.Usuario.AddEF(usuario);

                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Message = "Ocrrio un error";
                }
            }

            //ACTUALIZAR
            else
            {
                HttpPostedFileBase file = Request.Files["ImagenData"];

                if (file.ContentLength > 0)
                {
                    /*usuario.Imagen = ConvertToBytes(file);*/ //Metodo;
                }
                result = BL.Usuario.UpdateEF(usuario);
                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Message = "Ocrrio un error";
                }
            }
            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Delete(int? IdUsuario)
        {
            if (IdUsuario >= 1)
            {
                ML.Result result = BL.Usuario.DeleteEF(IdUsuario.Value);
                ViewBag.Message = result.Message;
            }
            else
            {
                ViewBag.Message = "Ocurrio un errror";
            }

            return PartialView("Modal");
        }


        public JsonResult GetEstado(int IdPais)
        {
            var result=BL.Estado.GetByIdPais(IdPais);
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetMunicipio(int IdEstado)
        {
            var result = BL.Municipio.GetByIdEstado(IdEstado);
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetColonia(int IdMunicipio)
        {
            var result = BL.Colonia.GetByIdMunicipio(IdMunicipio);
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }



        //METODO PARA AGREGAR IMAGEN
        //public byte[] ConvertToBytes(HttpPostedFileBase Imagen)
        //{
        //    byte[] data = null;

        //    System.IO.BinaryReader reader=new System.IO.BinaryReader(Imagen.InputStream);
        //    data = reader.ReadBytes((int)Imagen.ContentLength);

        //    return data;

        //}




    }


}