using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Dal;
using MPBA.AutoresIgnorados.Dal;
using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.SIAC.Bll {

/// <summary>
/// The SICClaseCejasDimensionManager class is responsible for managing Business Entities.SICClaseCejasDimension objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class SICClaseCejasDimensionManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all SICClaseCejasDimension objects in the database.
/// </summary>
/// <returns>A list with all SICClaseCejasDimension from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static SICClaseCejasDimensionList GetList(){
return SICClaseCejasDimensionDB.GetList();
}

/// <summary>
/// Gets a single SICClaseCejasDimension from the database without its data.
/// </summary>
/// <param name="id">The Id of the SICClaseCejasDimension in the database.</param>
/// <returns>A SICClaseCejasDimension object when the Id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static SICClaseCejasDimension GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single SICClaseCejasDimension from the database.
/// </summary>
/// <param name="id">The Id of the SICClaseCejasDimension in the database.</param>
/// <param name="getSICClaseCejasDimensionRecords">Determines whether to load all associated SICClaseCejasDimension records as well.</param>
/// <returns>
/// A SICClaseCejasDimension object when the Id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static SICClaseCejasDimension GetItem(int id, bool getSICClaseCejasDimensionRecords){
SICClaseCejasDimension mySICClaseCejasDimension = SICClaseCejasDimensionDB.GetItem(id);
if (mySICClaseCejasDimension != null && getSICClaseCejasDimensionRecords){
mySICClaseCejasDimension.autoress = AutoresDB.GetListByidDimensionCeja(id);
}
return mySICClaseCejasDimension;
}

/// <summary>
/// Saves a SICClaseCejasDimension in the database.
/// </summary>
/// <param name="mySICClaseCejasDimension">The SICClaseCejasDimension instance to save.</param>
/// <returns>The new Id if the SICClaseCejasDimension is new in the database or the existing Id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(SICClaseCejasDimension mySICClaseCejasDimension){
using (TransactionScope myTransactionScope = new TransactionScope()){
int sICClaseCejasDimensionId = SICClaseCejasDimensionDB.Save(mySICClaseCejasDimension);
foreach (Autores myAutores in mySICClaseCejasDimension.autoress){
myAutores.idDimensionCeja = sICClaseCejasDimensionId;
AutoresDB.Save(myAutores);
}

//  Assign the SICClaseCejasDimension its new (or existing Id).
mySICClaseCejasDimension.Id = sICClaseCejasDimensionId;

myTransactionScope.Complete();

return sICClaseCejasDimensionId;
}
}

/// <summary>
/// Deletes a SICClaseCejasDimension from the database.
/// </summary>
/// <param name="mySICClaseCejasDimension">The SICClaseCejasDimension instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(SICClaseCejasDimension mySICClaseCejasDimension){
return SICClaseCejasDimensionDB.Delete(mySICClaseCejasDimension.Id);
}

#endregion

}

}
