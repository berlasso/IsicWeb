using System;
using System.ComponentModel;
using System.Transactions;
using System.Data;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll {

/// <summary>
/// The BusquedaTatuajesManager class is responsible for managing Business Entities.BusquedaTatuajes objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BusquedaTatuajesManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BusquedaTatuajes objects in the database.
/// </summary>
/// <returns>A list with all BusquedaTatuajes from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BusquedaTatuajesList GetList(){
return BusquedaTatuajesDB.GetList();
}

/// <summary>
/// Gets a single BusquedaTatuajes from the database without its data.
/// </summary>
/// <param name="id">The id of the BusquedaTatuajes in the database.</param>
/// <returns>A BusquedaTatuajes object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaTatuajes GetItem(decimal id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single BusquedaTatuajes from the database.
/// </summary>
/// <param name="id">The id of the BusquedaTatuajes in the database.</param>
/// <param name="getBusquedaTatuajesRecords">Determines whether to load all associated BusquedaTatuajes records as well.</param>
/// <returns>
/// A BusquedaTatuajes object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaTatuajes GetItem(decimal id, bool getBusquedaTatuajesRecords){
BusquedaTatuajes myBusquedaTatuajes = BusquedaTatuajesDB.GetItem(id);
return myBusquedaTatuajes;
}

/// <summary>
/// Saves a BusquedaTatuajes in the database.
/// </summary>
/// <param name="myBusquedaTatuajes">The BusquedaTatuajes instance to save.</param>
/// <returns>The new id if the BusquedaTatuajes is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static decimal Save(BusquedaTatuajes myBusquedaTatuajes){
using (TransactionScope myTransactionScope = new TransactionScope()){
decimal busquedaTatuajesid = BusquedaTatuajesDB.Save(myBusquedaTatuajes);

//  Assign the BusquedaTatuajes its new (or existing id).
myBusquedaTatuajes.id = busquedaTatuajesid;

myTransactionScope.Complete();

return busquedaTatuajesid;
}
}

/// <summary>
/// Saves a BusquedaSeniasParticulares in the database.
/// </summary>
/// <param name="myBusquedaSeniasParticulares">The BusquedaSeniasParticulares instance to save.</param>
/// <returns>The new id if the BusquedaSeniasParticulares is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static decimal Save(BusquedaTatuajes myBusquedaTatuajes, SqlCommand myCommand)
{
    //using (TransactionScope myTransactionScope = new TransactionScope()){
    decimal busquedaTatuajesid = BusquedaTatuajesDB.Save(myBusquedaTatuajes, myCommand);

    //  Assign the BusquedaSeniasParticulares its new (or existing id).
    myBusquedaTatuajes.id = busquedaTatuajesid;

    //myTransactionScope.Complete();

    return busquedaTatuajesid;
    //}
}

/// <summary>
/// Deletes a BusquedaTatuajes from the database.
/// </summary>
/// <param name="myBusquedaTatuajes">The BusquedaTatuajes instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BusquedaTatuajes myBusquedaTatuajes){
return BusquedaTatuajesDB.Delete(myBusquedaTatuajes.id);
}

/// <summary>
/// Deletes las BusquedaSeniasParticulares de una Busqueda from the database.
/// </summary>
/// <param name="myBusquedaSeniasParticulares">The BusquedaSeniasParticulares instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool DeleteByIdBusqueda(decimal idBusqueda)
{
    return BusquedaTatuajesDB.DeleteByIdBusqueda(idBusqueda);
}

#endregion

}

}
