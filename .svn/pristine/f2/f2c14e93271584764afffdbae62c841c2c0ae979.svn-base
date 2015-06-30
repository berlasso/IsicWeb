using System;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;
using ISIC.Entities;
using ISICWeb.Areas.Otip.Models;
using MPBA.DataAccess;
using ISICWeb.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using Imputado = ISIC.Entities.Imputado;

//using System.Data.Entity.Core.Objects;

namespace ISICWeb.Services
{
    public class ImputadosSimilaresService : ISIC.Services.ImputadoService
    {
        private IRepository repository;


        public ImputadosSimilaresService(IRepository repository)
            : base(repository)
        {
            this.repository = repository;

        }

         /* Metodo que Dado un Codigo de Prontuario retorna los imputados */

        public List<ImputadosSimilaresViewModel> ScorePorProntuario(string CodProntuario,string imputadoAComparar)
        {
            Imputado imputado = repository.Set<Imputado>().FirstOrDefault(x => x.CodigoDeBarrasOriginal == imputadoAComparar);



            IEnumerable<Imputado> imputadosp = repository.Set<Imputado>().Where(x => x.Prontuario.ProntuarioNro == CodProntuario).ToList();
       
            return  ActualizaScore(imputadosp.ToList(), imputado).ToList();
        
        }


        /* Dado un imputado genera una lista de Imputados Similares y Actualiza su Score*/

        public IList<ImputadosSimilaresViewModel> ActualizaScore(List<Imputado> imputadosp, Imputado imputado)
        {
            IList<ImputadosSimilaresViewModel> imputadosParecidos = new List<ImputadosSimilaresViewModel>();
           foreach (var i in imputadosp)
            {
                ImputadosSimilaresViewModel elemento = new ImputadosSimilaresViewModel()
                {
                    Apellido = i.Persona.Apellido,
                    Nombres = i.Persona.Nombre,
                    Apodo = i.Persona.Apodo,
                    NombreMadre = i.Persona.Madre,
                    EdadActual = (i.Persona.FechaNacimiento != null) ?( (i.Persona.FechaNacimiento.Value.Month < DateTime.Today.Month || (i.Persona.FechaNacimiento.Value.Month == DateTime.Today.Month && i.Persona.FechaNacimiento.Value.Day < DateTime.Today.Day)) ? DateTime.Today.Year - i.Persona.FechaNacimiento.Value.Year : DateTime.Today.Year - i.Persona.FechaNacimiento.Value.Year - 1) : 0,
                    BioManoDerecha = i.BioManoDerecha,
                    ProntuarioSIC = i.Prontuario.ProntuarioNro,
                    CodigoDeBarras = i.CodigoDeBarrasOriginal,
                    Id = i.Id,
                    BioManoIzquierda = i.BioManoIzquierda,
                    DocumentoNumero = i.Persona.DocumentoNumero,
                    FechaFichaje = i.FechaCreacionI,
                    SCNombreMadre = i.Persona.Madre == imputado.Persona.Madre ? 5 : 0,
                    SCApodo = i.Persona.Apodo == imputado.Persona.Apodo ? 5 : 0,
                    SCDocumento = i.Persona.DocumentoNumero == imputado.Persona.DocumentoNumero ? 15 : 0,
                    SCApeyNom = (i.Persona.Nombre == imputado.Persona.Nombre && i.Persona.Apellido == imputado.Persona.Apellido ? 10 : 0),
                    SCApellido = (i.Persona.Apellido == imputado.Persona.Apellido ? 9 : 0),
                    SCEdad = (i.Persona.FechaNacimiento != null && imputado.Persona.FechaNacimiento != null) ?
                    ( (i.Persona.FechaNacimiento == null ? 0 : (DateTime.Compare(DateTime.Now, i.Persona.FechaNacimiento.Value) <=
                    DateTime.Compare(DateTime.Now, imputado.Persona.FechaNacimiento.Value) + 10 &&
                  DateTime.Compare(DateTime.Now, i.Persona.FechaNacimiento.Value) >=
                  DateTime.Compare(DateTime.Now, imputado.Persona.FechaNacimiento.Value) - 10) ? 4 : 0)): 0
                };
                elemento.ScoreTotal = elemento.SCEdad + elemento.SCApellido + elemento.SCApeyNom + elemento.SCDocumento;
                if (elemento.ScoreTotal >= 10)
                {
                    // Atencion SOLAMENTE se agregan los imputados cuyo Score sea mayor o igual a 10 
                    elemento.Extraccion = i.BioManoDerecha.ToList().Exists(x => x.imagen.Length > 0) || i.BioManoIzquierda.ToList().Exists(x => x.imagen.Length > 0);
                    imputadosParecidos.Add(elemento);
                }
               
            }
           imputadosParecidos.OrderByDescending(x => x.ScoreTotal);
           return imputadosParecidos;
        }

        /*Metodo que retorna los imputados similares y su Score sgrupados por Codigo de Prontuario*/
        public List<ImputadosSimilaresViewModel> BusquedaSimilaresDatosPersonales(string codigoDeBarra,ref Imputado imputadoR)
        {
           Imputado imputado= repository.Set<Imputado>().Include("Persona").FirstOrDefault(x => x.CodigoDeBarrasOriginal == codigoDeBarra );
            if (imputado == null)
                return null;
           imputadoR = imputado;

           IList<ImputadosSimilaresViewModel> imputadosParecidos = new List<ImputadosSimilaresViewModel>();
           //IList<Imputado> imputados 
           IEnumerable<Imputado> imputadosp = repository.Set<Imputado>().Where(x =>
              ( ((x.Persona.Sexo.descripcion != null) && (imputado.Persona.Sexo.descripcion != null)) && (x.Persona.Sexo.descripcion == imputado.Persona.Sexo.descripcion ? true : false)) &&
                                                              ( x.Id != imputado.Id) &&
                                                           ((x.Persona.Apellido == imputado.Persona.Apellido ||
                                                             (x.Persona.Apellido == imputado.Persona.Apellido && x.Persona.Nombre == imputado.Persona.Nombre) ||
                                                             x.Persona.Apodo == imputado.Persona.Apodo ||
                                                             x.Persona.DocumentoNumero == imputado.Persona.DocumentoNumero ||
                                                             x.Persona.Madre == imputado.Persona.Madre || (x.Persona.FechaNacimiento != null && imputado.Persona.FechaNacimiento != null)) && ((System.Data.Entity.DbFunctions.DiffYears(DateTime.Now, x.Persona.FechaNacimiento) <=
                                                                                                                                                                                                System.Data.Entity.DbFunctions.DiffYears(DateTime.Now, imputado.Persona.FechaNacimiento) + 10
                                                                                                                                                                                                &&
                                                                                                                                                                                                System.Data.Entity.DbFunctions.DiffYears(DateTime.Now, x.Persona.FechaNacimiento) >=
                                                                                                                                                                                                System.Data.Entity.DbFunctions.DiffYears(DateTime.Now, imputado.Persona.FechaNacimiento) - 10))
                                                              )).ToList();

      

           imputadosParecidos = ActualizaScore(imputadosp.ToList(), imputado);
           var imputadosAgrupados = imputadosParecidos.GroupBy(t => t.ProntuarioSIC).Select(group => new
           {
               group.Key,
               ScoreTotal = group.Max(x => x.ScoreTotal),
                                                                                                      SCEdad = group.Max(x => x.SCEdad),
                                                                                                      SCDocumento = group.Max(x => x.SCDocumento),
                                                                                                      SCApeyNom = group.Max(x =>  x. SCApeyNom),
                                                                                                      SCNombreMadre = group.Max(x => x.SCNombreMadre), 
                                                                                                       SCApellido = group.Max(x =>  x. SCApellido)});

          

           List<ImputadosSimilaresViewModel> imputadosAg = new List<ImputadosSimilaresViewModel>();
            foreach(var ag in imputadosAgrupados)
            {
                var result =  imputadosParecidos.Where(t=> t.ScoreTotal == ag.ScoreTotal && t.ProntuarioSIC ==ag.Key).First();


                imputadosAg.Add((ImputadosSimilaresViewModel)new ImputadosSimilaresViewModel
                {
                    ScoreTotal = result.ScoreTotal,
                    SCEdad = result.SCEdad,
                    SCDocumento = result.SCDocumento,
                    SCApeyNom = result.SCApeyNom,
                    SCNombreMadre = result.SCNombreMadre,
                    SCApellido = result.SCApellido,
                    Id = result.Id,
                    CodigoDeBarras = result.CodigoDeBarras,
                    ProntuarioSIC = result.ProntuarioSIC,
                    Apellido = result.Apellido,
                    NombreMadre = result.NombreMadre,
                    ScoreMax="S",
                    Nombres = result.Nombres,
                    EdadActual = result.EdadActual,
                    Apodo = result.Apodo,
                    DocumentoNumero = result.DocumentoNumero,
                    CantidadCoincidencias = ((result.SCEdad != 0) ? 1 : 0 ) + ((result.SCApellido != 0) ? 1 : 0) + ((result.SCApeyNom != 0) ? 1 : 0) + ((result.SCNombreMadre != 0) ? 1 : 0) + ((result.SCDocumento != 0) ? 1 : 0)
                });
            }
          
           return imputadosAg;

        }


    
    }
}
