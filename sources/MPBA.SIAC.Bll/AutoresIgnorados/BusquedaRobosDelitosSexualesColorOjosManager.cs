using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The BusquedaRobosDelitosSexualesColorOjosManager class is responsible for managing Business Entities.BusquedaRobosDelitosSexualesColorOjos objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BusquedaRobosDelitosSexualesColorOjosManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BusquedaRobosDelitosSexualesColorOjos objects in the database.
/// </summary>
/// <returns>A list with all BusquedaRobosDelitosSexualesColorOjos from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BusquedaRobosDelitosSexualesColorOjosList GetList(){
return BusquedaRobosDelitosSexualesColorOjosDB.GetList();
}

/// <summary>
/// Gets a single BusquedaRobosDelitosSexualesColorOjos from the database without its data.
/// </summary>
/// <param name="id">The id of the BusquedaRobosDelitosSexualesColorOjos in the database.</param>
/// <returns>A BusquedaRobosDelitosSexualesColorOjos object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRobosDelitosSexualesColorOjos GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single BusquedaRobosDelitosSexualesColorOjos from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRobosDelitosSexualesColorOjos in the database.</param>
/// <param name="getBusquedaRobosDelitosSexualesColorOjosRecords">Determines whether to load all associated BusquedaRobosDelitosSexualesColorOjos records as well.</param>
/// <returns>
/// A BusquedaRobosDelitosSexualesColorOjos object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRobosDelitosSexualesColorOjos GetItem(int id, bool getBusquedaRobosDelitosSexualesColorOjosRecords){
BusquedaRobosDelitosSexualesColorOjos myBusquedaRobosDelitosSexualesColorOjos = BusquedaRobosDelitosSexualesColorOjosDB.GetItem(id);
return myBusquedaRobosDelitosSexualesColorOjos;
}

/// <summary>
/// Saves a BusquedaRobosDelitosSexualesColorOjos in the database.
/// </summary>
/// <param name="myBusquedaRobosDelitosSexualesColorOjos">The BusquedaRobosDelitosSexualesColorOjos instance to save.</param>
/// <returns>The new id if the BusquedaRobosDelitosSexualesColorOjos is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(BusquedaRobosDelitosSexualesColorOjos myBusquedaRobosDelitosSexualesColorOjos){
using (TransactionScope myTransactionScope = new TransactionScope()){
int busquedaRobosDelitosSexualesColorOjosid = BusquedaRobosDelitosSexualesColorOjosDB.Save(myBusquedaRobosDelitosSexualesColorOjos);

//  Assign the BusquedaRobosDelitosSexualesColorOjos its new (or existing id).
myBusquedaRobosDelitosSexualesColorOjos.id = busquedaRobosDelitosSexualesColorOjosid;

myTransactionScope.Complete();

return busquedaRobosDelitosSexualesColorOjosid;
}
}

/// <summary>
/// Deletes a BusquedaRobosDelitosSexualesColorOjos from the database.
/// </summary>
/// <param name="myBusquedaRobosDelitosSexualesColorOjos">The BusquedaRobosDelitosSexualesColorOjos instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BusquedaRobosDelitosSexualesColorOjos myBusquedaRobosDelitosSexualesColorOjos){
return BusquedaRobosDelitosSexualesColorOjosDB.Delete(myBusquedaRobosDelitosSexualesColorOjos.id);
}

#endregion

}

}
