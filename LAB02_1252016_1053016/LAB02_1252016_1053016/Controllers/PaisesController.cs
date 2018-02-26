using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BinTree;
using LAB02_1252016_1053016.Models;
using System.IO; 

namespace LAB02_1252016_1053016.Controllers
{
    public class PaisesController : Controller
    {
        // GET: Paises
        public ActionResult Index()
        {
            return View();
        }


        //public ActionResult Cadenas()
        //{
        //    return RedirectToAction("Menu"); 
        //}

        //public ActionResult Enteros()
        //{
        //    return RedirectToAction("Menu");
        //}

        //public ActionResult Paises()
        //{
        //    return RedirectToAction("Menu");
        //}

        [HttpGet]
        public ActionResult LecturaArchivo()
        {
            //aqui se abre una vista para poder subir el archivo
            return View();
        }

       
    }
}