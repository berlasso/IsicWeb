using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Dal;


namespace MPBA.SIAC.Bll {

/// <summary>
/// The ClaseSeniaParticularManager class is responsible for managing Business Entities.ClaseSeniaParticular objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class ClaseSeniaParticularManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all ClaseSeniaParticular objects in the database.
/// </summary>
/// <returns>A list with all ClaseSeniaParticular from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static ClaseSeniaParticularList GetList(){
return ClaseSeniaParticularDB.GetList();
}

/// <summary>
/// Gets a single ClaseSeniaParticular from the database without its data.
/// </summary>
/// <param name="id">The id of the ClaseSeniaParticular in the database.</param>
/// <returns>A ClaseSeniaParticular object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static ClaseSeniaParticular GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single ClaseSeniaParticular from the database.
/// </summary>
/// <param name="id">The id of the ClaseSeniaParticular in the database.</param>
/// <param name="getClaseSeniaParticularRecords">Determines whether to load all associated ClaseSeniaParticular records as well.</param>
/// <returns>
/// A ClaseSeniaParticular object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static ClaseSeniaParticular GetItem(int id, bool getClaseSeniaParticularRecords){
ClaseSeniaParticular myClaseSeniaParticular = ClaseSeniaParticularDB.GetItem(id);
if (myClaseSeniaParticular != null && getClaseSeniaParticularRecords){
myClaseSeniaParticular.seniasParticularess = SeniasParticularesDB.GetListByidSeniaParticular(id);
}
return myClaseSeniaParticular;
}

/// <summary>
/// Saves a ClaseSeniaParticular in the database.
/// </summary>
/// <param name="myClaseSeniaParticular">The ClaseSeniaParticular instance to save.</param>
/// <returns>The new id if the ClaseSeniaParticular is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(ClaseSeniaParticular myClaseSeniaParticular){
using (TransactionScope myTransactionScope = new TransactionScope()){
int claseSeniaParticularid = ClaseSeniaParticularDB.Save(myClaseSeniaParticular);
foreach (SeniasParticulares mySeniasParticulares in myClaseSeniaParticular.seniasParticularess){
mySeniasParticulares.id = claseSeniaParticularid;
SeniasParticularesDB.Save(mySeniasParticulares);
}

//  Assign the ClaseSeniaParticular its new (or existing id).
myClaseSeniaParticular.id = claseSeniaParticularid;

myTransactionScope.Complete();

return claseSeniaParticularid;
}
}

/// <summary>
/// Deletes a ClaseSeniaParticular from the database.
/// </summary>
/// <param name="myClaseSeniaParticular">The ClaseSeniaParticular instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(ClaseSeniaParticular myClaseSeniaParticular){
return ClaseSeniaParticularDB.Delete(myClaseSeniaParticular.id);
}

#endregion

}

}
