using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The BusquedaRoboDelitosSexualesCejaDimensionManager class is responsible for managing Business Entities.BusquedaRoboDelitosSexualesCejaDimension objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BusquedaRoboDelitosSexualesCejaDimensionManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BusquedaRoboDelitosSexualesCejaDimension objects in the database.
/// </summary>
/// <returns>A list with all BusquedaRoboDelitosSexualesCejaDimension from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BusquedaRoboDelitosSexualesCejaDimensionList GetList(){
return BusquedaRoboDelitosSexualesCejaDimensionDB.GetList();
}

/// <summary>
/// Gets a single BusquedaRoboDelitosSexualesCejaDimension from the database without its data.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesCejaDimension in the database.</param>
/// <returns>A BusquedaRoboDelitosSexualesCejaDimension object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRoboDelitosSexualesCejaDimension GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single BusquedaRoboDelitosSexualesCejaDimension from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesCejaDimension in the database.</param>
/// <param name="getBusquedaRoboDelitosSexualesCejaDimensionRecords">Determines whether to load all associated BusquedaRoboDelitosSexualesCejaDimension records as well.</param>
/// <returns>
/// A BusquedaRoboDelitosSexualesCejaDimension object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRoboDelitosSexualesCejaDimension GetItem(int id, bool getBusquedaRoboDelitosSexualesCejaDimensionRecords){
BusquedaRoboDelitosSexualesCejaDimension myBusquedaRoboDelitosSexualesCejaDimension = BusquedaRoboDelitosSexualesCejaDimensionDB.GetItem(id);
return myBusquedaRoboDelitosSexualesCejaDimension;
}

/// <summary>
/// Saves a BusquedaRoboDelitosSexualesCejaDimension in the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesCejaDimension">The BusquedaRoboDelitosSexualesCejaDimension instance to save.</param>
/// <returns>The new id if the BusquedaRoboDelitosSexualesCejaDimension is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(BusquedaRoboDelitosSexualesCejaDimension myBusquedaRoboDelitosSexualesCejaDimension){
using (TransactionScope myTransactionScope = new TransactionScope()){
int busquedaRoboDelitosSexualesCejaDimensionid = BusquedaRoboDelitosSexualesCejaDimensionDB.Save(myBusquedaRoboDelitosSexualesCejaDimension);

//  Assign the BusquedaRoboDelitosSexualesCejaDimension its new (or existing id).
myBusquedaRoboDelitosSexualesCejaDimension.id = busquedaRoboDelitosSexualesCejaDimensionid;

myTransactionScope.Complete();

return busquedaRoboDelitosSexualesCejaDimensionid;
}
}

/// <summary>
/// Deletes a BusquedaRoboDelitosSexualesCejaDimension from the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesCejaDimension">The BusquedaRoboDelitosSexualesCejaDimension instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BusquedaRoboDelitosSexualesCejaDimension myBusquedaRoboDelitosSexualesCejaDimension){
return BusquedaRoboDelitosSexualesCejaDimensionDB.Delete(myBusquedaRoboDelitosSexualesCejaDimension.id);
}

#endregion

}

}
