using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The NNClaseZonaCuerpoLesionadaManager class is responsible for managing Business Object.NNClaseZonaCuerpoLesionada objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class NNClaseZonaCuerpoLesionadaManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all NNClaseZonaCuerpoLesionada objects in the database.
/// </summary>
/// <returns>A list with all NNClaseZonaCuerpoLesionada from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static NNClaseZonaCuerpoLesionadaList GetList(){
return NNClaseZonaCuerpoLesionadaDB.GetList();
}

/// <summary>
/// Gets a single NNClaseZonaCuerpoLesionada from the database without its data.
/// </summary>
/// <param name="id">The id of the NNClaseZonaCuerpoLesionada in the database.</param>
/// <returns>A NNClaseZonaCuerpoLesionada object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseZonaCuerpoLesionada GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single NNClaseZonaCuerpoLesionada from the database.
/// </summary>
/// <param name="id">The id of the NNClaseZonaCuerpoLesionada in the database.</param>
/// <param name="getNNClaseZonaCuerpoLesionadaRecords">Determines whether to load all associated NNClaseZonaCuerpoLesionada records as well.</param>
/// <returns>
/// A NNClaseZonaCuerpoLesionada object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseZonaCuerpoLesionada GetItem(int id, bool getNNClaseZonaCuerpoLesionadaRecords){
NNClaseZonaCuerpoLesionada myNNClaseZonaCuerpoLesionada = NNClaseZonaCuerpoLesionadaDB.GetItem(id);
if (myNNClaseZonaCuerpoLesionada != null && getNNClaseZonaCuerpoLesionadaRecords){
myNNClaseZonaCuerpoLesionada.delitoss = DelitosDB.GetListByidClaseZonaCuerpoLesionada(id);
}
return myNNClaseZonaCuerpoLesionada;
}

/// <summary>
/// Saves a NNClaseZonaCuerpoLesionada in the database.
/// </summary>
/// <param name="myNNClaseZonaCuerpoLesionada">The NNClaseZonaCuerpoLesionada instance to save.</param>
/// <returns>The new id if the NNClaseZonaCuerpoLesionada is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(NNClaseZonaCuerpoLesionada myNNClaseZonaCuerpoLesionada){
using (TransactionScope myTransactionScope = new TransactionScope()){
int nNClaseZonaCuerpoLesionadaid = NNClaseZonaCuerpoLesionadaDB.Save(myNNClaseZonaCuerpoLesionada);
foreach (Delitos myDelitos in myNNClaseZonaCuerpoLesionada.delitoss){
myDelitos.id = nNClaseZonaCuerpoLesionadaid;
DelitosDB.Save(myDelitos);
}

//  Assign the NNClaseZonaCuerpoLesionada its new (or existing id).
myNNClaseZonaCuerpoLesionada.id = nNClaseZonaCuerpoLesionadaid;

myTransactionScope.Complete();

return nNClaseZonaCuerpoLesionadaid;
}
}

/// <summary>
/// Deletes a NNClaseZonaCuerpoLesionada from the database.
/// </summary>
/// <param name="myNNClaseZonaCuerpoLesionada">The NNClaseZonaCuerpoLesionada instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(NNClaseZonaCuerpoLesionada myNNClaseZonaCuerpoLesionada){
return NNClaseZonaCuerpoLesionadaDB.Delete(myNNClaseZonaCuerpoLesionada.id);
}

#endregion

}

}
