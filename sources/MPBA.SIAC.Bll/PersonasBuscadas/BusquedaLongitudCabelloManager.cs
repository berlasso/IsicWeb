using System;
using System.ComponentModel;
using System.Transactions;
using System.Data;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll {

/// <summary>
/// The BusquedaLongitudCabelloManager class is responsible for managing Business Object.BusquedaLongitudCabello objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BusquedaLongitudCabelloManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BusquedaLongitudCabello objects in the database.
/// </summary>
/// <returns>A list with all BusquedaLongitudCabello from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BusquedaLongitudCabelloList GetList(){
return BusquedaLongitudCabelloDB.GetList();
}

/// <summary>
/// Gets a single BusquedaLongitudCabello from the database without its data.
/// </summary>
/// <param name="id">The id of the BusquedaLongitudCabello in the database.</param>
/// <returns>A BusquedaLongitudCabello object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaLongitudCabello GetItem(decimal id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single BusquedaLongitudCabello from the database.
/// </summary>
/// <param name="id">The id of the BusquedaLongitudCabello in the database.</param>
/// <param name="getBusquedaLongitudCabelloRecords">Determines whether to load all associated BusquedaLongitudCabello records as well.</param>
/// <returns>
/// A BusquedaLongitudCabello object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaLongitudCabello GetItem(decimal id, bool getBusquedaLongitudCabelloRecords){
BusquedaLongitudCabello myBusquedaLongitudCabello = BusquedaLongitudCabelloDB.GetItem(id);
return myBusquedaLongitudCabello;
}

/// <summary>
/// Saves a BusquedaLongitudCabello in the database.
/// </summary>
/// <param name="myBusquedaLongitudCabello">The BusquedaLongitudCabello instance to save.</param>
/// <returns>The new id if the BusquedaLongitudCabello is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static decimal Save(BusquedaLongitudCabello myBusquedaLongitudCabello, SqlCommand myCommand){
//using (TransactionScope myTransactionScope = new TransactionScope()){
decimal busquedaLongitudCabelloid = BusquedaLongitudCabelloDB.Save(myBusquedaLongitudCabello, myCommand);

//  Assign the BusquedaLongitudCabello its new (or existing id).
myBusquedaLongitudCabello.id = busquedaLongitudCabelloid;

//myTransactionScope.Complete();

return busquedaLongitudCabelloid;
//}
}

/// <summary>
/// Deletes a BusquedaLongitudCabello from the database.
/// </summary>
/// <param name="myBusquedaLongitudCabello">The BusquedaLongitudCabello instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BusquedaLongitudCabello myBusquedaLongitudCabello){
return BusquedaLongitudCabelloDB.Delete(myBusquedaLongitudCabello.id);
}

/// <summary>
/// Deletes las BusquedaLongitudCabello de una Busqueda from the database.
/// </summary>
/// <param name="myBusquedaLongitudCabello">The BusquedaLongitudCabello instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool DeleteByIdBusqueda(decimal idBusqueda)
{
    return BusquedaLongitudCabelloDB.DeleteByIdBusqueda(idBusqueda);
}

#endregion

}

}
