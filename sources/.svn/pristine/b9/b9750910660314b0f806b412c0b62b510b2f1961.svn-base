using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The NNClaseArmaManager class is responsible for managing Business Object.NNClaseArma objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class NNClaseArmaManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all NNClaseArma objects in the database.
/// </summary>
/// <returns>A list with all NNClaseArma from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static NNClaseArmaList GetList(){
return NNClaseArmaDB.GetList();
}

/// <summary>
/// Gets a single NNClaseArma from the database without its data.
/// </summary>
/// <param name="id">The id of the NNClaseArma in the database.</param>
/// <returns>A NNClaseArma object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseArma GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single NNClaseArma from the database.
/// </summary>
/// <param name="id">The id of the NNClaseArma in the database.</param>
/// <param name="getNNClaseArmaRecords">Determines whether to load all associated NNClaseArma records as well.</param>
/// <returns>
/// A NNClaseArma object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseArma GetItem(int id, bool getNNClaseArmaRecords){
NNClaseArma myNNClaseArma = NNClaseArmaDB.GetItem(id);
if (myNNClaseArma != null && getNNClaseArmaRecords){
myNNClaseArma.delitoss = DelitosDB.GetListByidClaseArma(id);
}
return myNNClaseArma;
}

/// <summary>
/// Saves a NNClaseArma in the database.
/// </summary>
/// <param name="myNNClaseArma">The NNClaseArma instance to save.</param>
/// <returns>The new id if the NNClaseArma is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(NNClaseArma myNNClaseArma){
using (TransactionScope myTransactionScope = new TransactionScope()){
int nNClaseArmaid = NNClaseArmaDB.Save(myNNClaseArma);
foreach (Delitos myDelitos in myNNClaseArma.delitoss){
myDelitos.id = nNClaseArmaid;
DelitosDB.Save(myDelitos);
}

//  Assign the NNClaseArma its new (or existing id).
myNNClaseArma.id = nNClaseArmaid;

myTransactionScope.Complete();

return nNClaseArmaid;
}
}

/// <summary>
/// Deletes a NNClaseArma from the database.
/// </summary>
/// <param name="myNNClaseArma">The NNClaseArma instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(NNClaseArma myNNClaseArma){
return NNClaseArmaDB.Delete(myNNClaseArma.id);
}

#endregion

}

}
