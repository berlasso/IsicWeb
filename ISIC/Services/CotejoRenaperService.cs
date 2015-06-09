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
    public class CotejoRenaperService : ICotejoRenaperService
    {

        IRepository repository;

        public CotejoRenaperService(IRepository repository) 
        {
            this.repository = repository;
        }

        public CotejoRenaper GetByTcn(string tcn)
        {
            return repository.Set<CotejoRenaper>().Where(i => i.Tcn == tcn).FirstOrDefault();
        }

        public CotejoRenaper GetByCodigoDeBarras(string codigoDeBarras)
        {
            return repository.Set<CotejoRenaper>().Where(i => i.CodigoDeBarras == codigoDeBarras).FirstOrDefault();
        }

        public void Agregar(CotejoRenaper cotejoRenaper)
        {
            this.repository.UnitOfWork.RegisterNew(cotejoRenaper);
            this.repository.UnitOfWork.Commit();
        }
        
        public void Modificar(CotejoRenaper cotejoRenaper)
        {
            this.repository.UnitOfWork.RegisterChanged(cotejoRenaper);
            this.repository.UnitOfWork.Commit();
        }
    }

    public interface ICotejoRenaperService
    {
        CotejoRenaper GetByTcn(string tcn);
        CotejoRenaper GetByCodigoDeBarras(string codigoDeBarras);
        void Agregar(CotejoRenaper cotejoRenaper);
        void Modificar(CotejoRenaper cotejoRenaper);
    }
}
