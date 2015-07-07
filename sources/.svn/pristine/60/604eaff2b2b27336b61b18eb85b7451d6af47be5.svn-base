using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The BusquedaRoboDelitosSexualesRobustezManager class is responsible for managing Business Entities.BusquedaRoboDelitosSexualesRobustez objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BusquedaRoboDelitosSexualesRobustezManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BusquedaRoboDelitosSexualesRobustez objects in the database.
/// </summary>
/// <returns>A list with all BusquedaRoboDelitosSexualesRobustez from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BusquedaRoboDelitosSexualesRobustezList GetList(){
return BusquedaRoboDelitosSexualesRobustezDB.GetList();
}

/// <summary>
/// Gets a single BusquedaRoboDelitosSexualesRobustez from the database without its data.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesRobustez in the database.</param>
/// <returns>A BusquedaRoboDelitosSexualesRobustez object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRoboDelitosSexualesRobustez GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single BusquedaRoboDelitosSexualesRobustez from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesRobustez in the database.</param>
/// <param name="getBusquedaRoboDelitosSexualesRobustezRecords">Determines whether to load all associated BusquedaRoboDelitosSexualesRobustez records as well.</param>
/// <returns>
/// A BusquedaRoboDelitosSexualesRobustez object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRoboDelitosSexualesRobustez GetItem(int id, bool getBusquedaRoboDelitosSexualesRobustezRecords){
BusquedaRoboDelitosSexualesRobustez myBusquedaRoboDelitosSexualesRobustez = BusquedaRoboDelitosSexualesRobustezDB.GetItem(id);
return myBusquedaRoboDelitosSexualesRobustez;
}

/// <summary>
/// Saves a BusquedaRoboDelitosSexualesRobustez in the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesRobustez">The BusquedaRoboDelitosSexualesRobustez instance to save.</param>
/// <returns>The new id if the BusquedaRoboDelitosSexualesRobustez is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(BusquedaRoboDelitosSexualesRobustez myBusquedaRoboDelitosSexualesRobustez){
using (TransactionScope myTransactionScope = new TransactionScope()){
int busquedaRoboDelitosSexualesRobustezid = BusquedaRoboDelitosSexualesRobustezDB.Save(myBusquedaRoboDelitosSexualesRobustez);

//  Assign the BusquedaRoboDelitosSexualesRobustez its new (or existing id).
myBusquedaRoboDelitosSexualesRobustez.id = busquedaRoboDelitosSexualesRobustezid;

myTransactionScope.Complete();

return busquedaRoboDelitosSexualesRobustezid;
}
}

/// <summary>
/// Deletes a BusquedaRoboDelitosSexualesRobustez from the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesRobustez">The BusquedaRoboDelitosSexualesRobustez instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BusquedaRoboDelitosSexualesRobustez myBusquedaRoboDelitosSexualesRobustez){
return BusquedaRoboDelitosSexualesRobustezDB.Delete(myBusquedaRoboDelitosSexualesRobustez.id);
}

#endregion

}

}
