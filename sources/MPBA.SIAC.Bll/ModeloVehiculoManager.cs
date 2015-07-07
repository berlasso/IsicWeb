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
/// The ModeloVehiculoManager class is responsible for managing Business Object.ModeloVehiculo objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class ModeloVehiculoManager
  {

#region "Public Methods"


  /// <summary>
  /// Gets a list with all ModeloVehiculo objects in the database.
  /// </summary>
  /// <returns>A list with all ModeloVehiculo from the database when the database contains any, or null otherwise.</returns>
  [DataObjectMethod(DataObjectMethodType.Select, true)]
  public static ModeloVehiculoList GetListByidMarcaVehiculo(int idMarcaVehiculo)
  {
      return ModeloVehiculoDB.GetListByidMarcaVehiculo(idMarcaVehiculo);
  }

  /// <summary>
  /// Gets a list with all ModeloVehiculo objects in the database.
  /// </summary>
  /// <returns>A list with all ModeloVehiculo from the database when the database contains any, or null otherwise.</returns>
  [DataObjectMethod(DataObjectMethodType.Select, false)]
  public static ModeloVehiculoList GetList()
  {
      return ModeloVehiculoDB.GetList();
  }



/// <summary>
/// Gets a single ModeloVehiculo from the database without its data.
/// </summary>
/// <param name="id">The id of the ModeloVehiculo in the database.</param>
/// <returns>A ModeloVehiculo object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static ModeloVehiculo GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single ModeloVehiculo from the database.
/// </summary>
/// <param name="id">The id of the ModeloVehiculo in the database.</param>
/// <param name="getModeloVehiculoRecords">Determines whether to load all associated ModeloVehiculo records as well.</param>
/// <returns>
/// A ModeloVehiculo object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static ModeloVehiculo GetItem(int id, bool getModeloVehiculoRecords){
ModeloVehiculo myModeloVehiculo = ModeloVehiculoDB.GetItem(id);
if (myModeloVehiculo != null && getModeloVehiculoRecords){
myModeloVehiculo.vehiculoss = VehiculosDB.GetListByidModeloVehiculo(id);
}
return myModeloVehiculo;
}

/// <summary>
/// Saves a ModeloVehiculo in the database.
/// </summary>
/// <param name="myModeloVehiculo">The ModeloVehiculo instance to save.</param>
/// <returns>The new id if the ModeloVehiculo is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(ModeloVehiculo myModeloVehiculo){
using (TransactionScope myTransactionScope = new TransactionScope()){
int modeloVehiculoid = ModeloVehiculoDB.Save(myModeloVehiculo);
foreach (Vehiculos myVehiculos in myModeloVehiculo.vehiculoss){
myVehiculos.id = modeloVehiculoid;
VehiculosDB.Save(myVehiculos);
}

//  Assign the ModeloVehiculo its new (or existing id).
myModeloVehiculo.id = modeloVehiculoid;

myTransactionScope.Complete();

return modeloVehiculoid;
}
}

/// <summary>
/// Deletes a ModeloVehiculo from the database.
/// </summary>
/// <param name="myModeloVehiculo">The ModeloVehiculo instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(ModeloVehiculo myModeloVehiculo){
return ModeloVehiculoDB.Delete(myModeloVehiculo.id);
}

#endregion

}

}
