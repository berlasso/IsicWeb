using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The NNClaseRostroManager class is responsible for managing Business Object.NNClaseRostro objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class NNClaseRostroManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all NNClaseRostro objects in the database.
/// </summary>
/// <returns>A list with all NNClaseRostro from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static NNClaseRostroList GetList(){
return NNClaseRostroDB.GetList();
}

/// <summary>
/// Gets a single NNClaseRostro from the database without its data.
/// </summary>
/// <param name="id">The id of the NNClaseRostro in the database.</param>
/// <returns>A NNClaseRostro object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseRostro GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single NNClaseRostro from the database.
/// </summary>
/// <param name="id">The id of the NNClaseRostro in the database.</param>
/// <param name="getNNClaseRostroRecords">Determines whether to load all associated NNClaseRostro records as well.</param>
/// <returns>
/// A NNClaseRostro object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseRostro GetItem(int id, bool getNNClaseRostroRecords){
NNClaseRostro myNNClaseRostro = NNClaseRostroDB.GetItem(id);
if (myNNClaseRostro != null && getNNClaseRostroRecords){
myNNClaseRostro.autoress = AutoresDB.GetListByidClaseRostro(id);
}
return myNNClaseRostro;
}

/// <summary>
/// Saves a NNClaseRostro in the database.
/// </summary>
/// <param name="myNNClaseRostro">The NNClaseRostro instance to save.</param>
/// <returns>The new id if the NNClaseRostro is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(NNClaseRostro myNNClaseRostro){
using (TransactionScope myTransactionScope = new TransactionScope()){
int nNClaseRostroid = NNClaseRostroDB.Save(myNNClaseRostro);
foreach (Autores myAutores in myNNClaseRostro.autoress){
myAutores.id = nNClaseRostroid;
AutoresDB.Save(myAutores);
}

//  Assign the NNClaseRostro its new (or existing id).
myNNClaseRostro.id = nNClaseRostroid;

myTransactionScope.Complete();

return nNClaseRostroid;
}
}

/// <summary>
/// Deletes a NNClaseRostro from the database.
/// </summary>
/// <param name="myNNClaseRostro">The NNClaseRostro instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(NNClaseRostro myNNClaseRostro){
return NNClaseRostroDB.Delete(myNNClaseRostro.id);
}

#endregion

}

}
