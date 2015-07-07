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
    public partial class PersDesapCantXDeptoXFechaManager
    {

        #region "Public Methods"

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static PersDesapCantXDeptoXFechaList GetList(string fechaDesde, string fechaHasta)
        {
            PersDesapCantXDeptoXFechaList myPersDesapCantXDeptoXFecha = PersDesapCantXDeptoXFechaDB.GetList(fechaDesde.Trim(), fechaHasta.Trim());
            return myPersDesapCantXDeptoXFecha;
        }

        #endregion

    }

}
