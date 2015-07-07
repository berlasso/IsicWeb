using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The BusquedaRoboDelitosSexualesFormaOrejaManager class is responsible for managing Business Entities.BusquedaRoboDelitosSexualesFormaOreja objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BusquedaRoboDelitosSexualesFormaOrejaManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BusquedaRoboDelitosSexualesFormaOreja objects in the database.
/// </summary>
/// <returns>A list with all BusquedaRoboDelitosSexualesFormaOreja from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BusquedaRoboDelitosSexualesFormaOrejaList GetList(){
return BusquedaRoboDelitosSexualesFormaOrejaDB.GetList();
}

/// <summary>
/// Gets a single BusquedaRoboDelitosSexualesFormaOreja from the database without its data.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesFormaOreja in the database.</param>
/// <returns>A BusquedaRoboDelitosSexualesFormaOreja object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRoboDelitosSexualesFormaOreja GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single BusquedaRoboDelitosSexualesFormaOreja from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesFormaOreja in the database.</param>
/// <param name="getBusquedaRoboDelitosSexualesFormaOrejaRecords">Determines whether to load all associated BusquedaRoboDelitosSexualesFormaOreja records as well.</param>
/// <returns>
/// A BusquedaRoboDelitosSexualesFormaOreja object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRoboDelitosSexualesFormaOreja GetItem(int id, bool getBusquedaRoboDelitosSexualesFormaOrejaRecords){
BusquedaRoboDelitosSexualesFormaOreja myBusquedaRoboDelitosSexualesFormaOreja = BusquedaRoboDelitosSexualesFormaOrejaDB.GetItem(id);
return myBusquedaRoboDelitosSexualesFormaOreja;
}

/// <summary>
/// Saves a BusquedaRoboDelitosSexualesFormaOreja in the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesFormaOreja">The BusquedaRoboDelitosSexualesFormaOreja instance to save.</param>
/// <returns>The new id if the BusquedaRoboDelitosSexualesFormaOreja is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(BusquedaRoboDelitosSexualesFormaOreja myBusquedaRoboDelitosSexualesFormaOreja){
using (TransactionScope myTransactionScope = new TransactionScope()){
int busquedaRoboDelitosSexualesFormaOrejaid = BusquedaRoboDelitosSexualesFormaOrejaDB.Save(myBusquedaRoboDelitosSexualesFormaOreja);

//  Assign the BusquedaRoboDelitosSexualesFormaOreja its new (or existing id).
myBusquedaRoboDelitosSexualesFormaOreja.id = busquedaRoboDelitosSexualesFormaOrejaid;

myTransactionScope.Complete();

return busquedaRoboDelitosSexualesFormaOrejaid;
}
}

/// <summary>
/// Deletes a BusquedaRoboDelitosSexualesFormaOreja from the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesFormaOreja">The BusquedaRoboDelitosSexualesFormaOreja instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BusquedaRoboDelitosSexualesFormaOreja myBusquedaRoboDelitosSexualesFormaOreja){
return BusquedaRoboDelitosSexualesFormaOrejaDB.Delete(myBusquedaRoboDelitosSexualesFormaOreja.id);
}

#endregion

}

}
