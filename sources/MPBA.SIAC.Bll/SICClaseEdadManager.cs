using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Dal;
using MPBA.AutoresIgnorados.Dal;
using MPBA.AutoresIgnorados.BusinessEntities;

namespace MPBA.SIAC.Bll {

/// <summary>
/// The SICClaseEdadManager class is responsible for managing Business Entities.SICClaseEdad objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class SICClaseEdadManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all SICClaseEdad objects in the database.
/// </summary>
/// <returns>A list with all SICClaseEdad from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static SICClaseEdadList GetList(){
return SICClaseEdadDB.GetList();
}

/// <summary>
/// Gets a single SICClaseEdad from the database without its data.
/// </summary>
/// <param name="id">The Id of the SICClaseEdad in the database.</param>
/// <returns>A SICClaseEdad object when the Id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static SICClaseEdad GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single SICClaseEdad from the database.
/// </summary>
/// <param name="id">The Id of the SICClaseEdad in the database.</param>
/// <param name="getSICClaseEdadRecords">Determines whether to load all associated SICClaseEdad records as well.</param>
/// <returns>
/// A SICClaseEdad object when the Id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static SICClaseEdad GetItem(int id, bool getSICClaseEdadRecords){
SICClaseEdad mySICClaseEdad = SICClaseEdadDB.GetItem(id);
if (mySICClaseEdad != null && getSICClaseEdadRecords){
mySICClaseEdad.nNClaseEdadAproximadas = NNClaseEdadAproximadaDB.GetListByidSICEdad(id);
}
return mySICClaseEdad;
}

/// <summary>
/// Saves a SICClaseEdad in the database.
/// </summary>
/// <param name="mySICClaseEdad">The SICClaseEdad instance to save.</param>
/// <returns>The new Id if the SICClaseEdad is new in the database or the existing Id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(SICClaseEdad mySICClaseEdad){
using (TransactionScope myTransactionScope = new TransactionScope()){
int sICClaseEdadId = SICClaseEdadDB.Save(mySICClaseEdad);
foreach (NNClaseEdadAproximada myNNClaseEdadAproximada in mySICClaseEdad.nNClaseEdadAproximadas){
myNNClaseEdadAproximada.idSICEdad = sICClaseEdadId;
NNClaseEdadAproximadaDB.Save(myNNClaseEdadAproximada);
}

//  Assign the SICClaseEdad its new (or existing Id).
mySICClaseEdad.Id = sICClaseEdadId;

myTransactionScope.Complete();

return sICClaseEdadId;
}
}

/// <summary>
/// Deletes a SICClaseEdad from the database.
/// </summary>
/// <param name="mySICClaseEdad">The SICClaseEdad instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(SICClaseEdad mySICClaseEdad){
return SICClaseEdadDB.Delete(mySICClaseEdad.Id);
}

#endregion

}

}
