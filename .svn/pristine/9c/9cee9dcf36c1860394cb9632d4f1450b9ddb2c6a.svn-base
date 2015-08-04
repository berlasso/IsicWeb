using ISIC.Entities;
using ISIC.Enums;
using MPBA.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIC.Services
{
    public class BioDactilarService : IBioDactilarService
    {

        IRepository repository;

        public BioDactilarService(IRepository repository) 
        {
            this.repository = repository;
        }

        public List<BioDactilar> GetBioManoDerechaByCodigoBarra(string codigoBarra)
        {
            return repository.Set<BioDactilar>().Where(i => i.CodigoDeBarra == codigoBarra && i.Mano == ClaseMano.Derecha).ToList();
        }

        public List<BioDactilar> GetBioManoIzquierdaByCodigoBarra(string codigoBarra)
        {
            return repository.Set<BioDactilar>().Where(i => i.CodigoDeBarra == codigoBarra && i.Mano == ClaseMano.Izquierda).ToList();
        }

        public BioDactilar GetById(int id)
        {
            return repository.Set<BioDactilar>().Where(i => i.Id == id).FirstOrDefault();
        }

        public List<VucClasificacion> GetListaClasificacionVuc()
        {
            return repository.Set<VucClasificacion>().ToList();
        }

        public List<VucSubClasificacion> GetListaSubClasificacionVuc(int idClasificacion)
        {
            return repository.Set<VucSubClasificacion>().Where(i => i.Clasificacion.Id == idClasificacion).ToList();
        }

        public VucClasificacion GetClasificacionVuc(int id)
        {
            return repository.Set<VucClasificacion>().SingleOrDefault(x => x.Id == id);
        }
        
        public VucSubClasificacion GetSubClasificacionVuc(int id)
        {
            return repository.Set<VucSubClasificacion>().SingleOrDefault(x => x.Id == id);
        }

        public void Modificar(BioDactilar bioDactilar)
        {
            this.repository.UnitOfWork.RegisterChanged(bioDactilar);
            this.repository.UnitOfWork.Commit();
        }

        public void BorrarBio(BioDactilar bioDactilar)
        {
            var bioDactilarDB = repository.Set<BioDactilar>().SingleOrDefault(s => s.Id == bioDactilar.Id);
            this.repository.UnitOfWork.RegisterDeleted(bioDactilarDB);
         
            
        }
    }

    public interface IBioDactilarService
    {
        List<BioDactilar> GetBioManoDerechaByCodigoBarra(string codigoBarra);
        List<BioDactilar> GetBioManoIzquierdaByCodigoBarra(string codigoBarra);
        BioDactilar GetById(int id);
        List<VucClasificacion> GetListaClasificacionVuc();
        List<VucSubClasificacion> GetListaSubClasificacionVuc(int idClasificacion);
        VucClasificacion GetClasificacionVuc(int id);
        VucSubClasificacion GetSubClasificacionVuc(int id);
        void Modificar(BioDactilar BioDactilar);
        void BorrarBio(BioDactilar BioDactilar);
    }
}
