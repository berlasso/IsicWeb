using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll {

/// <summary>
/// The PBClaseColorDePielManager class is responsible for managing Business Object.PBClaseColorDePiel objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class PBClaseColorDePielManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all PBClaseColorDePiel objects in the database.
/// </summary>
/// <returns>A list with all PBClaseColorDePiel from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static PBClaseColorDePielList GetList(){
return PBClaseColorDePielDB.GetList();
}

/// <summary>
/// Gets a single PBClaseColorDePiel from the database without its data.
/// </summary>
/// <param name="id">The Id of the PBClaseColorDePiel in the database.</param>
/// <returns>A PBClaseColorDePiel object when the Id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PBClaseColorDePiel GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single PBClaseColorDePiel from the database.
/// </summary>
/// <param name="id">The Id of the PBClaseColorDePiel in the database.</param>
/// <param name="getPBClaseColorDePielRecords">Determines whether to load all associated PBClaseColorDePiel records as well.</param>
/// <returns>
/// A PBClaseColorDePiel object when the Id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PBClaseColorDePiel GetItem(int id, bool getPBClaseColorDePielRecords){
PBClaseColorDePiel myPBClaseColorDePiel = PBClaseColorDePielDB.GetItem(id);
//if (myPBClaseColorDePiel != null && getPBClaseColorDePielRecords){
//myPBClaseColorDePiel.busquedas = BusquedaDB.GetListByidColorPiel(id);
//}
if (myPBClaseColorDePiel != null && getPBClaseColorDePielRecords){
myPBClaseColorDePiel.personasDesaparecidass = PersonasDesaparecidasDB.GetListByidColorPiel(id);
}
if (myPBClaseColorDePiel != null && getPBClaseColorDePielRecords){
myPBClaseColorDePiel.personasHalladass = PersonasHalladasDB.GetListByidColorPiel(id);
}
return myPBClaseColorDePiel;
}

/// <summary>
/// Saves a PBClaseColorDePiel in the database.
/// </summary>
/// <param name="myPBClaseColorDePiel">The PBClaseColorDePiel instance to save.</param>
/// <returns>The new Id if the PBClaseColorDePiel is new in the database or the existing Id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(PBClaseColorDePiel myPBClaseColorDePiel){
using (TransactionScope myTransactionScope = new TransactionScope()){
int pBClaseColorDePielId = PBClaseColorDePielDB.Save(myPBClaseColorDePiel);
foreach (Busqueda myBusqueda in myPBClaseColorDePiel.busquedas){
myBusqueda.Id = pBClaseColorDePielId;
BusquedaDB.Save(myBusqueda);
}
foreach (PersonasDesaparecidas myPersonasDesaparecidas in myPBClaseColorDePiel.personasDesaparecidass){
myPersonasDesaparecidas.Id = pBClaseColorDePielId;
PersonasDesaparecidasDB.Save(myPersonasDesaparecidas);
}
foreach (PersonasHalladas myPersonasHalladas in myPBClaseColorDePiel.personasHalladass){
myPersonasHalladas.Id = pBClaseColorDePielId;
PersonasHalladasDB.Save(myPersonasHalladas);
}

//  Assign the PBClaseColorDePiel its new (or existing Id).
myPBClaseColorDePiel.Id = pBClaseColorDePielId;

myTransactionScope.Complete();

return pBClaseColorDePielId;
}
}

/// <summary>
/// Deletes a PBClaseColorDePiel from the database.
/// </summary>
/// <param name="myPBClaseColorDePiel">The PBClaseColorDePiel instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(PBClaseColorDePiel myPBClaseColorDePiel){
return PBClaseColorDePielDB.Delete(myPBClaseColorDePiel.Id);
}

#endregion

}

}
