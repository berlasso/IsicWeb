using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Dal;


namespace MPBA.SIAC.Bll {

/// <summary>
/// The PersonalPoderJudicialManager class is responsible for managing Business Entities.PersonalPoderJudicial objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class PersonalPoderJudicialManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all PersonalPoderJudicial objects in the database.
/// </summary>
/// <returns>A list with all PersonalPoderJudicial from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static PersonalPoderJudicialList GetList(){
return PersonalPoderJudicialDB.GetList();
}



/// <summary>
/// Gets a single PersonalPoderJudicial from the database without its data.
/// </summary>
/// <param name="id">The id of the PersonalPoderJudicial in the database.</param>
/// <returns>A PersonalPoderJudicial object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PersonalPoderJudicial GetItem(string id){
return GetItem(id, false);
}



/// <summary>
/// Gets a single PersonalPoderJudicial from the database.
/// </summary>
/// <param name="id">The id of the PersonalPoderJudicial in the database.</param>
/// <param name="getPersonalPoderJudicialRecords">Determines whether to load all associated PersonalPoderJudicial records as well.</param>
/// <returns>
/// A PersonalPoderJudicial object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PersonalPoderJudicial GetItem(string id, bool getPersonalPoderJudicialRecords){
PersonalPoderJudicial myPersonalPoderJudicial = PersonalPoderJudicialDB.GetItem(id);
if (myPersonalPoderJudicial != null && getPersonalPoderJudicialRecords){
myPersonalPoderJudicial.usuarioss = UsuariosDB.GetListByidPersonalPoderJudicial(id);
}
return myPersonalPoderJudicial;
}

/// <summary>
/// Saves a PersonalPoderJudicial in the database.
/// </summary>
/// <param name="myPersonalPoderJudicial">The PersonalPoderJudicial instance to save.</param>
/// <returns>The new id if the PersonalPoderJudicial is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static string Save(PersonalPoderJudicial myPersonalPoderJudicial){
using (TransactionScope myTransactionScope = new TransactionScope()){
string personalPoderJudicialid = PersonalPoderJudicialDB.Save(myPersonalPoderJudicial);
foreach (Usuarios myUsuarios in myPersonalPoderJudicial.usuarioss){
myUsuarios.id = personalPoderJudicialid;
UsuariosDB.Save(myUsuarios);
}

//  Assign the PersonalPoderJudicial its new (or existing id).
myPersonalPoderJudicial.id = personalPoderJudicialid;

myTransactionScope.Complete();

return personalPoderJudicialid;
}
}

/// <summary>
/// Deletes a PersonalPoderJudicial from the database.
/// </summary>
/// <param name="myPersonalPoderJudicial">The PersonalPoderJudicial instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(PersonalPoderJudicial myPersonalPoderJudicial){
return PersonalPoderJudicialDB.Delete(myPersonalPoderJudicial.id);
}

#endregion

}

}
