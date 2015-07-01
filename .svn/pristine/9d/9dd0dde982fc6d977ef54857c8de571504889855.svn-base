using ISIC.Entities;
using ISIC.Services;
using ISIC.Enums;
using ISICWeb.Models;
using ISICWeb.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using MPBA.Jira.Model;
using MPBA.Jira;
using MPBA.DataAccess;

namespace ISICWeb.Controllers
{
    public class DigitalizacionController : Controller
    {
        private IJiraService jiraService;
        private IImputadoService imputadoService;
        private IBioDactilarService bioDactilarService;
        IRepository repository;

        public DigitalizacionController(IImputadoService imputadoService,
                                       IBioDactilarService bioDactilarService,
            IJiraService jiraService, IRepository repository)
        {
            this.imputadoService = imputadoService;
            this.bioDactilarService = bioDactilarService;
            this.jiraService = jiraService;
            this.repository = repository;
        }




        // GET: Digitalizacion
        public ActionResult Index(string CodigoBarra)
        {
            if (!string.IsNullOrEmpty(CodigoBarra))
            {
                ViewBag.CodigoBarra = CodigoBarra;
            }
            return View();
        }

        // GET: Digitalizacion
        public ActionResult VisualizaDecaDigital(string CodigoBarra)
        {

            if (!string.IsNullOrEmpty(CodigoBarra))
            {
                ViewBag.CodigoBarra = CodigoBarra;
            }
            return View();

        }


        [HttpPost]
        public ActionResult VisualizaHuellasDigitalDeca(string CodigoBarra)
        {
            if (string.IsNullOrWhiteSpace(CodigoBarra))
            {
                ModelState.AddModelError("CodigoBarra", "Debe ingresar el Codigo de Barras");
                return View("Index");
            }
            Imputado imputado = this.imputadoService.GetByCodigoBarra(CodigoBarra);
            if (imputado == null)
            {
                ModelState.AddModelError("CodigoBarra", "No se encontró ningún imputado");
                return View("Index");
            }
            return View(imputado);
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult MarcarHuellasDactilares(string CodigoBarra)
        {

            if (string.IsNullOrWhiteSpace(CodigoBarra))
            {
                ModelState.AddModelError("CodigoBarra", "Debe ingresar el Codigo de Barras");
                return View("Index");
            }

            ViewBag.CodigoBarra = CodigoBarra + "H.JPG";
            ViewBag.ImagenDecaDactilar = FuncionesGrales.DirectorioImagenes(CodigoBarra, false, FuncionesGrales.TipoImagen.HuellasDactulares, 1);
            Imputado imputadoDb = null;

            imputadoDb = this.imputadoService.GetByCodigoBarra(CodigoBarra);
            //this.imputadoService.InicializaHuellasDactilares(imputadoDb); 
            if (imputadoDb != null)
            {

                this.imputadoService.InicializaHuellasDactilares(imputadoDb);
                return View("MarcarHuellasDactilares", imputadoDb);
            }
            else
            {
                ModelState.AddModelError("CodigoBarra", "Debe ingresar los datos personales del imputado antes de digitalizar sus huellas!");
                ViewBag.CodigoBarra = "";
                return View("Index");
            }



        }



        [HttpPost]
        public ActionResult DigitalizaHuellaIndividual(decimal[][] areas, string imagenDeca, Imputado imputado)
        {
            string a = "dd";
            //  ViewBag.rectang= new Array[10,4];
            ViewBag.rectang = areas;
            ViewBag.imagenDeca = imagenDeca;
            return PartialView(imputado);

        }




        [HttpPost]
        public ActionResult SalvaHuellasDactilares(FormCollection form, Imputado imputado)
        {
            Imputado imputadoDb = this.imputadoService.GetByCodigoBarra(form["CodigoDeBarras"]);
            // Las Imagenes de las Huellas estan en los Strings del form collection Derecha0...Derecha4 Izquierda5


            // Mano Derecha
            // Normal=1,    Faltante=3,   Lastimada=2,  HuellaNoApta = 4

            int estado;
            int[] cantDedosAD = new int[5];
            int[] cantDedosAI = new int[5];


            for (var i = 0; i < 5; i++)
            {

                ISIC.Enums.ClaseDedo d = (ClaseDedo)i;
                BioDactilar dedod = null;
                BioDactilar dedoi = null;

                /*  dedod = (from x in imputadoDb.BioManoDerecha
                                  where x.Dedo == d  select x).FirstOrDefault();
                  dedoi = (from x in imputadoDb.BioManoIzquierda
                                  where x.Dedo == d  select x).FirstOrDefault();*/


                /*      imputadoDb.BioManoDerecha.Remove(dedod);
                      imputadoDb.BioManoIzquierda.Remove(dedoi);*/


                dedod = new BioDactilar();
                dedod.CodigoDeBarra = imputadoDb.CodigoDeBarras;
                dedod.Dedo = (ClaseDedo)i;


                dedoi = new BioDactilar();
                dedoi.CodigoDeBarra = imputadoDb.CodigoDeBarras;
                dedoi.Dedo = (ClaseDedo)i;


                int indiceI = i + 5;
                // Hacer Clase Dedo Model y un mapper que lleve de 0 a Pulgar...5 Pulgar Iz etc
                string nombre = "Derecha" + i;
                string nombrei = "Izquierda" + indiceI;

                dedod.Baja = false;
                dedoi.Baja = false;



                // estado Dedo puede ser 4 indicando que la Huella No es Apta
                // en ese caso no es una clase de estado de dedo sino una clase de estado de huella



                // dedo derecho
                if (form[nombre + "EstadoDedo"] != ClaseEstadoDedo.Normal.ToString())
                {
                    estado = Convert.ToInt32(form[nombre + "EstadoDedo"]);
                    dedod.EstadoDedo = (ClaseEstadoDedo)estado;
                    cantDedosAD[Convert.ToInt32(form[nombre + "EstadoDedo"])]++;
                }
                else
                    dedod.EstadoDedo = ClaseEstadoDedo.Normal;



                if (form[nombrei + "EstadoDedo"] != ClaseEstadoDedo.Normal.ToString())
                {
                    estado = Convert.ToInt32(form[nombrei + "EstadoDedo"]);
                    dedoi.EstadoDedo = (ClaseEstadoDedo)Convert.ToInt32(form[nombrei + "EstadoDedo"]);
                    cantDedosAI[Convert.ToInt32(form[nombrei + "EstadoDedo"])]++;

                }
                else
                {
                    dedoi.EstadoDedo = ClaseEstadoDedo.Normal;
                }







                dedod.FechaDigital = DateTime.Now;
                dedoi.FechaDigital = DateTime.Now;
                dedoi.imagen = null;
                dedod.imagen = null;
                //dedod.idUsuarioDigitaliza = 1;
                // Si estado del dedo no es Normal no guarda su imagen
                if (form[nombre + "EstadoDedo"] == ClaseEstadoDedo.Normal.ToString())
                {

                    //  string base64 = String.Format("data:image/png;base64,{0}", form[nombre]);
                    //   dedod.imagen = new byte[0];
                    dedod.imagen = Convert.FromBase64String(form[nombre]);

                    // dedod.imagen = System.Text.Encoding.UTF8.GetBytes(form[nombre]);


                }
                if (form[nombrei + "EstadoDedo"] == ClaseEstadoDedo.Normal.ToString())
                {
                    string base64I = form[nombrei];
                    dedoi.imagen = Convert.FromBase64String(base64I);
                }


                dedod.Mano = ClaseMano.Derecha;
                dedoi.Mano = ClaseMano.Izquierda;
                imputadoDb.BioManoDerecha.Add(dedod);
                imputadoDb.BioManoIzquierda.Add(dedoi);



            }
            int pos = Array.IndexOf(cantDedosAD, 5);



            // Si la cantidad de huellas no aptas, lastimadas o enyesadas: son 5,  se transforma en  ClaseEstadoMano ManoDerecha correspondiente
            // y no guarda la coleccion de Huellas de la mano con identico indicador


            if (pos == 1 || pos == -1)
            {
                // La Clase de la mano es normal aunque tenga algunos dedos que no
                imputadoDb.ManoDerecha = (ClaseEstadoMano)1;
            }
            else
            {
                // imputado.BioManoDerecha.Clear();
                //imputadoDb.BioManoDerecha  = null;
                imputadoDb.ManoDerecha = (ClaseEstadoMano)pos;
            }

            pos = Array.IndexOf(cantDedosAI, 5);
            if (pos == 1 || pos == -1)
            {
                //imputadoDb.BioManoIzquierda = BioManoIzquierda;
                imputadoDb.ManoDerecha = (ClaseEstadoMano)1;
            }
            else
            {
                //imputadoDb.BioManoIzquierda = null;
                imputadoDb.ManoIzquierda = (ClaseEstadoMano)pos;
            }


            //     if (imputadoDb.BioManoDerecha == null && imputadoDb.BioManoIzquierda == null)
            //    { imputadoDb.ExisteDecadactilar = 0; }
            //  else
            imputadoDb.ExisteDecadactilar = 1;
            SICEstadoTramite sicEstado = new SICEstadoTramite();
            imputadoDb.ExisteMonodactilar = 1;
            imputadoDb.FechaUltimaModificacion = DateTime.Now;
            var issue = jiraService.GetIssue(imputadoDb.CodigoDeBarras);
            if (issue != null)
            {  /*Actualiza estados del Jira cuando los imputados son nuevos y se esta segmentando, es nulo para los imputados segmentados a partir del cotejo manual*/
                Transition transition = jiraService.GetTransitions(issue).First();

                issue = jiraService.TransitionIssue(issue, transition);
            }
            //imputadoDb.Estado = repository.Set<SICEstadoTramite>().First(x => x.Descripcion == "Para Clasificar");

            imputadoService.Actualizar(imputadoDb);

            if (form["clasifica"] == "on")
            {
                return RedirectToAction("Index", "Clasificacion", new { CodigoBarra = form["CodigoDeBarras"] });
            }

            return RedirectToAction("Index", "Digitalizacion");
        }



        public void UploadImage(string imageData)
        {

            byte[] data1 = Convert.FromBase64String(imageData);

        }

        // GET: Digitalizacion
        public ActionResult DigitalizaHuella()
        {
            //return View("Prueba");
            return View();
        }
        // GET: Digitalizacion
        public ActionResult Recorte()
        {
            return View();
        }


        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }


        /// <summary>
        /// method to rotate an image either clockwise or counter-clockwise
        /// </summary>
        /// <param name="img">the image to be rotated</param>
        /// <param name="rotationAngle">the angle (in degrees).
        /// NOTE: 
        /// Positive values will rotate clockwise
        /// negative values will rotate counter-clockwise
        /// </param>
        /// <returns></returns>
        /*  http://stackoverflow.com/questions/2163829/how-do-i-rotate-a-picture-in-c-sharp */

        public ActionResult GuardarDedoIndividual()
        {
            //create an empty Bitmap image
            string originalFile = Server.MapPath("~/Images/decadactilar.jpeg");
            Image img = Image.FromFile(originalFile);

            Bitmap bmp = new Bitmap(img.Width, img.Height);
            float rotationAngle = 45;
            bmp.SetResolution(img.HorizontalResolution, img.VerticalResolution);
            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();
            ViewBag.picture = bmp;
            return View(ImageToByte(bmp));
            // la imagen rotada es un Bitmap bmp esta en BMP

        }
    }
}