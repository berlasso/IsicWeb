using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Dal;
using MPBA.AutoresIgnorados.Dal;
using MPBA.AutoresIgnorados.BusinessEntities;

namespace MPBA.SIAC.Bll {

/// <summary>
/// The SICClaseFormaCaraManager class is responsible for managing Business Entities.SICClaseFormaCara objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class SICClaseFormaCaraManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all SICClaseFormaCara objects in the database.
/// </summary>
/// <returns>A list with all SICClaseFormaCara from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static SICClaseFormaCaraList GetList(){
return SICClaseFormaCaraDB.GetList();
}

/// <summary>
/// Gets a single SICClaseFormaCara from the database without its data.
/// </summary>
/// <param name="id">The Id of the SICClaseFormaCara in the database.</param>
/// <returns>A SICClaseFormaCara object when the Id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static SICClaseFormaCara GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single SICClaseFormaCara from the database.
/// </summary>
/// <param name="id">The Id of the SICClaseFormaCara in the database.</param>
/// <param name="getSICClaseFormaCaraRecords">Determines whether to load all associated SICClaseFormaCara records as well.</param>
/// <returns>
/// A SICClaseFormaCara object when the Id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static SICClaseFormaCara GetItem(int id, bool getSICClaseFormaCaraRecords){
SICClaseFormaCara mySICClaseFormaCara = SICClaseFormaCaraDB.GetItem(id);
if (mySICClaseFormaCara != null && getSICClaseFormaCaraRecords){
mySICClaseFormaCara.autoress = AutoresDB.GetListByidClaseFormaCara(id);
}
return mySICClaseFormaCara;
}

/// <summary>
/// Saves a SICClaseFormaCara in the database.
/// </summary>
/// <param name="mySICClaseFormaCara">The SICClaseFormaCara instance to save.</param>
/// <returns>The new Id if the SICClaseFormaCara is new in the database or the existing Id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(SICClaseFormaCara mySICClaseFormaCara){
using (TransactionScope myTransactionScope = new TransactionScope()){
int sICClaseFormaCaraId = SICClaseFormaCaraDB.Save(mySICClaseFormaCara);
foreach (Autores myAutores in mySICClaseFormaCara.autoress){
myAutores.idClaseFormaCara = sICClaseFormaCaraId;
AutoresDB.Save(myAutores);
}

//  Assign the SICClaseFormaCara its new (or existing Id).
mySICClaseFormaCara.Id = sICClaseFormaCaraId;

myTransactionScope.Complete();

return sICClaseFormaCaraId;
}
}

/// <summary>
/// Deletes a SICClaseFormaCara from the database.
/// </summary>
/// <param name="mySICClaseFormaCara">The SICClaseFormaCara instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(SICClaseFormaCara mySICClaseFormaCara){
return SICClaseFormaCaraDB.Delete(mySICClaseFormaCara.Id);
}

#endregion

}

}
