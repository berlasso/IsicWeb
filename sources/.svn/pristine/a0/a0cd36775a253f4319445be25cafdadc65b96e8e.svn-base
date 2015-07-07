using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The BusquedaRoboDelitosSexualesFormaLabioSupManager class is responsible for managing Business Entities.BusquedaRoboDelitosSexualesFormaLabioSup objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BusquedaRoboDelitosSexualesFormaLabioSupManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BusquedaRoboDelitosSexualesFormaLabioSup objects in the database.
/// </summary>
/// <returns>A list with all BusquedaRoboDelitosSexualesFormaLabioSup from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BusquedaRoboDelitosSexualesFormaLabioSupList GetList(){
return BusquedaRoboDelitosSexualesFormaLabioSupDB.GetList();
}

/// <summary>
/// Gets a single BusquedaRoboDelitosSexualesFormaLabioSup from the database without its data.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesFormaLabioSup in the database.</param>
/// <returns>A BusquedaRoboDelitosSexualesFormaLabioSup object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRoboDelitosSexualesFormaLabioSup GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single BusquedaRoboDelitosSexualesFormaLabioSup from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesFormaLabioSup in the database.</param>
/// <param name="getBusquedaRoboDelitosSexualesFormaLabioSupRecords">Determines whether to load all associated BusquedaRoboDelitosSexualesFormaLabioSup records as well.</param>
/// <returns>
/// A BusquedaRoboDelitosSexualesFormaLabioSup object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRoboDelitosSexualesFormaLabioSup GetItem(int id, bool getBusquedaRoboDelitosSexualesFormaLabioSupRecords){
BusquedaRoboDelitosSexualesFormaLabioSup myBusquedaRoboDelitosSexualesFormaLabioSup = BusquedaRoboDelitosSexualesFormaLabioSupDB.GetItem(id);
return myBusquedaRoboDelitosSexualesFormaLabioSup;
}

/// <summary>
/// Saves a BusquedaRoboDelitosSexualesFormaLabioSup in the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesFormaLabioSup">The BusquedaRoboDelitosSexualesFormaLabioSup instance to save.</param>
/// <returns>The new id if the BusquedaRoboDelitosSexualesFormaLabioSup is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(BusquedaRoboDelitosSexualesFormaLabioSup myBusquedaRoboDelitosSexualesFormaLabioSup){
using (TransactionScope myTransactionScope = new TransactionScope()){
int busquedaRoboDelitosSexualesFormaLabioSupid = BusquedaRoboDelitosSexualesFormaLabioSupDB.Save(myBusquedaRoboDelitosSexualesFormaLabioSup);

//  Assign the BusquedaRoboDelitosSexualesFormaLabioSup its new (or existing id).
myBusquedaRoboDelitosSexualesFormaLabioSup.id = busquedaRoboDelitosSexualesFormaLabioSupid;

myTransactionScope.Complete();

return busquedaRoboDelitosSexualesFormaLabioSupid;
}
}

/// <summary>
/// Deletes a BusquedaRoboDelitosSexualesFormaLabioSup from the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesFormaLabioSup">The BusquedaRoboDelitosSexualesFormaLabioSup instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BusquedaRoboDelitosSexualesFormaLabioSup myBusquedaRoboDelitosSexualesFormaLabioSup){
return BusquedaRoboDelitosSexualesFormaLabioSupDB.Delete(myBusquedaRoboDelitosSexualesFormaLabioSup.id);
}

#endregion

}

}
