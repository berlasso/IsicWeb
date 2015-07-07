using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The NNClaseLugarManager class is responsible for managing Business Object.NNClaseLugar objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class NNClaseLugarManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all NNClaseLugar objects in the database.
/// </summary>
/// <returns>A list with all NNClaseLugar from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static NNClaseLugarList GetList(){
return NNClaseLugarDB.GetList();
}

/// <summary>
/// Gets a single NNClaseLugar from the database without its data.
/// </summary>
/// <param name="id">The id of the NNClaseLugar in the database.</param>
/// <returns>A NNClaseLugar object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseLugar GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single NNClaseLugar from the database.
/// </summary>
/// <param name="id">The id of the NNClaseLugar in the database.</param>
/// <param name="getNNClaseLugarRecords">Determines whether to load all associated NNClaseLugar records as well.</param>
/// <returns>
/// A NNClaseLugar object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseLugar GetItem(int id, bool getNNClaseLugarRecords){
NNClaseLugar myNNClaseLugar = NNClaseLugarDB.GetItem(id);
if (myNNClaseLugar != null && getNNClaseLugarRecords){
myNNClaseLugar.delitoss = DelitosDB.GetListByidClaseLugar(id);
}
if (myNNClaseLugar != null && getNNClaseLugarRecords){
myNNClaseLugar.nNClaseRubros = NNClaseRubroDB.GetListByidClaseLugar(id);
}
return myNNClaseLugar;
}

/// <summary>
/// Saves a NNClaseLugar in the database.
/// </summary>
/// <param name="myNNClaseLugar">The NNClaseLugar instance to save.</param>
/// <returns>The new id if the NNClaseLugar is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(NNClaseLugar myNNClaseLugar){
using (TransactionScope myTransactionScope = new TransactionScope()){
int nNClaseLugarid = NNClaseLugarDB.Save(myNNClaseLugar);
foreach (Delitos myDelitos in myNNClaseLugar.delitoss){
myDelitos.id = nNClaseLugarid;
DelitosDB.Save(myDelitos);
}
foreach (NNClaseRubro myNNClaseRubro in myNNClaseLugar.nNClaseRubros){
myNNClaseRubro.id = nNClaseLugarid;
NNClaseRubroDB.Save(myNNClaseRubro);
}

//  Assign the NNClaseLugar its new (or existing id).
myNNClaseLugar.id = nNClaseLugarid;

myTransactionScope.Complete();

return nNClaseLugarid;
}
}

/// <summary>
/// Deletes a NNClaseLugar from the database.
/// </summary>
/// <param name="myNNClaseLugar">The NNClaseLugar instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(NNClaseLugar myNNClaseLugar){
return NNClaseLugarDB.Delete(myNNClaseLugar.id);
}

#endregion

}

}
