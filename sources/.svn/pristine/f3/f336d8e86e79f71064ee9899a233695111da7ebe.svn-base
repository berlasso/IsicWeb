using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Dal;
using MPBA.AutoresIgnorados.Dal;
using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.SIAC.Bll {

/// <summary>
/// The SICClaseFormaNarizManager class is responsible for managing Business Entities.SICClaseFormaNariz objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class SICClaseFormaNarizManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all SICClaseFormaNariz objects in the database.
/// </summary>
/// <returns>A list with all SICClaseFormaNariz from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static SICClaseFormaNarizList GetList(){
return SICClaseFormaNarizDB.GetList();
}

/// <summary>
/// Gets a single SICClaseFormaNariz from the database without its data.
/// </summary>
/// <param name="id">The Id of the SICClaseFormaNariz in the database.</param>
/// <returns>A SICClaseFormaNariz object when the Id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static SICClaseFormaNariz GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single SICClaseFormaNariz from the database.
/// </summary>
/// <param name="id">The Id of the SICClaseFormaNariz in the database.</param>
/// <param name="getSICClaseFormaNarizRecords">Determines whether to load all associated SICClaseFormaNariz records as well.</param>
/// <returns>
/// A SICClaseFormaNariz object when the Id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static SICClaseFormaNariz GetItem(int id, bool getSICClaseFormaNarizRecords){
SICClaseFormaNariz mySICClaseFormaNariz = SICClaseFormaNarizDB.GetItem(id);
if (mySICClaseFormaNariz != null && getSICClaseFormaNarizRecords){
mySICClaseFormaNariz.autoress = AutoresDB.GetListByidFormaNariz(id);
}
return mySICClaseFormaNariz;
}

/// <summary>
/// Saves a SICClaseFormaNariz in the database.
/// </summary>
/// <param name="mySICClaseFormaNariz">The SICClaseFormaNariz instance to save.</param>
/// <returns>The new Id if the SICClaseFormaNariz is new in the database or the existing Id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(SICClaseFormaNariz mySICClaseFormaNariz){
using (TransactionScope myTransactionScope = new TransactionScope()){
int sICClaseFormaNarizId = SICClaseFormaNarizDB.Save(mySICClaseFormaNariz);
foreach (Autores myAutores in mySICClaseFormaNariz.autoress){
myAutores.idFormaNariz = sICClaseFormaNarizId;
AutoresDB.Save(myAutores);
}

//  Assign the SICClaseFormaNariz its new (or existing Id).
mySICClaseFormaNariz.Id = sICClaseFormaNarizId;

myTransactionScope.Complete();

return sICClaseFormaNarizId;
}
}

/// <summary>
/// Deletes a SICClaseFormaNariz from the database.
/// </summary>
/// <param name="mySICClaseFormaNariz">The SICClaseFormaNariz instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(SICClaseFormaNariz mySICClaseFormaNariz){
return SICClaseFormaNarizDB.Delete(mySICClaseFormaNariz.Id);
}

#endregion

}

}
