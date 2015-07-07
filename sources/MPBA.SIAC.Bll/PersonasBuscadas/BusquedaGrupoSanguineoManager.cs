using System;
using System.ComponentModel;
using System.Transactions;
using System.Data;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll {

/// <summary>
/// The BusquedaGrupoSanguineoManager class is responsible for managing Business Object.BusquedaGrupoSanguineo objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BusquedaGrupoSanguineoManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BusquedaGrupoSanguineo objects in the database.
/// </summary>
/// <returns>A list with all BusquedaGrupoSanguineo from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BusquedaGrupoSanguineoList GetList(){
return BusquedaGrupoSanguineoDB.GetList();
}

/// <summary>
/// Gets a single BusquedaGrupoSanguineo from the database without its data.
/// </summary>
/// <param name="id">The id of the BusquedaGrupoSanguineo in the database.</param>
/// <returns>A BusquedaGrupoSanguineo object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaGrupoSanguineo GetItem(decimal id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single BusquedaGrupoSanguineo from the database.
/// </summary>
/// <param name="id">The id of the BusquedaGrupoSanguineo in the database.</param>
/// <param name="getBusquedaGrupoSanguineoRecords">Determines whether to load all associated BusquedaGrupoSanguineo records as well.</param>
/// <returns>
/// A BusquedaGrupoSanguineo object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaGrupoSanguineo GetItem(decimal id, bool getBusquedaGrupoSanguineoRecords){
BusquedaGrupoSanguineo myBusquedaGrupoSanguineo = BusquedaGrupoSanguineoDB.GetItem(id);
return myBusquedaGrupoSanguineo;
}

/// <summary>
/// Saves a BusquedaGrupoSanguineo in the database.
/// </summary>
/// <param name="myBusquedaGrupoSanguineo">The BusquedaGrupoSanguineo instance to save.</param>
/// <returns>The new id if the BusquedaGrupoSanguineo is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static decimal Save(BusquedaGrupoSanguineo myBusquedaGrupoSanguineo, SqlCommand myCommand){
//using (TransactionScope myTransactionScope = new TransactionScope()){
decimal busquedaGrupoSanguineoid = BusquedaGrupoSanguineoDB.Save(myBusquedaGrupoSanguineo, myCommand);

//  Assign the BusquedaGrupoSanguineo its new (or existing id).
myBusquedaGrupoSanguineo.id = busquedaGrupoSanguineoid;

//myTransactionScope.Complete();

return busquedaGrupoSanguineoid;
//}
}

/// <summary>
/// Deletes a BusquedaGrupoSanguineo from the database.
/// </summary>
/// <param name="myBusquedaGrupoSanguineo">The BusquedaGrupoSanguineo instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BusquedaGrupoSanguineo myBusquedaGrupoSanguineo){
return BusquedaGrupoSanguineoDB.Delete(myBusquedaGrupoSanguineo.id);
}

/// <summary>
/// Deletes las BusquedaGrupoSanguineo de una Busqueda from the database.
/// </summary>
/// <param name="myBusquedaGrupoSanguineo">The BusquedaGrupoSanguineo instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool DeleteByIdBusqueda(decimal idBusqueda)
{
    return BusquedaGrupoSanguineoDB.DeleteByIdBusqueda(idBusqueda);
}

#endregion

}

}
