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
    public partial class DelitosCantXDeptoXFechaManager
    {

        #region "Public Methods"

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static DelitosCantXDeptoXFechaList GetList(int claseDelito, string fechaDesde, string fechaHasta)
        {
            DelitosCantXDeptoXFechaList myDelitosCantXDeptoXFecha = DelitosCantXDeptoXFechaDB.GetList(claseDelito, fechaDesde.Trim(), fechaHasta.Trim());
            return myDelitosCantXDeptoXFecha;
        }

        #endregion

    }

}
