using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The NNClaseLugarCuerpoManager class is responsible for managing Business Object.NNClaseLugarCuerpo objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class NNClaseLugarCuerpoManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all NNClaseLugarCuerpo objects in the database.
/// </summary>
/// <returns>A list with all NNClaseLugarCuerpo from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static NNClaseLugarCuerpoList GetList(){
return NNClaseLugarCuerpoDB.GetList();
}

/// <summary>
/// Gets a single NNClaseLugarCuerpo from the database without its data.
/// </summary>
/// <param name="id">The id of the NNClaseLugarCuerpo in the database.</param>
/// <returns>A NNClaseLugarCuerpo object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseLugarCuerpo GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single NNClaseLugarCuerpo from the database.
/// </summary>
/// <param name="id">The id of the NNClaseLugarCuerpo in the database.</param>
/// <param name="getNNClaseLugarCuerpoRecords">Determines whether to load all associated NNClaseLugarCuerpo records as well.</param>
/// <returns>
/// A NNClaseLugarCuerpo object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseLugarCuerpo GetItem(int id, bool getNNClaseLugarCuerpoRecords){
NNClaseLugarCuerpo myNNClaseLugarCuerpo = NNClaseLugarCuerpoDB.GetItem(id);
if (myNNClaseLugarCuerpo != null && getNNClaseLugarCuerpoRecords){
myNNClaseLugarCuerpo.autoress = AutoresDB.GetListByidClaseLugarDelCuerpo(id);
}
return myNNClaseLugarCuerpo;
}

/// <summary>
/// Saves a NNClaseLugarCuerpo in the database.
/// </summary>
/// <param name="myNNClaseLugarCuerpo">The NNClaseLugarCuerpo instance to save.</param>
/// <returns>The new id if the NNClaseLugarCuerpo is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(NNClaseLugarCuerpo myNNClaseLugarCuerpo){
using (TransactionScope myTransactionScope = new TransactionScope()){
int nNClaseLugarCuerpoid = NNClaseLugarCuerpoDB.Save(myNNClaseLugarCuerpo);
foreach (Autores myAutores in myNNClaseLugarCuerpo.autoress){
myAutores.id = nNClaseLugarCuerpoid;
AutoresDB.Save(myAutores);
}

//  Assign the NNClaseLugarCuerpo its new (or existing id).
myNNClaseLugarCuerpo.id = nNClaseLugarCuerpoid;

myTransactionScope.Complete();

return nNClaseLugarCuerpoid;
}
}

/// <summary>
/// Deletes a NNClaseLugarCuerpo from the database.
/// </summary>
/// <param name="myNNClaseLugarCuerpo">The NNClaseLugarCuerpo instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(NNClaseLugarCuerpo myNNClaseLugarCuerpo){
return NNClaseLugarCuerpoDB.Delete(myNNClaseLugarCuerpo.id);
}

#endregion

}

}
