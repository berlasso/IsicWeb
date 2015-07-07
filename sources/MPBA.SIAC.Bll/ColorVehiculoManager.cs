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
/// The ColorVehiculoManager class is responsible for managing Business Object.ColorVehiculo objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class ColorVehiculoManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all ColorVehiculo objects in the database.
/// </summary>
/// <returns>A list with all ColorVehiculo from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static ColorVehiculoList GetList(){
return ColorVehiculoDB.GetList();
}

/// <summary>
/// Gets a single ColorVehiculo from the database without its data.
/// </summary>
/// <param name="id">The id of the ColorVehiculo in the database.</param>
/// <returns>A ColorVehiculo object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static ColorVehiculo GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single ColorVehiculo from the database.
/// </summary>
/// <param name="id">The id of the ColorVehiculo in the database.</param>
/// <param name="getColorVehiculoRecords">Determines whether to load all associated ColorVehiculo records as well.</param>
/// <returns>
/// A ColorVehiculo object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static ColorVehiculo GetItem(int id, bool getColorVehiculoRecords){
ColorVehiculo myColorVehiculo = ColorVehiculoDB.GetItem(id);
if (myColorVehiculo != null && getColorVehiculoRecords){
myColorVehiculo.vehiculoss = VehiculosDB.GetListByidColorVehiculo(id);
}
return myColorVehiculo;
}

/// <summary>
/// Saves a ColorVehiculo in the database.
/// </summary>
/// <param name="myColorVehiculo">The ColorVehiculo instance to save.</param>
/// <returns>The new id if the ColorVehiculo is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(ColorVehiculo myColorVehiculo){
using (TransactionScope myTransactionScope = new TransactionScope()){
int colorVehiculoid = ColorVehiculoDB.Save(myColorVehiculo);
foreach (Vehiculos myVehiculos in myColorVehiculo.vehiculoss){
myVehiculos.id = colorVehiculoid;
VehiculosDB.Save(myVehiculos);
}

//  Assign the ColorVehiculo its new (or existing id).
myColorVehiculo.id = colorVehiculoid;

myTransactionScope.Complete();

return colorVehiculoid;
}
}

/// <summary>
/// Deletes a ColorVehiculo from the database.
/// </summary>
/// <param name="myColorVehiculo">The ColorVehiculo instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(ColorVehiculo myColorVehiculo){
return ColorVehiculoDB.Delete(myColorVehiculo.id);
}

#endregion

}

}
