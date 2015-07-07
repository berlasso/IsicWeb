using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Dal;
using MPBA.AutoresIgnorados.Dal;
using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.SIAC.Bll {

/// <summary>
/// The SICClaseFormaBocaManager class is responsible for managing Business Entities.SICClaseFormaBoca objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class SICClaseFormaBocaManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all SICClaseFormaBoca objects in the database.
/// </summary>
/// <returns>A list with all SICClaseFormaBoca from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static SICClaseFormaBocaList GetList(){
return SICClaseFormaBocaDB.GetList();
}

/// <summary>
/// Gets a single SICClaseFormaBoca from the database without its data.
/// </summary>
/// <param name="id">The Id of the SICClaseFormaBoca in the database.</param>
/// <returns>A SICClaseFormaBoca object when the Id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static SICClaseFormaBoca GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single SICClaseFormaBoca from the database.
/// </summary>
/// <param name="id">The Id of the SICClaseFormaBoca in the database.</param>
/// <param name="getSICClaseFormaBocaRecords">Determines whether to load all associated SICClaseFormaBoca records as well.</param>
/// <returns>
/// A SICClaseFormaBoca object when the Id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static SICClaseFormaBoca GetItem(int id, bool getSICClaseFormaBocaRecords){
SICClaseFormaBoca mySICClaseFormaBoca = SICClaseFormaBocaDB.GetItem(id);
if (mySICClaseFormaBoca != null && getSICClaseFormaBocaRecords){
mySICClaseFormaBoca.autoress = AutoresDB.GetListByidFormaBoca(id);
}
return mySICClaseFormaBoca;
}

/// <summary>
/// Saves a SICClaseFormaBoca in the database.
/// </summary>
/// <param name="mySICClaseFormaBoca">The SICClaseFormaBoca instance to save.</param>
/// <returns>The new Id if the SICClaseFormaBoca is new in the database or the existing Id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(SICClaseFormaBoca mySICClaseFormaBoca){
using (TransactionScope myTransactionScope = new TransactionScope()){
int sICClaseFormaBocaId = SICClaseFormaBocaDB.Save(mySICClaseFormaBoca);
foreach (Autores myAutores in mySICClaseFormaBoca.autoress){
myAutores.idFormaBoca = sICClaseFormaBocaId;
AutoresDB.Save(myAutores);
}

//  Assign the SICClaseFormaBoca its new (or existing Id).
mySICClaseFormaBoca.Id = sICClaseFormaBocaId;

myTransactionScope.Complete();

return sICClaseFormaBocaId;
}
}

/// <summary>
/// Deletes a SICClaseFormaBoca from the database.
/// </summary>
/// <param name="mySICClaseFormaBoca">The SICClaseFormaBoca instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(SICClaseFormaBoca mySICClaseFormaBoca){
return SICClaseFormaBocaDB.Delete(mySICClaseFormaBoca.Id);
}

#endregion

}

}
