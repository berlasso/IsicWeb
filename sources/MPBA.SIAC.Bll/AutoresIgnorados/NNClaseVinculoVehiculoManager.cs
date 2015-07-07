using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The NNClaseVinculoVehiculoManager class is responsible for managing Business Object.NNClaseVinculoVehiculo objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class NNClaseVinculoVehiculoManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all NNClaseVinculoVehiculo objects in the database.
/// </summary>
/// <returns>A list with all NNClaseVinculoVehiculo from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static NNClaseVinculoVehiculoList GetList(){
return NNClaseVinculoVehiculoDB.GetList();
}

/// <summary>
/// Gets a single NNClaseVinculoVehiculo from the database without its data.
/// </summary>
/// <param name="id">The id of the NNClaseVinculoVehiculo in the database.</param>
/// <returns>A NNClaseVinculoVehiculo object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseVinculoVehiculo GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single NNClaseVinculoVehiculo from the database.
/// </summary>
/// <param name="id">The id of the NNClaseVinculoVehiculo in the database.</param>
/// <param name="getNNClaseVinculoVehiculoRecords">Determines whether to load all associated NNClaseVinculoVehiculo records as well.</param>
/// <returns>
/// A NNClaseVinculoVehiculo object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseVinculoVehiculo GetItem(int id, bool getNNClaseVinculoVehiculoRecords){
NNClaseVinculoVehiculo myNNClaseVinculoVehiculo = NNClaseVinculoVehiculoDB.GetItem(id);
if (myNNClaseVinculoVehiculo != null && getNNClaseVinculoVehiculoRecords){
myNNClaseVinculoVehiculo.vehiculoss = VehiculosDB.GetListByidClaseVinculoVehiculo(id);
}
return myNNClaseVinculoVehiculo;
}

/// <summary>
/// Saves a NNClaseVinculoVehiculo in the database.
/// </summary>
/// <param name="myNNClaseVinculoVehiculo">The NNClaseVinculoVehiculo instance to save.</param>
/// <returns>The new id if the NNClaseVinculoVehiculo is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(NNClaseVinculoVehiculo myNNClaseVinculoVehiculo){
using (TransactionScope myTransactionScope = new TransactionScope()){
int nNClaseVinculoVehiculoid = NNClaseVinculoVehiculoDB.Save(myNNClaseVinculoVehiculo);
foreach (Vehiculos myVehiculos in myNNClaseVinculoVehiculo.vehiculoss){
myVehiculos.id = nNClaseVinculoVehiculoid;
VehiculosDB.Save(myVehiculos);
}

//  Assign the NNClaseVinculoVehiculo its new (or existing id).
myNNClaseVinculoVehiculo.id = nNClaseVinculoVehiculoid;

myTransactionScope.Complete();

return nNClaseVinculoVehiculoid;
}
}

/// <summary>
/// Deletes a NNClaseVinculoVehiculo from the database.
/// </summary>
/// <param name="myNNClaseVinculoVehiculo">The NNClaseVinculoVehiculo instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(NNClaseVinculoVehiculo myNNClaseVinculoVehiculo){
return NNClaseVinculoVehiculoDB.Delete(myNNClaseVinculoVehiculo.id);
}

#endregion

}

}
