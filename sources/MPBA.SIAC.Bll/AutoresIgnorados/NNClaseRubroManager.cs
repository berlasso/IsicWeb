using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The NNClaseRubroManager class is responsible for managing Business Object.NNClaseRubro objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class NNClaseRubroManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all NNClaseRubro objects in the database.
/// </summary>
/// <returns>A list with all NNClaseRubro from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static NNClaseRubroList GetList(){
return NNClaseRubroDB.GetList();
}

/// <summary>
/// Gets a list with all NNClaseRubro objects in the database.
/// </summary>
/// <returns>A list with all NNClaseRubro from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static NNClaseRubroList GetListByidClaseLugar(int idClaseLugar)
{
    return NNClaseRubroDB.GetListByidClaseLugar(idClaseLugar);
}

/// <summary>
/// Gets a single NNClaseRubro from the database without its data.
/// </summary>
/// <param name="id">The id of the NNClaseRubro in the database.</param>
/// <returns>A NNClaseRubro object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseRubro GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single NNClaseRubro from the database.
/// </summary>
/// <param name="id">The id of the NNClaseRubro in the database.</param>
/// <param name="getNNClaseRubroRecords">Determines whether to load all associated NNClaseRubro records as well.</param>
/// <returns>
/// A NNClaseRubro object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseRubro GetItem(int id, bool getNNClaseRubroRecords){
NNClaseRubro myNNClaseRubro = NNClaseRubroDB.GetItem(id);
if (myNNClaseRubro != null && getNNClaseRubroRecords){
myNNClaseRubro.delitoss = DelitosDB.GetListByidClaseRubro(id);
}
return myNNClaseRubro;
}

/// <summary>
/// Saves a NNClaseRubro in the database.
/// </summary>
/// <param name="myNNClaseRubro">The NNClaseRubro instance to save.</param>
/// <returns>The new id if the NNClaseRubro is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(NNClaseRubro myNNClaseRubro){
using (TransactionScope myTransactionScope = new TransactionScope()){
int nNClaseRubroid = NNClaseRubroDB.Save(myNNClaseRubro);
foreach (Delitos myDelitos in myNNClaseRubro.delitoss){
myDelitos.id = nNClaseRubroid;
DelitosDB.Save(myDelitos);
}

//  Assign the NNClaseRubro its new (or existing id).
myNNClaseRubro.id = nNClaseRubroid;

myTransactionScope.Complete();

return nNClaseRubroid;
}
}

/// <summary>
/// Deletes a NNClaseRubro from the database.
/// </summary>
/// <param name="myNNClaseRubro">The NNClaseRubro instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(NNClaseRubro myNNClaseRubro){
return NNClaseRubroDB.Delete(myNNClaseRubro.id);
}

#endregion

}

}
