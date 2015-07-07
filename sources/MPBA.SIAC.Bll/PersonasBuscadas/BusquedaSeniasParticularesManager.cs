using System;
using System.ComponentModel;
using System.Transactions;
using System.Data;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll {

/// <summary>
/// The BusquedaSeniasParticularesManager class is responsible for managing Business Object.BusquedaSeniasParticulares objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BusquedaSeniasParticularesManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BusquedaSeniasParticulares objects in the database.
/// </summary>
/// <returns>A list with all BusquedaSeniasParticulares from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BusquedaSeniasParticularesList GetList(){
return BusquedaSeniasParticularesDB.GetList();
}

/// <summary>
/// Gets a single BusquedaSeniasParticulares from the database without its data.
/// </summary>
/// <param name="id">The id of the BusquedaSeniasParticulares in the database.</param>
/// <returns>A BusquedaSeniasParticulares object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaSeniasParticulares GetItem(decimal id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single BusquedaSeniasParticulares from the database.
/// </summary>
/// <param name="id">The id of the BusquedaSeniasParticulares in the database.</param>
/// <param name="getBusquedaSeniasParticularesRecords">Determines whether to load all associated BusquedaSeniasParticulares records as well.</param>
/// <returns>
/// A BusquedaSeniasParticulares object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaSeniasParticulares GetItem(decimal id, bool getBusquedaSeniasParticularesRecords){
BusquedaSeniasParticulares myBusquedaSeniasParticulares = BusquedaSeniasParticularesDB.GetItem(id);
return myBusquedaSeniasParticulares;
}

/// <summary>
/// Saves a BusquedaSeniasParticulares in the database.
/// </summary>
/// <param name="myBusquedaSeniasParticulares">The BusquedaSeniasParticulares instance to save.</param>
/// <returns>The new id if the BusquedaSeniasParticulares is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static decimal Save(BusquedaSeniasParticulares myBusquedaSeniasParticulares, SqlCommand myCommand){
//using (TransactionScope myTransactionScope = new TransactionScope()){
decimal busquedaSeniasParticularesid = BusquedaSeniasParticularesDB.Save(myBusquedaSeniasParticulares, myCommand);

//  Assign the BusquedaSeniasParticulares its new (or existing id).
myBusquedaSeniasParticulares.id = busquedaSeniasParticularesid;

//myTransactionScope.Complete();

return busquedaSeniasParticularesid;
//}
}

/// <summary>
/// Deletes a BusquedaSeniasParticulares from the database.
/// </summary>
/// <param name="myBusquedaSeniasParticulares">The BusquedaSeniasParticulares instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BusquedaSeniasParticulares myBusquedaSeniasParticulares){
return BusquedaSeniasParticularesDB.Delete(myBusquedaSeniasParticulares.id);
}

/// <summary>
/// Deletes las BusquedaSeniasParticulares de una Busqueda from the database.
/// </summary>
/// <param name="myBusquedaSeniasParticulares">The BusquedaSeniasParticulares instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool DeleteByIdBusqueda(decimal idBusqueda)
{
    return BusquedaSeniasParticularesDB.DeleteByIdBusqueda(idBusqueda);
}

#endregion

}

}
