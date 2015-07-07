using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Dal;


namespace MPBA.SIAC.Bll
{

/// <summary>
/// The PuntoGestionManager class is responsible for managing Business Entities.PuntoGestion objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class PuntoGestionManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all PuntoGestion objects in the database.
/// </summary>
/// <returns>A list with all PuntoGestion from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static PuntoGestionList GetList(){
return PuntoGestionDB.GetList();
}


/// <summary>
/// Gets a list with all PuntoGestion objects in the database.
/// </summary>
/// <returns>A list with all PuntoGestion from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static PuntoGestionList GetList(int idDepartamento)
{
    return PuntoGestionDB.GetListByidDepartamento(idDepartamento);
}

/// <summary>
/// Gets a list with all PuntoGestion objects in the database.
/// </summary>
/// <returns>A list with all PuntoGestion from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static PuntoGestionList GetListDependenciasPJByidDepartamento(int idDepartamento)
{
    return PuntoGestionDB.GetListDependenciasPJByidDepartamento(idDepartamento);
}

/// <summary>
/// Gets a single PuntoGestion from the database without its data.
/// </summary>
/// <param name="id">The id of the PuntoGestion in the database.</param>
/// <returns>A PuntoGestion object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PuntoGestion GetItem(string id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single PuntoGestion from the database for a usuario without its data.
/// </summary>
/// <param name="id">The id of the usuario in the database.</param>
/// <returns>A PuntoGestion object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PuntoGestion GetItemByUsuario(string idUsuario)
{
    return PuntoGestionDB.GetItemByUsuario(idUsuario);
}

/// <summary>
/// Gets a single PuntoGestion from the database.
/// </summary>
/// <param name="id">The id of the PuntoGestion in the database.</param>
/// <param name="getPuntoGestionRecords">Determines whether to load all associated PuntoGestion records as well.</param>
/// <returns>
/// A PuntoGestion object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PuntoGestion GetItem(string id, bool getPuntoGestionRecords){
PuntoGestion myPuntoGestion = PuntoGestionDB.GetItem(id);
if (myPuntoGestion != null && getPuntoGestionRecords){
myPuntoGestion.personalPoderJudicials = PersonalPoderJudicialDB.GetListByidPuntoGestion(id);
}
return myPuntoGestion;
}

/// <summary>
/// Saves a PuntoGestion in the database.
/// </summary>
/// <param name="myPuntoGestion">The PuntoGestion instance to save.</param>
/// <returns>The new id if the PuntoGestion is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static string Save(PuntoGestion myPuntoGestion){
using (TransactionScope myTransactionScope = new TransactionScope()){
string puntoGestionid = PuntoGestionDB.Save(myPuntoGestion);
foreach (PersonalPoderJudicial myPersonalPoderJudicial in myPuntoGestion.personalPoderJudicials){
myPersonalPoderJudicial.id = puntoGestionid;
PersonalPoderJudicialDB.Save(myPersonalPoderJudicial);
}

//  Assign the PuntoGestion its new (or existing id).
myPuntoGestion.id = puntoGestionid;

myTransactionScope.Complete();

return puntoGestionid;
}
}

/// <summary>
/// Deletes a PuntoGestion from the database.
/// </summary>
/// <param name="myPuntoGestion">The PuntoGestion instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(PuntoGestion myPuntoGestion){
return PuntoGestionDB.Delete(myPuntoGestion.id);
}

#endregion

}

}
