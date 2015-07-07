using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll {

/// <summary>
/// The PBParametrosGeneralesManager class is responsible for managing Business Object.PBParametrosGenerales objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class PBParametrosGeneralesManager
  {

#region "Public Methods"

/// <summary>
      /// Gets a list with all PBParametrosGenerales objects in the database.
/// </summary>
      /// <returns>A list with all PBParametrosGenerales from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
    public static PBParametrosGeneralesList GetList()
    {
        return PBParametrosGeneralesDB.GetList();
}


#endregion

}

}
