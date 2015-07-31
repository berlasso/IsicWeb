using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using ISIC.Entities;
using ISICWeb.Areas.Otip.Models;
using MPBA.DataAccess;
using System.Drawing;
using System.Drawing.Imaging;
using br.com.arcnet.barcodegenerator;
using ISICWeb.Services;
using Novacode;

using Image = System.Drawing.Image;

namespace ISICWeb.Areas.Otip.Controllers
{
    [Audit]
    [Autorizar(Roles = "Administrador, OTIP")]
    public class ReporteController : Controller
    {
        IRepository repository;
        public ReporteController(IRepository repository)
        {
            this.repository = repository;
        
        }

     
        // GET: Reporte
        public string GenerarReporte(int id, bool sinHuellas)
        {
            if (id > 0)
            {
                ImputadoExtraService imputadoSrv=new ImputadoExtraService(repository);
                DatosGeneralesViewModel dg=new DatosGeneralesViewModel();
                dg=imputadoSrv.LlenarViewModelConImputado(id,0);
                
                string path = Server.MapPath("~/Content/");
                string fileTmp = Guid.NewGuid().ToString() + ".docx";
                string pathTmp = path + fileTmp;
                if (sinHuellas)
                    System.IO.File.Copy(path + "reporteSinLugarHuellas.docx", pathTmp);
                else
                {
                    System.IO.File.Copy(path + "reporteConLugarHuellas.docx", pathTmp);
                }
                DocX doc = DocX.Load(pathTmp);
                doc.ReplaceText("${apellidoynombre}", string.Format("{0}, {1}", dg.Apellido, dg.Nombres));
                doc.ReplaceText("${padre}", dg.Padre);
                doc.ReplaceText("${madre}", dg.Madre);
                doc.ReplaceText("${paisnac}", dg.PaisNacimiento);
                doc.ReplaceText("${pcianac}",
                    dg.ProvinciaList.FirstOrDefault(p => p.Value == dg.ProvinciaNacimiento) == null
                        ? ""
                        : dg.ProvinciaList.FirstOrDefault(p => p.Value == dg.ProvinciaNacimiento).Text);
                doc.ReplaceText("${lugarnac}", dg.LocalidadNacimiento);
                doc.ReplaceText("${fechanac}", dg.FechaNacimiento);
                doc.ReplaceText("${tipo}", dg.TipoDocumentoList.First(d => d.Value == dg.TipoDocumento).Text);
                doc.ReplaceText("${sexo}", dg.SexoList.First(s => s.Value == dg.Sexo).Text);
                doc.ReplaceText("${docnro}", dg.NumeroDocumento);
                doc.ReplaceText("${conyuge}", dg.Conyuge);
                doc.ReplaceText("${profesion}", dg.Profesion);
                doc.ReplaceText("${ecivil}", dg.EstadoCivilList.First(e => e.Value == dg.EstadoCivil).Text);
                doc.ReplaceText("${domicilio}", string.Format("{0} nro. {1}", dg.Calle, dg.NroH));
                doc.ReplaceText("${localidad}", dg.Localidad??" ");
                doc.ReplaceText("${caratula}", dg.Delito);
                doc.ReplaceText("${estudios}", dg.InstruccionList.First(i => i.Value == dg.Instruccion).Text);
                doc.ReplaceText("${ufi}", dg.UFI);
                doc.ReplaceText("${ipp}", dg.IPP);

                string comisaria = "";
                if (dg.DependenciaPolicial!="")
                    comisaria= repository.Set<PuntoGestion>().First(c => c.Id.ToString() == dg.hidIdComisaria).Descripcion;
                string locPol = "";
                if (dg.LocalidadPolicial != "")
                    locPol = repository.Set<Localidad>().First(l => l.Id.ToString() == dg.hidIdLocalidadPolicial).LocalidadNombre;
                doc.ReplaceText("${dependencia}",string.Format("{0} - {1}",locPol, comisaria));
                doc.ReplaceText("${juez}", "");
                doc.ReplaceText("${concubino}", "");
                doc.ReplaceText("${alias}", dg.Apodos);
                doc.ReplaceText("${fecha}", dg.FechaDelito);
                doc.ReplaceText("${localidaddelito}", dg.LocalidadDelito??"");
                doc.ReplaceText("${fisgral}", dg.FiscaliaGeneral);
                doc.ReplaceText("${fechahoy}", DateTime.Now.ToString("dd/MM/yyyy"));
                doc.ReplaceText("${prontuarionac}", "");
                doc.ReplaceText("${codbarra}", dg.CodBarras);
                doc.ReplaceText("${otrosnombres}", dg.OtrosNombres);
                doc.ReplaceText("${juzgar}", dg.JuzgadoGarantias);
                doc.ReplaceText("${fecarga}", dg.FechaCarga);
                string prontuario=repository.Set<Imputado>().First(d => d.CodigoDeBarras == dg.CodBarras).Prontuario.ProntuarioNro;
                doc.ReplaceText("${prontuariopcia}", prontuario);
                int dj =Convert.ToInt32(dg.CodBarras.Substring(2, 2));
                string deptoJud=repository.Set<ClaseDepartamentoJudicial>().First(d => d.Id == dj).descripcion;
                doc.ReplaceText("${depto_judicial}", deptoJud);
                doc.ReplaceText("${estatura}", dg.Estatura.ToString());
                
                var barcode2 = new Barcode();
                barcode2.IncludeLabel = true;
                var bar128 = barcode2.Encode(TypeBarcode.Code128, dg.CodBarras);
                var nombrecb = string.Format("codbarras{0}.png", Guid.NewGuid());
                bar128.Save(path+nombrecb);
            	

                
                Novacode.Image img=doc.Images[0];

                Bitmap b= new Bitmap(path+nombrecb);
   
                b.Save(img.GetStream(FileMode.Create, FileAccess.Write), ImageFormat.Png);

                doc.Save();
                b.Dispose();
                doc.Dispose();
                System.IO.File.Delete(path+nombrecb);
                //byte[] fileBytes = System.IO.File.ReadAllBytes(pathTmp);
                //System.IO.File.Delete(pathTmp);
                
                //return File(fileBytes, "application/octet-stream", "Reporte.docx");
                //string f = "~/Content/" + fileTmp;
                //return Json(f, JsonRequestBehavior.AllowGet);
                return pathTmp;


            }
            return null;
        }

        public ActionResult BajarReporte(string rptPath)
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(rptPath);
            
            System.IO.File.Delete(rptPath);
            return File(fileBytes, "application/octet-stream", "Reporte.docx");
        }
     
    }
}