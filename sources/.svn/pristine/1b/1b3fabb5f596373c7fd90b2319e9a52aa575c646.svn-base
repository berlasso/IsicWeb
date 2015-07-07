using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll {

/// <summary>
/// The PBClaseTablaDestinoManager class is responsible for managing Business Object.PBClaseTablaDestino objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class PBClaseTablaDestinoManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all PBClaseTablaDestino objects in the database.
/// </summary>
/// <returns>A list with all PBClaseTablaDestino from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static PBClaseTablaDestinoList GetList(){
return PBClaseTablaDestinoDB.GetList();
}

/// <summary>
/// Gets a single PBClaseTablaDestino from the database without its data.
/// </summary>
/// <param name="id">The Id of the PBClaseTablaDestino in the database.</param>
/// <returns>A PBClaseTablaDestino object when the Id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PBClaseTablaDestino GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single PBClaseTablaDestino from the database.
/// </summary>
/// <param name="id">The Id of the PBClaseTablaDestino in the database.</param>
/// <param name="getPBClaseTablaDestinoRecords">Determines whether to load all associated PBClaseTablaDestino records as well.</param>
/// <returns>
/// A PBClaseTablaDestino object when the Id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PBClaseTablaDestino GetItem(int id, bool getPBClaseTablaDestinoRecords){
PBClaseTablaDestino myPBClaseTablaDestino = PBClaseTablaDestinoDB.GetItem(id);
if (myPBClaseTablaDestino != null && getPBClaseTablaDestinoRecords){
myPBClaseTablaDestino.busquedas = BusquedaDB.GetListByidOrigen(id);
}
return myPBClaseTablaDestino;
}

/// <summary>
/// Saves a PBClaseTablaDestino in the database.
/// </summary>
/// <param name="myPBClaseTablaDestino">The PBClaseTablaDestino instance to save.</param>
/// <returns>The new Id if the PBClaseTablaDestino is new in the database or the existing Id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(PBClaseTablaDestino myPBClaseTablaDestino){
using (TransactionScope myTransactionScope = new TransactionScope()){
int pBClaseTablaDestinoId = PBClaseTablaDestinoDB.Save(myPBClaseTablaDestino);
foreach (Busqueda myBusqueda in myPBClaseTablaDestino.busquedas){
myBusqueda.Id = pBClaseTablaDestinoId;
BusquedaDB.Save(myBusqueda);
}

//  Assign the PBClaseTablaDestino its new (or existing Id).
myPBClaseTablaDestino.Id = pBClaseTablaDestinoId;

myTransactionScope.Complete();

return pBClaseTablaDestinoId;
}
}

/// <summary>
/// Deletes a PBClaseTablaDestino from the database.
/// </summary>
/// <param name="myPBClaseTablaDestino">The PBClaseTablaDestino instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(PBClaseTablaDestino myPBClaseTablaDestino){
return PBClaseTablaDestinoDB.Delete(myPBClaseTablaDestino.Id);
}

#endregion

}

}
