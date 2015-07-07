using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The NNClaseSubtipoArmaManager class is responsible for managing Business Entities.NNClaseSubtipoArma objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class NNClaseSubtipoArmaManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all NNClaseSubtipoArma objects in the database.
/// </summary>
/// <returns>A list with all NNClaseSubtipoArma from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static NNClaseSubtipoArmaList GetList(){
return NNClaseSubtipoArmaDB.GetList();
}

/// <summary>
/// Gets a list with all NNClaseSubtipoArma objects in the database.
/// </summary>
/// <returns>A list with all NNClaseSubtipoArma from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static NNClaseSubtipoArmaList GetListByidTipoArma(int idClaseArma)
{
    return NNClaseSubtipoArmaDB.GetListByidClaseArma(idClaseArma);
}

/// <summary>
/// Gets a single NNClaseSubtipoArma from the database without its data.
/// </summary>
/// <param name="id">The id of the NNClaseSubtipoArma in the database.</param>
/// <returns>A NNClaseSubtipoArma object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseSubtipoArma GetItem(short id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single NNClaseSubtipoArma from the database.
/// </summary>
/// <param name="id">The id of the NNClaseSubtipoArma in the database.</param>
/// <param name="getNNClaseSubtipoArmaRecords">Determines whether to load all associated NNClaseSubtipoArma records as well.</param>
/// <returns>
/// A NNClaseSubtipoArma object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseSubtipoArma GetItem(short id, bool getNNClaseSubtipoArmaRecords){
NNClaseSubtipoArma myNNClaseSubtipoArma = NNClaseSubtipoArmaDB.GetItem(id);
if (myNNClaseSubtipoArma != null && getNNClaseSubtipoArmaRecords){
myNNClaseSubtipoArma.delitoss = DelitosDB.GetListByidClaseSubTipoArma(id);
}
return myNNClaseSubtipoArma;
}

/// <summary>
/// Saves a NNClaseSubtipoArma in the database.
/// </summary>
/// <param name="myNNClaseSubtipoArma">The NNClaseSubtipoArma instance to save.</param>
/// <returns>The new id if the NNClaseSubtipoArma is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static short Save(NNClaseSubtipoArma myNNClaseSubtipoArma){
using (TransactionScope myTransactionScope = new TransactionScope()){
short nNClaseSubtipoArmaid = NNClaseSubtipoArmaDB.Save(myNNClaseSubtipoArma);
foreach (Delitos myDelitos in myNNClaseSubtipoArma.delitoss){
myDelitos.id = nNClaseSubtipoArmaid;
DelitosDB.Save(myDelitos);
}

//  Assign the NNClaseSubtipoArma its new (or existing id).
myNNClaseSubtipoArma.id = nNClaseSubtipoArmaid;

myTransactionScope.Complete();

return nNClaseSubtipoArmaid;
}
}

/// <summary>
/// Deletes a NNClaseSubtipoArma from the database.
/// </summary>
/// <param name="myNNClaseSubtipoArma">The NNClaseSubtipoArma instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(NNClaseSubtipoArma myNNClaseSubtipoArma){
return NNClaseSubtipoArmaDB.Delete(myNNClaseSubtipoArma.id);
}

#endregion

}

}
