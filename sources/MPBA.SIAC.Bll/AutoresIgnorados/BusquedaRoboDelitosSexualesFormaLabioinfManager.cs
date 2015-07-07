using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The BusquedaRoboDelitosSexualesFormaLabioinfManager class is responsible for managing Business Entities.BusquedaRoboDelitosSexualesFormaLabioinf objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BusquedaRoboDelitosSexualesFormaLabioinfManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BusquedaRoboDelitosSexualesFormaLabioinf objects in the database.
/// </summary>
/// <returns>A list with all BusquedaRoboDelitosSexualesFormaLabioinf from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BusquedaRoboDelitosSexualesFormaLabioinfList GetList(){
return BusquedaRoboDelitosSexualesFormaLabioinfDB.GetList();
}

/// <summary>
/// Gets a single BusquedaRoboDelitosSexualesFormaLabioinf from the database without its data.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesFormaLabioinf in the database.</param>
/// <returns>A BusquedaRoboDelitosSexualesFormaLabioinf object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRoboDelitosSexualesFormaLabioinf GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single BusquedaRoboDelitosSexualesFormaLabioinf from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesFormaLabioinf in the database.</param>
/// <param name="getBusquedaRoboDelitosSexualesFormaLabioinfRecords">Determines whether to load all associated BusquedaRoboDelitosSexualesFormaLabioinf records as well.</param>
/// <returns>
/// A BusquedaRoboDelitosSexualesFormaLabioinf object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRoboDelitosSexualesFormaLabioinf GetItem(int id, bool getBusquedaRoboDelitosSexualesFormaLabioinfRecords){
BusquedaRoboDelitosSexualesFormaLabioinf myBusquedaRoboDelitosSexualesFormaLabioinf = BusquedaRoboDelitosSexualesFormaLabioinfDB.GetItem(id);
return myBusquedaRoboDelitosSexualesFormaLabioinf;
}

/// <summary>
/// Saves a BusquedaRoboDelitosSexualesFormaLabioinf in the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesFormaLabioinf">The BusquedaRoboDelitosSexualesFormaLabioinf instance to save.</param>
/// <returns>The new id if the BusquedaRoboDelitosSexualesFormaLabioinf is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(BusquedaRoboDelitosSexualesFormaLabioinf myBusquedaRoboDelitosSexualesFormaLabioinf){
using (TransactionScope myTransactionScope = new TransactionScope()){
int busquedaRoboDelitosSexualesFormaLabioinfid = BusquedaRoboDelitosSexualesFormaLabioinfDB.Save(myBusquedaRoboDelitosSexualesFormaLabioinf);

//  Assign the BusquedaRoboDelitosSexualesFormaLabioinf its new (or existing id).
myBusquedaRoboDelitosSexualesFormaLabioinf.id = busquedaRoboDelitosSexualesFormaLabioinfid;

myTransactionScope.Complete();

return busquedaRoboDelitosSexualesFormaLabioinfid;
}
}

/// <summary>
/// Deletes a BusquedaRoboDelitosSexualesFormaLabioinf from the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesFormaLabioinf">The BusquedaRoboDelitosSexualesFormaLabioinf instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BusquedaRoboDelitosSexualesFormaLabioinf myBusquedaRoboDelitosSexualesFormaLabioinf){
return BusquedaRoboDelitosSexualesFormaLabioinfDB.Delete(myBusquedaRoboDelitosSexualesFormaLabioinf.id);
}

#endregion

}

}
