using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The BusquedaRoboDelitosSexualesFormaBocaManager class is responsible for managing Business Entities.BusquedaRoboDelitosSexualesFormaBoca objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BusquedaRoboDelitosSexualesFormaBocaManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BusquedaRoboDelitosSexualesFormaBoca objects in the database.
/// </summary>
/// <returns>A list with all BusquedaRoboDelitosSexualesFormaBoca from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BusquedaRoboDelitosSexualesFormaBocaList GetList(){
return BusquedaRoboDelitosSexualesFormaBocaDB.GetList();
}

/// <summary>
/// Gets a single BusquedaRoboDelitosSexualesFormaBoca from the database without its data.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesFormaBoca in the database.</param>
/// <returns>A BusquedaRoboDelitosSexualesFormaBoca object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRoboDelitosSexualesFormaBoca GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single BusquedaRoboDelitosSexualesFormaBoca from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesFormaBoca in the database.</param>
/// <param name="getBusquedaRoboDelitosSexualesFormaBocaRecords">Determines whether to load all associated BusquedaRoboDelitosSexualesFormaBoca records as well.</param>
/// <returns>
/// A BusquedaRoboDelitosSexualesFormaBoca object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRoboDelitosSexualesFormaBoca GetItem(int id, bool getBusquedaRoboDelitosSexualesFormaBocaRecords){
BusquedaRoboDelitosSexualesFormaBoca myBusquedaRoboDelitosSexualesFormaBoca = BusquedaRoboDelitosSexualesFormaBocaDB.GetItem(id);
return myBusquedaRoboDelitosSexualesFormaBoca;
}

/// <summary>
/// Saves a BusquedaRoboDelitosSexualesFormaBoca in the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesFormaBoca">The BusquedaRoboDelitosSexualesFormaBoca instance to save.</param>
/// <returns>The new id if the BusquedaRoboDelitosSexualesFormaBoca is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(BusquedaRoboDelitosSexualesFormaBoca myBusquedaRoboDelitosSexualesFormaBoca){
using (TransactionScope myTransactionScope = new TransactionScope()){
int busquedaRoboDelitosSexualesFormaBocaid = BusquedaRoboDelitosSexualesFormaBocaDB.Save(myBusquedaRoboDelitosSexualesFormaBoca);

//  Assign the BusquedaRoboDelitosSexualesFormaBoca its new (or existing id).
myBusquedaRoboDelitosSexualesFormaBoca.id = busquedaRoboDelitosSexualesFormaBocaid;

myTransactionScope.Complete();

return busquedaRoboDelitosSexualesFormaBocaid;
}
}

/// <summary>
/// Deletes a BusquedaRoboDelitosSexualesFormaBoca from the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesFormaBoca">The BusquedaRoboDelitosSexualesFormaBoca instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BusquedaRoboDelitosSexualesFormaBoca myBusquedaRoboDelitosSexualesFormaBoca){
return BusquedaRoboDelitosSexualesFormaBocaDB.Delete(myBusquedaRoboDelitosSexualesFormaBoca.id);
}

#endregion

}

}
