using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The NNClaseDiametroArmaFuegoManager class is responsible for managing Business Entities.NNClaseDiametroArmaFuego objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class NNClaseDiametroArmaFuegoManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all NNClaseDiametroArmaFuego objects in the database.
/// </summary>
/// <returns>A list with all NNClaseDiametroArmaFuego from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static NNClaseDiametroArmaFuegoList GetList(){
return NNClaseDiametroArmaFuegoDB.GetList();
}

/// <summary>
/// Gets a single NNClaseDiametroArmaFuego from the database without its data.
/// </summary>
/// <param name="id">The id of the NNClaseDiametroArmaFuego in the database.</param>
/// <returns>A NNClaseDiametroArmaFuego object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseDiametroArmaFuego GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single NNClaseDiametroArmaFuego from the database.
/// </summary>
/// <param name="id">The id of the NNClaseDiametroArmaFuego in the database.</param>
/// <param name="getNNClaseDiametroArmaFuegoRecords">Determines whether to load all associated NNClaseDiametroArmaFuego records as well.</param>
/// <returns>
/// A NNClaseDiametroArmaFuego object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseDiametroArmaFuego GetItem(int id, bool getNNClaseDiametroArmaFuegoRecords){
NNClaseDiametroArmaFuego myNNClaseDiametroArmaFuego = NNClaseDiametroArmaFuegoDB.GetItem(id);
return myNNClaseDiametroArmaFuego;
}

/// <summary>
/// Saves a NNClaseDiametroArmaFuego in the database.
/// </summary>
/// <param name="myNNClaseDiametroArmaFuego">The NNClaseDiametroArmaFuego instance to save.</param>
/// <returns>The new id if the NNClaseDiametroArmaFuego is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(NNClaseDiametroArmaFuego myNNClaseDiametroArmaFuego){
using (TransactionScope myTransactionScope = new TransactionScope()){
int nNClaseDiametroArmaFuegoid = NNClaseDiametroArmaFuegoDB.Save(myNNClaseDiametroArmaFuego);

//  Assign the NNClaseDiametroArmaFuego its new (or existing id).
myNNClaseDiametroArmaFuego.id = nNClaseDiametroArmaFuegoid;

myTransactionScope.Complete();

return nNClaseDiametroArmaFuegoid;
}
}

/// <summary>
/// Deletes a NNClaseDiametroArmaFuego from the database.
/// </summary>
/// <param name="myNNClaseDiametroArmaFuego">The NNClaseDiametroArmaFuego instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(NNClaseDiametroArmaFuego myNNClaseDiametroArmaFuego){
return NNClaseDiametroArmaFuegoDB.Delete(myNNClaseDiametroArmaFuego.id);
}

#endregion

}

}
