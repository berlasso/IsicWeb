using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The NNClaseEdadAproximadaManager class is responsible for managing Business Object.NNClaseEdadAproximada objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class NNClaseEdadAproximadaManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all NNClaseEdadAproximada objects in the database.
/// </summary>
/// <returns>A list with all NNClaseEdadAproximada from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static NNClaseEdadAproximadaList GetList(){
return NNClaseEdadAproximadaDB.GetList();
}

/// <summary>
/// Gets a single NNClaseEdadAproximada from the database without its data.
/// </summary>
/// <param name="id">The id of the NNClaseEdadAproximada in the database.</param>
/// <returns>A NNClaseEdadAproximada object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseEdadAproximada GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single NNClaseEdadAproximada from the database.
/// </summary>
/// <param name="id">The id of the NNClaseEdadAproximada in the database.</param>
/// <param name="getNNClaseEdadAproximadaRecords">Determines whether to load all associated NNClaseEdadAproximada records as well.</param>
/// <returns>
/// A NNClaseEdadAproximada object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseEdadAproximada GetItem(int id, bool getNNClaseEdadAproximadaRecords){
NNClaseEdadAproximada myNNClaseEdadAproximada = NNClaseEdadAproximadaDB.GetItem(id);
if (myNNClaseEdadAproximada != null && getNNClaseEdadAproximadaRecords){
myNNClaseEdadAproximada.autoress = AutoresDB.GetListByidClaseEdadAproximada(id);
}
return myNNClaseEdadAproximada;
}

/// <summary>
/// Saves a NNClaseEdadAproximada in the database.
/// </summary>
/// <param name="myNNClaseEdadAproximada">The NNClaseEdadAproximada instance to save.</param>
/// <returns>The new id if the NNClaseEdadAproximada is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(NNClaseEdadAproximada myNNClaseEdadAproximada){
using (TransactionScope myTransactionScope = new TransactionScope()){
int nNClaseEdadAproximadaid = NNClaseEdadAproximadaDB.Save(myNNClaseEdadAproximada);
foreach (Autores myAutores in myNNClaseEdadAproximada.autoress){
myAutores.id = nNClaseEdadAproximadaid;
AutoresDB.Save(myAutores);
}

//  Assign the NNClaseEdadAproximada its new (or existing id).
myNNClaseEdadAproximada.id = nNClaseEdadAproximadaid;

myTransactionScope.Complete();

return nNClaseEdadAproximadaid;
}
}

/// <summary>
/// Deletes a NNClaseEdadAproximada from the database.
/// </summary>
/// <param name="myNNClaseEdadAproximada">The NNClaseEdadAproximada instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(NNClaseEdadAproximada myNNClaseEdadAproximada){
return NNClaseEdadAproximadaDB.Delete(myNNClaseEdadAproximada.id);
}

#endregion

}

}
