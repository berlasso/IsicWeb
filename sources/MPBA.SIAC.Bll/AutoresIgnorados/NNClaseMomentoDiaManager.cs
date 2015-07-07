using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The NNClaseMomentoDiaManager class is responsible for managing Business Object.NNClaseMomentoDia objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class NNClaseMomentoDiaManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all NNClaseMomentoDia objects in the database.
/// </summary>
/// <returns>A list with all NNClaseMomentoDia from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static NNClaseMomentoDiaList GetList(){
return NNClaseMomentoDiaDB.GetList();
}

/// <summary>
/// Gets a single NNClaseMomentoDia from the database without its data.
/// </summary>
/// <param name="id">The id of the NNClaseMomentoDia in the database.</param>
/// <returns>A NNClaseMomentoDia object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseMomentoDia GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single NNClaseMomentoDia from the database.
/// </summary>
/// <param name="id">The id of the NNClaseMomentoDia in the database.</param>
/// <param name="getNNClaseMomentoDiaRecords">Determines whether to load all associated NNClaseMomentoDia records as well.</param>
/// <returns>
/// A NNClaseMomentoDia object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseMomentoDia GetItem(int id, bool getNNClaseMomentoDiaRecords){
NNClaseMomentoDia myNNClaseMomentoDia = NNClaseMomentoDiaDB.GetItem(id);
if (myNNClaseMomentoDia != null && getNNClaseMomentoDiaRecords){
myNNClaseMomentoDia.delitoss = DelitosDB.GetListByidClaseMomentoDelDia(id);
}
return myNNClaseMomentoDia;
}

/// <summary>
/// Saves a NNClaseMomentoDia in the database.
/// </summary>
/// <param name="myNNClaseMomentoDia">The NNClaseMomentoDia instance to save.</param>
/// <returns>The new id if the NNClaseMomentoDia is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(NNClaseMomentoDia myNNClaseMomentoDia){
using (TransactionScope myTransactionScope = new TransactionScope()){
int nNClaseMomentoDiaid = NNClaseMomentoDiaDB.Save(myNNClaseMomentoDia);
foreach (Delitos myDelitos in myNNClaseMomentoDia.delitoss){
myDelitos.id = nNClaseMomentoDiaid;
DelitosDB.Save(myDelitos);
}

//  Assign the NNClaseMomentoDia its new (or existing id).
myNNClaseMomentoDia.id = nNClaseMomentoDiaid;

myTransactionScope.Complete();

return nNClaseMomentoDiaid;
}
}

/// <summary>
/// Deletes a NNClaseMomentoDia from the database.
/// </summary>
/// <param name="myNNClaseMomentoDia">The NNClaseMomentoDia instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(NNClaseMomentoDia myNNClaseMomentoDia){
return NNClaseMomentoDiaDB.Delete(myNNClaseMomentoDia.id);
}

#endregion

}

}
