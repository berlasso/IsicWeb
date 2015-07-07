using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The NNClaseTipoArmaFuegoManager class is responsible for managing Business Entities.NNClaseTipoArmaFuego objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class NNClaseTipoArmaFuegoManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all NNClaseTipoArmaFuego objects in the database.
/// </summary>
/// <returns>A list with all NNClaseTipoArmaFuego from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static NNClaseTipoArmaFuegoList GetList(){
return NNClaseTipoArmaFuegoDB.GetList();
}

/// <summary>
/// Gets a single NNClaseTipoArmaFuego from the database without its data.
/// </summary>
/// <param name="id">The id of the NNClaseTipoArmaFuego in the database.</param>
/// <returns>A NNClaseTipoArmaFuego object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseTipoArmaFuego GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single NNClaseTipoArmaFuego from the database.
/// </summary>
/// <param name="id">The id of the NNClaseTipoArmaFuego in the database.</param>
/// <param name="getNNClaseTipoArmaFuegoRecords">Determines whether to load all associated NNClaseTipoArmaFuego records as well.</param>
/// <returns>
/// A NNClaseTipoArmaFuego object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseTipoArmaFuego GetItem(int id, bool getNNClaseTipoArmaFuegoRecords){
NNClaseTipoArmaFuego myNNClaseTipoArmaFuego = NNClaseTipoArmaFuegoDB.GetItem(id);
return myNNClaseTipoArmaFuego;
}

/// <summary>
/// Saves a NNClaseTipoArmaFuego in the database.
/// </summary>
/// <param name="myNNClaseTipoArmaFuego">The NNClaseTipoArmaFuego instance to save.</param>
/// <returns>The new id if the NNClaseTipoArmaFuego is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(NNClaseTipoArmaFuego myNNClaseTipoArmaFuego){
using (TransactionScope myTransactionScope = new TransactionScope()){
int nNClaseTipoArmaFuegoid = NNClaseTipoArmaFuegoDB.Save(myNNClaseTipoArmaFuego);

//  Assign the NNClaseTipoArmaFuego its new (or existing id).
myNNClaseTipoArmaFuego.id = nNClaseTipoArmaFuegoid;

myTransactionScope.Complete();

return nNClaseTipoArmaFuegoid;
}
}

/// <summary>
/// Deletes a NNClaseTipoArmaFuego from the database.
/// </summary>
/// <param name="myNNClaseTipoArmaFuego">The NNClaseTipoArmaFuego instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(NNClaseTipoArmaFuego myNNClaseTipoArmaFuego){
return NNClaseTipoArmaFuegoDB.Delete(myNNClaseTipoArmaFuego.id);
}

#endregion

}

}
