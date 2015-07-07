using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll {

/// <summary>
/// The PBClaseColorCabelloManager class is responsible for managing Business Object.PBClaseColorCabello objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class PBClaseColorCabelloManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all PBClaseColorCabello objects in the database.
/// </summary>
/// <returns>A list with all PBClaseColorCabello from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static PBClaseColorCabelloList GetList(){
return PBClaseColorCabelloDB.GetList();
}

/// <summary>
/// Gets a single PBClaseColorCabello from the database without its data.
/// </summary>
/// <param name="id">The Id of the PBClaseColorCabello in the database.</param>
/// <returns>A PBClaseColorCabello object when the Id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PBClaseColorCabello GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single PBClaseColorCabello from the database.
/// </summary>
/// <param name="id">The Id of the PBClaseColorCabello in the database.</param>
/// <param name="getPBClaseColorCabelloRecords">Determines whether to load all associated PBClaseColorCabello records as well.</param>
/// <returns>
/// A PBClaseColorCabello object when the Id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PBClaseColorCabello GetItem(int id, bool getPBClaseColorCabelloRecords){
PBClaseColorCabello myPBClaseColorCabello = PBClaseColorCabelloDB.GetItem(id);
//if (myPBClaseColorCabello != null && getPBClaseColorCabelloRecords){
//myPBClaseColorCabello.busquedas = BusquedaDB.GetListByidColorCabello(id);
//}
if (myPBClaseColorCabello != null && getPBClaseColorCabelloRecords){
myPBClaseColorCabello.personasDesaparecidass = PersonasDesaparecidasDB.GetListByidColorCabello(id);
}
if (myPBClaseColorCabello != null && getPBClaseColorCabelloRecords){
myPBClaseColorCabello.personasHalladass = PersonasHalladasDB.GetListByidColorCabello(id);
}
return myPBClaseColorCabello;
}

/// <summary>
/// Saves a PBClaseColorCabello in the database.
/// </summary>
/// <param name="myPBClaseColorCabello">The PBClaseColorCabello instance to save.</param>
/// <returns>The new Id if the PBClaseColorCabello is new in the database or the existing Id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(PBClaseColorCabello myPBClaseColorCabello){
using (TransactionScope myTransactionScope = new TransactionScope()){
int pBClaseColorCabelloId = PBClaseColorCabelloDB.Save(myPBClaseColorCabello);
foreach (Busqueda myBusqueda in myPBClaseColorCabello.busquedas){
myBusqueda.Id = pBClaseColorCabelloId;
BusquedaDB.Save(myBusqueda);
}
foreach (PersonasDesaparecidas myPersonasDesaparecidas in myPBClaseColorCabello.personasDesaparecidass){
myPersonasDesaparecidas.Id = pBClaseColorCabelloId;
PersonasDesaparecidasDB.Save(myPersonasDesaparecidas);
}
foreach (PersonasHalladas myPersonasHalladas in myPBClaseColorCabello.personasHalladass){
myPersonasHalladas.Id = pBClaseColorCabelloId;
PersonasHalladasDB.Save(myPersonasHalladas);
}

//  Assign the PBClaseColorCabello its new (or existing Id).
myPBClaseColorCabello.Id = pBClaseColorCabelloId;

myTransactionScope.Complete();

return pBClaseColorCabelloId;
}
}

/// <summary>
/// Deletes a PBClaseColorCabello from the database.
/// </summary>
/// <param name="myPBClaseColorCabello">The PBClaseColorCabello instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(PBClaseColorCabello myPBClaseColorCabello){
return PBClaseColorCabelloDB.Delete(myPBClaseColorCabello.Id);
}

#endregion

}

}
