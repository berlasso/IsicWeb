using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The NNClaseBooleanManager class is responsible for managing Business Object.NNClaseBoolean objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class NNClaseBooleanManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all NNClaseBoolean objects in the database.
/// </summary>
/// <returns>A list with all NNClaseBoolean from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static NNClaseBooleanList GetList(){
return NNClaseBooleanDB.GetList();
}

/// <summary>
/// Gets a single NNClaseBoolean from the database without its data.
/// </summary>
/// <param name="id">The Id of the NNClaseBoolean in the database.</param>
/// <returns>A NNClaseBoolean object when the Id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseBoolean GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single NNClaseBoolean from the database.
/// </summary>
/// <param name="id">The Id of the NNClaseBoolean in the database.</param>
/// <param name="getNNClaseBooleanRecords">Determines whether to load all associated NNClaseBoolean records as well.</param>
/// <returns>
/// A NNClaseBoolean object when the Id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseBoolean GetItem(int id, bool getNNClaseBooleanRecords){
NNClaseBoolean myNNClaseBoolean = NNClaseBooleanDB.GetItem(id);
if (myNNClaseBoolean != null && getNNClaseBooleanRecords){
myNNClaseBoolean.delitoss = DelitosDB.GetListByHuboAgresionFisicaAVictima(id);
}
if (myNNClaseBoolean != null && getNNClaseBooleanRecords){
myNNClaseBoolean.delitoss = DelitosDB.GetListByUsoDeArmas(id);
}
if (myNNClaseBoolean != null && getNNClaseBooleanRecords){
myNNClaseBoolean.delitoss = DelitosDB.GetListByVictimasEnElLugar(id);
}
if (myNNClaseBoolean != null && getNNClaseBooleanRecords){
myNNClaseBoolean.delitoss = DelitosDB.GetListByVictimaTrasladadaAOtroLugar(id);
}
if (myNNClaseBoolean != null && getNNClaseBooleanRecords){
myNNClaseBoolean.vehiculoss = VehiculosDB.GetListByGNC(id);
}
return myNNClaseBoolean;
}

/// <summary>
/// Saves a NNClaseBoolean in the database.
/// </summary>
/// <param name="myNNClaseBoolean">The NNClaseBoolean instance to save.</param>
/// <returns>The new Id if the NNClaseBoolean is new in the database or the existing Id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(NNClaseBoolean myNNClaseBoolean){
using (TransactionScope myTransactionScope = new TransactionScope()){
int nNClaseBooleanId = NNClaseBooleanDB.Save(myNNClaseBoolean);
foreach (Delitos myDelitos in myNNClaseBoolean.delitoss){
myDelitos.id = nNClaseBooleanId;
DelitosDB.Save(myDelitos);
}
foreach (Delitos myDelitos in myNNClaseBoolean.delitoss){
myDelitos.id = nNClaseBooleanId;
DelitosDB.Save(myDelitos);
}
foreach (Delitos myDelitos in myNNClaseBoolean.delitoss){
myDelitos.id = nNClaseBooleanId;
DelitosDB.Save(myDelitos);
}
foreach (Delitos myDelitos in myNNClaseBoolean.delitoss){
myDelitos.id = nNClaseBooleanId;
DelitosDB.Save(myDelitos);
}
foreach (Vehiculos myVehiculos in myNNClaseBoolean.vehiculoss){
myVehiculos.id = nNClaseBooleanId;
VehiculosDB.Save(myVehiculos);
}

//  Assign the NNClaseBoolean its new (or existing Id).
myNNClaseBoolean.Id = nNClaseBooleanId;

myTransactionScope.Complete();

return nNClaseBooleanId;
}
}

/// <summary>
/// Deletes a NNClaseBoolean from the database.
/// </summary>
/// <param name="myNNClaseBoolean">The NNClaseBoolean instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(NNClaseBoolean myNNClaseBoolean){
return NNClaseBooleanDB.Delete(myNNClaseBoolean.Id);
}

#endregion

}

}
