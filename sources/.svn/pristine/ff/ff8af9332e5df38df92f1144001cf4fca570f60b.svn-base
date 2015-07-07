using System;
using System.ComponentModel;
using System.Transactions;
using System.Data;
using System.Data.SqlClient;
using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll {

/// <summary>
/// The BusquedaColorCabelloManager class is responsible for managing Business Object.BusquedaColorCabello objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BusquedaColorCabelloManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BusquedaColorCabello objects in the database.
/// </summary>
/// <returns>A list with all BusquedaColorCabello from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BusquedaColorCabelloList GetList(){
return BusquedaColorCabelloDB.GetList();
}

/// <summary>
/// Gets a single BusquedaColorCabello from the database without its data.
/// </summary>
/// <param name="id">The id of the BusquedaColorCabello in the database.</param>
/// <returns>A BusquedaColorCabello object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaColorCabello GetItem(decimal id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single BusquedaColorCabello from the database.
/// </summary>
/// <param name="id">The id of the BusquedaColorCabello in the database.</param>
/// <param name="getBusquedaColorCabelloRecords">Determines whether to load all associated BusquedaColorCabello records as well.</param>
/// <returns>
/// A BusquedaColorCabello object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaColorCabello GetItem(decimal id, bool getBusquedaColorCabelloRecords){
BusquedaColorCabello myBusquedaColorCabello = BusquedaColorCabelloDB.GetItem(id);
return myBusquedaColorCabello;
}

/// <summary>
/// Saves a BusquedaColorCabello in the database.
/// </summary>
/// <param name="myBusquedaColorCabello">The BusquedaColorCabello instance to save.</param>
/// <returns>The new id if the BusquedaColorCabello is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static decimal Save(BusquedaColorCabello myBusquedaColorCabello, SqlCommand myCommand){
//using (TransactionScope myTransactionScope = new TransactionScope()){
decimal busquedaColorCabelloid = BusquedaColorCabelloDB.Save(myBusquedaColorCabello, myCommand);

//  Assign the BusquedaColorCabello its new (or existing id).
myBusquedaColorCabello.id = busquedaColorCabelloid;

//myTransactionScope.Complete();

return busquedaColorCabelloid;
//}
}

/// <summary>
/// Deletes a BusquedaColorCabello from the database.
/// </summary>
/// <param name="myBusquedaColorCabello">The BusquedaColorCabello instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BusquedaColorCabello myBusquedaColorCabello){
return BusquedaColorCabelloDB.Delete(myBusquedaColorCabello.id);
}
/// <summary>
/// Deletes las BusquedaColorCabello de una Busqueda from the database.
/// </summary>
/// <param name="myBusquedaColorCabello">The BusquedaColorCabello instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool DeletebyIdBusqueda(decimal idBusqueda)
{
    return BusquedaColorCabelloDB.DeleteByIdBusqueda(idBusqueda);
}

#endregion

}

}
