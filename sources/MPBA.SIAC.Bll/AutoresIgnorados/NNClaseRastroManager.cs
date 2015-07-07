using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The NNClaseRastroManager class is responsible for managing Business Object.NNClaseRastro objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class NNClaseRastroManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all NNClaseRastro objects in the database.
/// </summary>
/// <returns>A list with all NNClaseRastro from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static NNClaseRastroList GetList(){
return NNClaseRastroDB.GetList();
}

/// <summary>
/// Gets a single NNClaseRastro from the database without its data.
/// </summary>
/// <param name="id">The id of the NNClaseRastro in the database.</param>
/// <returns>A NNClaseRastro object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseRastro GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single NNClaseRastro from the database.
/// </summary>
/// <param name="id">The id of the NNClaseRastro in the database.</param>
/// <param name="getNNClaseRastroRecords">Determines whether to load all associated NNClaseRastro records as well.</param>
/// <returns>
/// A NNClaseRastro object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseRastro GetItem(int id, bool getNNClaseRastroRecords){
NNClaseRastro myNNClaseRastro = NNClaseRastroDB.GetItem(id);
if (myNNClaseRastro != null && getNNClaseRastroRecords){
myNNClaseRastro.rastross = RastrosDB.GetListByidClaseRastro(id);
}
return myNNClaseRastro;
}

/// <summary>
/// Saves a NNClaseRastro in the database.
/// </summary>
/// <param name="myNNClaseRastro">The NNClaseRastro instance to save.</param>
/// <returns>The new id if the NNClaseRastro is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(NNClaseRastro myNNClaseRastro){
using (TransactionScope myTransactionScope = new TransactionScope()){
int nNClaseRastroid = NNClaseRastroDB.Save(myNNClaseRastro);
foreach (Rastros myRastros in myNNClaseRastro.rastross){
myRastros.id = nNClaseRastroid;
RastrosDB.Save(myRastros);
}

//  Assign the NNClaseRastro its new (or existing id).
myNNClaseRastro.id = nNClaseRastroid;

myTransactionScope.Complete();

return nNClaseRastroid;
}
}

/// <summary>
/// Deletes a NNClaseRastro from the database.
/// </summary>
/// <param name="myNNClaseRastro">The NNClaseRastro instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(NNClaseRastro myNNClaseRastro){
return NNClaseRastroDB.Delete(myNNClaseRastro.id);
}

#endregion

}

}
