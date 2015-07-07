using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;
using System.Data.SqlClient;
using System.Data;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The VehiculosManager class is responsible for managing Business Object.Vehiculos objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class VehiculosManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all Vehiculos objects in the database.
/// </summary>
/// <returns>A list with all Vehiculos from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static VehiculosList GetList(){
return VehiculosDB.GetList();
}

/// <summary>
/// Gets a single Vehiculos from the database without its data.
/// </summary>
/// <param name="id">The id of the Vehiculos in the database.</param>
/// <returns>A Vehiculos object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static Vehiculos GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single Vehiculos from the database without its data.
/// </summary>
/// <param name="id">The id of the Vehiculos in the database.</param>
/// <returns>A Vehiculos object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static Vehiculos GetItemByBienSustraido(int idBienSustraido)
{
    return VehiculosDB.GetItemByBienSustraido(idBienSustraido);
}

/// <summary>
/// Gets a single Vehiculos from the database.
/// </summary>
/// <param name="id">The id of the Vehiculos in the database.</param>
/// <param name="getVehiculosRecords">Determines whether to load all associated Vehiculos records as well.</param>
/// <returns>
/// A Vehiculos object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static Vehiculos GetItem(int id, bool getVehiculosRecords){
Vehiculos myVehiculos = VehiculosDB.GetItem(id);
return myVehiculos;
}

/// <summary>
/// Saves a Vehiculos in the database.
/// </summary>
/// <param name="myVehiculos">The Vehiculos instance to save.</param>
/// <returns>The new id if the Vehiculos is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(Vehiculos myVehiculos){
using (TransactionScope myTransactionScope = new TransactionScope()){
int vehiculosid = VehiculosDB.Save(myVehiculos);

//  Assign the Vehiculos its new (or existing id).
myVehiculos.id = vehiculosid;

myTransactionScope.Complete();

return vehiculosid;
}
}

/// <summary>
/// Saves a Vehiculos in the database.
/// </summary>
/// <param name="myVehiculos">The Vehiculos instance to save.</param>
/// <returns>The new id if the Vehiculos is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(Vehiculos myVehiculos, SqlCommand myCommand)
{
    //using (TransactionScope myTransactionScope = new TransactionScope())
    //{
        int vehiculosid = VehiculosDB.Save(myVehiculos,myCommand);

        //  Assign the Vehiculos its new (or existing id).
        myVehiculos.id = vehiculosid;

        //myTransactionScope.Complete();

        return vehiculosid;
    //}
}


/// <summary>
/// Deletes a Vehiculos from the database.
/// </summary>
/// <param name="myVehiculos">The Vehiculos instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(Vehiculos myVehiculos){
return VehiculosDB.Delete(myVehiculos.id);
}

#endregion

}

}
