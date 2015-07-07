using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Dal;
using MPBA.AutoresIgnorados.Dal;
using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.SIAC.Bll {

/// <summary>
/// The SICClaseFormaOrejaManager class is responsible for managing Business Entities.SICClaseFormaOreja objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class SICClaseFormaOrejaManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all SICClaseFormaOreja objects in the database.
/// </summary>
/// <returns>A list with all SICClaseFormaOreja from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static SICClaseFormaOrejaList GetList(){
return SICClaseFormaOrejaDB.GetList();
}

/// <summary>
/// Gets a single SICClaseFormaOreja from the database without its data.
/// </summary>
/// <param name="id">The Id of the SICClaseFormaOreja in the database.</param>
/// <returns>A SICClaseFormaOreja object when the Id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static SICClaseFormaOreja GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single SICClaseFormaOreja from the database.
/// </summary>
/// <param name="id">The Id of the SICClaseFormaOreja in the database.</param>
/// <param name="getSICClaseFormaOrejaRecords">Determines whether to load all associated SICClaseFormaOreja records as well.</param>
/// <returns>
/// A SICClaseFormaOreja object when the Id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static SICClaseFormaOreja GetItem(int id, bool getSICClaseFormaOrejaRecords){
SICClaseFormaOreja mySICClaseFormaOreja = SICClaseFormaOrejaDB.GetItem(id);
if (mySICClaseFormaOreja != null && getSICClaseFormaOrejaRecords){
mySICClaseFormaOreja.autoress = AutoresDB.GetListByidFormaOreja(id);
}
return mySICClaseFormaOreja;
}

/// <summary>
/// Saves a SICClaseFormaOreja in the database.
/// </summary>
/// <param name="mySICClaseFormaOreja">The SICClaseFormaOreja instance to save.</param>
/// <returns>The new Id if the SICClaseFormaOreja is new in the database or the existing Id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(SICClaseFormaOreja mySICClaseFormaOreja){
using (TransactionScope myTransactionScope = new TransactionScope()){
int sICClaseFormaOrejaId = SICClaseFormaOrejaDB.Save(mySICClaseFormaOreja);
foreach (Autores myAutores in mySICClaseFormaOreja.autoress){
myAutores.idFormaOreja = sICClaseFormaOrejaId;
AutoresDB.Save(myAutores);
}

//  Assign the SICClaseFormaOreja its new (or existing Id).
mySICClaseFormaOreja.Id = sICClaseFormaOrejaId;

myTransactionScope.Complete();

return sICClaseFormaOrejaId;
}
}

/// <summary>
/// Deletes a SICClaseFormaOreja from the database.
/// </summary>
/// <param name="mySICClaseFormaOreja">The SICClaseFormaOreja instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(SICClaseFormaOreja mySICClaseFormaOreja){
return SICClaseFormaOrejaDB.Delete(mySICClaseFormaOreja.Id);
}

#endregion

}

}
