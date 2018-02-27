using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BinTree;
using LAB02_1252016_1053016.Models;
using System.IO;
using Newtonsoft.Json; 

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

            return View("Cadenas");
        }

        public ActionResult Enteros()
        {
            opciones[0] = false;
            opciones[1] = true;
            opciones[2] = false;
            Session["Opcion"] = opciones;

            return View("Enteros");
        }

        public ActionResult Paises()
        {
            opciones[0] = false;
            opciones[1] = false;
            opciones[2] = true;
            Session["Opcion"] = opciones;

            return View("Paises");
        }

        [HttpGet]
        public ActionResult LecturaArchivo()
        {
            //aqui se abre una vista para poder subir el archivo
            return View();
        }

        private bool isValidContentType(HttpPostedFileBase contentType)
        {
            return contentType.FileName.EndsWith(".json");
        }

        [HttpPost]
        public ActionResult LecturaArchivo(HttpPostedFileBase File)
        {          
            if (File == null || File.ContentLength == 0)
            {
                ViewBag.Error = "El archivo seleccionado está vacío o no hay archivo seleccionado";
                return View("Index");
            }
            else
            {
                if (!isValidContentType(File))
                {
                    ViewBag.Error = "Solo archivos Json son válidos para la entrada";
                    return View("Index");
                }

                if (File.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(File.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/JsonFiles/" + fileName));
                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);
                    File.SaveAs(path);
                    using (StreamReader reader = new StreamReader(path))
                    {
                        //Seleccion de tipo de lista utilizar
                        opciones = (bool[])Session["Opcion"];
                        ABBCadena = (BinaryTree<string>)Session["ABBCadena"];
                        ABBint = (BinaryTree<int>)Session["ABBint"];
                        ABBPais = (BinaryTree<Pais>)Session["ABBPais"];                       

                        //Realizar if donde dependiendo el booleano es la lista que se va a seleccionar    
                        
                        if (opciones[0] == true) // arbol de cadenas
                        {
                           string info =  reader.ReadToEnd();                             
                           ABBCadena = JsonConvert.DeserializeObject<BinaryTree<string>>(info);                             
                            Session["ABBCadena"] = ABBCadena;                           
                        }
                        else if (opciones[1] == true) //Arbol de enteros
                        {
                           
                            Session["ABBint"] = ABBint;                           
                        }                        
                        else if (opciones[2] == true) //Arbol de paises
                        {
                            string info = reader.ReadToEnd();
                            List<Pais> lista = JsonConvert.DeserializeObject<List<Pais>>(info);
                            lista.ForEach(p =>
                            {
                                Pais newPais = new Pais()
                                {
                                    NombrePais = p.NombrePais,
                                    Grupo = p.Grupo
                                };
                                ABBPais.Insert(newPais); 
                            }); 
                        }

                        // no es ninguno de los 2 
                        else
                        {
                            return RedirectToRoute("Paises/Index");
                        }
                    }
                }              
            }

            if (opciones[0] == true)
            {
                ABBCadena = (BinaryTree<string>)Session["ABBCadena"];
                return View("GenericSuccess");
            }
            else
            {
                ABBint = (BinaryTree<int>)Session["ABBint"];
                return View("NETSuccess");
            }
        }


    }
}