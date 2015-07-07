using System;
using System.ComponentModel;
using System.Transactions;
using System.Data;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll {

/// <summary>
/// The BusquedaColorPielManager class is responsible for managing Business Object.BusquedaColorPiel objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BusquedaColorPielManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BusquedaColorPiel objects in the database.
/// </summary>
/// <returns>A list with all BusquedaColorPiel from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BusquedaColorPielList GetList(){
return BusquedaColorPielDB.GetList();
}

/// <summary>
/// Gets a single BusquedaColorPiel from the database without its data.
/// </summary>
/// <param name="id">The id of the BusquedaColorPiel in the database.</param>
/// <returns>A BusquedaColorPiel object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaColorPiel GetItem(decimal id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single BusquedaColorPiel from the database.
/// </summary>
/// <param name="id">The id of the BusquedaColorPiel in the database.</param>
/// <param name="getBusquedaColorPielRecords">Determines whether to load all associated BusquedaColorPiel records as well.</param>
/// <returns>
/// A BusquedaColorPiel object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaColorPiel GetItem(decimal id, bool getBusquedaColorPielRecords){
BusquedaColorPiel myBusquedaColorPiel = BusquedaColorPielDB.GetItem(id);
return myBusquedaColorPiel;
}

/// <summary>
/// Saves a BusquedaColorPiel in the database.
/// </summary>
/// <param name="myBusquedaColorPiel">The BusquedaColorPiel instance to save.</param>
/// <returns>The new id if the BusquedaColorPiel is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static decimal Save(BusquedaColorPiel myBusquedaColorPiel,SqlCommand myCommand){
//using (TransactionScope myTransactionScope = new TransactionScope()){
decimal busquedaColorPielid = BusquedaColorPielDB.Save(myBusquedaColorPiel,myCommand);

//  Assign the BusquedaColorPiel its new (or existing id).
myBusquedaColorPiel.id = busquedaColorPielid;

//myTransactionScope.Complete();

return busquedaColorPielid;
//}
}

/// <summary>
/// Deletes a BusquedaColorPiel from the database.
/// </summary>
/// <param name="myBusquedaColorPiel">The BusquedaColorPiel instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BusquedaColorPiel myBusquedaColorPiel){
return BusquedaColorPielDB.Delete(myBusquedaColorPiel.id);
}

/// <summary>
/// Deletes las BusquedaColorPiel de una Busqueda from the database.
/// </summary>
/// <param name="myBusquedaColorPiel">The BusquedaColorPiel instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool DeleteByIdBusqueda(decimal idBusqueda)
{
    return BusquedaColorPielDB.DeleteByIdBusqueda(idBusqueda);
}

#endregion

}

}
