using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The NNClaseAgresionManager class is responsible for managing Business Object.NNClaseAgresion objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class NNClaseAgresionManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all NNClaseAgresion objects in the database.
/// </summary>
/// <returns>A list with all NNClaseAgresion from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static NNClaseAgresionList GetList(){
return NNClaseAgresionDB.GetList();
}

/// <summary>
/// Gets a single NNClaseAgresion from the database without its data.
/// </summary>
/// <param name="id">The id of the NNClaseAgresion in the database.</param>
/// <returns>A NNClaseAgresion object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseAgresion GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single NNClaseAgresion from the database.
/// </summary>
/// <param name="id">The id of the NNClaseAgresion in the database.</param>
/// <param name="getNNClaseAgresionRecords">Determines whether to load all associated NNClaseAgresion records as well.</param>
/// <returns>
/// A NNClaseAgresion object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseAgresion GetItem(int id, bool getNNClaseAgresionRecords){
NNClaseAgresion myNNClaseAgresion = NNClaseAgresionDB.GetItem(id);
if (myNNClaseAgresion != null && getNNClaseAgresionRecords){
myNNClaseAgresion.delitoss = DelitosDB.GetListByidClaseAgresion(id);
}
return myNNClaseAgresion;
}

/// <summary>
/// Saves a NNClaseAgresion in the database.
/// </summary>
/// <param name="myNNClaseAgresion">The NNClaseAgresion instance to save.</param>
/// <returns>The new id if the NNClaseAgresion is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(NNClaseAgresion myNNClaseAgresion){
using (TransactionScope myTransactionScope = new TransactionScope()){
int nNClaseAgresionid = NNClaseAgresionDB.Save(myNNClaseAgresion);
foreach (Delitos myDelitos in myNNClaseAgresion.delitoss){
myDelitos.id = nNClaseAgresionid;
DelitosDB.Save(myDelitos);
}
//  Assign the NNClaseAgresion its new (or existing id).
myNNClaseAgresion.id = nNClaseAgresionid;

myTransactionScope.Complete();

return nNClaseAgresionid;
}
}

/// <summary>
/// Deletes a NNClaseAgresion from the database.
/// </summary>
/// <param name="myNNClaseAgresion">The NNClaseAgresion instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(NNClaseAgresion myNNClaseAgresion){
return NNClaseAgresionDB.Delete(myNNClaseAgresion.id);
}

#endregion

}

}
