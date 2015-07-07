using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Dal;
using MPBA.AutoresIgnorados.Dal;
using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.SIAC.Bll {

/// <summary>
/// The SICClaseColorPielManager class is responsible for managing Business Entities.SICClaseColorPiel objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class SICClaseColorPielManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all SICClaseColorPiel objects in the database.
/// </summary>
/// <returns>A list with all SICClaseColorPiel from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static SICClaseColorPielList GetList(){
return SICClaseColorPielDB.GetList();
}

/// <summary>
/// Gets a single SICClaseColorPiel from the database without its data.
/// </summary>
/// <param name="id">The Id of the SICClaseColorPiel in the database.</param>
/// <returns>A SICClaseColorPiel object when the Id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static SICClaseColorPiel GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single SICClaseColorPiel from the database.
/// </summary>
/// <param name="id">The Id of the SICClaseColorPiel in the database.</param>
/// <param name="getSICClaseColorPielRecords">Determines whether to load all associated SICClaseColorPiel records as well.</param>
/// <returns>
/// A SICClaseColorPiel object when the Id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static SICClaseColorPiel GetItem(int id, bool getSICClaseColorPielRecords){
SICClaseColorPiel mySICClaseColorPiel = SICClaseColorPielDB.GetItem(id);
if (mySICClaseColorPiel != null && getSICClaseColorPielRecords){
mySICClaseColorPiel.autoress = AutoresDB.GetListByidClaseColorPiel(id);
}
return mySICClaseColorPiel;
}

/// <summary>
/// Saves a SICClaseColorPiel in the database.
/// </summary>
/// <param name="mySICClaseColorPiel">The SICClaseColorPiel instance to save.</param>
/// <returns>The new Id if the SICClaseColorPiel is new in the database or the existing Id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(SICClaseColorPiel mySICClaseColorPiel){
using (TransactionScope myTransactionScope = new TransactionScope()){
int sICClaseColorPielId = SICClaseColorPielDB.Save(mySICClaseColorPiel);
foreach (Autores myAutores in mySICClaseColorPiel.autoress){
myAutores.idClaseColorPiel = sICClaseColorPielId;
AutoresDB.Save(myAutores);
}

//  Assign the SICClaseColorPiel its new (or existing Id).
mySICClaseColorPiel.Id = sICClaseColorPielId;

myTransactionScope.Complete();

return sICClaseColorPielId;
}
}

/// <summary>
/// Deletes a SICClaseColorPiel from the database.
/// </summary>
/// <param name="mySICClaseColorPiel">The SICClaseColorPiel instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(SICClaseColorPiel mySICClaseColorPiel){
return SICClaseColorPielDB.Delete(mySICClaseColorPiel.Id);
}

#endregion

}

}
