using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll {

/// <summary>
/// The PBCausaExtranaJurisdiccionManager class is responsible for managing Business Object.PBCausaExtranaJurisdiccion objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class PBCausaExtranaJurisdiccionManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all PBCausaExtranaJurisdiccion objects in the database.
/// </summary>
/// <returns>A list with all PBCausaExtranaJurisdiccion from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static PBCausaExtranaJurisdiccionList GetList(){
return PBCausaExtranaJurisdiccionDB.GetList();
}

/// <summary>
/// Gets a single PBCausaExtranaJurisdiccion from the database without its data.
/// </summary>
/// <param name="id">The id of the PBCausaExtranaJurisdiccion in the database.</param>
/// <returns>A PBCausaExtranaJurisdiccion object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PBCausaExtranaJurisdiccion GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single PBCausaExtranaJurisdiccion from the database.
/// </summary>
/// <param name="id">The id of the PBCausaExtranaJurisdiccion in the database.</param>
/// <param name="getPBCausaExtranaJurisdiccionRecords">Determines whether to load all associated PBCausaExtranaJurisdiccion records as well.</param>
/// <returns>
/// A PBCausaExtranaJurisdiccion object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PBCausaExtranaJurisdiccion GetItem(int id, bool getPBCausaExtranaJurisdiccionRecords){
PBCausaExtranaJurisdiccion myPBCausaExtranaJurisdiccion = PBCausaExtranaJurisdiccionDB.GetItem(id);
return myPBCausaExtranaJurisdiccion;
}

/// <summary>
/// Gets a single PBCausaExtranaJurisdiccion from the database.
/// </summary>
/// <param name="id">The id of the PBCausaExtranaJurisdiccion in the database.</param>
/// <param name="getPBCausaExtranaJurisdiccionRecords">Determines whether to load all associated PBCausaExtranaJurisdiccion records as well.</param>
/// <returns>
/// A PBCausaExtranaJurisdiccion object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PBCausaExtranaJurisdiccion GetItem(string nroCausa, int idTipoBusqueda)
{
    PBCausaExtranaJurisdiccion myPBCausaExtranaJurisdiccion = PBCausaExtranaJurisdiccionDB.GetItem(nroCausa,idTipoBusqueda);
    return myPBCausaExtranaJurisdiccion;
}

/// <summary>
/// Saves a PBCausaExtranaJurisdiccion in the database.
/// </summary>
/// <param name="myPBCausaExtranaJurisdiccion">The PBCausaExtranaJurisdiccion instance to save.</param>
/// <returns>The new id if the PBCausaExtranaJurisdiccion is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(PBCausaExtranaJurisdiccion myPBCausaExtranaJurisdiccion){
using (TransactionScope myTransactionScope = new TransactionScope()){
int pBCausaExtranaJurisdiccionid = PBCausaExtranaJurisdiccionDB.Save(myPBCausaExtranaJurisdiccion);

//  Assign the PBCausaExtranaJurisdiccion its new (or existing id).
myPBCausaExtranaJurisdiccion.id = pBCausaExtranaJurisdiccionid;

myTransactionScope.Complete();

return pBCausaExtranaJurisdiccionid;
}
}

/// <summary>
/// Deletes a PBCausaExtranaJurisdiccion from the database.
/// </summary>
/// <param name="myPBCausaExtranaJurisdiccion">The PBCausaExtranaJurisdiccion instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(PBCausaExtranaJurisdiccion myPBCausaExtranaJurisdiccion){
return PBCausaExtranaJurisdiccionDB.Delete(myPBCausaExtranaJurisdiccion.id);
}

#endregion

}

}
