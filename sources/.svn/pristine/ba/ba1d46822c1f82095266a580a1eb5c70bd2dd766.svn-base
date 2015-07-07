using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The BusquedaRoboDelitosSexualesTipoCalvicieManager class is responsible for managing Business Entities.BusquedaRoboDelitosSexualesTipoCalvicie objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BusquedaRoboDelitosSexualesTipoCalvicieManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BusquedaRoboDelitosSexualesTipoCalvicie objects in the database.
/// </summary>
/// <returns>A list with all BusquedaRoboDelitosSexualesTipoCalvicie from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BusquedaRoboDelitosSexualesTipoCalvicieList GetList(){
return BusquedaRoboDelitosSexualesTipoCalvicieDB.GetList();
}

/// <summary>
/// Gets a single BusquedaRoboDelitosSexualesTipoCalvicie from the database without its data.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesTipoCalvicie in the database.</param>
/// <returns>A BusquedaRoboDelitosSexualesTipoCalvicie object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRoboDelitosSexualesTipoCalvicie GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single BusquedaRoboDelitosSexualesTipoCalvicie from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesTipoCalvicie in the database.</param>
/// <param name="getBusquedaRoboDelitosSexualesTipoCalvicieRecords">Determines whether to load all associated BusquedaRoboDelitosSexualesTipoCalvicie records as well.</param>
/// <returns>
/// A BusquedaRoboDelitosSexualesTipoCalvicie object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRoboDelitosSexualesTipoCalvicie GetItem(int id, bool getBusquedaRoboDelitosSexualesTipoCalvicieRecords){
BusquedaRoboDelitosSexualesTipoCalvicie myBusquedaRoboDelitosSexualesTipoCalvicie = BusquedaRoboDelitosSexualesTipoCalvicieDB.GetItem(id);
return myBusquedaRoboDelitosSexualesTipoCalvicie;
}

/// <summary>
/// Saves a BusquedaRoboDelitosSexualesTipoCalvicie in the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesTipoCalvicie">The BusquedaRoboDelitosSexualesTipoCalvicie instance to save.</param>
/// <returns>The new id if the BusquedaRoboDelitosSexualesTipoCalvicie is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(BusquedaRoboDelitosSexualesTipoCalvicie myBusquedaRoboDelitosSexualesTipoCalvicie){
using (TransactionScope myTransactionScope = new TransactionScope()){
int busquedaRoboDelitosSexualesTipoCalvicieid = BusquedaRoboDelitosSexualesTipoCalvicieDB.Save(myBusquedaRoboDelitosSexualesTipoCalvicie);

//  Assign the BusquedaRoboDelitosSexualesTipoCalvicie its new (or existing id).
myBusquedaRoboDelitosSexualesTipoCalvicie.id = busquedaRoboDelitosSexualesTipoCalvicieid;

myTransactionScope.Complete();

return busquedaRoboDelitosSexualesTipoCalvicieid;
}
}

/// <summary>
/// Deletes a BusquedaRoboDelitosSexualesTipoCalvicie from the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesTipoCalvicie">The BusquedaRoboDelitosSexualesTipoCalvicie instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BusquedaRoboDelitosSexualesTipoCalvicie myBusquedaRoboDelitosSexualesTipoCalvicie){
return BusquedaRoboDelitosSexualesTipoCalvicieDB.Delete(myBusquedaRoboDelitosSexualesTipoCalvicie.id);
}

#endregion

}

}
