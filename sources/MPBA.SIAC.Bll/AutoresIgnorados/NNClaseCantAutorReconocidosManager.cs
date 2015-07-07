using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The NNClaseCantAutorReconocidosManager class is responsible for managing Business Object.NNClaseCantAutorReconocidos objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class NNClaseCantAutorReconocidosManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all NNClaseCantAutorReconocidos objects in the database.
/// </summary>
/// <returns>A list with all NNClaseCantAutorReconocidos from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static NNClaseCantAutorReconocidosList GetList(){
return NNClaseCantAutorReconocidosDB.GetList();
}

/// <summary>
/// Gets a single NNClaseCantAutorReconocidos from the database without its data.
/// </summary>
/// <param name="id">The id of the NNClaseCantAutorReconocidos in the database.</param>
/// <returns>A NNClaseCantAutorReconocidos object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseCantAutorReconocidos GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single NNClaseCantAutorReconocidos from the database.
/// </summary>
/// <param name="id">The id of the NNClaseCantAutorReconocidos in the database.</param>
/// <param name="getNNClaseCantAutorReconocidosRecords">Determines whether to load all associated NNClaseCantAutorReconocidos records as well.</param>
/// <returns>
/// A NNClaseCantAutorReconocidos object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseCantAutorReconocidos GetItem(int id, bool getNNClaseCantAutorReconocidosRecords){
NNClaseCantAutorReconocidos myNNClaseCantAutorReconocidos = NNClaseCantAutorReconocidosDB.GetItem(id);
if (myNNClaseCantAutorReconocidos != null && getNNClaseCantAutorReconocidosRecords){
myNNClaseCantAutorReconocidos.delitoss = DelitosDB.GetListByidClaseCantAutorReconocidos(id);
}
return myNNClaseCantAutorReconocidos;
}

/// <summary>
/// Saves a NNClaseCantAutorReconocidos in the database.
/// </summary>
/// <param name="myNNClaseCantAutorReconocidos">The NNClaseCantAutorReconocidos instance to save.</param>
/// <returns>The new id if the NNClaseCantAutorReconocidos is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(NNClaseCantAutorReconocidos myNNClaseCantAutorReconocidos){
using (TransactionScope myTransactionScope = new TransactionScope()){
int nNClaseCantAutorReconocidosid = NNClaseCantAutorReconocidosDB.Save(myNNClaseCantAutorReconocidos);
foreach (Delitos myDelitos in myNNClaseCantAutorReconocidos.delitoss){
myDelitos.id = nNClaseCantAutorReconocidosid;
DelitosDB.Save(myDelitos);
}

//  Assign the NNClaseCantAutorReconocidos its new (or existing id).
myNNClaseCantAutorReconocidos.id = nNClaseCantAutorReconocidosid;

myTransactionScope.Complete();

return nNClaseCantAutorReconocidosid;
}
}

/// <summary>
/// Deletes a NNClaseCantAutorReconocidos from the database.
/// </summary>
/// <param name="myNNClaseCantAutorReconocidos">The NNClaseCantAutorReconocidos instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(NNClaseCantAutorReconocidos myNNClaseCantAutorReconocidos){
return NNClaseCantAutorReconocidosDB.Delete(myNNClaseCantAutorReconocidos.id);
}

#endregion

}

}
