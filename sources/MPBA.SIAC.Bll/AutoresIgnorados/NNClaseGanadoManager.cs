using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The NNClaseGanadoManager class is responsible for managing Business Object.NNClaseGanado objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class NNClaseGanadoManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all NNClaseGanado objects in the database.
/// </summary>
/// <returns>A list with all NNClaseGanado from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static NNClaseGanadoList GetList(){
return NNClaseGanadoDB.GetList();
}

/// <summary>
/// Gets a single NNClaseGanado from the database without its data.
/// </summary>
/// <param name="id">The id of the NNClaseGanado in the database.</param>
/// <returns>A NNClaseGanado object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseGanado GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single NNClaseGanado from the database.
/// </summary>
/// <param name="id">The id of the NNClaseGanado in the database.</param>
/// <param name="getNNClaseGanadoRecords">Determines whether to load all associated NNClaseGanado records as well.</param>
/// <returns>
/// A NNClaseGanado object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseGanado GetItem(int id, bool getNNClaseGanadoRecords){
NNClaseGanado myNNClaseGanado = NNClaseGanadoDB.GetItem(id);
if (myNNClaseGanado != null && getNNClaseGanadoRecords){
myNNClaseGanado.bienesSustraidosAnimals = BienesSustraidosAnimalDB.GetListByidClaseGanado(id);
}
return myNNClaseGanado;
}

/// <summary>
/// Saves a NNClaseGanado in the database.
/// </summary>
/// <param name="myNNClaseGanado">The NNClaseGanado instance to save.</param>
/// <returns>The new id if the NNClaseGanado is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(NNClaseGanado myNNClaseGanado){
using (TransactionScope myTransactionScope = new TransactionScope()){
int nNClaseGanadoid = NNClaseGanadoDB.Save(myNNClaseGanado);
foreach (BienesSustraidosAnimal myBienesSustraidosAnimal in myNNClaseGanado.bienesSustraidosAnimals){
myBienesSustraidosAnimal.id = nNClaseGanadoid;
BienesSustraidosAnimalDB.Save(myBienesSustraidosAnimal);
}

//  Assign the NNClaseGanado its new (or existing id).
myNNClaseGanado.id = nNClaseGanadoid;

myTransactionScope.Complete();

return nNClaseGanadoid;
}
}

/// <summary>
/// Deletes a NNClaseGanado from the database.
/// </summary>
/// <param name="myNNClaseGanado">The NNClaseGanado instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(NNClaseGanado myNNClaseGanado){
return NNClaseGanadoDB.Delete(myNNClaseGanado.id);
}

#endregion

}

}
