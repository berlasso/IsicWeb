using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Dal;
using MPBA.AutoresIgnorados.Dal;
using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.SIAC.Bll
{

/// <summary>
/// The MarcaVehiculoManager class is responsible for managing Business Object.MarcaVehiculo objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class MarcaVehiculoManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all MarcaVehiculo objects in the database.
/// </summary>
/// <returns>A list with all MarcaVehiculo from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static MarcaVehiculoList GetList(){
return MarcaVehiculoDB.GetList();
}



/// <summary>
/// Gets a single MarcaVehiculo from the database without its data.
/// </summary>
/// <param name="id">The id of the MarcaVehiculo in the database.</param>
/// <returns>A MarcaVehiculo object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static MarcaVehiculo GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single MarcaVehiculo from the database.
/// </summary>
/// <param name="id">The id of the MarcaVehiculo in the database.</param>
/// <param name="getMarcaVehiculoRecords">Determines whether to load all associated MarcaVehiculo records as well.</param>
/// <returns>
/// A MarcaVehiculo object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static MarcaVehiculo GetItem(int id, bool getMarcaVehiculoRecords){
MarcaVehiculo myMarcaVehiculo = MarcaVehiculoDB.GetItem(id);
if (myMarcaVehiculo != null && getMarcaVehiculoRecords){
myMarcaVehiculo.modeloVehiculos = ModeloVehiculoDB.GetListByidMarcaVehiculo(id);
}
if (myMarcaVehiculo != null && getMarcaVehiculoRecords){
myMarcaVehiculo.vehiculoss = VehiculosDB.GetListByidMarcaVehiculo(id);
}
return myMarcaVehiculo;
}

/// <summary>
/// Saves a MarcaVehiculo in the database.
/// </summary>
/// <param name="myMarcaVehiculo">The MarcaVehiculo instance to save.</param>
/// <returns>The new id if the MarcaVehiculo is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(MarcaVehiculo myMarcaVehiculo){
using (TransactionScope myTransactionScope = new TransactionScope()){
int marcaVehiculoid = MarcaVehiculoDB.Save(myMarcaVehiculo);
foreach (ModeloVehiculo myModeloVehiculo in myMarcaVehiculo.modeloVehiculos){
myModeloVehiculo.id = marcaVehiculoid;
ModeloVehiculoDB.Save(myModeloVehiculo);
}
foreach (Vehiculos myVehiculos in myMarcaVehiculo.vehiculoss){
myVehiculos.id = marcaVehiculoid;
VehiculosDB.Save(myVehiculos);
}

//  Assign the MarcaVehiculo its new (or existing id).
myMarcaVehiculo.id = marcaVehiculoid;

myTransactionScope.Complete();

return marcaVehiculoid;
}
}

/// <summary>
/// Deletes a MarcaVehiculo from the database.
/// </summary>
/// <param name="myMarcaVehiculo">The MarcaVehiculo instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(MarcaVehiculo myMarcaVehiculo){
return MarcaVehiculoDB.Delete(myMarcaVehiculo.id);
}

#endregion

}

}
