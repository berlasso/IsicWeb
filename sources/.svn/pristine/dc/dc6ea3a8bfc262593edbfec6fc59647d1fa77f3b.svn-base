using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The NNClaseCantidadAutoresManager class is responsible for managing Business Object.NNClaseCantidadAutores objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class NNClaseCantidadAutoresManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all NNClaseCantidadAutores objects in the database.
/// </summary>
/// <returns>A list with all NNClaseCantidadAutores from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static NNClaseCantidadAutoresList GetList(){
return NNClaseCantidadAutoresDB.GetList();
}

/// <summary>
/// Gets a single NNClaseCantidadAutores from the database without its data.
/// </summary>
/// <param name="id">The id of the NNClaseCantidadAutores in the database.</param>
/// <returns>A NNClaseCantidadAutores object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseCantidadAutores GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single NNClaseCantidadAutores from the database.
/// </summary>
/// <param name="id">The id of the NNClaseCantidadAutores in the database.</param>
/// <param name="getNNClaseCantidadAutoresRecords">Determines whether to load all associated NNClaseCantidadAutores records as well.</param>
/// <returns>
/// A NNClaseCantidadAutores object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseCantidadAutores GetItem(int id, bool getNNClaseCantidadAutoresRecords){
NNClaseCantidadAutores myNNClaseCantidadAutores = NNClaseCantidadAutoresDB.GetItem(id);
if (myNNClaseCantidadAutores != null && getNNClaseCantidadAutoresRecords){
myNNClaseCantidadAutores.delitoss = DelitosDB.GetListByidClaseCantidadAutores(id);
}
return myNNClaseCantidadAutores;
}

/// <summary>
/// Saves a NNClaseCantidadAutores in the database.
/// </summary>
/// <param name="myNNClaseCantidadAutores">The NNClaseCantidadAutores instance to save.</param>
/// <returns>The new id if the NNClaseCantidadAutores is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(NNClaseCantidadAutores myNNClaseCantidadAutores){
using (TransactionScope myTransactionScope = new TransactionScope()){
int nNClaseCantidadAutoresid = NNClaseCantidadAutoresDB.Save(myNNClaseCantidadAutores);
foreach (Delitos myDelitos in myNNClaseCantidadAutores.delitoss){
myDelitos.id = nNClaseCantidadAutoresid;
DelitosDB.Save(myDelitos);
}

//  Assign the NNClaseCantidadAutores its new (or existing id).
myNNClaseCantidadAutores.id = nNClaseCantidadAutoresid;

myTransactionScope.Complete();

return nNClaseCantidadAutoresid;
}
}

/// <summary>
/// Deletes a NNClaseCantidadAutores from the database.
/// </summary>
/// <param name="myNNClaseCantidadAutores">The NNClaseCantidadAutores instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(NNClaseCantidadAutores myNNClaseCantidadAutores){
return NNClaseCantidadAutoresDB.Delete(myNNClaseCantidadAutores.id);
}

#endregion

}

}
