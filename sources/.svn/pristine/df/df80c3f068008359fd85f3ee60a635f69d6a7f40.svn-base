using System;
using System.ComponentModel;
using System.Transactions;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll
{

    [DataObjectAttribute()]
    public partial class PersHalladaCantXDependenciaXFechaManager
    {

        #region "Public Methods"

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static PersHalladaCantXDependenciaXFechaList GetList(string fechaDesde, string fechaHasta, int idDepto)
        {
            PersHalladaCantXDependenciaXFechaList myPersHalladaCantXDependenciaXFecha = PersHalladaCantXDependenciaXFechaDB.GetList(fechaDesde.Trim(), fechaHasta.Trim(),idDepto);
            return myPersHalladaCantXDependenciaXFecha;
        }

        #endregion

    }

}
