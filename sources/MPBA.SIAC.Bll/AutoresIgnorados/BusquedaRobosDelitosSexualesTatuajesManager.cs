using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll
{

/// <summary>
/// The BusquedaRobosDelitosSexualesTatuajesManager class is responsible for managing Business Entities.BusquedaRobosDelitosSexualesTatuajes objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BusquedaRobosDelitosSexualesTatuajesManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BusquedaRobosDelitosSexualesTatuajes objects in the database.
/// </summary>
/// <returns>A list with all BusquedaRobosDelitosSexualesTatuajes from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BusquedaRobosDelitosSexualesTatuajesList GetList(){
return BusquedaRobosDelitosSexualesTatuajesDB.GetList();
}

/// <summary>
/// Gets a single BusquedaRobosDelitosSexualesTatuajes from the database without its data.
/// </summary>
/// <param name="id">The id of the BusquedaRobosDelitosSexualesTatuajes in the database.</param>
/// <returns>A BusquedaRobosDelitosSexualesTatuajes object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRobosDelitosSexualesTatuajes GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single BusquedaRobosDelitosSexualesTatuajes from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRobosDelitosSexualesTatuajes in the database.</param>
/// <param name="getBusquedaRobosDelitosSexualesTatuajesRecords">Determines whether to load all associated BusquedaRobosDelitosSexualesTatuajes records as well.</param>
/// <returns>
/// A BusquedaRobosDelitosSexualesTatuajes object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRobosDelitosSexualesTatuajes GetItem(int id, bool getBusquedaRobosDelitosSexualesTatuajesRecords){
BusquedaRobosDelitosSexualesTatuajes myBusquedaRobosDelitosSexualesTatuajes = BusquedaRobosDelitosSexualesTatuajesDB.GetItem(id);
return myBusquedaRobosDelitosSexualesTatuajes;
}

/// <summary>
/// Saves a BusquedaRobosDelitosSexualesTatuajes in the database.
/// </summary>
/// <param name="myBusquedaRobosDelitosSexualesTatuajes">The BusquedaRobosDelitosSexualesTatuajes instance to save.</param>
/// <returns>The new id if the BusquedaRobosDelitosSexualesTatuajes is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(BusquedaRobosDelitosSexualesTatuajes myBusquedaRobosDelitosSexualesTatuajes){
using (TransactionScope myTransactionScope = new TransactionScope()){
int busquedaRobosDelitosSexualesTatuajesid = BusquedaRobosDelitosSexualesTatuajesDB.Save(myBusquedaRobosDelitosSexualesTatuajes);

//  Assign the BusquedaRobosDelitosSexualesTatuajes its new (or existing id).
myBusquedaRobosDelitosSexualesTatuajes.id = busquedaRobosDelitosSexualesTatuajesid;

myTransactionScope.Complete();

return busquedaRobosDelitosSexualesTatuajesid;
}
}

/// <summary>
/// Deletes a BusquedaRobosDelitosSexualesTatuajes from the database.
/// </summary>
/// <param name="myBusquedaRobosDelitosSexualesTatuajes">The BusquedaRobosDelitosSexualesTatuajes instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BusquedaRobosDelitosSexualesTatuajes myBusquedaRobosDelitosSexualesTatuajes){
return BusquedaRobosDelitosSexualesTatuajesDB.Delete(myBusquedaRobosDelitosSexualesTatuajes.id);
}

#endregion

}

}
