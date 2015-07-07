using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The BusquedaRobosDelitosSexualesComisariasManager class is responsible for managing Business Object.BusquedaRobosDelitosSexualesComisarias objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BusquedaRobosDelitosSexualesComisariasManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BusquedaRobosDelitosSexualesComisarias objects in the database.
/// </summary>
/// <returns>A list with all BusquedaRobosDelitosSexualesComisarias from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BusquedaRobosDelitosSexualesComisariasList GetList(){
return BusquedaRobosDelitosSexualesComisariasDB.GetList();
}

/// <summary>
/// Gets a single BusquedaRobosDelitosSexualesComisarias from the database without its data.
/// </summary>
/// <param name="id">The id of the BusquedaRobosDelitosSexualesComisarias in the database.</param>
/// <returns>A BusquedaRobosDelitosSexualesComisarias object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRobosDelitosSexualesComisarias GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single BusquedaRobosDelitosSexualesComisarias from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRobosDelitosSexualesComisarias in the database.</param>
/// <param name="getBusquedaRobosDelitosSexualesComisariasRecords">Determines whether to load all associated BusquedaRobosDelitosSexualesComisarias records as well.</param>
/// <returns>
/// A BusquedaRobosDelitosSexualesComisarias object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRobosDelitosSexualesComisarias GetItem(int id, bool getBusquedaRobosDelitosSexualesComisariasRecords){
BusquedaRobosDelitosSexualesComisarias myBusquedaRobosDelitosSexualesComisarias = BusquedaRobosDelitosSexualesComisariasDB.GetItem(id);
return myBusquedaRobosDelitosSexualesComisarias;
}

/// <summary>
/// Saves a BusquedaRobosDelitosSexualesComisarias in the database.
/// </summary>
/// <param name="myBusquedaRobosDelitosSexualesComisarias">The BusquedaRobosDelitosSexualesComisarias instance to save.</param>
/// <returns>The new id if the BusquedaRobosDelitosSexualesComisarias is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(BusquedaRobosDelitosSexualesComisarias myBusquedaRobosDelitosSexualesComisarias){
using (TransactionScope myTransactionScope = new TransactionScope()){
int busquedaRobosDelitosSexualesComisariasid = BusquedaRobosDelitosSexualesComisariasDB.Save(myBusquedaRobosDelitosSexualesComisarias);

//  Assign the BusquedaRobosDelitosSexualesComisarias its new (or existing id).
myBusquedaRobosDelitosSexualesComisarias.id = busquedaRobosDelitosSexualesComisariasid;

myTransactionScope.Complete();

return busquedaRobosDelitosSexualesComisariasid;
}
}

/// <summary>
/// Deletes a BusquedaRobosDelitosSexualesComisarias from the database.
/// </summary>
/// <param name="myBusquedaRobosDelitosSexualesComisarias">The BusquedaRobosDelitosSexualesComisarias instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BusquedaRobosDelitosSexualesComisarias myBusquedaRobosDelitosSexualesComisarias){
return BusquedaRobosDelitosSexualesComisariasDB.Delete(myBusquedaRobosDelitosSexualesComisarias.id);
}

#endregion

}

}
