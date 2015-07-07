using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The NNClaseTipoDelitoManager class is responsible for managing Business Entities.NNClaseTipoDelito objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class NNClaseTipoDelitoManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all NNClaseTipoDelito objects in the database.
/// </summary>
/// <returns>A list with all NNClaseTipoDelito from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static NNClaseTipoDelitoList GetList(){
return NNClaseTipoDelitoDB.GetList();
}

/// <summary>
/// Gets a single NNClaseTipoDelito from the database without its data.
/// </summary>
/// <param name="id">The id of the NNClaseTipoDelito in the database.</param>
/// <returns>A NNClaseTipoDelito object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseTipoDelito GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single NNClaseTipoDelito from the database.
/// </summary>
/// <param name="id">The id of the NNClaseTipoDelito in the database.</param>
/// <param name="getNNClaseTipoDelitoRecords">Determines whether to load all associated NNClaseTipoDelito records as well.</param>
/// <returns>
/// A NNClaseTipoDelito object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseTipoDelito GetItem(int id, bool getNNClaseTipoDelitoRecords){
NNClaseTipoDelito myNNClaseTipoDelito = NNClaseTipoDelitoDB.GetItem(id);
if (myNNClaseTipoDelito != null && getNNClaseTipoDelitoRecords){
myNNClaseTipoDelito.delitoss = DelitosDB.GetListByidClaseDelito(id);
}
return myNNClaseTipoDelito;
}

/// <summary>
/// Saves a NNClaseTipoDelito in the database.
/// </summary>
/// <param name="myNNClaseTipoDelito">The NNClaseTipoDelito instance to save.</param>
/// <returns>The new id if the NNClaseTipoDelito is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(NNClaseTipoDelito myNNClaseTipoDelito){
using (TransactionScope myTransactionScope = new TransactionScope()){
int nNClaseTipoDelitoid = NNClaseTipoDelitoDB.Save(myNNClaseTipoDelito);
foreach (Delitos myDelitos in myNNClaseTipoDelito.delitoss){
myDelitos.id = nNClaseTipoDelitoid;
DelitosDB.Save(myDelitos);
}

//  Assign the NNClaseTipoDelito its new (or existing id).
myNNClaseTipoDelito.id = nNClaseTipoDelitoid;

myTransactionScope.Complete();

return nNClaseTipoDelitoid;
}
}

/// <summary>
/// Deletes a NNClaseTipoDelito from the database.
/// </summary>
/// <param name="myNNClaseTipoDelito">The NNClaseTipoDelito instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(NNClaseTipoDelito myNNClaseTipoDelito){
return NNClaseTipoDelitoDB.Delete(myNNClaseTipoDelito.id);
}

#endregion

}

}
