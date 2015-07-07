using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Dal;
using MPBA.AutoresIgnorados.Dal;
using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.SIAC.Bll {

/// <summary>
/// The SICClaseTipoCabelloManager class is responsible for managing Business Entities.SICClaseTipoCabello objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class SICClaseTipoCabelloManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all SICClaseTipoCabello objects in the database.
/// </summary>
/// <returns>A list with all SICClaseTipoCabello from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static SICClaseTipoCabelloList GetList(){
return SICClaseTipoCabelloDB.GetList();
}

/// <summary>
/// Gets a single SICClaseTipoCabello from the database without its data.
/// </summary>
/// <param name="id">The Id of the SICClaseTipoCabello in the database.</param>
/// <returns>A SICClaseTipoCabello object when the Id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static SICClaseTipoCabello GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single SICClaseTipoCabello from the database.
/// </summary>
/// <param name="id">The Id of the SICClaseTipoCabello in the database.</param>
/// <param name="getSICClaseTipoCabelloRecords">Determines whether to load all associated SICClaseTipoCabello records as well.</param>
/// <returns>
/// A SICClaseTipoCabello object when the Id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static SICClaseTipoCabello GetItem(int id, bool getSICClaseTipoCabelloRecords){
SICClaseTipoCabello mySICClaseTipoCabello = SICClaseTipoCabelloDB.GetItem(id);
if (mySICClaseTipoCabello != null && getSICClaseTipoCabelloRecords){
mySICClaseTipoCabello.autoress = AutoresDB.GetListByidClaseTipoCabello(id);
}
return mySICClaseTipoCabello;
}

/// <summary>
/// Saves a SICClaseTipoCabello in the database.
/// </summary>
/// <param name="mySICClaseTipoCabello">The SICClaseTipoCabello instance to save.</param>
/// <returns>The new Id if the SICClaseTipoCabello is new in the database or the existing Id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(SICClaseTipoCabello mySICClaseTipoCabello){
using (TransactionScope myTransactionScope = new TransactionScope()){
int sICClaseTipoCabelloId = SICClaseTipoCabelloDB.Save(mySICClaseTipoCabello);
foreach (Autores myAutores in mySICClaseTipoCabello.autoress){
myAutores.idClaseTipoCabello = sICClaseTipoCabelloId;
AutoresDB.Save(myAutores);
}

//  Assign the SICClaseTipoCabello its new (or existing Id).
mySICClaseTipoCabello.Id = sICClaseTipoCabelloId;

myTransactionScope.Complete();

return sICClaseTipoCabelloId;
}
}

/// <summary>
/// Deletes a SICClaseTipoCabello from the database.
/// </summary>
/// <param name="mySICClaseTipoCabello">The SICClaseTipoCabello instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(SICClaseTipoCabello mySICClaseTipoCabello){
return SICClaseTipoCabelloDB.Delete(mySICClaseTipoCabello.Id);
}

#endregion

}

}
