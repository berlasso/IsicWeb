using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The BusquedaRoboDelitosSexualesColorCabelloManager class is responsible for managing Business Entities.BusquedaRoboDelitosSexualesColorCabello objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BusquedaRoboDelitosSexualesColorCabelloManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BusquedaRoboDelitosSexualesColorCabello objects in the database.
/// </summary>
/// <returns>A list with all BusquedaRoboDelitosSexualesColorCabello from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BusquedaRoboDelitosSexualesColorCabelloList GetList(){
return BusquedaRoboDelitosSexualesColorCabelloDB.GetList();
}

/// <summary>
/// Gets a single BusquedaRoboDelitosSexualesColorCabello from the database without its data.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesColorCabello in the database.</param>
/// <returns>A BusquedaRoboDelitosSexualesColorCabello object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRoboDelitosSexualesColorCabello GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single BusquedaRoboDelitosSexualesColorCabello from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesColorCabello in the database.</param>
/// <param name="getBusquedaRoboDelitosSexualesColorCabelloRecords">Determines whether to load all associated BusquedaRoboDelitosSexualesColorCabello records as well.</param>
/// <returns>
/// A BusquedaRoboDelitosSexualesColorCabello object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRoboDelitosSexualesColorCabello GetItem(int id, bool getBusquedaRoboDelitosSexualesColorCabelloRecords){
BusquedaRoboDelitosSexualesColorCabello myBusquedaRoboDelitosSexualesColorCabello = BusquedaRoboDelitosSexualesColorCabelloDB.GetItem(id);
return myBusquedaRoboDelitosSexualesColorCabello;
}

/// <summary>
/// Saves a BusquedaRoboDelitosSexualesColorCabello in the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesColorCabello">The BusquedaRoboDelitosSexualesColorCabello instance to save.</param>
/// <returns>The new id if the BusquedaRoboDelitosSexualesColorCabello is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(BusquedaRoboDelitosSexualesColorCabello myBusquedaRoboDelitosSexualesColorCabello){
using (TransactionScope myTransactionScope = new TransactionScope()){
int busquedaRoboDelitosSexualesColorCabelloid = BusquedaRoboDelitosSexualesColorCabelloDB.Save(myBusquedaRoboDelitosSexualesColorCabello);

//  Assign the BusquedaRoboDelitosSexualesColorCabello its new (or existing id).
myBusquedaRoboDelitosSexualesColorCabello.id = busquedaRoboDelitosSexualesColorCabelloid;

myTransactionScope.Complete();

return busquedaRoboDelitosSexualesColorCabelloid;
}
}

/// <summary>
/// Deletes a BusquedaRoboDelitosSexualesColorCabello from the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesColorCabello">The BusquedaRoboDelitosSexualesColorCabello instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BusquedaRoboDelitosSexualesColorCabello myBusquedaRoboDelitosSexualesColorCabello){
return BusquedaRoboDelitosSexualesColorCabelloDB.Delete(myBusquedaRoboDelitosSexualesColorCabello.id);
}

#endregion

}

}
