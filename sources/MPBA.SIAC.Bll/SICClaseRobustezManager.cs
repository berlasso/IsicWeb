using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Dal;
using MPBA.AutoresIgnorados.Dal;
using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.SIAC.Bll {

/// <summary>
/// The SICClaseRobustezManager class is responsible for managing Business Entities.SICClaseRobustez objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class SICClaseRobustezManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all SICClaseRobustez objects in the database.
/// </summary>
/// <returns>A list with all SICClaseRobustez from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static SICClaseRobustezList GetList(){
return SICClaseRobustezDB.GetList();
}

/// <summary>
/// Gets a single SICClaseRobustez from the database without its data.
/// </summary>
/// <param name="id">The Id of the SICClaseRobustez in the database.</param>
/// <returns>A SICClaseRobustez object when the Id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static SICClaseRobustez GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single SICClaseRobustez from the database.
/// </summary>
/// <param name="id">The Id of the SICClaseRobustez in the database.</param>
/// <param name="getSICClaseRobustezRecords">Determines whether to load all associated SICClaseRobustez records as well.</param>
/// <returns>
/// A SICClaseRobustez object when the Id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static SICClaseRobustez GetItem(int id, bool getSICClaseRobustezRecords){
SICClaseRobustez mySICClaseRobustez = SICClaseRobustezDB.GetItem(id);
if (mySICClaseRobustez != null && getSICClaseRobustezRecords){
mySICClaseRobustez.autoress = AutoresDB.GetListByidClaseRobustez(id);
}
return mySICClaseRobustez;
}

/// <summary>
/// Saves a SICClaseRobustez in the database.
/// </summary>
/// <param name="mySICClaseRobustez">The SICClaseRobustez instance to save.</param>
/// <returns>The new Id if the SICClaseRobustez is new in the database or the existing Id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(SICClaseRobustez mySICClaseRobustez){
using (TransactionScope myTransactionScope = new TransactionScope()){
int sICClaseRobustezId = SICClaseRobustezDB.Save(mySICClaseRobustez);
foreach (Autores myAutores in mySICClaseRobustez.autoress){
myAutores.idClaseRobustez = sICClaseRobustezId;
AutoresDB.Save(myAutores);
}

//  Assign the SICClaseRobustez its new (or existing Id).
mySICClaseRobustez.Id = sICClaseRobustezId;

myTransactionScope.Complete();

return sICClaseRobustezId;
}
}

/// <summary>
/// Deletes a SICClaseRobustez from the database.
/// </summary>
/// <param name="mySICClaseRobustez">The SICClaseRobustez instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(SICClaseRobustez mySICClaseRobustez){
return SICClaseRobustezDB.Delete(mySICClaseRobustez.Id);
}

#endregion

}

}
