using ISIC.Entities;
using MPBA.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISIC.Enums;

namespace ISIC.Services
{
    public class ClaseSexoService : IClaseSexoService
    {

        IRepository repository;

        public ClaseSexoService(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<ClaseSexo> GetAll()
        {
            return repository.Set<ClaseSexo>().ToList();
        }


    }



    public interface IClaseSexoService
    {
        IList<ClaseSexo> GetAll();
    }


    //public class ClaseDedoService : IClaseDedoService
    //{

    //    IRepository repository;

    //    public ClaseDedoService(IRepository repository)
    //    {
    //        this.repository = repository;
    //    }

    //    public IList<ClaseDedo> GetAll()
    //    {
    //        return repository.Set<ClaseDedo>().ToList();
    //    }


    //}

    public interface IClaseDedoService
    {
        IList<ClaseDedo> GetAll();
    }


    public class ClaseEstadoCivilService : IClaseEstadoCivilService
    {

        IRepository repository;

        public ClaseEstadoCivilService(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<ClaseEstadoCivil> GetAll()
        {
            return repository.Set<ClaseEstadoCivil>().ToList();
        }
    }

  

    public interface IClaseEstadoCivilService
    {
        IList<ClaseEstadoCivil> GetAll();
    }

       public class ClaseEstudiosCursadosService : IClaseEstudiosCursadosService
    {
        IRepository repository;
        public ClaseEstudiosCursadosService(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<ClaseEstudiosCursados> GetAll()
        {
            return repository.Set<ClaseEstudiosCursados>().ToList();
        }
    }
    public interface IClaseEstudiosCursadosService
    {
        IList<ClaseEstudiosCursados> GetAll();
    }

       public class ClaseSeniaParticularService : IClaseSeniaParticularService
    {
        IRepository repository;
        public ClaseSeniaParticularService(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<ClaseSeniaParticular> GetAll()
        {
            return repository.Set<ClaseSeniaParticular>().ToList();
        }
    }
    public interface IClaseSeniaParticularService
    {
        IList<ClaseSeniaParticular> GetAll();
    }

       public class ClaseTatuajeService : IClaseTatuajeService
    {
        IRepository repository;
        public ClaseTatuajeService(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<ClaseTatuaje> GetAll()
        {
            return repository.Set<ClaseTatuaje>().ToList();
        }
    }
    public interface IClaseTatuajeService
    {
        IList<ClaseTatuaje> GetAll();
    }

       public class ClaseTipoDniService : IClaseTipoDniService
    {
        IRepository repository;
        public ClaseTipoDniService(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<ClaseTipoDNI> GetAll()
        {
            return repository.Set<ClaseTipoDNI>().ToList();
        }
    }
    public interface IClaseTipoDniService
    {
        IList<ClaseTipoDNI> GetAll();
    }

       public class ClaseUbicacionSeniaPartService : IClaseUbicacionSeniaPartService
    {
        IRepository repository;
        public ClaseUbicacionSeniaPartService(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<ClaseUbicacionSeniaPart> GetAll()
        {
            return repository.Set<ClaseUbicacionSeniaPart>().ToList();
        }
    }
    public interface IClaseUbicacionSeniaPartService
    {
        IList<ClaseUbicacionSeniaPart> GetAll();
    }

       public class ClaseCejasDimensionService : IClaseCejasDimensionService
    {
        IRepository repository;
        public ClaseCejasDimensionService(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<SICClaseCejasDimension> GetAll()
        {
            return repository.Set<SICClaseCejasDimension>().ToList();
        }
    }
    public interface IClaseCejasDimensionService
    {
        IList<SICClaseCejasDimension> GetAll();
    }

       public class ClaseCejasTipoService : IClaseCejasTipoService
    {
        IRepository repository;
        public ClaseCejasTipoService(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<SICClaseCejasTipo> GetAll()
        {
            return repository.Set<SICClaseCejasTipo>().ToList();
        }
    }
    public interface IClaseCejasTipoService
    {
        IList<SICClaseCejasTipo> GetAll();
    }

       public class ClaseColorCabelloService : IClaseColorCabelloService
    {
        IRepository repository;
        public ClaseColorCabelloService(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<SICClaseColorCabello> GetAll()
        {
            return repository.Set<SICClaseColorCabello>().ToList();
        }
    }
    public interface IClaseColorCabelloService
    {
        IList<SICClaseColorCabello> GetAll();
    }

       public class ClaseColorOjosService : IClaseColorOjosService
    {
        IRepository repository;
        public ClaseColorOjosService(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<SICClaseColorOjos> GetAll()
        {
            return repository.Set<SICClaseColorOjos>().ToList();
        }
    }
    public interface IClaseColorOjosService
    {
        IList<SICClaseColorOjos> GetAll();
    }

       public class ClaseColorPielService : IClaseColorPielService
    {
        IRepository repository;
        public ClaseColorPielService(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<SICClaseColorPiel> GetAll()
        {
            return repository.Set<SICClaseColorPiel>().ToList();
        }
    }
    public interface IClaseColorPielService
    {
        IList<SICClaseColorPiel> GetAll();
    }

       public class ClaseFormaBocaService : IClaseFormaBocaService
    {
        IRepository repository;
        public ClaseFormaBocaService(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<SICClaseFormaBoca> GetAll()
        {
            return repository.Set<SICClaseFormaBoca>().ToList();
        }
    }
    public interface IClaseFormaBocaService
    {
        IList<SICClaseFormaBoca> GetAll();
    }

       public class ClaseFormaCaraService : IClaseFormaCaraService
    {
        IRepository repository;
        public ClaseFormaCaraService(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<SICClaseFormaCara> GetAll()
        {
            return repository.Set<SICClaseFormaCara>().ToList();
        }
    }
    public interface IClaseFormaCaraService
    {
        IList<SICClaseFormaCara> GetAll();
    }

       public class ClaseFormaLabioInferiorService : IClaseFormaLabioInferiorService
    {
        IRepository repository;
        public ClaseFormaLabioInferiorService(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<SICClaseFormaLabioInferior> GetAll()
        {
            return repository.Set<SICClaseFormaLabioInferior>().ToList();
        }
    }
    public interface IClaseFormaLabioInferiorService
    {
        IList<SICClaseFormaLabioInferior> GetAll();
    }

       public class ClaseFormaLabioSuperiorService : IClaseFormaLabioSuperiorService
    {
        IRepository repository;
        public ClaseFormaLabioSuperiorService(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<SICClaseFormaLabioSuperior> GetAll()
        {
            return repository.Set<SICClaseFormaLabioSuperior>().ToList();
        }
    }
    public interface IClaseFormaLabioSuperiorService
    {
        IList<SICClaseFormaLabioSuperior> GetAll();
    }

       public class ClaseFormaMentonService : IClaseFormaMentonService
    {
        IRepository repository;
        public ClaseFormaMentonService(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<SICClaseFormaMenton> GetAll()
        {
            return repository.Set<SICClaseFormaMenton>().ToList();
        }
    }
    public interface IClaseFormaMentonService
    {
        IList<SICClaseFormaMenton> GetAll();
    }

       public class ClaseFormaNarizService : IClaseFormaNarizService
    {
        IRepository repository;
        public ClaseFormaNarizService(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<SICClaseFormaNariz> GetAll()
        {
            return repository.Set<SICClaseFormaNariz>().ToList();
        }
    }
    public interface IClaseFormaNarizService
    {
        IList<SICClaseFormaNariz> GetAll();
    }

       public class ClaseFormaOrejaService : IClaseFormaOrejaService
    {
        IRepository repository;
        public ClaseFormaOrejaService(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<SICClaseFormaOreja> GetAll()
        {
            return repository.Set<SICClaseFormaOreja>().ToList();
        }
    }
    public interface IClaseFormaOrejaService
    {
        IList<SICClaseFormaOreja> GetAll();
    }

       public class ClaseRobustezService : IClaseRobustezService
    {
        IRepository repository;
        public ClaseRobustezService(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<SICClaseRobustez> GetAll()
        {
            return repository.Set<SICClaseRobustez>().ToList();
        }
    }
    public interface IClaseRobustezService
    {
        IList<SICClaseRobustez> GetAll();
    }

       public class ClaseTipoCabelloService : IClaseTipoCabelloService
    {
        IRepository repository;
        public ClaseTipoCabelloService(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<SICClaseTipoCabello> GetAll()
        {
            return repository.Set<SICClaseTipoCabello>().ToList();
        }
    }
    public interface IClaseTipoCabelloService
    {
        IList<SICClaseTipoCabello> GetAll();
    }

       public class ClaseTipoCalvicieService : IClaseTipoCalvicieService
    {
        IRepository repository;
        public ClaseTipoCalvicieService(IRepository repository)
        {
            this.repository = repository;
        }

        public IList<SICClaseTipoCalvicie> GetAll()
        {
            return repository.Set<SICClaseTipoCalvicie>().ToList();
        }
    }
    public interface IClaseTipoCalvicieService
    {
        IList<SICClaseTipoCalvicie> GetAll();
    }
}
