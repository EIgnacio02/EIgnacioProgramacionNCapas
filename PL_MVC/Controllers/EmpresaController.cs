using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class EmpresaController : Controller
    {
        // GET: Empresa
        [HttpGet]
        public ActionResult GetAll()
        
        {
            ML.Result result = BL.Empresa.GetAllEF();
            ML.Empresa empresa = new ML.Empresa();


            if (result.Correct)
            {
                empresa.Empresas = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error";
            }
            return View(empresa);
        }

        [HttpGet]
        public ActionResult Form(int? IdEmpresa)
        {
            if (IdEmpresa==null)
            {
                //MOSTRAR FORMULARIO
                return View();
            }
            else
            {
                //GETBYID
                ML.Result result = BL.Empresa.GetByIdEF(IdEmpresa.Value);
                ML.Empresa empresa = new ML.Empresa();

                if (result.Correct)
                {
                    empresa = (ML.Empresa)result.Object;
                }
                else
                {
                    ViewBag.Message = "Ocurrio un errro al solicitar los datos";
                }
                return View(empresa);
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Empresa empresa)
        {
            if (empresa.IdEmpresa==0)
            {
                ML.Result result = BL.Empresa.AddEF(empresa);
                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error";
                }

            }
            else
            {
                ML.Result result = BL.Empresa.UpdateEF(empresa);
                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error";
                }
            }
            //Creamos el modal 
            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Delete(int? IdEmpresa)
        {
            
            if (IdEmpresa >= 1)
            {
                ML.Result result = BL.Empresa.DeleteEF(IdEmpresa.Value);
                ViewBag.Message = result.Message;

            }
            else
            {
                ViewBag.Message = "Ocurrio un error";
            }
            return PartialView("Modal");

        }
    }
}