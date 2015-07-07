using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The NNClaseTipoAutorManager class is responsible for managing Business Entities.NNClaseTipoAutor objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class NNClaseTipoAutorManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all NNClaseTipoAutor objects in the database.
/// </summary>
/// <returns>A list with all NNClaseTipoAutor from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static NNClaseTipoAutorList GetList(){
return NNClaseTipoAutorDB.GetList();
}

/// <summary>
/// Gets a single NNClaseTipoAutor from the database without its data.
/// </summary>
/// <param name="id">The id of the NNClaseTipoAutor in the database.</param>
/// <returns>A NNClaseTipoAutor object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseTipoAutor GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single NNClaseTipoAutor from the database.
/// </summary>
/// <param name="id">The id of the NNClaseTipoAutor in the database.</param>
/// <param name="getNNClaseTipoAutorRecords">Determines whether to load all associated NNClaseTipoAutor records as well.</param>
/// <returns>
/// A NNClaseTipoAutor object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseTipoAutor GetItem(int id, bool getNNClaseTipoAutorRecords){
NNClaseTipoAutor myNNClaseTipoAutor = NNClaseTipoAutorDB.GetItem(id);
return myNNClaseTipoAutor;
}

/// <summary>
/// Saves a NNClaseTipoAutor in the database.
/// </summary>
/// <param name="myNNClaseTipoAutor">The NNClaseTipoAutor instance to save.</param>
/// <returns>The new id if the NNClaseTipoAutor is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(NNClaseTipoAutor myNNClaseTipoAutor){
using (TransactionScope myTransactionScope = new TransactionScope()){
int nNClaseTipoAutorid = NNClaseTipoAutorDB.Save(myNNClaseTipoAutor);

//  Assign the NNClaseTipoAutor its new (or existing id).
myNNClaseTipoAutor.id = nNClaseTipoAutorid;

myTransactionScope.Complete();

return nNClaseTipoAutorid;
}
}

/// <summary>
/// Deletes a NNClaseTipoAutor from the database.
/// </summary>
/// <param name="myNNClaseTipoAutor">The NNClaseTipoAutor instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(NNClaseTipoAutor myNNClaseTipoAutor){
return NNClaseTipoAutorDB.Delete(myNNClaseTipoAutor.id);
}

#endregion

}

}
