using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll{

/// <summary>
/// The PBClaseLongitudCabelloManager class is responsible for managing Business Object.PBClaseLongitudCabello objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class PBClaseLongitudCabelloManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all PBClaseLongitudCabello objects in the database.
/// </summary>
/// <returns>A list with all PBClaseLongitudCabello from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static PBClaseLongitudCabelloList GetList(){
return PBClaseLongitudCabelloDB.GetList();
}

/// <summary>
/// Gets a single PBClaseLongitudCabello from the database without its data.
/// </summary>
/// <param name="id">The Id of the PBClaseLongitudCabello in the database.</param>
/// <returns>A PBClaseLongitudCabello object when the Id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PBClaseLongitudCabello GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single PBClaseLongitudCabello from the database.
/// </summary>
/// <param name="id">The Id of the PBClaseLongitudCabello in the database.</param>
/// <param name="getPBClaseLongitudCabelloRecords">Determines whether to load all associated PBClaseLongitudCabello records as well.</param>
/// <returns>
/// A PBClaseLongitudCabello object when the Id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PBClaseLongitudCabello GetItem(int id, bool getPBClaseLongitudCabelloRecords){
PBClaseLongitudCabello myPBClaseLongitudCabello = PBClaseLongitudCabelloDB.GetItem(id);
//if (myPBClaseLongitudCabello != null && getPBClaseLongitudCabelloRecords){
//myPBClaseLongitudCabello.busquedas = BusquedaDB.GetListByidLongitudCabellos(id);
//}
if (myPBClaseLongitudCabello != null && getPBClaseLongitudCabelloRecords){
myPBClaseLongitudCabello.personasDesaparecidass = PersonasDesaparecidasDB.GetListByidLongitudCabello(id);
}
if (myPBClaseLongitudCabello != null && getPBClaseLongitudCabelloRecords){
myPBClaseLongitudCabello.personasHalladass = PersonasHalladasDB.GetListByidLongitudCabello(id);
}
return myPBClaseLongitudCabello;
}

/// <summary>
/// Saves a PBClaseLongitudCabello in the database.
/// </summary>
/// <param name="myPBClaseLongitudCabello">The PBClaseLongitudCabello instance to save.</param>
/// <returns>The new Id if the PBClaseLongitudCabello is new in the database or the existing Id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(PBClaseLongitudCabello myPBClaseLongitudCabello){
using (TransactionScope myTransactionScope = new TransactionScope()){
int pBClaseLongitudCabelloId = PBClaseLongitudCabelloDB.Save(myPBClaseLongitudCabello);
foreach (Busqueda myBusqueda in myPBClaseLongitudCabello.busquedas){
myBusqueda.Id = pBClaseLongitudCabelloId;
BusquedaDB.Save(myBusqueda);
}
foreach (PersonasDesaparecidas myPersonasDesaparecidas in myPBClaseLongitudCabello.personasDesaparecidass){
myPersonasDesaparecidas.Id = pBClaseLongitudCabelloId;
PersonasDesaparecidasDB.Save(myPersonasDesaparecidas);
}
foreach (PersonasHalladas myPersonasHalladas in myPBClaseLongitudCabello.personasHalladass){
myPersonasHalladas.Id = pBClaseLongitudCabelloId;
PersonasHalladasDB.Save(myPersonasHalladas);
}

//  Assign the PBClaseLongitudCabello its new (or existing Id).
myPBClaseLongitudCabello.Id = pBClaseLongitudCabelloId;

myTransactionScope.Complete();

return pBClaseLongitudCabelloId;
}
}

/// <summary>
/// Deletes a PBClaseLongitudCabello from the database.
/// </summary>
/// <param name="myPBClaseLongitudCabello">The PBClaseLongitudCabello instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(PBClaseLongitudCabello myPBClaseLongitudCabello){
return PBClaseLongitudCabelloDB.Delete(myPBClaseLongitudCabello.Id);
}

#endregion

}

}
