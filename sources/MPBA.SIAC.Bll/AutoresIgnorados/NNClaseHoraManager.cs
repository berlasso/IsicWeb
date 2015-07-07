using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The NNClaseHoraManager class is responsible for managing Business Object.NNClaseHora objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class NNClaseHoraManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all NNClaseHora objects in the database.
/// </summary>
/// <returns>A list with all NNClaseHora from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static NNClaseHoraList GetList(){
return NNClaseHoraDB.GetList();
}

/// <summary>
/// Gets a single NNClaseHora from the database without its data.
/// </summary>
/// <param name="id">The id of the NNClaseHora in the database.</param>
/// <returns>A NNClaseHora object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseHora GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single NNClaseHora from the database.
/// </summary>
/// <param name="id">The id of the NNClaseHora in the database.</param>
/// <param name="getNNClaseHoraRecords">Determines whether to load all associated NNClaseHora records as well.</param>
/// <returns>
/// A NNClaseHora object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseHora GetItem(int id, bool getNNClaseHoraRecords){
NNClaseHora myNNClaseHora = NNClaseHoraDB.GetItem(id);
if (myNNClaseHora != null && getNNClaseHoraRecords){
myNNClaseHora.delitoss = DelitosDB.GetListByidClaseHora(id);
}
return myNNClaseHora;
}

/// <summary>
/// Saves a NNClaseHora in the database.
/// </summary>
/// <param name="myNNClaseHora">The NNClaseHora instance to save.</param>
/// <returns>The new id if the NNClaseHora is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(NNClaseHora myNNClaseHora){
using (TransactionScope myTransactionScope = new TransactionScope()){
int nNClaseHoraid = NNClaseHoraDB.Save(myNNClaseHora);
foreach (Delitos myDelitos in myNNClaseHora.delitoss){
myDelitos.id = nNClaseHoraid;
DelitosDB.Save(myDelitos);
}

//  Assign the NNClaseHora its new (or existing id).
myNNClaseHora.id = nNClaseHoraid;

myTransactionScope.Complete();

return nNClaseHoraid;
}
}

/// <summary>
/// Deletes a NNClaseHora from the database.
/// </summary>
/// <param name="myNNClaseHora">The NNClaseHora instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(NNClaseHora myNNClaseHora){
return NNClaseHoraDB.Delete(myNNClaseHora.id);
}

#endregion

}

}
