using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Dal;
using MPBA.AutoresIgnorados.Dal;
using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.SIAC.Bll {

/// <summary>
/// The SICClaseFormaLabioSuperiorManager class is responsible for managing Business Entities.SICClaseFormaLabioSuperior objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class SICClaseFormaLabioSuperiorManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all SICClaseFormaLabioSuperior objects in the database.
/// </summary>
/// <returns>A list with all SICClaseFormaLabioSuperior from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static SICClaseFormaLabioSuperiorList GetList(){
return SICClaseFormaLabioSuperiorDB.GetList();
}

/// <summary>
/// Gets a single SICClaseFormaLabioSuperior from the database without its data.
/// </summary>
/// <param name="id">The Id of the SICClaseFormaLabioSuperior in the database.</param>
/// <returns>A SICClaseFormaLabioSuperior object when the Id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static SICClaseFormaLabioSuperior GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single SICClaseFormaLabioSuperior from the database.
/// </summary>
/// <param name="id">The Id of the SICClaseFormaLabioSuperior in the database.</param>
/// <param name="getSICClaseFormaLabioSuperiorRecords">Determines whether to load all associated SICClaseFormaLabioSuperior records as well.</param>
/// <returns>
/// A SICClaseFormaLabioSuperior object when the Id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static SICClaseFormaLabioSuperior GetItem(int id, bool getSICClaseFormaLabioSuperiorRecords){
SICClaseFormaLabioSuperior mySICClaseFormaLabioSuperior = SICClaseFormaLabioSuperiorDB.GetItem(id);
if (mySICClaseFormaLabioSuperior != null && getSICClaseFormaLabioSuperiorRecords){
mySICClaseFormaLabioSuperior.autoress = AutoresDB.GetListByidFormaLabioSuperior(id);
}
return mySICClaseFormaLabioSuperior;
}

/// <summary>
/// Saves a SICClaseFormaLabioSuperior in the database.
/// </summary>
/// <param name="mySICClaseFormaLabioSuperior">The SICClaseFormaLabioSuperior instance to save.</param>
/// <returns>The new Id if the SICClaseFormaLabioSuperior is new in the database or the existing Id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(SICClaseFormaLabioSuperior mySICClaseFormaLabioSuperior){
using (TransactionScope myTransactionScope = new TransactionScope()){
int sICClaseFormaLabioSuperiorId = SICClaseFormaLabioSuperiorDB.Save(mySICClaseFormaLabioSuperior);
foreach (Autores myAutores in mySICClaseFormaLabioSuperior.autoress){
myAutores.idFormaLabioSuperior = sICClaseFormaLabioSuperiorId;
AutoresDB.Save(myAutores);
}

//  Assign the SICClaseFormaLabioSuperior its new (or existing Id).
mySICClaseFormaLabioSuperior.Id = sICClaseFormaLabioSuperiorId;

myTransactionScope.Complete();

return sICClaseFormaLabioSuperiorId;
}
}

/// <summary>
/// Deletes a SICClaseFormaLabioSuperior from the database.
/// </summary>
/// <param name="mySICClaseFormaLabioSuperior">The SICClaseFormaLabioSuperior instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(SICClaseFormaLabioSuperior mySICClaseFormaLabioSuperior){
return SICClaseFormaLabioSuperiorDB.Delete(mySICClaseFormaLabioSuperior.Id);
}

#endregion

}

}
