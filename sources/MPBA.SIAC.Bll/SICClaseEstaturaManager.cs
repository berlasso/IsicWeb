using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Dal;
using MPBA.AutoresIgnorados.Dal;
using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.SIAC.Bll {

/// <summary>
/// The SICClaseEstaturaManager class is responsible for managing Business Entities.SICClaseEstatura objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class SICClaseEstaturaManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all SICClaseEstatura objects in the database.
/// </summary>
/// <returns>A list with all SICClaseEstatura from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static SICClaseEstaturaList GetList(){
return SICClaseEstaturaDB.GetList();
}

/// <summary>
/// Gets a single SICClaseEstatura from the database without its data.
/// </summary>
/// <param name="id">The Id of the SICClaseEstatura in the database.</param>
/// <returns>A SICClaseEstatura object when the Id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static SICClaseEstatura GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single SICClaseEstatura from the database.
/// </summary>
/// <param name="id">The Id of the SICClaseEstatura in the database.</param>
/// <param name="getSICClaseEstaturaRecords">Determines whether to load all associated SICClaseEstatura records as well.</param>
/// <returns>
/// A SICClaseEstatura object when the Id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static SICClaseEstatura GetItem(int id, bool getSICClaseEstaturaRecords){
SICClaseEstatura mySICClaseEstatura = SICClaseEstaturaDB.GetItem(id);
if (mySICClaseEstatura != null && getSICClaseEstaturaRecords){
mySICClaseEstatura.autoress = AutoresDB.GetListByidClaseEstatura(id);
}
return mySICClaseEstatura;
}

/// <summary>
/// Saves a SICClaseEstatura in the database.
/// </summary>
/// <param name="mySICClaseEstatura">The SICClaseEstatura instance to save.</param>
/// <returns>The new Id if the SICClaseEstatura is new in the database or the existing Id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(SICClaseEstatura mySICClaseEstatura){
using (TransactionScope myTransactionScope = new TransactionScope()){
int sICClaseEstaturaId = SICClaseEstaturaDB.Save(mySICClaseEstatura);
foreach (Autores myAutores in mySICClaseEstatura.autoress){
myAutores.idClaseEstatura = sICClaseEstaturaId;
AutoresDB.Save(myAutores);
}

//  Assign the SICClaseEstatura its new (or existing Id).
mySICClaseEstatura.Id = sICClaseEstaturaId;

myTransactionScope.Complete();

return sICClaseEstaturaId;
}
}

/// <summary>
/// Deletes a SICClaseEstatura from the database.
/// </summary>
/// <param name="mySICClaseEstatura">The SICClaseEstatura instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(SICClaseEstatura mySICClaseEstatura){
return SICClaseEstaturaDB.Delete(mySICClaseEstatura.Id);
}

#endregion

}

}
