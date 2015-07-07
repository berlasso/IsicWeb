using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Dal;
using MPBA.AutoresIgnorados.Dal;
using MPBA.AutoresIgnorados.BusinessEntities;

namespace MPBA.SIAC.Bll {

/// <summary>
/// The SICClaseTipoCalvicieManager class is responsible for managing Business Entities.SICClaseTipoCalvicie objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class SICClaseTipoCalvicieManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all SICClaseTipoCalvicie objects in the database.
/// </summary>
/// <returns>A list with all SICClaseTipoCalvicie from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static SICClaseTipoCalvicieList GetList(){
return SICClaseTipoCalvicieDB.GetList();
}

/// <summary>
/// Gets a single SICClaseTipoCalvicie from the database without its data.
/// </summary>
/// <param name="id">The Id of the SICClaseTipoCalvicie in the database.</param>
/// <returns>A SICClaseTipoCalvicie object when the Id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static SICClaseTipoCalvicie GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single SICClaseTipoCalvicie from the database.
/// </summary>
/// <param name="id">The Id of the SICClaseTipoCalvicie in the database.</param>
/// <param name="getSICClaseTipoCalvicieRecords">Determines whether to load all associated SICClaseTipoCalvicie records as well.</param>
/// <returns>
/// A SICClaseTipoCalvicie object when the Id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static SICClaseTipoCalvicie GetItem(int id, bool getSICClaseTipoCalvicieRecords){
SICClaseTipoCalvicie mySICClaseTipoCalvicie = SICClaseTipoCalvicieDB.GetItem(id);
if (mySICClaseTipoCalvicie != null && getSICClaseTipoCalvicieRecords){
mySICClaseTipoCalvicie.autoress = AutoresDB.GetListByidClaseCalvicie(id);
}
return mySICClaseTipoCalvicie;
}

/// <summary>
/// Saves a SICClaseTipoCalvicie in the database.
/// </summary>
/// <param name="mySICClaseTipoCalvicie">The SICClaseTipoCalvicie instance to save.</param>
/// <returns>The new Id if the SICClaseTipoCalvicie is new in the database or the existing Id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(SICClaseTipoCalvicie mySICClaseTipoCalvicie){
using (TransactionScope myTransactionScope = new TransactionScope()){
int sICClaseTipoCalvicieId = SICClaseTipoCalvicieDB.Save(mySICClaseTipoCalvicie);
foreach (Autores myAutores in mySICClaseTipoCalvicie.autoress){
myAutores.idClaseCalvicie = sICClaseTipoCalvicieId;
AutoresDB.Save(myAutores);
}

//  Assign the SICClaseTipoCalvicie its new (or existing Id).
mySICClaseTipoCalvicie.Id = sICClaseTipoCalvicieId;

myTransactionScope.Complete();

return sICClaseTipoCalvicieId;
}
}

/// <summary>
/// Deletes a SICClaseTipoCalvicie from the database.
/// </summary>
/// <param name="mySICClaseTipoCalvicie">The SICClaseTipoCalvicie instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(SICClaseTipoCalvicie mySICClaseTipoCalvicie){
return SICClaseTipoCalvicieDB.Delete(mySICClaseTipoCalvicie.Id);
}

#endregion

}

}
