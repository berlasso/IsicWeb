using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The BusquedaRoboDelitosSexualesFormaMentonManager class is responsible for managing Business Entities.BusquedaRoboDelitosSexualesFormaMenton objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BusquedaRoboDelitosSexualesFormaMentonManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BusquedaRoboDelitosSexualesFormaMenton objects in the database.
/// </summary>
/// <returns>A list with all BusquedaRoboDelitosSexualesFormaMenton from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BusquedaRoboDelitosSexualesFormaMentonList GetList(){
return BusquedaRoboDelitosSexualesFormaMentonDB.GetList();
}

/// <summary>
/// Gets a single BusquedaRoboDelitosSexualesFormaMenton from the database without its data.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesFormaMenton in the database.</param>
/// <returns>A BusquedaRoboDelitosSexualesFormaMenton object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRoboDelitosSexualesFormaMenton GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single BusquedaRoboDelitosSexualesFormaMenton from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesFormaMenton in the database.</param>
/// <param name="getBusquedaRoboDelitosSexualesFormaMentonRecords">Determines whether to load all associated BusquedaRoboDelitosSexualesFormaMenton records as well.</param>
/// <returns>
/// A BusquedaRoboDelitosSexualesFormaMenton object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRoboDelitosSexualesFormaMenton GetItem(int id, bool getBusquedaRoboDelitosSexualesFormaMentonRecords){
BusquedaRoboDelitosSexualesFormaMenton myBusquedaRoboDelitosSexualesFormaMenton = BusquedaRoboDelitosSexualesFormaMentonDB.GetItem(id);
return myBusquedaRoboDelitosSexualesFormaMenton;
}

/// <summary>
/// Saves a BusquedaRoboDelitosSexualesFormaMenton in the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesFormaMenton">The BusquedaRoboDelitosSexualesFormaMenton instance to save.</param>
/// <returns>The new id if the BusquedaRoboDelitosSexualesFormaMenton is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(BusquedaRoboDelitosSexualesFormaMenton myBusquedaRoboDelitosSexualesFormaMenton){
using (TransactionScope myTransactionScope = new TransactionScope()){
int busquedaRoboDelitosSexualesFormaMentonid = BusquedaRoboDelitosSexualesFormaMentonDB.Save(myBusquedaRoboDelitosSexualesFormaMenton);

//  Assign the BusquedaRoboDelitosSexualesFormaMenton its new (or existing id).
myBusquedaRoboDelitosSexualesFormaMenton.id = busquedaRoboDelitosSexualesFormaMentonid;

myTransactionScope.Complete();

return busquedaRoboDelitosSexualesFormaMentonid;
}
}

/// <summary>
/// Deletes a BusquedaRoboDelitosSexualesFormaMenton from the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesFormaMenton">The BusquedaRoboDelitosSexualesFormaMenton instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BusquedaRoboDelitosSexualesFormaMenton myBusquedaRoboDelitosSexualesFormaMenton){
return BusquedaRoboDelitosSexualesFormaMentonDB.Delete(myBusquedaRoboDelitosSexualesFormaMenton.id);
}

#endregion

}

}
