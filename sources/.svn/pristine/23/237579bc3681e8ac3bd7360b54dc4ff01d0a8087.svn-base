using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Dal;


namespace MPBA.SIAC.Bll {

/// <summary>
/// The ClaseTipoPersonaManager class is responsible for managing Business Entities.ClaseTipoPersona objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class ClaseTipoPersonaManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all ClaseTipoPersona objects in the database.
/// </summary>
/// <returns>A list with all ClaseTipoPersona from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static ClaseTipoPersonaList GetList(){
return ClaseTipoPersonaDB.GetList();
}

/// <summary>
/// Gets a single ClaseTipoPersona from the database without its data.
/// </summary>
/// <param name="id">The id of the ClaseTipoPersona in the database.</param>
/// <returns>A ClaseTipoPersona object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static ClaseTipoPersona GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single ClaseTipoPersona from the database.
/// </summary>
/// <param name="id">The id of the ClaseTipoPersona in the database.</param>
/// <param name="getClaseTipoPersonaRecords">Determines whether to load all associated ClaseTipoPersona records as well.</param>
/// <returns>
/// A ClaseTipoPersona object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static ClaseTipoPersona GetItem(int id, bool getClaseTipoPersonaRecords){
ClaseTipoPersona myClaseTipoPersona = ClaseTipoPersonaDB.GetItem(id);
if (myClaseTipoPersona != null && getClaseTipoPersonaRecords){
myClaseTipoPersona.seniasParticularess = SeniasParticularesDB.GetListByidTablaDestino(id);
}
return myClaseTipoPersona;
}

/// <summary>
/// Saves a ClaseTipoPersona in the database.
/// </summary>
/// <param name="myClaseTipoPersona">The ClaseTipoPersona instance to save.</param>
/// <returns>The new id if the ClaseTipoPersona is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(ClaseTipoPersona myClaseTipoPersona){
using (TransactionScope myTransactionScope = new TransactionScope()){
int claseTipoPersonaid = ClaseTipoPersonaDB.Save(myClaseTipoPersona);
foreach (SeniasParticulares mySeniasParticulares in myClaseTipoPersona.seniasParticularess){
mySeniasParticulares.id = claseTipoPersonaid;
SeniasParticularesDB.Save(mySeniasParticulares);
}

//  Assign the ClaseTipoPersona its new (or existing id).
myClaseTipoPersona.id = claseTipoPersonaid;

myTransactionScope.Complete();

return claseTipoPersonaid;
}
}

/// <summary>
/// Deletes a ClaseTipoPersona from the database.
/// </summary>
/// <param name="myClaseTipoPersona">The ClaseTipoPersona instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(ClaseTipoPersona myClaseTipoPersona){
return ClaseTipoPersonaDB.Delete(myClaseTipoPersona.id);
}

#endregion

}

}
