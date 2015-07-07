using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll {

/// <summary>
/// The PBClaseSeniaParticularManager class is responsible for managing Business Object.PBClaseSeniaParticular objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class PBClaseSeniaParticularManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all PBClaseSeniaParticular objects in the database.
/// </summary>
/// <returns>A list with all PBClaseSeniaParticular from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static PBClaseSeniaParticularList GetList(){
return PBClaseSeniaParticularDB.GetList();
}

/// <summary>
/// Gets a single PBClaseSeniaParticular from the database without its data.
/// </summary>
/// <param name="id">The Id of the PBClaseSeniaParticular in the database.</param>
/// <returns>A PBClaseSeniaParticular object when the Id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PBClaseSeniaParticular GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single PBClaseSeniaParticular from the database.
/// </summary>
/// <param name="id">The Id of the PBClaseSeniaParticular in the database.</param>
/// <param name="getPBClaseSeniaParticularRecords">Determines whether to load all associated PBClaseSeniaParticular records as well.</param>
/// <returns>
/// A PBClaseSeniaParticular object when the Id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PBClaseSeniaParticular GetItem(int id, bool getPBClaseSeniaParticularRecords){
PBClaseSeniaParticular myPBClaseSeniaParticular = PBClaseSeniaParticularDB.GetItem(id);
//if (myPBClaseSeniaParticular != null && getPBClaseSeniaParticularRecords){
//myPBClaseSeniaParticular.busquedas = BusquedaDB.GetListByidSeniaParticular(id);
//}
if (myPBClaseSeniaParticular != null && getPBClaseSeniaParticularRecords){
myPBClaseSeniaParticular.personasDesaparecidass = PersonasDesaparecidasDB.GetListByidSeniaParticular(id);
}
if (myPBClaseSeniaParticular != null && getPBClaseSeniaParticularRecords){
myPBClaseSeniaParticular.personasHalladass = PersonasHalladasDB.GetListByidSeniaParticular(id);
}
return myPBClaseSeniaParticular;
}

/// <summary>
/// Saves a PBClaseSeniaParticular in the database.
/// </summary>
/// <param name="myPBClaseSeniaParticular">The PBClaseSeniaParticular instance to save.</param>
/// <returns>The new Id if the PBClaseSeniaParticular is new in the database or the existing Id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(PBClaseSeniaParticular myPBClaseSeniaParticular){
using (TransactionScope myTransactionScope = new TransactionScope()){
int pBClaseSeniaParticularId = PBClaseSeniaParticularDB.Save(myPBClaseSeniaParticular);
foreach (Busqueda myBusqueda in myPBClaseSeniaParticular.busquedas){
myBusqueda.Id = pBClaseSeniaParticularId;
BusquedaDB.Save(myBusqueda);
}
foreach (PersonasDesaparecidas myPersonasDesaparecidas in myPBClaseSeniaParticular.personasDesaparecidass){
myPersonasDesaparecidas.Id = pBClaseSeniaParticularId;
PersonasDesaparecidasDB.Save(myPersonasDesaparecidas);
}
foreach (PersonasHalladas myPersonasHalladas in myPBClaseSeniaParticular.personasHalladass){
myPersonasHalladas.Id = pBClaseSeniaParticularId;
PersonasHalladasDB.Save(myPersonasHalladas);
}

//  Assign the PBClaseSeniaParticular its new (or existing Id).
myPBClaseSeniaParticular.Id = pBClaseSeniaParticularId;

myTransactionScope.Complete();

return pBClaseSeniaParticularId;
}
}

/// <summary>
/// Deletes a PBClaseSeniaParticular from the database.
/// </summary>
/// <param name="myPBClaseSeniaParticular">The PBClaseSeniaParticular instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(PBClaseSeniaParticular myPBClaseSeniaParticular){
return PBClaseSeniaParticularDB.Delete(myPBClaseSeniaParticular.Id);
}

#endregion

}

}
