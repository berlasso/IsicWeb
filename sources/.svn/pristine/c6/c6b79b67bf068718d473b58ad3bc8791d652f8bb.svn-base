using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Dal;
using MPBA.AutoresIgnorados.Dal;
using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.SIAC.Bll {

/// <summary>
/// The SICClaseFormaLabioInferiorManager class is responsible for managing Business Entities.SICClaseFormaLabioInferior objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class SICClaseFormaLabioInferiorManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all SICClaseFormaLabioInferior objects in the database.
/// </summary>
/// <returns>A list with all SICClaseFormaLabioInferior from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static SICClaseFormaLabioInferiorList GetList(){
return SICClaseFormaLabioInferiorDB.GetList();
}

/// <summary>
/// Gets a single SICClaseFormaLabioInferior from the database without its data.
/// </summary>
/// <param name="id">The Id of the SICClaseFormaLabioInferior in the database.</param>
/// <returns>A SICClaseFormaLabioInferior object when the Id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static SICClaseFormaLabioInferior GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single SICClaseFormaLabioInferior from the database.
/// </summary>
/// <param name="id">The Id of the SICClaseFormaLabioInferior in the database.</param>
/// <param name="getSICClaseFormaLabioInferiorRecords">Determines whether to load all associated SICClaseFormaLabioInferior records as well.</param>
/// <returns>
/// A SICClaseFormaLabioInferior object when the Id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static SICClaseFormaLabioInferior GetItem(int id, bool getSICClaseFormaLabioInferiorRecords){
SICClaseFormaLabioInferior mySICClaseFormaLabioInferior = SICClaseFormaLabioInferiorDB.GetItem(id);
if (mySICClaseFormaLabioInferior != null && getSICClaseFormaLabioInferiorRecords){
mySICClaseFormaLabioInferior.autoress = AutoresDB.GetListByidFormaLabioInferior(id);
}
return mySICClaseFormaLabioInferior;
}

/// <summary>
/// Saves a SICClaseFormaLabioInferior in the database.
/// </summary>
/// <param name="mySICClaseFormaLabioInferior">The SICClaseFormaLabioInferior instance to save.</param>
/// <returns>The new Id if the SICClaseFormaLabioInferior is new in the database or the existing Id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(SICClaseFormaLabioInferior mySICClaseFormaLabioInferior){
using (TransactionScope myTransactionScope = new TransactionScope()){
int sICClaseFormaLabioInferiorId = SICClaseFormaLabioInferiorDB.Save(mySICClaseFormaLabioInferior);
foreach (Autores myAutores in mySICClaseFormaLabioInferior.autoress){
myAutores.idFormaLabioInferior = sICClaseFormaLabioInferiorId;
AutoresDB.Save(myAutores);
}

//  Assign the SICClaseFormaLabioInferior its new (or existing Id).
mySICClaseFormaLabioInferior.Id = sICClaseFormaLabioInferiorId;

myTransactionScope.Complete();

return sICClaseFormaLabioInferiorId;
}
}

/// <summary>
/// Deletes a SICClaseFormaLabioInferior from the database.
/// </summary>
/// <param name="mySICClaseFormaLabioInferior">The SICClaseFormaLabioInferior instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(SICClaseFormaLabioInferior mySICClaseFormaLabioInferior){
return SICClaseFormaLabioInferiorDB.Delete(mySICClaseFormaLabioInferior.Id);
}

#endregion

}

}
