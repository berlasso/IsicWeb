using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Dal;


namespace MPBA.SIAC.Bll {

/// <summary>
/// The ClasePuntoGestionManager class is responsible for managing Business Object.ClasePuntoGestion objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class ClasePuntoGestionManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all ClasePuntoGestion objects in the database.
/// </summary>
/// <returns>A list with all ClasePuntoGestion from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static ClasePuntoGestionList GetList(){
return ClasePuntoGestionDB.GetList();
}

/// <summary>
/// Gets a single ClasePuntoGestion from the database without its data.
/// </summary>
/// <param name="id">The id of the ClasePuntoGestion in the database.</param>
/// <returns>A ClasePuntoGestion object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static ClasePuntoGestion GetItem(string id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single ClasePuntoGestion from the database.
/// </summary>
/// <param name="id">The id of the ClasePuntoGestion in the database.</param>
/// <param name="getClasePuntoGestionRecords">Determines whether to load all associated ClasePuntoGestion records as well.</param>
/// <returns>
/// A ClasePuntoGestion object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static ClasePuntoGestion GetItem(string id, bool getClasePuntoGestionRecords){
ClasePuntoGestion myClasePuntoGestion = ClasePuntoGestionDB.GetItem(id);
if (myClasePuntoGestion != null && getClasePuntoGestionRecords){
myClasePuntoGestion.puntoGestions = PuntoGestionDB.GetListByidClasePuntoGestion(id);
}
return myClasePuntoGestion;
}

/// <summary>
/// Saves a ClasePuntoGestion in the database.
/// </summary>
/// <param name="myClasePuntoGestion">The ClasePuntoGestion instance to save.</param>
/// <returns>The new id if the ClasePuntoGestion is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static string Save(ClasePuntoGestion myClasePuntoGestion){
using (TransactionScope myTransactionScope = new TransactionScope()){
string clasePuntoGestionid = Convert.ToString(ClasePuntoGestionDB.Save(myClasePuntoGestion));
foreach (PuntoGestion myPuntoGestion in myClasePuntoGestion.puntoGestions){
myPuntoGestion.id = clasePuntoGestionid;
PuntoGestionDB.Save(myPuntoGestion);
}

//  Assign the ClasePuntoGestion its new (or existing id).
myClasePuntoGestion.id = clasePuntoGestionid;

myTransactionScope.Complete();

return clasePuntoGestionid;
}
}

/// <summary>
/// Deletes a ClasePuntoGestion from the database.
/// </summary>
/// <param name="myClasePuntoGestion">The ClasePuntoGestion instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(ClasePuntoGestion myClasePuntoGestion){
return ClasePuntoGestionDB.Delete(myClasePuntoGestion.id);
}

#endregion

}

}
