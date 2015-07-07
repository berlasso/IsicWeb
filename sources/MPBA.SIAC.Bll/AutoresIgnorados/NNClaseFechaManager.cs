using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The NNClaseFechaManager class is responsible for managing Business Object.NNClaseFecha objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class NNClaseFechaManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all NNClaseFecha objects in the database.
/// </summary>
/// <returns>A list with all NNClaseFecha from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static NNClaseFechaList GetList(){
return NNClaseFechaDB.GetList();
}

/// <summary>
/// Gets a single NNClaseFecha from the database without its data.
/// </summary>
/// <param name="id">The id of the NNClaseFecha in the database.</param>
/// <returns>A NNClaseFecha object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseFecha GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single NNClaseFecha from the database.
/// </summary>
/// <param name="id">The id of the NNClaseFecha in the database.</param>
/// <param name="getNNClaseFechaRecords">Determines whether to load all associated NNClaseFecha records as well.</param>
/// <returns>
/// A NNClaseFecha object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseFecha GetItem(int id, bool getNNClaseFechaRecords){
NNClaseFecha myNNClaseFecha = NNClaseFechaDB.GetItem(id);
if (myNNClaseFecha != null && getNNClaseFechaRecords){
myNNClaseFecha.delitoss = DelitosDB.GetListByidClaseFecha(id);
}
return myNNClaseFecha;
}

/// <summary>
/// Saves a NNClaseFecha in the database.
/// </summary>
/// <param name="myNNClaseFecha">The NNClaseFecha instance to save.</param>
/// <returns>The new id if the NNClaseFecha is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(NNClaseFecha myNNClaseFecha){
using (TransactionScope myTransactionScope = new TransactionScope()){
int nNClaseFechaid = NNClaseFechaDB.Save(myNNClaseFecha);
foreach (Delitos myDelitos in myNNClaseFecha.delitoss){
myDelitos.id = nNClaseFechaid;
DelitosDB.Save(myDelitos);
}

//  Assign the NNClaseFecha its new (or existing id).
myNNClaseFecha.id = nNClaseFechaid;

myTransactionScope.Complete();

return nNClaseFechaid;
}
}

/// <summary>
/// Deletes a NNClaseFecha from the database.
/// </summary>
/// <param name="myNNClaseFecha">The NNClaseFecha instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(NNClaseFecha myNNClaseFecha){
return NNClaseFechaDB.Delete(myNNClaseFecha.id);
}

#endregion

}

}
