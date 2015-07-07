using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The BusquedaRobosDelitosSexualesEstaturaManager class is responsible for managing Business Entities.BusquedaRobosDelitosSexualesEstatura objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BusquedaRobosDelitosSexualesEstaturaManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BusquedaRobosDelitosSexualesEstatura objects in the database.
/// </summary>
/// <returns>A list with all BusquedaRobosDelitosSexualesEstatura from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BusquedaRobosDelitosSexualesEstaturaList GetList(){
return BusquedaRobosDelitosSexualesEstaturaDB.GetList();
}

/// <summary>
/// Gets a single BusquedaRobosDelitosSexualesEstatura from the database without its data.
/// </summary>
/// <param name="id">The id of the BusquedaRobosDelitosSexualesEstatura in the database.</param>
/// <returns>A BusquedaRobosDelitosSexualesEstatura object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRobosDelitosSexualesEstatura GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single BusquedaRobosDelitosSexualesEstatura from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRobosDelitosSexualesEstatura in the database.</param>
/// <param name="getBusquedaRobosDelitosSexualesEstaturaRecords">Determines whether to load all associated BusquedaRobosDelitosSexualesEstatura records as well.</param>
/// <returns>
/// A BusquedaRobosDelitosSexualesEstatura object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRobosDelitosSexualesEstatura GetItem(int id, bool getBusquedaRobosDelitosSexualesEstaturaRecords){
BusquedaRobosDelitosSexualesEstatura myBusquedaRobosDelitosSexualesEstatura = BusquedaRobosDelitosSexualesEstaturaDB.GetItem(id);
return myBusquedaRobosDelitosSexualesEstatura;
}

/// <summary>
/// Saves a BusquedaRobosDelitosSexualesEstatura in the database.
/// </summary>
/// <param name="myBusquedaRobosDelitosSexualesEstatura">The BusquedaRobosDelitosSexualesEstatura instance to save.</param>
/// <returns>The new id if the BusquedaRobosDelitosSexualesEstatura is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(BusquedaRobosDelitosSexualesEstatura myBusquedaRobosDelitosSexualesEstatura){
using (TransactionScope myTransactionScope = new TransactionScope()){
int busquedaRobosDelitosSexualesEstaturaid = BusquedaRobosDelitosSexualesEstaturaDB.Save(myBusquedaRobosDelitosSexualesEstatura);

//  Assign the BusquedaRobosDelitosSexualesEstatura its new (or existing id).
myBusquedaRobosDelitosSexualesEstatura.id = busquedaRobosDelitosSexualesEstaturaid;

myTransactionScope.Complete();

return busquedaRobosDelitosSexualesEstaturaid;
}
}

/// <summary>
/// Deletes a BusquedaRobosDelitosSexualesEstatura from the database.
/// </summary>
/// <param name="myBusquedaRobosDelitosSexualesEstatura">The BusquedaRobosDelitosSexualesEstatura instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BusquedaRobosDelitosSexualesEstatura myBusquedaRobosDelitosSexualesEstatura){
return BusquedaRobosDelitosSexualesEstaturaDB.Delete(myBusquedaRobosDelitosSexualesEstatura.id);
}

#endregion

}

}
