using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The NNClaseTatuajeManager class is responsible for managing Business Object.NNClaseTatuaje objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class NNClaseTatuajeManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all NNClaseTatuaje objects in the database.
/// </summary>
/// <returns>A list with all NNClaseTatuaje from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static NNClaseTatuajeList GetList(){
return NNClaseTatuajeDB.GetList();
}

/// <summary>
/// Gets a single NNClaseTatuaje from the database without its data.
/// </summary>
/// <param name="id">The id of the NNClaseTatuaje in the database.</param>
/// <returns>A NNClaseTatuaje object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseTatuaje GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single NNClaseTatuaje from the database.
/// </summary>
/// <param name="id">The id of the NNClaseTatuaje in the database.</param>
/// <param name="getNNClaseTatuajeRecords">Determines whether to load all associated NNClaseTatuaje records as well.</param>
/// <returns>
/// A NNClaseTatuaje object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseTatuaje GetItem(int id, bool getNNClaseTatuajeRecords){
NNClaseTatuaje myNNClaseTatuaje = NNClaseTatuajeDB.GetItem(id);
if (myNNClaseTatuaje != null && getNNClaseTatuajeRecords){
myNNClaseTatuaje.autoress = AutoresDB.GetListByidClaseTatuaje(id);
}
return myNNClaseTatuaje;
}

/// <summary>
/// Saves a NNClaseTatuaje in the database.
/// </summary>
/// <param name="myNNClaseTatuaje">The NNClaseTatuaje instance to save.</param>
/// <returns>The new id if the NNClaseTatuaje is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(NNClaseTatuaje myNNClaseTatuaje){
using (TransactionScope myTransactionScope = new TransactionScope()){
int nNClaseTatuajeid = NNClaseTatuajeDB.Save(myNNClaseTatuaje);
foreach (Autores myAutores in myNNClaseTatuaje.autoress){
myAutores.id = nNClaseTatuajeid;
AutoresDB.Save(myAutores);
}

//  Assign the NNClaseTatuaje its new (or existing id).
myNNClaseTatuaje.id = nNClaseTatuajeid;

myTransactionScope.Complete();

return nNClaseTatuajeid;
}
}

/// <summary>
/// Deletes a NNClaseTatuaje from the database.
/// </summary>
/// <param name="myNNClaseTatuaje">The NNClaseTatuaje instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(NNClaseTatuaje myNNClaseTatuaje){
return NNClaseTatuajeDB.Delete(myNNClaseTatuaje.id);
}

#endregion

}

}
