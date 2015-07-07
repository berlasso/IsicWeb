using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Dal;
using MPBA.AutoresIgnorados.Dal;
using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.SIAC.Bll {

/// <summary>
/// The SICClaseColorCabelloManager class is responsible for managing Business Entities.SICClaseColorCabello objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class SICClaseColorCabelloManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all SICClaseColorCabello objects in the database.
/// </summary>
/// <returns>A list with all SICClaseColorCabello from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static SICClaseColorCabelloList GetList(){
return SICClaseColorCabelloDB.GetList();
}

/// <summary>
/// Gets a single SICClaseColorCabello from the database without its data.
/// </summary>
/// <param name="id">The Id of the SICClaseColorCabello in the database.</param>
/// <returns>A SICClaseColorCabello object when the Id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static SICClaseColorCabello GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single SICClaseColorCabello from the database.
/// </summary>
/// <param name="id">The Id of the SICClaseColorCabello in the database.</param>
/// <param name="getSICClaseColorCabelloRecords">Determines whether to load all associated SICClaseColorCabello records as well.</param>
/// <returns>
/// A SICClaseColorCabello object when the Id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static SICClaseColorCabello GetItem(int id, bool getSICClaseColorCabelloRecords){
SICClaseColorCabello mySICClaseColorCabello = SICClaseColorCabelloDB.GetItem(id);
if (mySICClaseColorCabello != null && getSICClaseColorCabelloRecords){
mySICClaseColorCabello.autoress = AutoresDB.GetListByidClaseColorCabello(id);
}
return mySICClaseColorCabello;
}

/// <summary>
/// Saves a SICClaseColorCabello in the database.
/// </summary>
/// <param name="mySICClaseColorCabello">The SICClaseColorCabello instance to save.</param>
/// <returns>The new Id if the SICClaseColorCabello is new in the database or the existing Id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(SICClaseColorCabello mySICClaseColorCabello){
using (TransactionScope myTransactionScope = new TransactionScope()){
int sICClaseColorCabelloId = SICClaseColorCabelloDB.Save(mySICClaseColorCabello);
foreach (Autores myAutores in mySICClaseColorCabello.autoress){
myAutores.idClaseColorCabello = sICClaseColorCabelloId;
AutoresDB.Save(myAutores);
}

//  Assign the SICClaseColorCabello its new (or existing Id).
mySICClaseColorCabello.Id = sICClaseColorCabelloId;

myTransactionScope.Complete();

return sICClaseColorCabelloId;
}
}

/// <summary>
/// Deletes a SICClaseColorCabello from the database.
/// </summary>
/// <param name="mySICClaseColorCabello">The SICClaseColorCabello instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(SICClaseColorCabello mySICClaseColorCabello){
return SICClaseColorCabelloDB.Delete(mySICClaseColorCabello.Id);
}

#endregion

}

}
