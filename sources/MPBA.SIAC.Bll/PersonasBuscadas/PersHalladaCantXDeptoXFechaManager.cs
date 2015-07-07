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
    public partial class PersHalladaCantXDeptoXFechaManager
    {

        #region "Public Methods"

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static PersHalladaCantXDeptoXFechaList GetList(string fechaDesde, string fechaHasta)
        {
            PersHalladaCantXDeptoXFechaList myPersHalladaCantXDeptoXFecha = PersHalladaCantXDeptoXFechaDB.GetList(fechaDesde.Trim(), fechaHasta.Trim());
            return myPersHalladaCantXDeptoXFecha;
        }

        #endregion

    }

}
