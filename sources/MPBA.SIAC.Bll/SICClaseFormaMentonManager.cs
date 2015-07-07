using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Dal;
using MPBA.AutoresIgnorados.Dal;
using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.SIAC.Bll {

/// <summary>
/// The SICClaseFormaMentonManager class is responsible for managing Business Entities.SICClaseFormaMenton objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class SICClaseFormaMentonManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all SICClaseFormaMenton objects in the database.
/// </summary>
/// <returns>A list with all SICClaseFormaMenton from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static SICClaseFormaMentonList GetList(){
return SICClaseFormaMentonDB.GetList();
}

/// <summary>
/// Gets a single SICClaseFormaMenton from the database without its data.
/// </summary>
/// <param name="id">The Id of the SICClaseFormaMenton in the database.</param>
/// <returns>A SICClaseFormaMenton object when the Id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static SICClaseFormaMenton GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single SICClaseFormaMenton from the database.
/// </summary>
/// <param name="id">The Id of the SICClaseFormaMenton in the database.</param>
/// <param name="getSICClaseFormaMentonRecords">Determines whether to load all associated SICClaseFormaMenton records as well.</param>
/// <returns>
/// A SICClaseFormaMenton object when the Id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static SICClaseFormaMenton GetItem(int id, bool getSICClaseFormaMentonRecords){
SICClaseFormaMenton mySICClaseFormaMenton = SICClaseFormaMentonDB.GetItem(id);
if (mySICClaseFormaMenton != null && getSICClaseFormaMentonRecords){
mySICClaseFormaMenton.autoress = AutoresDB.GetListByidFormaMenton(id);
}
return mySICClaseFormaMenton;
}

/// <summary>
/// Saves a SICClaseFormaMenton in the database.
/// </summary>
/// <param name="mySICClaseFormaMenton">The SICClaseFormaMenton instance to save.</param>
/// <returns>The new Id if the SICClaseFormaMenton is new in the database or the existing Id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(SICClaseFormaMenton mySICClaseFormaMenton){
using (TransactionScope myTransactionScope = new TransactionScope()){
int sICClaseFormaMentonId = SICClaseFormaMentonDB.Save(mySICClaseFormaMenton);
foreach (Autores myAutores in mySICClaseFormaMenton.autoress){
myAutores.idFormaMenton = sICClaseFormaMentonId;
AutoresDB.Save(myAutores);
}

//  Assign the SICClaseFormaMenton its new (or existing Id).
mySICClaseFormaMenton.Id = sICClaseFormaMentonId;

myTransactionScope.Complete();

return sICClaseFormaMentonId;
}
}

/// <summary>
/// Deletes a SICClaseFormaMenton from the database.
/// </summary>
/// <param name="mySICClaseFormaMenton">The SICClaseFormaMenton instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(SICClaseFormaMenton mySICClaseFormaMenton){
return SICClaseFormaMentonDB.Delete(mySICClaseFormaMenton.Id);
}

#endregion

}

}
