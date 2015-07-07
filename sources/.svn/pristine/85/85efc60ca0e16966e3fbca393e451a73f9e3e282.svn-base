using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The NNClaseCondicionVictimaManager class is responsible for managing Business Object.NNClaseCondicionVictima objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class NNClaseCondicionVictimaManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all NNClaseCondicionVictima objects in the database.
/// </summary>
/// <returns>A list with all NNClaseCondicionVictima from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static NNClaseCondicionVictimaList GetList(){
return NNClaseCondicionVictimaDB.GetList();
}

/// <summary>
/// Gets a single NNClaseCondicionVictima from the database without its data.
/// </summary>
/// <param name="id">The id of the NNClaseCondicionVictima in the database.</param>
/// <returns>A NNClaseCondicionVictima object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseCondicionVictima GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single NNClaseCondicionVictima from the database.
/// </summary>
/// <param name="id">The id of the NNClaseCondicionVictima in the database.</param>
/// <param name="getNNClaseCondicionVictimaRecords">Determines whether to load all associated NNClaseCondicionVictima records as well.</param>
/// <returns>
/// A NNClaseCondicionVictima object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseCondicionVictima GetItem(int id, bool getNNClaseCondicionVictimaRecords){
NNClaseCondicionVictima myNNClaseCondicionVictima = NNClaseCondicionVictimaDB.GetItem(id);
if (myNNClaseCondicionVictima != null && getNNClaseCondicionVictimaRecords){
myNNClaseCondicionVictima.delitoss = DelitosDB.GetListByidClaseCondicionVictima(id);
}
return myNNClaseCondicionVictima;
}

/// <summary>
/// Saves a NNClaseCondicionVictima in the database.
/// </summary>
/// <param name="myNNClaseCondicionVictima">The NNClaseCondicionVictima instance to save.</param>
/// <returns>The new id if the NNClaseCondicionVictima is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(NNClaseCondicionVictima myNNClaseCondicionVictima){
using (TransactionScope myTransactionScope = new TransactionScope()){
int nNClaseCondicionVictimaid = NNClaseCondicionVictimaDB.Save(myNNClaseCondicionVictima);
foreach (Delitos myDelitos in myNNClaseCondicionVictima.delitoss){
myDelitos.id = nNClaseCondicionVictimaid;
DelitosDB.Save(myDelitos);
}

//  Assign the NNClaseCondicionVictima its new (or existing id).
myNNClaseCondicionVictima.id = nNClaseCondicionVictimaid;

myTransactionScope.Complete();

return nNClaseCondicionVictimaid;
}
}

/// <summary>
/// Deletes a NNClaseCondicionVictima from the database.
/// </summary>
/// <param name="myNNClaseCondicionVictima">The NNClaseCondicionVictima instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(NNClaseCondicionVictima myNNClaseCondicionVictima){
return NNClaseCondicionVictimaDB.Delete(myNNClaseCondicionVictima.id);
}

#endregion

}

}
