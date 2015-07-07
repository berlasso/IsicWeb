using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The NNClaseMonedaManager class is responsible for managing Business Entities.NNClaseMoneda objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class NNClaseMonedaManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all NNClaseMoneda objects in the database.
/// </summary>
/// <returns>A list with all NNClaseMoneda from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static NNClaseMonedaList GetList(){
return NNClaseMonedaDB.GetList();
}

/// <summary>
/// Gets a single NNClaseMoneda from the database without its data.
/// </summary>
/// <param name="id">The id of the NNClaseMoneda in the database.</param>
/// <returns>A NNClaseMoneda object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseMoneda GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single NNClaseMoneda from the database.
/// </summary>
/// <param name="id">The id of the NNClaseMoneda in the database.</param>
/// <param name="getNNClaseMonedaRecords">Determines whether to load all associated NNClaseMoneda records as well.</param>
/// <returns>
/// A NNClaseMoneda object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static NNClaseMoneda GetItem(int id, bool getNNClaseMonedaRecords){
NNClaseMoneda myNNClaseMoneda = NNClaseMonedaDB.GetItem(id);
return myNNClaseMoneda;
}

/// <summary>
/// Saves a NNClaseMoneda in the database.
/// </summary>
/// <param name="myNNClaseMoneda">The NNClaseMoneda instance to save.</param>
/// <returns>The new id if the NNClaseMoneda is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(NNClaseMoneda myNNClaseMoneda){
using (TransactionScope myTransactionScope = new TransactionScope()){
int nNClaseMonedaid = NNClaseMonedaDB.Save(myNNClaseMoneda);

//  Assign the NNClaseMoneda its new (or existing id).
myNNClaseMoneda.id = nNClaseMonedaid;

myTransactionScope.Complete();

return nNClaseMonedaid;
}
}

/// <summary>
/// Deletes a NNClaseMoneda from the database.
/// </summary>
/// <param name="myNNClaseMoneda">The NNClaseMoneda instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(NNClaseMoneda myNNClaseMoneda){
return NNClaseMonedaDB.Delete(myNNClaseMoneda.id);
}

#endregion

}

}
