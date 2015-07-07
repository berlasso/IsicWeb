using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The BusquedaRobosDelitosSexualesLocalidadesManager class is responsible for managing Business Object.BusquedaRobosDelitosSexualesLocalidades objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BusquedaRobosDelitosSexualesLocalidadesManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BusquedaRobosDelitosSexualesLocalidades objects in the database.
/// </summary>
/// <returns>A list with all BusquedaRobosDelitosSexualesLocalidades from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BusquedaRobosDelitosSexualesLocalidadesList GetList(){
return BusquedaRobosDelitosSexualesLocalidadesDB.GetList();
}

/// <summary>
/// Gets a single BusquedaRobosDelitosSexualesLocalidades from the database without its data.
/// </summary>
/// <param name="id">The id of the BusquedaRobosDelitosSexualesLocalidades in the database.</param>
/// <returns>A BusquedaRobosDelitosSexualesLocalidades object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRobosDelitosSexualesLocalidades GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single BusquedaRobosDelitosSexualesLocalidades from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRobosDelitosSexualesLocalidades in the database.</param>
/// <param name="getBusquedaRobosDelitosSexualesLocalidadesRecords">Determines whether to load all associated BusquedaRobosDelitosSexualesLocalidades records as well.</param>
/// <returns>
/// A BusquedaRobosDelitosSexualesLocalidades object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRobosDelitosSexualesLocalidades GetItem(int id, bool getBusquedaRobosDelitosSexualesLocalidadesRecords){
BusquedaRobosDelitosSexualesLocalidades myBusquedaRobosDelitosSexualesLocalidades = BusquedaRobosDelitosSexualesLocalidadesDB.GetItem(id);
return myBusquedaRobosDelitosSexualesLocalidades;
}

/// <summary>
/// Saves a BusquedaRobosDelitosSexualesLocalidades in the database.
/// </summary>
/// <param name="myBusquedaRobosDelitosSexualesLocalidades">The BusquedaRobosDelitosSexualesLocalidades instance to save.</param>
/// <returns>The new id if the BusquedaRobosDelitosSexualesLocalidades is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(BusquedaRobosDelitosSexualesLocalidades myBusquedaRobosDelitosSexualesLocalidades){
using (TransactionScope myTransactionScope = new TransactionScope()){
int busquedaRobosDelitosSexualesLocalidadesid = BusquedaRobosDelitosSexualesLocalidadesDB.Save(myBusquedaRobosDelitosSexualesLocalidades);

//  Assign the BusquedaRobosDelitosSexualesLocalidades its new (or existing id).
myBusquedaRobosDelitosSexualesLocalidades.id = busquedaRobosDelitosSexualesLocalidadesid;

myTransactionScope.Complete();

return busquedaRobosDelitosSexualesLocalidadesid;
}
}

/// <summary>
/// Deletes a BusquedaRobosDelitosSexualesLocalidades from the database.
/// </summary>
/// <param name="myBusquedaRobosDelitosSexualesLocalidades">The BusquedaRobosDelitosSexualesLocalidades instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BusquedaRobosDelitosSexualesLocalidades myBusquedaRobosDelitosSexualesLocalidades){
return BusquedaRobosDelitosSexualesLocalidadesDB.Delete(myBusquedaRobosDelitosSexualesLocalidades.id);
}

#endregion

}

}
