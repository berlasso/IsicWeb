
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ISIC.Entities;
using ISIC.Services;
using ISICWeb.Areas.Otip.Models;
using ISICWeb.Models;
using MPBA.DataAccess;
using MvcFileUploader;
using MvcFileUploader.Models;

namespace ISICWeb.Areas.Otip.Controllers
{

    public class FilesUploaderController : Controller
    {

        IRepository _repository;

        const string UploadsDir = "~/Areas/Otip/Content/uploads";




        public FilesUploaderController(IRepository repository)
        {
            this._repository = repository;
        }

        [OutputCache(NoStore = true, Duration = 1)]
        // GET: /MvcUploaderTest/Imagenes
        public ActionResult Imagenes(int idImputado, string cb)
        {
            ImagenesViewModel model = new ImagenesViewModel
            {
                codBarras = cb,
                idImputado = idImputado
            };
            ViewBag.TipoArchivo = new SelectList(_repository.Set<ClaseTipoArchivo>().ToList(), "Id", "Descripcion", 1);
            ViewBag.UbicacionSena = new SelectList(_repository.Set<ClaseUbicacionSeniaPart>().ToList(), "Id", "Descripcion", 0);
            ViewBag.TipoSena = new SelectList(_repository.Set<ClaseSeniaParticular>().ToList(), "Id", "Descripcion", 0);
            
            //ViewBag.TipoTatuaje = new SelectList(_repository.Set<ClaseTatuaje>().ToList(), "Id", "Descripcion", 0); 
            //ViewBag.id = id;
            //ViewBag.codBarras = cb;


            //string subDir = "/" + cb.Substring(0, 4) + "/";
            //string imagenesDir = UploadsDir + subDir;
            //if (Directory.Exists(Server.MapPath(imagenesDir)))
            //{
                Imputado imputado = _repository.Set<Imputado>().FirstOrDefault(s => s.Id == idImputado);
                ICollection<Archivo> archivosEnBase = imputado.Archivos;
                model.archivos = imputado.Archivos.ToList();
            ViewBag.Nombre = string.Concat(imputado.Persona.Apellido, ", ", imputado.Persona.Nombre);

                // model.path = imagenesDir;
            //}

            return View(model);
        }

        public ActionResult UploadFile(int? imputadoId, string codBarras = "", string hidDescripcionArchivo = "", int hidTipoArchivo = 0, string hidDescripcionTatuaje = "", int? hidTipoSena = 0, int? hidIdUbicacion = 0, string hidImagenCapturada = "", int? esCaptura = null) // optionally receive values specified with Html helper
        {
            // here we can send in some extra info to be included with the delete url 
            var statuses = new List<ViewDataUploadFileResult>();
            FuncionesGrales.TipoImagen TipoImagen=FuncionesGrales.TipoImagen.Rostro;
            switch (hidTipoArchivo)
            {
                case 1:
                    TipoImagen=FuncionesGrales.TipoImagen.Rostro;
                    break;
                case 2:
                    TipoImagen = FuncionesGrales.TipoImagen.Senas;
                    break;
                case 3:
                    TipoImagen = FuncionesGrales.TipoImagen.Tatuaje;
                    break;
                case 4:
                    TipoImagen = FuncionesGrales.TipoImagen.HuellasDactulares;
                    break;
                case 5:
                    TipoImagen = FuncionesGrales.TipoImagen.HuellasPalmares;
                    break;
                case 6:
                    TipoImagen = FuncionesGrales.TipoImagen.Documentacion;
                    break;
            }


            if (esCaptura != null && esCaptura == 1) //si capturo imagen
            {
                byte[] bytes = Convert.FromBase64String(hidImagenCapturada);

                Image image;
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    image = Image.FromStream(ms);
                    string nombre = "";
                    string pathThumb = "";
                    string pathImagen = FuncionesGrales.DirectorioAbsolutoImagenes(codBarras, false, TipoImagen, 1);
                    int nrofoto = 0;
                    string dir = Path.GetDirectoryName(pathImagen) ?? "";
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);
                    do
                    {
                        nrofoto++;
                        pathImagen = FuncionesGrales.DirectorioAbsolutoImagenes(codBarras, false,TipoImagen, nrofoto);
                        pathThumb = FuncionesGrales.DirectorioAbsolutoImagenes(codBarras, true,TipoImagen, nrofoto);

                    } while (System.IO.File.Exists(pathImagen));




                    image.Save(pathImagen);
                    FileInfo fiImagen = new FileInfo(pathImagen);
                    string tamanoArchivo = (fiImagen.Length / 1024).ToString();
                     string fileUrl = FuncionesGrales.SwapPathsImagen(pathImagen,
                            FuncionesGrales.TipoSwap.AbsolutoAVirtual);
                    ViewDataUploadFileResult st = new ViewDataUploadFileResult()
                    {
                        error = null,
                        FullPath = pathImagen,
                        SavedFileName = Path.GetFileName(pathImagen),
                        deleteType = "POST",

                        deleteUrl = Url.Action("DeleteFile", new { archivoId = "cambiar", fileUrl = fileUrl }),
                        name = fiImagen.Name,
                        size = Convert.ToInt32(fiImagen.Length),
                        thumbnailUrl = pathThumb,
                        type = "image/jpeg",
                        url = fileUrl
                    };
                    if (st.error == null)
                    {
                        if (imputadoId > 0)
                        {

                            GuardarDatosFoto(imputadoId, hidTipoArchivo, nombre, hidDescripcionArchivo, hidTipoSena, hidIdUbicacion, hidDescripcionTatuaje, tamanoArchivo, pathImagen, pathThumb, st);
                        }
                        statuses.Add(st);
                    }
                }

            }
            else //subio imagen manual
            {
                for (var i = 0; i < Request.Files.Count; i++)
                {
                    string nombre = "";
                    string letra = "";
                    string pathThumb = "";
                    string pathImagen = FuncionesGrales.DirectorioAbsolutoImagenes(codBarras, false,TipoImagen, 1);
                    int nrofoto = 0;
                    string dir = Path.GetDirectoryName(pathImagen) ?? "";
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);
                    do
                    {
                        nrofoto++;
                        pathImagen = FuncionesGrales.DirectorioAbsolutoImagenes(codBarras, false, TipoImagen, nrofoto);
                        pathThumb = FuncionesGrales.DirectorioAbsolutoImagenes(codBarras, true, TipoImagen, nrofoto);

                    } while (System.IO.File.Exists(pathImagen));




             
                    var st = FileSaver.StoreFile(x =>
                    {
                        x.File = Request.Files[i];
                        x.StorageDirectory = dir;
                        x.UrlPrefix = Path.GetDirectoryName(pathImagen);
                        // this is used to generate the relative url of the file
                        //note how we are adding an additional value to be posted with delete request
                        //and giving it the same value posted with upload
                        string fileUrl = FuncionesGrales.SwapPathsImagen(pathImagen,
                            FuncionesGrales.TipoSwap.AbsolutoAVirtual);
                        x.DeleteUrl = Url.Action("DeleteFile", new { archivoId = "cambiar" });
                        string extension = Path.GetExtension(Request.Files[i].FileName);
                        //overriding defaults
                        //x.FileName = Request.Files[i].FileName;// default is filename suffixed with filetimestamp
                        nombre = Path.GetFileName(pathImagen);
                        x.FileName = Path.GetFileName(pathImagen);
                        x.ThrowExceptions = true;
                        //default is false, if false exception message is set in error property
                    });
                    if (st.error == null)
                    {
                        if (imputadoId > 0)
                        {
                            string tamanoArchivo = Request.Files[i] == null ? "" : (Request.Files[i].ContentLength / 1024).ToString();
                            GuardarDatosFoto(imputadoId, hidTipoArchivo, nombre, hidDescripcionArchivo,  hidTipoSena, hidIdUbicacion, hidDescripcionTatuaje, tamanoArchivo,pathImagen,pathThumb, st);
                        }
                    }
                    statuses.Add(st);
                }
            }
            //statuses contains all the uploaded files details (if error occurs then check error property is not null or empty)
            //todo: add additional code to generate thumbnail for videos, associate files with entities etc



            //setting custom download url instead of direct url to file which is default
            //statuses.ForEach(x => x.url = Url.Action("DownloadFile", new { fileUrl = x.url, mimetype = x.type }));
            
            statuses.ForEach(x => x.url = FuncionesGrales.SwapPathsImagen(x.url,FuncionesGrales.TipoSwap.AbsolutoAVirtual));

            //adding thumbnail url for jquery file upload javascript plugin
            statuses.ForEach(x => x.thumbnailUrl = x.url + "?width=80&height=80&r="+Guid.NewGuid()); // uses ImageResizer httpmodule to resize images from this url

            //server side error generation, generate some random error if entity id is 13
            if (imputadoId == 13)
            {
                var rnd = new Random();
                statuses.ForEach(x =>
                {
                    //setting the error property removes the deleteUrl, thumbnailUrl and url property values
                    x.error = rnd.Next(0, 2) > 0 ? "We do not have any entity with unlucky Id : '13'" : String.Format("Your file size is {0} bytes which is un-acceptable", x.size);
                    //delete file by using FullPath property
                    if (System.IO.File.Exists(x.FullPath)) System.IO.File.Delete(x.FullPath);
                });
            }

            var viewresult = Json(new { files = statuses, status = "Success" });
            //for IE8 which does not accept application/json
            if (Request.Headers["Accept"] != null && !Request.Headers["Accept"].Contains("application/json"))
                viewresult.ContentType = "text/plain";


            //Request.Headers["Accept"] = "application/json, text/javascript, */*; q=0.01";
            return viewresult;
        }

        private void GuardarDatosFoto(int? imputadoId, int hidTipoArchivo, string nombre, string hidDescripcionArchivo,  int? hidTipoSena, int? hidIdUbicacion, string hidDescripcionTatuaje, string tamanoArchivo, string pathImage,string pathThumb, ViewDataUploadFileResult storeFile = null)
        {
            if (hidIdUbicacion == 0)
                hidIdUbicacion = 1;//indeterminado
            Imputado imputado = _repository.Set<Imputado>().FirstOrDefault(s => s.Id == imputadoId);
            ClaseTipoArchivo tipoArchivo =
                _repository.Set<ClaseTipoArchivo>().FirstOrDefault(s => s.Id == hidTipoArchivo);
            Archivo archivo = new Archivo
            {
                Nombre = nombre,
                Tamano = tamanoArchivo,
                Descripcion = hidDescripcionArchivo,
                FechaUpload = DateTime.Now,
                Imputado = imputado,
                Url = FuncionesGrales.SwapPathsImagen(pathImage,FuncionesGrales.TipoSwap.AbsolutoAVirtual),
                ThumbUrl = FuncionesGrales.SwapPathsImagen(pathThumb,FuncionesGrales.TipoSwap.AbsolutoAVirtual),
                TipoArchivo = tipoArchivo

            };
    
            if (hidTipoArchivo == 2) //sena
            {

                if (hidTipoSena == 0)//seleccionar
                    hidTipoSena = 1;//indeterminada
                ClaseSeniaParticular claseSenia =
                    _repository.Set<ClaseSeniaParticular>().FirstOrDefault(x => x.Id == hidTipoSena);
                ClaseUbicacionSeniaPart claseUbicacionSenia =
                    _repository.Set<ClaseUbicacionSeniaPart>()
                        .FirstOrDefault(x => x.Id == hidIdUbicacion);
                archivo.SeniaParticular = new SeniaParticular
                {
                    descripcion = archivo.Descripcion,
                    ClaseSeniaParticular = claseSenia,
                    ClaseUbicacionSeniaPart = claseUbicacionSenia
                };
            }

            if (hidTipoArchivo == 3) //tatuaje
            {
                //   var tatuajes = imputado.TatuajesPersonas ?? new List<TatuajePersona>();
                ClaseUbicacionSeniaPart claseUbicacionTatuaje =
                    _repository.Set<ClaseUbicacionSeniaPart>()
                        .FirstOrDefault(x => x.Id == hidIdUbicacion);
                TatuajePersona tatuaje = new TatuajePersona
                {
                    // ClaseTatuaje = new ClaseTatuaje{descripcion = DescripcionTatuaje}, 

                    ClaseTatuaje =
                        _repository.Set<ClaseTatuaje>()
                            .FirstOrDefault(x => x.descripcion.ToLower().Contains("otro")),
                    ClaseUbicacionSeniaPart = claseUbicacionTatuaje,
                    descripcion = hidDescripcionTatuaje,

                };
                archivo.TatuajePersona = tatuaje;
                imputado.TatuajesPersonas.Add(tatuaje);
            }

            //crea thumbnail

            Image originalImage = System.Drawing.Image.FromFile(pathImage);

            int newWidth = Convert.ToInt32(originalImage.Width * 0.25);
            Image thumbnail = originalImage.GetThumbnailImage(newWidth,
                (newWidth * originalImage.Height) / originalImage.Width, null, IntPtr.Zero);
            if (!Directory.Exists(Path.GetDirectoryName(pathThumb)))
                Directory.CreateDirectory(Path.GetDirectoryName(pathThumb));
            thumbnail.Save(pathThumb, System.Drawing.Imaging.ImageFormat.Jpeg);
            thumbnail.Dispose();
            originalImage.Dispose();




            _repository.UnitOfWork.RegisterNew(archivo);
            _repository.UnitOfWork.Commit();
            if (storeFile != null)
                storeFile.deleteUrl = storeFile.deleteUrl.Replace("cambiar", archivo.Id.ToString());
        }


        //here i am receving the extra info injected
        [HttpPost] // should accept only post
        public ActionResult DeleteFile(int? archivoId, string fileUrl, bool? existente = null)
        {
            Archivo archivo = _repository.Set<Archivo>().First(x => x.Id == archivoId);
            if (archivo==null)
                return  Json(new { error = "No se encontró el archivo en la base" });
            string filePath = FuncionesGrales.SwapPathsImagen(archivo.Url, FuncionesGrales.TipoSwap.VirtualAAbsoluto);
            string thumbPath = FuncionesGrales.SwapPathsImagen(archivo.ThumbUrl, FuncionesGrales.TipoSwap.VirtualAAbsoluto);
            //fileUrl = FuncionesGrales.SwapPathsImagen(fileUrl,FuncionesGrales.TipoSwap.VirtualAAbsoluto);
            //if (!fileUrl.StartsWith("~"))
            //    fileUrl = "~" + fileUrl;
            //var filePath = Server.MapPath(fileUrl);
           // var filePath = fileUrl;
            
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
                //string thumbPath = filePath.Replace("uploads", "uploads/thumbnails");
                if (System.IO.File.Exists(thumbPath))
                {
                    System.IO.File.Delete(thumbPath);
                }
                //Archivo archivo = _repository.Set<Archivo>().ToList().FirstOrDefault(a => a.Id == archivoId);
               
                    _repository.UnitOfWork.RegisterDeleted(archivo);
                    _repository.UnitOfWork.Commit();
               
                if (existente != null && existente == false)
                    return Content(""); //si pulso borrar en el listado de archivos existentes
                else
                {
                    var viewresult = Json(new { error = "" });
                    //for IE8 which does not accept application/json
                    if (Request.Headers["Accept"] != null && !Request.Headers["Accept"].Contains("application/json"))
                        viewresult.ContentType = "text/plain";
                    return viewresult; //si borro del listado de archivos recien subidos
                }
            }
            else
            {
                var viewresult = Json(new { error = "No se encontro el archivo" });
                //for IE8 which does not accept application/json
                if (Request.Headers["Accept"] != null && !Request.Headers["Accept"].Contains("application/json"))
                    viewresult.ContentType = "text/plain";
                //if (existente != null && existente == false)
                //    return Content("");  //si pulso borrar en el listado de archivos existentes
                //else
                return viewresult;//si borro del listado de archivos recien subidos
            }



        }


        //public ActionResult DownloadFile(string fileUrl, string mimetype)
        //{
        //    //var filePath = Server.MapPath("~" + fileUrl);
        //    string filePath = FuncionesGrales.SwapPathsImagen(fileUrl, FuncionesGrales.TipoSwap.AbsolutoAVirtual);
        //    //if (System.IO.File.Exists(filePath))
        //        //return File(filePath, mimetype);
        //    return File(filePath, mimetype);
        //    //else
        //    //{
        //    //    return new HttpNotFoundResult("File not found");
        //    //}
        //}
    }

}
