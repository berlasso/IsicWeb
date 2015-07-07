using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The BusquedaRoboDelitosSexualesTipoCabelloManager class is responsible for managing Business Entities.BusquedaRoboDelitosSexualesTipoCabello objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BusquedaRoboDelitosSexualesTipoCabelloManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BusquedaRoboDelitosSexualesTipoCabello objects in the database.
/// </summary>
/// <returns>A list with all BusquedaRoboDelitosSexualesTipoCabello from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BusquedaRoboDelitosSexualesTipoCabelloList GetList(){
return BusquedaRoboDelitosSexualesTipoCabelloDB.GetList();
}

/// <summary>
/// Gets a single BusquedaRoboDelitosSexualesTipoCabello from the database without its data.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesTipoCabello in the database.</param>
/// <returns>A BusquedaRoboDelitosSexualesTipoCabello object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRoboDelitosSexualesTipoCabello GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single BusquedaRoboDelitosSexualesTipoCabello from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesTipoCabello in the database.</param>
/// <param name="getBusquedaRoboDelitosSexualesTipoCabelloRecords">Determines whether to load all associated BusquedaRoboDelitosSexualesTipoCabello records as well.</param>
/// <returns>
/// A BusquedaRoboDelitosSexualesTipoCabello object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRoboDelitosSexualesTipoCabello GetItem(int id, bool getBusquedaRoboDelitosSexualesTipoCabelloRecords){
BusquedaRoboDelitosSexualesTipoCabello myBusquedaRoboDelitosSexualesTipoCabello = BusquedaRoboDelitosSexualesTipoCabelloDB.GetItem(id);
return myBusquedaRoboDelitosSexualesTipoCabello;
}

/// <summary>
/// Saves a BusquedaRoboDelitosSexualesTipoCabello in the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesTipoCabello">The BusquedaRoboDelitosSexualesTipoCabello instance to save.</param>
/// <returns>The new id if the BusquedaRoboDelitosSexualesTipoCabello is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(BusquedaRoboDelitosSexualesTipoCabello myBusquedaRoboDelitosSexualesTipoCabello){
using (TransactionScope myTransactionScope = new TransactionScope()){
int busquedaRoboDelitosSexualesTipoCabelloid = BusquedaRoboDelitosSexualesTipoCabelloDB.Save(myBusquedaRoboDelitosSexualesTipoCabello);

//  Assign the BusquedaRoboDelitosSexualesTipoCabello its new (or existing id).
myBusquedaRoboDelitosSexualesTipoCabello.id = busquedaRoboDelitosSexualesTipoCabelloid;

myTransactionScope.Complete();

return busquedaRoboDelitosSexualesTipoCabelloid;
}
}

/// <summary>
/// Deletes a BusquedaRoboDelitosSexualesTipoCabello from the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesTipoCabello">The BusquedaRoboDelitosSexualesTipoCabello instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BusquedaRoboDelitosSexualesTipoCabello myBusquedaRoboDelitosSexualesTipoCabello){
return BusquedaRoboDelitosSexualesTipoCabelloDB.Delete(myBusquedaRoboDelitosSexualesTipoCabello.id);
}

#endregion

}

}
