using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Dal;
using MPBA.AutoresIgnorados.Dal;
using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.SIAC.Bll {

/// <summary>
/// The SICClaseColorOjosManager class is responsible for managing Business Entities.SICClaseColorOjos objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class SICClaseColorOjosManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all SICClaseColorOjos objects in the database.
/// </summary>
/// <returns>A list with all SICClaseColorOjos from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static SICClaseColorOjosList GetList(){
return SICClaseColorOjosDB.GetList();
}

/// <summary>
/// Gets a single SICClaseColorOjos from the database without its data.
/// </summary>
/// <param name="id">The Id of the SICClaseColorOjos in the database.</param>
/// <returns>A SICClaseColorOjos object when the Id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static SICClaseColorOjos GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single SICClaseColorOjos from the database.
/// </summary>
/// <param name="id">The Id of the SICClaseColorOjos in the database.</param>
/// <param name="getSICClaseColorOjosRecords">Determines whether to load all associated SICClaseColorOjos records as well.</param>
/// <returns>
/// A SICClaseColorOjos object when the Id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static SICClaseColorOjos GetItem(int id, bool getSICClaseColorOjosRecords){
SICClaseColorOjos mySICClaseColorOjos = SICClaseColorOjosDB.GetItem(id);
if (mySICClaseColorOjos != null && getSICClaseColorOjosRecords){
mySICClaseColorOjos.autoress = AutoresDB.GetListByidClaseColorOjos(id);
}
return mySICClaseColorOjos;
}

/// <summary>
/// Saves a SICClaseColorOjos in the database.
/// </summary>
/// <param name="mySICClaseColorOjos">The SICClaseColorOjos instance to save.</param>
/// <returns>The new Id if the SICClaseColorOjos is new in the database or the existing Id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(SICClaseColorOjos mySICClaseColorOjos){
using (TransactionScope myTransactionScope = new TransactionScope()){
int sICClaseColorOjosId = SICClaseColorOjosDB.Save(mySICClaseColorOjos);
foreach (Autores myAutores in mySICClaseColorOjos.autoress){
myAutores.idClaseColorOjos = sICClaseColorOjosId;
AutoresDB.Save(myAutores);
}

//  Assign the SICClaseColorOjos its new (or existing Id).
mySICClaseColorOjos.Id = sICClaseColorOjosId;

myTransactionScope.Complete();

return sICClaseColorOjosId;
}
}

/// <summary>
/// Deletes a SICClaseColorOjos from the database.
/// </summary>
/// <param name="mySICClaseColorOjos">The SICClaseColorOjos instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(SICClaseColorOjos mySICClaseColorOjos){
return SICClaseColorOjosDB.Delete(mySICClaseColorOjos.Id);
}

#endregion

}

}
