using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The NNClaseSeniaParticularManager class is responsible for managing Business Object.NNClaseSeniaParticular objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class NNClaseSeniaParticularManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all NNClaseSeniaParticular objects in the database.
/// </summary>
/// <returns>A list with all NNClaseSeniaParticular from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static NNClaseSeniaParticularList GetList(){
return NNClaseSeniaParticularDB.GetList();
}

/// <summary>
/// Gets a single NNClaseSeniaParticular from the database without its data.
/// </summary>
/// <param name="id">The id of the NNClaseSeniaParticular in the database.</param>
/// <returns>A NNClaseSeniaParticular object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseSeniaParticular GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single NNClaseSeniaParticular from the database.
/// </summary>
/// <param name="id">The id of the NNClaseSeniaParticular in the database.</param>
/// <param name="getNNClaseSeniaParticularRecords">Determines whether to load all associated NNClaseSeniaParticular records as well.</param>
/// <returns>
/// A NNClaseSeniaParticular object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseSeniaParticular GetItem(int id, bool getNNClaseSeniaParticularRecords){
NNClaseSeniaParticular myNNClaseSeniaParticular = NNClaseSeniaParticularDB.GetItem(id);
if (myNNClaseSeniaParticular != null && getNNClaseSeniaParticularRecords){
myNNClaseSeniaParticular.autoress = AutoresDB.GetListByidClaseSeniaParticular(id);
}
return myNNClaseSeniaParticular;
}

/// <summary>
/// Saves a NNClaseSeniaParticular in the database.
/// </summary>
/// <param name="myNNClaseSeniaParticular">The NNClaseSeniaParticular instance to save.</param>
/// <returns>The new id if the NNClaseSeniaParticular is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(NNClaseSeniaParticular myNNClaseSeniaParticular){
using (TransactionScope myTransactionScope = new TransactionScope()){
int nNClaseSeniaParticularid = NNClaseSeniaParticularDB.Save(myNNClaseSeniaParticular);
foreach (Autores myAutores in myNNClaseSeniaParticular.autoress){
myAutores.id = nNClaseSeniaParticularid;
AutoresDB.Save(myAutores);
}

//  Assign the NNClaseSeniaParticular its new (or existing id).
myNNClaseSeniaParticular.id = nNClaseSeniaParticularid;

myTransactionScope.Complete();

return nNClaseSeniaParticularid;
}
}

/// <summary>
/// Deletes a NNClaseSeniaParticular from the database.
/// </summary>
/// <param name="myNNClaseSeniaParticular">The NNClaseSeniaParticular instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(NNClaseSeniaParticular myNNClaseSeniaParticular){
return NNClaseSeniaParticularDB.Delete(myNNClaseSeniaParticular.id);
}

#endregion

}

}
