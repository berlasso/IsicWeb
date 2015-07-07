using System;
using System.ComponentModel;
using System.Transactions;
using System.Data;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll {

/// <summary>
/// The BusquedaColorTenidoManager class is responsible for managing Business Object.BusquedaColorTenido objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BusquedaColorTenidoManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BusquedaColorTenido objects in the database.
/// </summary>
/// <returns>A list with all BusquedaColorTenido from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BusquedaColorTenidoList GetList(){
return BusquedaColorTenidoDB.GetList();
}

/// <summary>
/// Gets a single BusquedaColorTenido from the database without its data.
/// </summary>
/// <param name="id">The id of the BusquedaColorTenido in the database.</param>
/// <returns>A BusquedaColorTenido object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaColorTenido GetItem(decimal id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single BusquedaColorTenido from the database.
/// </summary>
/// <param name="id">The id of the BusquedaColorTenido in the database.</param>
/// <param name="getBusquedaColorTenidoRecords">Determines whether to load all associated BusquedaColorTenido records as well.</param>
/// <returns>
/// A BusquedaColorTenido object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaColorTenido GetItem(decimal id, bool getBusquedaColorTenidoRecords){
BusquedaColorTenido myBusquedaColorTenido = BusquedaColorTenidoDB.GetItem(id);
return myBusquedaColorTenido;
}

/// <summary>
/// Saves a BusquedaColorTenido in the database.
/// </summary>
/// <param name="myBusquedaColorTenido">The BusquedaColorTenido instance to save.</param>
/// <returns>The new id if the BusquedaColorTenido is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static decimal Save(BusquedaColorTenido myBusquedaColorTenido, SqlCommand myCommand){
//using (TransactionScope myTransactionScope = new TransactionScope()){
decimal busquedaColorTenidoid = BusquedaColorTenidoDB.Save(myBusquedaColorTenido, myCommand);

//  Assign the BusquedaColorTenido its new (or existing id).
myBusquedaColorTenido.id = busquedaColorTenidoid;

//myTransactionScope.Complete();

return busquedaColorTenidoid;
//}
}

/// <summary>
/// Deletes a BusquedaColorTenido from the database.
/// </summary>
/// <param name="myBusquedaColorTenido">The BusquedaColorTenido instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BusquedaColorTenido myBusquedaColorTenido){
return BusquedaColorTenidoDB.Delete(myBusquedaColorTenido.id);
}

/// <summary>
/// Deletes las BusquedaColorTenido de una Busqueda from the database.
/// </summary>
/// <param name="myBusquedaColorTenido">The BusquedaColorTenido instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool DeleteByIdBusqueda(decimal idBusqueda)
{
    return BusquedaColorTenidoDB.DeleteByIdBusqueda(idBusqueda);
}

#endregion

}

}
