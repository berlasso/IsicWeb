using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MPBA.SIAC.Web.Models;

using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.UI.WebControls;
using MPBA.PersonasBuscadas.Web;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;
using MPBA.SIAC.Web.Filters;

namespace MPBA.SIAC.Web.Controllers
{
    public class PBFotosController : Controller
    {
        private SIACEntities db = new SIACEntities();

        //
        // GET: /PBFotos/


        public class PersonaTipoDestino
        {
            public int idPersona { get; set; }
            public int idTablaDestino { get; set; }
        }



        public static Stream CreateThumbnail(MemoryStream input, Int32 targetWidth, Int32 targetHeight)
    {
       MemoryStream  output = new MemoryStream();
            using (Bitmap bitmap = new Bitmap(input))
            {
                System.Drawing.Imaging.ImageFormat format = bitmap.RawFormat;
                Boolean isJpeg = (format.Equals(ImageFormat.Jpeg));
                Boolean isPng = (format.Equals(ImageFormat.Png));
                Int32 width = bitmap.Width;
                Int32 height = bitmap.Height;
                getTargetSizes(out width, out height, bitmap, targetWidth, targetHeight);
                using (Bitmap thumbnailBitmap = new Bitmap(width, height))
                {
                    Graphics G = Graphics.FromImage(thumbnailBitmap);
                    G.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    G.DrawImage(bitmap, 0, 0, width, height);
                    thumbnailBitmap.SetResolution(72, 72);
                    if (isJpeg)
                    {
                        var codecParams = new EncoderParameters(1);
                        codecParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 80L);
                        ImageCodecInfo[] arrayICI;
                        ImageCodecInfo jpegICI = null;
                        arrayICI = ImageCodecInfo.GetImageEncoders();
                        for (int i = 0; i < arrayICI.Length; i++)
                        {
                            if (arrayICI[i].FormatDescription.Equals("JPEG"))
                            {
                                jpegICI = arrayICI[i];
                                break;
                            }
                        }
                        thumbnailBitmap.Save(output, jpegICI, codecParams);
                    }
                    else
                    {
                        thumbnailBitmap.Save(output, ImageFormat.Png);
                    }
                }
            }
        return output;
    }

    private static void getTargetSizes(out Int32 targetWidth, out Int32 targetHeight, Bitmap BM, Int32 maxWidth = 700, Int32 maxHeight = 500)
    {
        Int32 startWidth = BM.Width;
        Int32 startHeight = BM.Height;
        targetWidth = startWidth;
        targetHeight = startHeight;
        Boolean resizeByWidth = false;
        Boolean resizeByHeight = false;
        if ((maxWidth > 0) && (maxHeight > 0))
        {
            if ((startWidth > maxWidth) || (startHeight > maxHeight))
            {
                if (startHeight <= startWidth)
                {
                    if(targetWidth > maxWidth) resizeByWidth = true;
                }
                else
                {
                    if(targetHeight > maxHeight) resizeByHeight = true;
                }
            }
        }
        else if (maxWidth > 0)
        {
            // Resize within width only
            if (startWidth > maxWidth)
            {
                if (targetWidth > maxWidth) resizeByWidth = true;
            }
        }
        else if (maxHeight > 0)
        {
            // Resize by height only
            if (startHeight > maxHeight)
            {
                if (targetHeight > maxHeight) resizeByHeight = true;
            }
        }
        if (resizeByWidth)
        {
            targetWidth = maxWidth;
            targetHeight = (Int32)(startHeight * ((Decimal)targetWidth / (Decimal)startWidth));
        }
        if (resizeByHeight)
        {
            targetHeight = maxHeight;
            targetWidth = (Int32)(startWidth * ((Decimal)targetHeight / (Decimal)startHeight));
        }
    }


    public ActionResult NavegadorFotosPersonasFiltro()
    {
      
        PBFotos unafoto = new PBFotos();
        unafoto.idTablaDestino = 1;
        /*Traigo las fotos y dsps las filtro*/
       
        ViewBag.idTipoFoto = new SelectList(db.PBClaseFotos, "id", "tipoFoto");
        ViewBag.idTablaDestino = new SelectList(db.PBClaseTablaDestinos, "Id", "Descripcion");
        return View("NavegadorFotosPersonasFiltro",unafoto);
    }
         
    /*    public ActionResult Index()
        {
            var pbfotos = db.PBFotos.Include(p => p.PBClaseFoto).Include(p => p.PBClaseTablaDestino);
            return View("FotoPersonalPagina",pbfotos.ToList());
        }
        */
       [Audita(AuditingLevel = 2)]
        public ActionResult FotoPersonalPagina()
        {


            FuncionesGrales.TipoBusqueda tipoBusqueda = (FuncionesGrales.TipoBusqueda) Session["TipoBusquedaPersonas"];
             int tipoB;
            List<PBFotosDatosPersonales> fotospersonales =  new List<PBFotosDatosPersonales>();
            switch (tipoBusqueda)
            {
                case FuncionesGrales.TipoBusqueda.PersonaDesaparecida:
                    tipoB = Convert.ToInt16(FuncionesGrales.TipoBusqueda.PersonaDesaparecida);
                    List<MPBA.PersonasBuscadas.BusinessEntities.PersonasDesaparecidas> personasD = Session["ResultadoBusquedaPersonas"] as List<MPBA.PersonasBuscadas.BusinessEntities.PersonasDesaparecidas>;

                    ViewBag.titulo = "Desaparecidas";
                    foreach (var per in personasD)
                    {
                         PBFotosDatosPersonales fotospersonal =   AgregoFotos(per.Id, tipoB, per.Ipp, per.DNI, per.Apellido, per.Nombre); 
                       if (fotospersonal !=null) 
                               fotospersonales.Add(fotospersonal );
                       }
                  
                    break;
                case FuncionesGrales.TipoBusqueda.PersonaHallada:
                    tipoB = Convert.ToInt16(FuncionesGrales.TipoBusqueda.PersonaHallada);
                    List<MPBA.PersonasBuscadas.BusinessEntities.PersonasHalladas> personasH = Session["ResultadoBusquedaPersonas"] as List<MPBA.PersonasBuscadas.BusinessEntities.PersonasHalladas>;
                    ViewBag.titulo = "Halladas";

                    foreach (var per in personasH)
                    {
                        PBFotosDatosPersonales fotospersonal =   AgregoFotos(per.Id, tipoB, per.Ipp, per.DNI, per.Apellido, per.Nombre); 
                       if (fotospersonal !=null) 
                               fotospersonales.Add(fotospersonal );
                                              
                        }
                    break;

                   }
       
//            var pbfotos = db.PBFotos.Include(p => p.PBClaseFoto).Include(p => p.PBClaseTablaDestino);
            return View("FotoPersonalWebForm", fotospersonales);
        }

       [Audita(AuditingLevel = 2)]
       [HttpPost]
        public ActionResult NavegadorFotosPersonas(string idTablaDestino, string sexo)
        {
            /*   PersonaDesaparecida = 1,
                 PersonaHallada = 2
                 Todas = 3
             */
            int tipoPersona =3;
            int idSexo =0;
            idSexo = sexo == "Femenino" ? 2 : (sexo == "Masculino" ? 3 : 0);
         
                      
            
            if (idTablaDestino!= "" && idTablaDestino!= null)
                tipoPersona = Convert.ToInt16(idTablaDestino);
            var pbfotos = from p in db.PBFotos 
                          group p by new { p.idPersona, p.idTablaDestino };

            
                          
                         // select new PersonaTipoDestino() { idPersona = p.idPersona, idTablaDestino = p.idTablaDestino } into x
                         // AsQueryable()
                      

      /*     var pbfotos = db.PBFotos.AsQueryable().*/
                        //       GroupBy(p => new PersonaTipoDestino(){ p.idPersona, p.idTablaDestino });
               
        

            //return View("FotoPersonalPagina", pbfotos.ToList());
            switch (tipoPersona)
            {
                
                case 1:

                    pbfotos = pbfotos.Where(p => p.Key.idTablaDestino == 1);
                   ViewBag.titulo = "Desaparecidas";
                    break;
                case 2:

                    pbfotos = pbfotos.Where(p => p.Key.idTablaDestino == 2);
                   ViewBag.titulo = "Halladas";
                    break;
              
            }
                

                    List<PBFotosDatosPersonales> fotospersonales = new List<PBFotosDatosPersonales>();
                    String apellido = "";
                    String nombre = "";
                    String DNI;
                  
                  
                    PBFotosDatosPersonales fotospersonal = null;
                 
                
                    foreach (var per in pbfotos)
                    {


                        if (per.Key.idTablaDestino == 1 )
                        {
                         MPBA.SIAC.Web.Models.PersonasDesaparecidas persona = (MPBA.SIAC.Web.Models.PersonasDesaparecidas)db.PersonasDesaparecidas.Find(per.Key.idPersona);
                                               

                            if (persona == null || (idSexo !=0 && persona.idSexo !=idSexo) || persona.Baja==true  )
                                continue;
                            apellido= persona.Apellido != null ? persona.Apellido:"NN " ;
                            nombre = persona.Nombre != null ? persona.Nombre : "NN ";
                            DNI = persona.DNI != null ? persona.DNI : " ";                                   
                            fotospersonal = AgregoFotosString(per.Key.idPersona, tipoPersona, persona.Ipp, DNI, apellido, nombre);
                            if (fotospersonal != null)
                                fotospersonales.Add(fotospersonal);

                        }
                        if (per.Key.idTablaDestino == 2  )
                        { 
                            MPBA.SIAC.Web.Models.PersonasHalladas persona = db.PersonasHalladas.Find(per.Key.idPersona);
                            
                            if (persona == null || (idSexo != 0 && persona.idSexo != idSexo) ||  persona.Baja ==true)
                                  continue;
                            apellido = persona.Apellido != null ? persona.Apellido : "NN ";
                            nombre = persona.Nombre != null ? persona.Nombre : "NN ";
                            DNI = persona.DNI != null ? persona.DNI : " ";
                            fotospersonal = AgregoFotosString(per.Key.idPersona, tipoPersona, persona.Ipp, DNI, persona.Apellido, persona.Nombre);


                            if (fotospersonal != null)
                                fotospersonales.Add(fotospersonal);
                        }

                       

                            
                           
                    }

                    
                
            

            //            var pbfotos = db.PBFotos.Include(p => p.PBClaseFoto).Include(p => p.PBClaseTablaDestino);
            return View(fotospersonales);
        }


       public PBFotosDatosPersonales AgregoFotos(int vidPersona, int vidTablaDestino, string Ipp, string DNI, string Apellido, string Nombre)
       {
           PBFotosDatosPersonales fotoPersonal = new PBFotosDatosPersonales();
           List<String> fotosString = new List<String>();

     
           List<PBFotos> fotos = (from d in db.PBFotos
                                  where (d.idPersona == vidPersona && d.idTablaDestino == vidTablaDestino)
                                  select d).ToList();

           if (fotos.Count == 0)
               return null;


         
           fotoPersonal.IdPersona = vidPersona;
           fotoPersonal.Ipp = Ipp;
           fotoPersonal.DNI = DNI;
           if (Apellido != null)
               fotoPersonal.Apellido = Regex.Replace(Apellido, @"\b[a-z]", delegate(Match m) { return m.Value.ToUpper(); });
           if (Nombre != null)
               fotoPersonal.Nombre = Regex.Replace(Nombre, @"\b[a-z]", delegate(Match m) { return m.Value.ToUpper(); });


           fotoPersonal.pbFotos = new List<PBFotos>();
            fotoPersonal.pbFotos.AddRange(fotos);
        

           return fotoPersonal;


       }
        /* Se utilizaria si se podia parsear la foto con Html5 directamente*/
        public PBFotosDatosPersonales AgregoFotosString(int vidPersona,int vidTablaDestino,string Ipp,string DNI,string Apellido,string Nombre)
        {
         PBFotosDatosPersonales fotoPersonal = new PBFotosDatosPersonales();
       /*  List<String> fotosString = new List<String>();*/
        /* List<PBFotos> fotos = db.PBFotos
                        .Include(p => p.PBClaseFoto).Include(p => p.PBClaseTablaDestino)
                        .Where(p => p.idPersona ==  vidPersona && p.idTablaDestino == vidTablaDestino)
                        .ToList();*/

         List<PBFotos> fotos = (from d in db.PBFotos
                                where (d.idPersona ==  vidPersona && d.idTablaDestino == vidTablaDestino)
                                select d).ToList();
       
                         if (fotos.Count == 0)
                           return null;
                        
            /*
                        foreach (var imageData in fotos)
                        {
                            if (imageData == null)
                                continue;
                            byte[] fotoReducida = GetImage(imageData.Foto);
                            

                            string imageBase64 = Convert.ToBase64String(fotoReducida);
                            string imageSrc = string.Format("data:image/gif;base64,{0}", imageBase64);
                            if (fotos.Count == 0)
                                return null;
                        
                            fotosString.Add(imageSrc);

                        }                 
         */
                        fotoPersonal.IdPersona = vidPersona;
                        fotoPersonal.Ipp = Ipp;
                        fotoPersonal.DNI = DNI;
                        if (Apellido!= null)
                         fotoPersonal.Apellido = Regex.Replace(Apellido, @"\b[a-z]", delegate (Match m) { return m.Value.ToUpper(); });
                        if (Nombre != null)
                            fotoPersonal.Nombre = Regex.Replace(Nombre, @"\b[a-z]", delegate(Match m) { return m.Value.ToUpper(); });
                                                              
                       
                        fotoPersonal.pbFotos = new List<PBFotos>();
           /*             fotoPersonal.fotosString=new List<String>();*/
                        fotoPersonal.pbFotos.AddRange(fotos);
                        /*fotoPersonal.fotosString.AddRange(fotosString);*/
                       
                        return fotoPersonal;
                

        }





       
        // Metodo que busca la Foto de la Base de Datos dada un id De PBFotos
        // Metodo que busca la Foto de la Base de Datos dada un id De PBFotos
       
        public ActionResult GetImageById(int indice)
        {

            byte[] imageDB = (from d in db.PBFotos
                              where d.id == indice
                              select d.Foto).First();

            if (imageDB == null)
            {
                return new FilePathResult("~/App_Images/SinFoto.gif", "image/png");

            }


            MemoryStream strm = new MemoryStream(imageDB);
            strm = (MemoryStream)CreateThumbnail(strm, 800, 600);
            /*   byte[] buffer = new byte[16 * 1024];
               using (MemoryStream ms = new MemoryStream())
               {
                   int read;
                   while ((read = strm.Read(buffer, 0, buffer.Length)) > 0)
                   {
                       ms.Write(buffer, 0, read);
                   }
                
               }*/

            return new FileContentResult(strm.ToArray(), "image/jpg");
        }
    

        /*Tomo la imagen desde un arraglo de bytes y lo reduzco*/
        public byte[] GetImage(byte[] imageDB)
        {
                   
          /*  MemoryStream strm = new MemoryStream(imageDB);
            strm =   (MemoryStream) CreateThumbnail(strm, 700,500);
            imageDB = strm.ToArray();
          //return new FileContentResult(strm.ToArray(), "image/jpg");*/
            return imageDB;
        }

      
    
       

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}