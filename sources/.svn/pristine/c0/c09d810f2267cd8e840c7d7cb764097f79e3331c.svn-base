using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll {

/// <summary>
/// The PBClaseOrganismoIntervinienteManager class is responsible for managing Business Object.PBClaseOrganismoInterviniente objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class PBClaseOrganismoIntervinienteManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all PBClaseOrganismoInterviniente objects in the database.
/// </summary>
/// <returns>A list with all PBClaseOrganismoInterviniente from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static PBClaseOrganismoIntervinienteList GetList(){
return PBClaseOrganismoIntervinienteDB.GetList();
}

/// <summary>
/// Gets a single PBClaseOrganismoInterviniente from the database without its data.
/// </summary>
/// <param name="id">The Id of the PBClaseOrganismoInterviniente in the database.</param>
/// <returns>A PBClaseOrganismoInterviniente object when the Id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PBClaseOrganismoInterviniente GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single PBClaseOrganismoInterviniente from the database.
/// </summary>
/// <param name="id">The Id of the PBClaseOrganismoInterviniente in the database.</param>
/// <param name="getPBClaseOrganismoIntervinienteRecords">Determines whether to load all associated PBClaseOrganismoInterviniente records as well.</param>
/// <returns>
/// A PBClaseOrganismoInterviniente object when the Id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PBClaseOrganismoInterviniente GetItem(int id, bool getPBClaseOrganismoIntervinienteRecords){
PBClaseOrganismoInterviniente myPBClaseOrganismoInterviniente = PBClaseOrganismoIntervinienteDB.GetItem(id);
if (myPBClaseOrganismoInterviniente != null && getPBClaseOrganismoIntervinienteRecords){
myPBClaseOrganismoInterviniente.personasDesaparecidass = PersonasDesaparecidasDB.GetListByidOrganismoInterviniente(id);
}
if (myPBClaseOrganismoInterviniente != null && getPBClaseOrganismoIntervinienteRecords){
myPBClaseOrganismoInterviniente.personasHalladass = PersonasHalladasDB.GetListByidOrganismoInterviniente(id);
}
return myPBClaseOrganismoInterviniente;
}

/// <summary>
/// Saves a PBClaseOrganismoInterviniente in the database.
/// </summary>
/// <param name="myPBClaseOrganismoInterviniente">The PBClaseOrganismoInterviniente instance to save.</param>
/// <returns>The new Id if the PBClaseOrganismoInterviniente is new in the database or the existing Id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(PBClaseOrganismoInterviniente myPBClaseOrganismoInterviniente){
using (TransactionScope myTransactionScope = new TransactionScope()){
int pBClaseOrganismoIntervinienteId = PBClaseOrganismoIntervinienteDB.Save(myPBClaseOrganismoInterviniente);
foreach (PersonasDesaparecidas myPersonasDesaparecidas in myPBClaseOrganismoInterviniente.personasDesaparecidass){
myPersonasDesaparecidas.Id = pBClaseOrganismoIntervinienteId;
PersonasDesaparecidasDB.Save(myPersonasDesaparecidas);
}
foreach (PersonasHalladas myPersonasHalladas in myPBClaseOrganismoInterviniente.personasHalladass){
myPersonasHalladas.Id = pBClaseOrganismoIntervinienteId;
PersonasHalladasDB.Save(myPersonasHalladas);
}

//  Assign the PBClaseOrganismoInterviniente its new (or existing Id).
myPBClaseOrganismoInterviniente.Id = pBClaseOrganismoIntervinienteId;

myTransactionScope.Complete();

return pBClaseOrganismoIntervinienteId;
}
}

/// <summary>
/// Deletes a PBClaseOrganismoInterviniente from the database.
/// </summary>
/// <param name="myPBClaseOrganismoInterviniente">The PBClaseOrganismoInterviniente instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(PBClaseOrganismoInterviniente myPBClaseOrganismoInterviniente){
return PBClaseOrganismoIntervinienteDB.Delete(myPBClaseOrganismoInterviniente.Id);
}

#endregion

}

}
