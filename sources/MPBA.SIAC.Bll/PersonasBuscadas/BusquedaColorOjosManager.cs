using System;
using System.ComponentModel;
using System.Transactions;
using System.Data;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll {

/// <summary>
/// The BusquedaColorOjosManager class is responsible for managing Business Object.BusquedaColorOjos objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BusquedaColorOjosManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BusquedaColorOjos objects in the database.
/// </summary>
/// <returns>A list with all BusquedaColorOjos from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BusquedaColorOjosList GetList(){
return BusquedaColorOjosDB.GetList();
}

/// <summary>
/// Gets a single BusquedaColorOjos from the database without its data.
/// </summary>
/// <param name="id">The id of the BusquedaColorOjos in the database.</param>
/// <returns>A BusquedaColorOjos object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaColorOjos GetItem(decimal id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single BusquedaColorOjos from the database.
/// </summary>
/// <param name="id">The id of the BusquedaColorOjos in the database.</param>
/// <param name="getBusquedaColorOjosRecords">Determines whether to load all associated BusquedaColorOjos records as well.</param>
/// <returns>
/// A BusquedaColorOjos object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaColorOjos GetItem(decimal id, bool getBusquedaColorOjosRecords){
BusquedaColorOjos myBusquedaColorOjos = BusquedaColorOjosDB.GetItem(id);
return myBusquedaColorOjos;
}

/// <summary>
/// Saves a BusquedaColorOjos in the database.
/// </summary>
/// <param name="myBusquedaColorOjos">The BusquedaColorOjos instance to save.</param>
/// <returns>The new id if the BusquedaColorOjos is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static decimal Save(BusquedaColorOjos myBusquedaColorOjos, SqlCommand myCommand){
//using (TransactionScope myTransactionScope = new TransactionScope()){
decimal busquedaColorOjosid = BusquedaColorOjosDB.Save(myBusquedaColorOjos, myCommand);

//  Assign the BusquedaColorOjos its new (or existing id).
myBusquedaColorOjos.id = busquedaColorOjosid;

//myTransactionScope.Complete();

return busquedaColorOjosid;
//}
}

/// <summary>
/// Deletes a BusquedaColorOjos from the database.
/// </summary>
/// <param name="myBusquedaColorOjos">The BusquedaColorOjos instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BusquedaColorOjos myBusquedaColorOjos){
return BusquedaColorOjosDB.Delete(myBusquedaColorOjos.id);
}

/// <summary>
/// Deletes las BusquedaColorOjos de una Busqueda from the database.
/// </summary>
/// <param name="myBusquedaColorOjos">The BusquedaColorOjos instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool DeleteByIdBusqueda(decimal idBusqueda)
{
    return BusquedaColorOjosDB.DeleteByIdBusqueda(idBusqueda);
}

#endregion

}

}
