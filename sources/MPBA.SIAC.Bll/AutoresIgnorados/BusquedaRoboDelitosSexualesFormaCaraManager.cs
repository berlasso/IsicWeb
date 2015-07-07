using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The BusquedaRoboDelitosSexualesFormaCaraManager class is responsible for managing Business Entities.BusquedaRoboDelitosSexualesFormaCara objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BusquedaRoboDelitosSexualesFormaCaraManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BusquedaRoboDelitosSexualesFormaCara objects in the database.
/// </summary>
/// <returns>A list with all BusquedaRoboDelitosSexualesFormaCara from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BusquedaRoboDelitosSexualesFormaCaraList GetList(){
return BusquedaRoboDelitosSexualesFormaCaraDB.GetList();
}

/// <summary>
/// Gets a single BusquedaRoboDelitosSexualesFormaCara from the database without its data.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesFormaCara in the database.</param>
/// <returns>A BusquedaRoboDelitosSexualesFormaCara object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRoboDelitosSexualesFormaCara GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single BusquedaRoboDelitosSexualesFormaCara from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesFormaCara in the database.</param>
/// <param name="getBusquedaRoboDelitosSexualesFormaCaraRecords">Determines whether to load all associated BusquedaRoboDelitosSexualesFormaCara records as well.</param>
/// <returns>
/// A BusquedaRoboDelitosSexualesFormaCara object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRoboDelitosSexualesFormaCara GetItem(int id, bool getBusquedaRoboDelitosSexualesFormaCaraRecords){
BusquedaRoboDelitosSexualesFormaCara myBusquedaRoboDelitosSexualesFormaCara = BusquedaRoboDelitosSexualesFormaCaraDB.GetItem(id);
return myBusquedaRoboDelitosSexualesFormaCara;
}

/// <summary>
/// Saves a BusquedaRoboDelitosSexualesFormaCara in the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesFormaCara">The BusquedaRoboDelitosSexualesFormaCara instance to save.</param>
/// <returns>The new id if the BusquedaRoboDelitosSexualesFormaCara is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(BusquedaRoboDelitosSexualesFormaCara myBusquedaRoboDelitosSexualesFormaCara){
using (TransactionScope myTransactionScope = new TransactionScope()){
int busquedaRoboDelitosSexualesFormaCaraid = BusquedaRoboDelitosSexualesFormaCaraDB.Save(myBusquedaRoboDelitosSexualesFormaCara);

//  Assign the BusquedaRoboDelitosSexualesFormaCara its new (or existing id).
myBusquedaRoboDelitosSexualesFormaCara.id = busquedaRoboDelitosSexualesFormaCaraid;

myTransactionScope.Complete();

return busquedaRoboDelitosSexualesFormaCaraid;
}
}

/// <summary>
/// Deletes a BusquedaRoboDelitosSexualesFormaCara from the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesFormaCara">The BusquedaRoboDelitosSexualesFormaCara instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BusquedaRoboDelitosSexualesFormaCara myBusquedaRoboDelitosSexualesFormaCara){
return BusquedaRoboDelitosSexualesFormaCaraDB.Delete(myBusquedaRoboDelitosSexualesFormaCara.id);
}

#endregion

}

}
