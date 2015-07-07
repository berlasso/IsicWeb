using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The NNClaseSexoManager class is responsible for managing Business Object.NNClaseSexo objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class NNClaseSexoManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all NNClaseSexo objects in the database.
/// </summary>
/// <returns>A list with all NNClaseSexo from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static NNClaseSexoList GetList(){
return NNClaseSexoDB.GetList();
}

/// <summary>
/// Gets a single NNClaseSexo from the database without its data.
/// </summary>
/// <param name="id">The id of the NNClaseSexo in the database.</param>
/// <returns>A NNClaseSexo object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseSexo GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single NNClaseSexo from the database.
/// </summary>
/// <param name="id">The id of the NNClaseSexo in the database.</param>
/// <param name="getNNClaseSexoRecords">Determines whether to load all associated NNClaseSexo records as well.</param>
/// <returns>
/// A NNClaseSexo object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseSexo GetItem(int id, bool getNNClaseSexoRecords){
NNClaseSexo myNNClaseSexo = NNClaseSexoDB.GetItem(id);
if (myNNClaseSexo != null && getNNClaseSexoRecords){
myNNClaseSexo.autoress = AutoresDB.GetListByidClaseSexo(id);
}
return myNNClaseSexo;
}

/// <summary>
/// Saves a NNClaseSexo in the database.
/// </summary>
/// <param name="myNNClaseSexo">The NNClaseSexo instance to save.</param>
/// <returns>The new id if the NNClaseSexo is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(NNClaseSexo myNNClaseSexo){
using (TransactionScope myTransactionScope = new TransactionScope()){
int nNClaseSexoid = NNClaseSexoDB.Save(myNNClaseSexo);
foreach (Autores myAutores in myNNClaseSexo.autoress){
myAutores.id = nNClaseSexoid;
AutoresDB.Save(myAutores);
}

//  Assign the NNClaseSexo its new (or existing id).
myNNClaseSexo.id = nNClaseSexoid;

myTransactionScope.Complete();

return nNClaseSexoid;
}
}

/// <summary>
/// Deletes a NNClaseSexo from the database.
/// </summary>
/// <param name="myNNClaseSexo">The NNClaseSexo instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(NNClaseSexo myNNClaseSexo){
return NNClaseSexoDB.Delete(myNNClaseSexo.id);
}

#endregion

}

}
