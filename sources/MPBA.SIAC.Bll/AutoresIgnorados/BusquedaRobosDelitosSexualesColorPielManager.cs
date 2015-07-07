using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The BusquedaRobosDelitosSexualesColorPielManager class is responsible for managing Business Entities.BusquedaRobosDelitosSexualesColorPiel objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BusquedaRobosDelitosSexualesColorPielManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BusquedaRobosDelitosSexualesColorPiel objects in the database.
/// </summary>
/// <returns>A list with all BusquedaRobosDelitosSexualesColorPiel from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BusquedaRobosDelitosSexualesColorPielList GetList(){
return BusquedaRobosDelitosSexualesColorPielDB.GetList();
}

/// <summary>
/// Gets a single BusquedaRobosDelitosSexualesColorPiel from the database without its data.
/// </summary>
/// <param name="id">The id of the BusquedaRobosDelitosSexualesColorPiel in the database.</param>
/// <returns>A BusquedaRobosDelitosSexualesColorPiel object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRobosDelitosSexualesColorPiel GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single BusquedaRobosDelitosSexualesColorPiel from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRobosDelitosSexualesColorPiel in the database.</param>
/// <param name="getBusquedaRobosDelitosSexualesColorPielRecords">Determines whether to load all associated BusquedaRobosDelitosSexualesColorPiel records as well.</param>
/// <returns>
/// A BusquedaRobosDelitosSexualesColorPiel object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRobosDelitosSexualesColorPiel GetItem(int id, bool getBusquedaRobosDelitosSexualesColorPielRecords){
BusquedaRobosDelitosSexualesColorPiel myBusquedaRobosDelitosSexualesColorPiel = BusquedaRobosDelitosSexualesColorPielDB.GetItem(id);
return myBusquedaRobosDelitosSexualesColorPiel;
}

/// <summary>
/// Saves a BusquedaRobosDelitosSexualesColorPiel in the database.
/// </summary>
/// <param name="myBusquedaRobosDelitosSexualesColorPiel">The BusquedaRobosDelitosSexualesColorPiel instance to save.</param>
/// <returns>The new id if the BusquedaRobosDelitosSexualesColorPiel is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(BusquedaRobosDelitosSexualesColorPiel myBusquedaRobosDelitosSexualesColorPiel){
using (TransactionScope myTransactionScope = new TransactionScope()){
int busquedaRobosDelitosSexualesColorPielid = BusquedaRobosDelitosSexualesColorPielDB.Save(myBusquedaRobosDelitosSexualesColorPiel);

//  Assign the BusquedaRobosDelitosSexualesColorPiel its new (or existing id).
myBusquedaRobosDelitosSexualesColorPiel.id = busquedaRobosDelitosSexualesColorPielid;

myTransactionScope.Complete();

return busquedaRobosDelitosSexualesColorPielid;
}
}

/// <summary>
/// Deletes a BusquedaRobosDelitosSexualesColorPiel from the database.
/// </summary>
/// <param name="myBusquedaRobosDelitosSexualesColorPiel">The BusquedaRobosDelitosSexualesColorPiel instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BusquedaRobosDelitosSexualesColorPiel myBusquedaRobosDelitosSexualesColorPiel){
return BusquedaRobosDelitosSexualesColorPielDB.Delete(myBusquedaRobosDelitosSexualesColorPiel.id);
}

#endregion

}

}
