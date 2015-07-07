using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The NNClaseModusOperandiManager class is responsible for managing Business Object.NNClaseModusOperandi objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class NNClaseModusOperandiManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all NNClaseModusOperandi objects in the database.
/// </summary>
/// <returns>A list with all NNClaseModusOperandi from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static NNClaseModusOperandiList GetList(){
return NNClaseModusOperandiDB.GetList();
}

/// <summary>
/// Gets a single NNClaseModusOperandi from the database without its data.
/// </summary>
/// <param name="id">The id of the NNClaseModusOperandi in the database.</param>
/// <returns>A NNClaseModusOperandi object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseModusOperandi GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single NNClaseModusOperandi from the database.
/// </summary>
/// <param name="id">The id of the NNClaseModusOperandi in the database.</param>
/// <param name="getNNClaseModusOperandiRecords">Determines whether to load all associated NNClaseModusOperandi records as well.</param>
/// <returns>
/// A NNClaseModusOperandi object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseModusOperandi GetItem(int id, bool getNNClaseModusOperandiRecords){
NNClaseModusOperandi myNNClaseModusOperandi = NNClaseModusOperandiDB.GetItem(id);
if (myNNClaseModusOperandi != null && getNNClaseModusOperandiRecords){
myNNClaseModusOperandi.delitoss = DelitosDB.GetListByidClaseModusOperandis(id);
}
return myNNClaseModusOperandi;
}

/// <summary>
/// Saves a NNClaseModusOperandi in the database.
/// </summary>
/// <param name="myNNClaseModusOperandi">The NNClaseModusOperandi instance to save.</param>
/// <returns>The new id if the NNClaseModusOperandi is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(NNClaseModusOperandi myNNClaseModusOperandi){
using (TransactionScope myTransactionScope = new TransactionScope()){
int nNClaseModusOperandiid = NNClaseModusOperandiDB.Save(myNNClaseModusOperandi);
foreach (Delitos myDelitos in myNNClaseModusOperandi.delitoss){
myDelitos.id = nNClaseModusOperandiid;
DelitosDB.Save(myDelitos);
}

//  Assign the NNClaseModusOperandi its new (or existing id).
myNNClaseModusOperandi.id = nNClaseModusOperandiid;

myTransactionScope.Complete();

return nNClaseModusOperandiid;
}
}

/// <summary>
/// Deletes a NNClaseModusOperandi from the database.
/// </summary>
/// <param name="myNNClaseModusOperandi">The NNClaseModusOperandi instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(NNClaseModusOperandi myNNClaseModusOperandi){
return NNClaseModusOperandiDB.Delete(myNNClaseModusOperandi.id);
}

#endregion

}

}
