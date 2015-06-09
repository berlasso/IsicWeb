using ISIC.Entities;
using MPBA.DataAccess;
using System.Collections.Generic;
using System.Linq;
using ISIC.Enums;
using System;
 


namespace ISIC.Services
{
    public class ImputadoService : IImputadoService
    {
        readonly IRepository _repository;

        public ImputadoService(IRepository repository) 
        {
            _repository = repository;
        }

        public IList<Imputado> GetAll() 
        {
            return _repository.Set<Imputado>().ToList();
        }
        public IList<Imputado> GetAllByEstado(SICEstadoTramite estado)
        {
            return _repository.Set<Imputado>().ToList().FindAll(i => i.Estado == estado);
           
        }

        public Imputado GetByCodigoBarra(string codigoBarra)
        {
            return _repository.Set<Imputado>().FirstOrDefault(i => i.CodigoDeBarras == codigoBarra);
        }

        public Imputado GetById(int id)
        {
            return _repository.Set<Imputado>().FirstOrDefault(i => i.Id == id);
        }

        public void BorrarHuellas(Imputado imputado)
        {
            try
            {
                imputado.BioManoDerecha.Where(x => x.CodigoDeBarra == imputado.CodigoDeBarras);
                imputado.BioManoIzquierda.Where(x => x.CodigoDeBarra == imputado.CodigoDeBarras);

                foreach (var bioDactilarD in imputado.BioManoDerecha.ToArray())
                {
                    imputado.BioManoDerecha.Remove(bioDactilarD);
                    _repository.UnitOfWork.RegisterDeleted(bioDactilarD);

                }

                 foreach (var bioDactilarI in imputado.BioManoIzquierda.ToArray())
                {
                    imputado.BioManoIzquierda.Remove(bioDactilarI);
                    _repository.UnitOfWork.RegisterDeleted(bioDactilarI);
                }
                _repository.UnitOfWork.Commit();

            }
            catch {
                // ignorado
            }

            return;
        }
        public void InicializaHuellasDactilares(Imputado imputado)
        {

            this.BorrarHuellas(imputado);
            List<BioDactilar> bioManoD = new List<BioDactilar>();
           List<BioDactilar> bioManoI = new List<BioDactilar>();
       

          bioManoD = new List<BioDactilar>();
          bioManoI = new List<BioDactilar>();

            for (var i = 0; i < 10; i++)
            {
                ClaseDedo dedo = (ClaseDedo)i;
              
                if (i < 5)
                {
                     BioDactilar bioD = new BioDactilar()
                    {
                        CodigoDeBarra = imputado.CodigoDeBarras,
                        imagen = null,
                        Mano = ISIC.Enums.ClaseMano.Derecha,
                        Dedo = dedo,
                        EstadoDedo = ISIC.Enums.ClaseEstadoDedo.Normal,
                      
                        FechaDigital = DateTime.Now,
                        Baja = false
                      
                    };
                    bioManoD.Add(bioD);
                }
                if (i >= 5)
                {
                    BioDactilar bioI = new BioDactilar()
                    {
                        CodigoDeBarra = imputado.CodigoDeBarras,
                        imagen = null,
                        Mano = ISIC.Enums.ClaseMano.Izquierda,
                        Dedo = dedo,
                        EstadoDedo = ISIC.Enums.ClaseEstadoDedo.Normal,
                   
                        FechaDigital = DateTime.Now,
                        Baja = false
                      
                    };
                    bioManoI.Add(bioI);
                }
               
               
            }

            imputado.BioManoDerecha = bioManoD;
            imputado.BioManoIzquierda = bioManoI;
            return;
      
        }
        public void Actualizar(Imputado imputado)
        {
            this._repository.UnitOfWork.RegisterChanged(imputado);
            this._repository.UnitOfWork.Commit();
        }


        public bool DeleteById(int idImputado)
        {
            bool borroBien=false;
            try
            {
                var imputadoDb = _repository.Set<Imputado>().SingleOrDefault(s => s.Id == idImputado);
                if (imputadoDb != null)
                {
                    if (imputadoDb.BioManoDerecha.Count > 0)
                    {
                        foreach (var bioDactilarD in imputadoDb.BioManoDerecha.ToArray())
                        {
                            _repository.UnitOfWork.RegisterDeleted(bioDactilarD);
                        }
                    }
                    if (imputadoDb.BioManoIzquierda.Count > 0)
                    {
                        foreach (var bioDactilarI in imputadoDb.BioManoIzquierda.ToArray())
                        {
                            _repository.UnitOfWork.RegisterDeleted(bioDactilarI);
                        }
                    }
                    if (imputadoDb.Archivos!=null && imputadoDb.Archivos.Count > 0)
                    {
                        foreach (var archivo in imputadoDb.Archivos.ToArray())
                        {
                            _repository.UnitOfWork.RegisterDeleted(archivo);
                        }
                    }
                    _repository.UnitOfWork.RegisterDeleted(imputadoDb);
                    _repository.UnitOfWork.Commit();
                    borroBien= true;
                }
                
            }
            catch
            {
                // ignored
            }
            return borroBien;
        }


        public Imputado GetByCodigoHuellas(string codigoBarra)
        {
            return _repository.Set<Imputado>().Where(x => x.BioManoDerecha.FirstOrDefault().CodigoDeBarra ==x.BioManoIzquierda.FirstOrDefault().CodigoDeBarra ).FirstOrDefault(i => i.CodigoDeBarras == codigoBarra);

        }

    }

     
 


    public interface IImputadoService
    {
        IList<Imputado> GetAll();
        IList<Imputado> GetAllByEstado(SICEstadoTramite estado);
        Imputado GetByCodigoBarra(string codigoBarra);
        Imputado GetByCodigoHuellas(string codigoBarra);
        void Actualizar(Imputado imputado);
        void InicializaHuellasDactilares(Imputado imputado);
        bool DeleteById(int idImputado);
        void BorrarHuellas(Imputado imputado);

    }
}
