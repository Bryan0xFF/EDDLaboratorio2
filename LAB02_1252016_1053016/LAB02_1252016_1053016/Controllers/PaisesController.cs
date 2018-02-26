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
        BinaryTree<string> ABBCadena = new BinaryTree<string>();
        BinaryTree<int> ABBint = new BinaryTree<int>();
        BinaryTree<Pais> ABBPais = new BinaryTree<Pais>();
        //1. cadena, 2. entero, 3. pais
        bool[] opciones = new bool[3];

        // GET: Paises
        public ActionResult Index()
        {
            Session["ABBCadena"] = Session["ABBCadena"] ?? ABBCadena;
            Session["ABBInt"] = Session["ABBInt"] ?? ABBint;
            Session["ABBPais"] = Session["ABBPais"] ?? ABBPais;
            Session["Opcion"] = Session["Opcion"] ?? opciones;

            return View();
            
        }


        public ActionResult Cadenas()
        {
            opciones = (bool[])Session["Opcion"];
            opciones[0] = true;
            opciones[1] = false;
            opciones[2] = false;
            Session["Opcion"] = opciones;

            return RedirectToAction("Menu");
        }

        public ActionResult Enteros()
        {
            opciones[0] = false;
            opciones[1] = true;
            opciones[2] = false;
            Session["Opcion"] = opciones;

            return RedirectToAction("Menu");
        }

        public ActionResult Paises()
        {
            opciones[0] = false;
            opciones[1] = false;
            opciones[2] = true;
            Session["Opcion"] = opciones;

            return RedirectToAction("Menu");
        }

        

        [HttpGet]
        public ActionResult LecturaArchivo()
        {
            //aqui se abre una vista para poder subir el archivo
            return View();
        }

       
    }
}