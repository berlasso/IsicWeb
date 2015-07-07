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
    public partial class PersDesapCantXDependenciaXFechaManager
    {

        #region "Public Methods"

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static PersDesapCantXDependenciaXFechaList GetList(string fechaDesde, string fechaHasta, int idDepto)
        {
            PersDesapCantXDependenciaXFechaList myPersDesapCantXDependenciaXFecha = PersDesapCantXDependenciaXFechaDB.GetList(fechaDesde.Trim(), fechaHasta.Trim(), idDepto);
            return myPersDesapCantXDependenciaXFecha;
        }

        #endregion

    }

}
