using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Dal;
using MPBA.AutoresIgnorados.Dal;
using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.SIAC.Bll {

/// <summary>
/// The SICClaseCejasTipoManager class is responsible for managing Business Entities.SICClaseCejasTipo objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class SICClaseCejasTipoManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all SICClaseCejasTipo objects in the database.
/// </summary>
/// <returns>A list with all SICClaseCejasTipo from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static SICClaseCejasTipoList GetList(){
return SICClaseCejasTipoDB.GetList();
}

/// <summary>
/// Gets a single SICClaseCejasTipo from the database without its data.
/// </summary>
/// <param name="id">The Id of the SICClaseCejasTipo in the database.</param>
/// <returns>A SICClaseCejasTipo object when the Id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static SICClaseCejasTipo GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single SICClaseCejasTipo from the database.
/// </summary>
/// <param name="id">The Id of the SICClaseCejasTipo in the database.</param>
/// <param name="getSICClaseCejasTipoRecords">Determines whether to load all associated SICClaseCejasTipo records as well.</param>
/// <returns>
/// A SICClaseCejasTipo object when the Id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static SICClaseCejasTipo GetItem(int id, bool getSICClaseCejasTipoRecords){
SICClaseCejasTipo mySICClaseCejasTipo = SICClaseCejasTipoDB.GetItem(id);
if (mySICClaseCejasTipo != null && getSICClaseCejasTipoRecords){
mySICClaseCejasTipo.autoress = AutoresDB.GetListByidTipoCeja(id);
}
return mySICClaseCejasTipo;
}

/// <summary>
/// Saves a SICClaseCejasTipo in the database.
/// </summary>
/// <param name="mySICClaseCejasTipo">The SICClaseCejasTipo instance to save.</param>
/// <returns>The new Id if the SICClaseCejasTipo is new in the database or the existing Id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(SICClaseCejasTipo mySICClaseCejasTipo){
using (TransactionScope myTransactionScope = new TransactionScope()){
int sICClaseCejasTipoId = SICClaseCejasTipoDB.Save(mySICClaseCejasTipo);
foreach (Autores myAutores in mySICClaseCejasTipo.autoress){
myAutores.idTipoCeja = sICClaseCejasTipoId;
AutoresDB.Save(myAutores);
}

//  Assign the SICClaseCejasTipo its new (or existing Id).
mySICClaseCejasTipo.Id = sICClaseCejasTipoId;

myTransactionScope.Complete();

return sICClaseCejasTipoId;
}
}

/// <summary>
/// Deletes a SICClaseCejasTipo from the database.
/// </summary>
/// <param name="mySICClaseCejasTipo">The SICClaseCejasTipo instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(SICClaseCejasTipo mySICClaseCejasTipo){
return SICClaseCejasTipoDB.Delete(mySICClaseCejasTipo.Id);
}

#endregion

}

}
