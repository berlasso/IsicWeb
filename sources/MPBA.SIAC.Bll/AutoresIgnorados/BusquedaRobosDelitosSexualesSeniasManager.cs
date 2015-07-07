using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll
{

/// <summary>
/// The BusquedaRobosDelitosSexualesSeniasManager class is responsible for managing Business Entities.BusquedaRobosDelitosSexualesSenias objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BusquedaRobosDelitosSexualesSeniasManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BusquedaRobosDelitosSexualesSenias objects in the database.
/// </summary>
/// <returns>A list with all BusquedaRobosDelitosSexualesSenias from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BusquedaRobosDelitosSexualesSeniasList GetList(){
return BusquedaRobosDelitosSexualesSeniasDB.GetList();
}

/// <summary>
/// Gets a single BusquedaRobosDelitosSexualesSenias from the database without its data.
/// </summary>
/// <param name="id">The id of the BusquedaRobosDelitosSexualesSenias in the database.</param>
/// <returns>A BusquedaRobosDelitosSexualesSenias object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRobosDelitosSexualesSenias GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single BusquedaRobosDelitosSexualesSenias from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRobosDelitosSexualesSenias in the database.</param>
/// <param name="getBusquedaRobosDelitosSexualesSeniasRecords">Determines whether to load all associated BusquedaRobosDelitosSexualesSenias records as well.</param>
/// <returns>
/// A BusquedaRobosDelitosSexualesSenias object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRobosDelitosSexualesSenias GetItem(int id, bool getBusquedaRobosDelitosSexualesSeniasRecords){
BusquedaRobosDelitosSexualesSenias myBusquedaRobosDelitosSexualesSenias = BusquedaRobosDelitosSexualesSeniasDB.GetItem(id);
return myBusquedaRobosDelitosSexualesSenias;
}

/// <summary>
/// Saves a BusquedaRobosDelitosSexualesSenias in the database.
/// </summary>
/// <param name="myBusquedaRobosDelitosSexualesSenias">The BusquedaRobosDelitosSexualesSenias instance to save.</param>
/// <returns>The new id if the BusquedaRobosDelitosSexualesSenias is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(BusquedaRobosDelitosSexualesSenias myBusquedaRobosDelitosSexualesSenias){
using (TransactionScope myTransactionScope = new TransactionScope()){
int busquedaRobosDelitosSexualesSeniasid = BusquedaRobosDelitosSexualesSeniasDB.Save(myBusquedaRobosDelitosSexualesSenias);

//  Assign the BusquedaRobosDelitosSexualesSenias its new (or existing id).
myBusquedaRobosDelitosSexualesSenias.id = busquedaRobosDelitosSexualesSeniasid;

myTransactionScope.Complete();

return busquedaRobosDelitosSexualesSeniasid;
}
}

/// <summary>
/// Deletes a BusquedaRobosDelitosSexualesSenias from the database.
/// </summary>
/// <param name="myBusquedaRobosDelitosSexualesSenias">The BusquedaRobosDelitosSexualesSenias instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BusquedaRobosDelitosSexualesSenias myBusquedaRobosDelitosSexualesSenias){
return BusquedaRobosDelitosSexualesSeniasDB.Delete(myBusquedaRobosDelitosSexualesSenias.id);
}

#endregion

}

}
