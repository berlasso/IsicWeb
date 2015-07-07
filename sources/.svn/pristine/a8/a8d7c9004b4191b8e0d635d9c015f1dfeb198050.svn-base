using System;
using System.ComponentModel;
using System.Transactions;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll
{

    [DataObjectAttribute()]
    public partial class DelitosCantXDependenciaXFechaManager
    {

        #region "Public Methods"

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static DelitosCantXDependenciaXFechaList GetList(int claseDelito, string fechaDesde, string fechaHasta, int idDepto)
        {
            DelitosCantXDependenciaXFechaList myDelitosCantXDependenciaXFecha = DelitosCantXDependenciaXFechaDB.GetList(claseDelito, fechaDesde.Trim(), fechaHasta.Trim(), idDepto);
            return myDelitosCantXDependenciaXFecha;
        }

        #endregion

    }

}
