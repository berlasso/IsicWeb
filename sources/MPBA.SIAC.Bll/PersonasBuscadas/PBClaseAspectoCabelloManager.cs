using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll {

/// <summary>
/// The PBClaseAspectoCabelloManager class is responsible for managing Business Object.PBClaseAspectoCabello objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class PBClaseAspectoCabelloManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all PBClaseAspectoCabello objects in the database.
/// </summary>
/// <returns>A list with all PBClaseAspectoCabello from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static PBClaseAspectoCabelloList GetList(){
return PBClaseAspectoCabelloDB.GetList();
}

/// <summary>
/// Gets a single PBClaseAspectoCabello from the database without its data.
/// </summary>
/// <param name="id">The Id of the PBClaseAspectoCabello in the database.</param>
/// <returns>A PBClaseAspectoCabello object when the Id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PBClaseAspectoCabello GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single PBClaseAspectoCabello from the database.
/// </summary>
/// <param name="id">The Id of the PBClaseAspectoCabello in the database.</param>
/// <param name="getPBClaseAspectoCabelloRecords">Determines whether to load all associated PBClaseAspectoCabello records as well.</param>
/// <returns>
/// A PBClaseAspectoCabello object when the Id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PBClaseAspectoCabello GetItem(int id, bool getPBClaseAspectoCabelloRecords){
PBClaseAspectoCabello myPBClaseAspectoCabello = PBClaseAspectoCabelloDB.GetItem(id);
//if (myPBClaseAspectoCabello != null && getPBClaseAspectoCabelloRecords){
//myPBClaseAspectoCabello.busquedas = BusquedaDB.GetListByidAspectoCabello(id);
//}
if (myPBClaseAspectoCabello != null && getPBClaseAspectoCabelloRecords){
myPBClaseAspectoCabello.personasDesaparecidass = PersonasDesaparecidasDB.GetListByidAspectoCabello(id);
}
if (myPBClaseAspectoCabello != null && getPBClaseAspectoCabelloRecords){
myPBClaseAspectoCabello.personasHalladass = PersonasHalladasDB.GetListByidAspectoCabello(id);
}
return myPBClaseAspectoCabello;
}

/// <summary>
/// Saves a PBClaseAspectoCabello in the database.
/// </summary>
/// <param name="myPBClaseAspectoCabello">The PBClaseAspectoCabello instance to save.</param>
/// <returns>The new Id if the PBClaseAspectoCabello is new in the database or the existing Id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(PBClaseAspectoCabello myPBClaseAspectoCabello){
using (TransactionScope myTransactionScope = new TransactionScope()){
int pBClaseAspectoCabelloId = PBClaseAspectoCabelloDB.Save(myPBClaseAspectoCabello);
foreach (Busqueda myBusqueda in myPBClaseAspectoCabello.busquedas){
myBusqueda.Id = pBClaseAspectoCabelloId;
BusquedaDB.Save(myBusqueda);
}
foreach (PersonasDesaparecidas myPersonasDesaparecidas in myPBClaseAspectoCabello.personasDesaparecidass){
myPersonasDesaparecidas.Id = pBClaseAspectoCabelloId;
PersonasDesaparecidasDB.Save(myPersonasDesaparecidas);
}
foreach (PersonasHalladas myPersonasHalladas in myPBClaseAspectoCabello.personasHalladass){
myPersonasHalladas.Id = pBClaseAspectoCabelloId;
PersonasHalladasDB.Save(myPersonasHalladas);
}

//  Assign the PBClaseAspectoCabello its new (or existing Id).
myPBClaseAspectoCabello.Id = pBClaseAspectoCabelloId;

myTransactionScope.Complete();

return pBClaseAspectoCabelloId;
}
}

/// <summary>
/// Deletes a PBClaseAspectoCabello from the database.
/// </summary>
/// <param name="myPBClaseAspectoCabello">The PBClaseAspectoCabello instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(PBClaseAspectoCabello myPBClaseAspectoCabello){
return PBClaseAspectoCabelloDB.Delete(myPBClaseAspectoCabello.Id);
}

#endregion

}

}
