using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Dal;


namespace MPBA.SIAC.Bll {

/// <summary>
/// The ClasePersonaManager class is responsible for managing Business Entities.ClasePersona objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class ClasePersonaManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all ClasePersona objects in the database.
/// </summary>
/// <returns>A list with all ClasePersona from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static ClasePersonaList GetList(){
return ClasePersonaDB.GetList();
}

/// <summary>
/// Gets a single ClasePersona from the database without its data.
/// </summary>
/// <param name="id">The id of the ClasePersona in the database.</param>
/// <returns>A ClasePersona object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static ClasePersona GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single ClasePersona from the database.
/// </summary>
/// <param name="id">The id of the ClasePersona in the database.</param>
/// <param name="getClasePersonaRecords">Determines whether to load all associated ClasePersona records as well.</param>
/// <returns>
/// A ClasePersona object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static ClasePersona GetItem(int id, bool getClasePersonaRecords){
ClasePersona myClasePersona = ClasePersonaDB.GetItem(id);
if (myClasePersona != null && getClasePersonaRecords){
myClasePersona.personas = PersonaDB.GetListByidTipoPersona(id);
}
return myClasePersona;
}

/// <summary>
/// Saves a ClasePersona in the database.
/// </summary>
/// <param name="myClasePersona">The ClasePersona instance to save.</param>
/// <returns>The new id if the ClasePersona is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(ClasePersona myClasePersona){
using (TransactionScope myTransactionScope = new TransactionScope()){
int clasePersonaid = ClasePersonaDB.Save(myClasePersona);
foreach (Persona myPersona in myClasePersona.personas){
myPersona.idTipoPersona = clasePersonaid;
PersonaDB.Save(myPersona);
}

//  Assign the ClasePersona its new (or existing id).
myClasePersona.id = clasePersonaid;

myTransactionScope.Complete();

return clasePersonaid;
}
}

/// <summary>
/// Deletes a ClasePersona from the database.
/// </summary>
/// <param name="myClasePersona">The ClasePersona instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(ClasePersona myClasePersona){
return ClasePersonaDB.Delete(myClasePersona.id);
}

#endregion

}

}
