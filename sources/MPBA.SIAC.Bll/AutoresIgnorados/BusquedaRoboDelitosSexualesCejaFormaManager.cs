using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The BusquedaRoboDelitosSexualesCejaFormaManager class is responsible for managing Business Entities.BusquedaRoboDelitosSexualesCejaForma objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BusquedaRoboDelitosSexualesCejaFormaManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BusquedaRoboDelitosSexualesCejaForma objects in the database.
/// </summary>
/// <returns>A list with all BusquedaRoboDelitosSexualesCejaForma from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BusquedaRoboDelitosSexualesCejaFormaList GetList(){
return BusquedaRoboDelitosSexualesCejaFormaDB.GetList();
}

/// <summary>
/// Gets a single BusquedaRoboDelitosSexualesCejaForma from the database without its data.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesCejaForma in the database.</param>
/// <returns>A BusquedaRoboDelitosSexualesCejaForma object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRoboDelitosSexualesCejaForma GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single BusquedaRoboDelitosSexualesCejaForma from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesCejaForma in the database.</param>
/// <param name="getBusquedaRoboDelitosSexualesCejaFormaRecords">Determines whether to load all associated BusquedaRoboDelitosSexualesCejaForma records as well.</param>
/// <returns>
/// A BusquedaRoboDelitosSexualesCejaForma object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRoboDelitosSexualesCejaForma GetItem(int id, bool getBusquedaRoboDelitosSexualesCejaFormaRecords){
BusquedaRoboDelitosSexualesCejaForma myBusquedaRoboDelitosSexualesCejaForma = BusquedaRoboDelitosSexualesCejaFormaDB.GetItem(id);
return myBusquedaRoboDelitosSexualesCejaForma;
}

/// <summary>
/// Saves a BusquedaRoboDelitosSexualesCejaForma in the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesCejaForma">The BusquedaRoboDelitosSexualesCejaForma instance to save.</param>
/// <returns>The new id if the BusquedaRoboDelitosSexualesCejaForma is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(BusquedaRoboDelitosSexualesCejaForma myBusquedaRoboDelitosSexualesCejaForma){
using (TransactionScope myTransactionScope = new TransactionScope()){
int busquedaRoboDelitosSexualesCejaFormaid = BusquedaRoboDelitosSexualesCejaFormaDB.Save(myBusquedaRoboDelitosSexualesCejaForma);

//  Assign the BusquedaRoboDelitosSexualesCejaForma its new (or existing id).
myBusquedaRoboDelitosSexualesCejaForma.id = busquedaRoboDelitosSexualesCejaFormaid;

myTransactionScope.Complete();

return busquedaRoboDelitosSexualesCejaFormaid;
}
}

/// <summary>
/// Deletes a BusquedaRoboDelitosSexualesCejaForma from the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesCejaForma">The BusquedaRoboDelitosSexualesCejaForma instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BusquedaRoboDelitosSexualesCejaForma myBusquedaRoboDelitosSexualesCejaForma){
return BusquedaRoboDelitosSexualesCejaFormaDB.Delete(myBusquedaRoboDelitosSexualesCejaForma.id);
}

#endregion

}

}
