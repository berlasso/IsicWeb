using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The NNClaseVidrioVehiculoManager class is responsible for managing Business Object.NNClaseVidrioVehiculo objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class NNClaseVidrioVehiculoManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all NNClaseVidrioVehiculo objects in the database.
/// </summary>
/// <returns>A list with all NNClaseVidrioVehiculo from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static NNClaseVidrioVehiculoList GetList(){
return NNClaseVidrioVehiculoDB.GetList();
}

/// <summary>
/// Gets a single NNClaseVidrioVehiculo from the database without its data.
/// </summary>
/// <param name="id">The id of the NNClaseVidrioVehiculo in the database.</param>
/// <returns>A NNClaseVidrioVehiculo object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseVidrioVehiculo GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single NNClaseVidrioVehiculo from the database.
/// </summary>
/// <param name="id">The id of the NNClaseVidrioVehiculo in the database.</param>
/// <param name="getNNClaseVidrioVehiculoRecords">Determines whether to load all associated NNClaseVidrioVehiculo records as well.</param>
/// <returns>
/// A NNClaseVidrioVehiculo object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseVidrioVehiculo GetItem(int id, bool getNNClaseVidrioVehiculoRecords){
NNClaseVidrioVehiculo myNNClaseVidrioVehiculo = NNClaseVidrioVehiculoDB.GetItem(id);
if (myNNClaseVidrioVehiculo != null && getNNClaseVidrioVehiculoRecords){
myNNClaseVidrioVehiculo.vehiculoss = VehiculosDB.GetListByidClaseVidrioVehiculo(id);
}
return myNNClaseVidrioVehiculo;
}

/// <summary>
/// Saves a NNClaseVidrioVehiculo in the database.
/// </summary>
/// <param name="myNNClaseVidrioVehiculo">The NNClaseVidrioVehiculo instance to save.</param>
/// <returns>The new id if the NNClaseVidrioVehiculo is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(NNClaseVidrioVehiculo myNNClaseVidrioVehiculo){
using (TransactionScope myTransactionScope = new TransactionScope()){
int nNClaseVidrioVehiculoid = NNClaseVidrioVehiculoDB.Save(myNNClaseVidrioVehiculo);
foreach (Vehiculos myVehiculos in myNNClaseVidrioVehiculo.vehiculoss){
myVehiculos.id = nNClaseVidrioVehiculoid;
VehiculosDB.Save(myVehiculos);
}

//  Assign the NNClaseVidrioVehiculo its new (or existing id).
myNNClaseVidrioVehiculo.id = nNClaseVidrioVehiculoid;

myTransactionScope.Complete();

return nNClaseVidrioVehiculoid;
}
}

/// <summary>
/// Deletes a NNClaseVidrioVehiculo from the database.
/// </summary>
/// <param name="myNNClaseVidrioVehiculo">The NNClaseVidrioVehiculo instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(NNClaseVidrioVehiculo myNNClaseVidrioVehiculo){
return NNClaseVidrioVehiculoDB.Delete(myNNClaseVidrioVehiculo.id);
}

#endregion

}

}
