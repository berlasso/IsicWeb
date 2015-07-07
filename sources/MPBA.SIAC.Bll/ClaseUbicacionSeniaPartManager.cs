using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Dal;


namespace MPBA.SIAC.Bll {

/// <summary>
/// The ClaseUbicacionSeniaPartManager class is responsible for managing Business Entities.ClaseUbicacionSeniaPart objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class ClaseUbicacionSeniaPartManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all ClaseUbicacionSeniaPart objects in the database.
/// </summary>
/// <returns>A list with all ClaseUbicacionSeniaPart from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static ClaseUbicacionSeniaPartList GetList(){
return ClaseUbicacionSeniaPartDB.GetList();
}

/// <summary>
/// Gets a single ClaseUbicacionSeniaPart from the database without its data.
/// </summary>
/// <param name="id">The id of the ClaseUbicacionSeniaPart in the database.</param>
/// <returns>A ClaseUbicacionSeniaPart object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static ClaseUbicacionSeniaPart GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single ClaseUbicacionSeniaPart from the database.
/// </summary>
/// <param name="id">The id of the ClaseUbicacionSeniaPart in the database.</param>
/// <param name="getClaseUbicacionSeniaPartRecords">Determines whether to load all associated ClaseUbicacionSeniaPart records as well.</param>
/// <returns>
/// A ClaseUbicacionSeniaPart object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static ClaseUbicacionSeniaPart GetItem(int id, bool getClaseUbicacionSeniaPartRecords){
ClaseUbicacionSeniaPart myClaseUbicacionSeniaPart = ClaseUbicacionSeniaPartDB.GetItem(id);
if (myClaseUbicacionSeniaPart != null && getClaseUbicacionSeniaPartRecords){
myClaseUbicacionSeniaPart.seniasParticularess = SeniasParticularesDB.GetListByidUbicacionSeniaParticular(id);
}
return myClaseUbicacionSeniaPart;
}

/// <summary>
/// Saves a ClaseUbicacionSeniaPart in the database.
/// </summary>
/// <param name="myClaseUbicacionSeniaPart">The ClaseUbicacionSeniaPart instance to save.</param>
/// <returns>The new id if the ClaseUbicacionSeniaPart is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(ClaseUbicacionSeniaPart myClaseUbicacionSeniaPart){
using (TransactionScope myTransactionScope = new TransactionScope()){
int claseUbicacionSeniaPartid = ClaseUbicacionSeniaPartDB.Save(myClaseUbicacionSeniaPart);
foreach (SeniasParticulares mySeniasParticulares in myClaseUbicacionSeniaPart.seniasParticularess){
mySeniasParticulares.id = claseUbicacionSeniaPartid;
SeniasParticularesDB.Save(mySeniasParticulares);
}

//  Assign the ClaseUbicacionSeniaPart its new (or existing id).
myClaseUbicacionSeniaPart.id = claseUbicacionSeniaPartid;

myTransactionScope.Complete();

return claseUbicacionSeniaPartid;
}
}

/// <summary>
/// Deletes a ClaseUbicacionSeniaPart from the database.
/// </summary>
/// <param name="myClaseUbicacionSeniaPart">The ClaseUbicacionSeniaPart instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(ClaseUbicacionSeniaPart myClaseUbicacionSeniaPart){
return ClaseUbicacionSeniaPartDB.Delete(myClaseUbicacionSeniaPart.id);
}

#endregion

}

}
