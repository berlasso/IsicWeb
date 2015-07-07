using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The BusquedaRoboDelitosSexualesFormaNarizManager class is responsible for managing Business Entities.BusquedaRoboDelitosSexualesFormaNariz objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BusquedaRoboDelitosSexualesFormaNarizManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BusquedaRoboDelitosSexualesFormaNariz objects in the database.
/// </summary>
/// <returns>A list with all BusquedaRoboDelitosSexualesFormaNariz from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BusquedaRoboDelitosSexualesFormaNarizList GetList(){
return BusquedaRoboDelitosSexualesFormaNarizDB.GetList();
}

/// <summary>
/// Gets a single BusquedaRoboDelitosSexualesFormaNariz from the database without its data.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesFormaNariz in the database.</param>
/// <returns>A BusquedaRoboDelitosSexualesFormaNariz object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRoboDelitosSexualesFormaNariz GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single BusquedaRoboDelitosSexualesFormaNariz from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesFormaNariz in the database.</param>
/// <param name="getBusquedaRoboDelitosSexualesFormaNarizRecords">Determines whether to load all associated BusquedaRoboDelitosSexualesFormaNariz records as well.</param>
/// <returns>
/// A BusquedaRoboDelitosSexualesFormaNariz object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRoboDelitosSexualesFormaNariz GetItem(int id, bool getBusquedaRoboDelitosSexualesFormaNarizRecords){
BusquedaRoboDelitosSexualesFormaNariz myBusquedaRoboDelitosSexualesFormaNariz = BusquedaRoboDelitosSexualesFormaNarizDB.GetItem(id);
return myBusquedaRoboDelitosSexualesFormaNariz;
}

/// <summary>
/// Saves a BusquedaRoboDelitosSexualesFormaNariz in the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesFormaNariz">The BusquedaRoboDelitosSexualesFormaNariz instance to save.</param>
/// <returns>The new id if the BusquedaRoboDelitosSexualesFormaNariz is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(BusquedaRoboDelitosSexualesFormaNariz myBusquedaRoboDelitosSexualesFormaNariz){
using (TransactionScope myTransactionScope = new TransactionScope()){
int busquedaRoboDelitosSexualesFormaNarizid = BusquedaRoboDelitosSexualesFormaNarizDB.Save(myBusquedaRoboDelitosSexualesFormaNariz);

//  Assign the BusquedaRoboDelitosSexualesFormaNariz its new (or existing id).
myBusquedaRoboDelitosSexualesFormaNariz.id = busquedaRoboDelitosSexualesFormaNarizid;

myTransactionScope.Complete();

return busquedaRoboDelitosSexualesFormaNarizid;
}
}

/// <summary>
/// Deletes a BusquedaRoboDelitosSexualesFormaNariz from the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesFormaNariz">The BusquedaRoboDelitosSexualesFormaNariz instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BusquedaRoboDelitosSexualesFormaNariz myBusquedaRoboDelitosSexualesFormaNariz){
return BusquedaRoboDelitosSexualesFormaNarizDB.Delete(myBusquedaRoboDelitosSexualesFormaNariz.id);
}

#endregion

}

}
