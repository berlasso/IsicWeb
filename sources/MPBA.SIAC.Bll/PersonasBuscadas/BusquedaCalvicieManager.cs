using System;
using System.ComponentModel;
using System.Transactions;
using System.Data;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll {

/// <summary>
/// The BusquedaCalvicieManager class is responsible for managing Business Object.BusquedaCalvicie objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BusquedaCalvicieManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BusquedaCalvicie objects in the database.
/// </summary>
/// <returns>A list with all BusquedaCalvicie from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BusquedaCalvicieList GetList(){
return BusquedaCalvicieDB.GetList();
}

/// <summary>
/// Gets a single BusquedaCalvicie from the database without its data.
/// </summary>
/// <param name="id">The id of the BusquedaCalvicie in the database.</param>
/// <returns>A BusquedaCalvicie object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaCalvicie GetItem(decimal id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single BusquedaCalvicie from the database.
/// </summary>
/// <param name="id">The id of the BusquedaCalvicie in the database.</param>
/// <param name="getBusquedaCalvicieRecords">Determines whether to load all associated BusquedaCalvicie records as well.</param>
/// <returns>
/// A BusquedaCalvicie object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaCalvicie GetItem(decimal id, bool getBusquedaCalvicieRecords){
BusquedaCalvicie myBusquedaCalvicie = BusquedaCalvicieDB.GetItem(id);
return myBusquedaCalvicie;
}

/// <summary>
/// Saves a BusquedaCalvicie in the database.
/// </summary>
/// <param name="myBusquedaCalvicie">The BusquedaCalvicie instance to save.</param>
/// <returns>The new id if the BusquedaCalvicie is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static decimal Save(BusquedaCalvicie myBusquedaCalvicie, SqlCommand myCommand){
//using (TransactionScope myTransactionScope = new TransactionScope()){
decimal busquedaCalvicieid = BusquedaCalvicieDB.Save(myBusquedaCalvicie,myCommand);

//  Assign the BusquedaCalvicie its new (or existing id).
myBusquedaCalvicie.id = busquedaCalvicieid;

//myTransactionScope.Complete();

return busquedaCalvicieid;
//}
}

/// <summary>
/// Deletes a BusquedaCalvicie from the database.
/// </summary>
/// <param name="myBusquedaCalvicie">The BusquedaCalvicie instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BusquedaCalvicie myBusquedaCalvicie){
return BusquedaCalvicieDB.Delete(myBusquedaCalvicie.id);
}
/// <summary>
/// Deletes las BusquedaCalvicie de una Busqueda from the database.
/// </summary>
/// <param name="myBusquedaCalvicie">The BusquedaCalvicie instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool DeletebyIdBusqueda(decimal idBusqueda)
{
    return BusquedaCalvicieDB.DeleteByIdBusqueda(idBusqueda);
}

#endregion

}

}
