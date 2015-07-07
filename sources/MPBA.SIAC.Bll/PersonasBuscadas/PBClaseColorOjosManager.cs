using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll {

/// <summary>
/// The PBClaseColorOjosManager class is responsible for managing Business Object.PBClaseColorOjos objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class PBClaseColorOjosManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all PBClaseColorOjos objects in the database.
/// </summary>
/// <returns>A list with all PBClaseColorOjos from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static PBClaseColorOjosList GetList(){
return PBClaseColorOjosDB.GetList();
}

/// <summary>
/// Gets a single PBClaseColorOjos from the database without its data.
/// </summary>
/// <param name="id">The Id of the PBClaseColorOjos in the database.</param>
/// <returns>A PBClaseColorOjos object when the Id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PBClaseColorOjos GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single PBClaseColorOjos from the database.
/// </summary>
/// <param name="id">The Id of the PBClaseColorOjos in the database.</param>
/// <param name="getPBClaseColorOjosRecords">Determines whether to load all associated PBClaseColorOjos records as well.</param>
/// <returns>
/// A PBClaseColorOjos object when the Id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PBClaseColorOjos GetItem(int id, bool getPBClaseColorOjosRecords){
PBClaseColorOjos myPBClaseColorOjos = PBClaseColorOjosDB.GetItem(id);
//if (myPBClaseColorOjos != null && getPBClaseColorOjosRecords){
//myPBClaseColorOjos.busquedas = BusquedaDB.GetListByidColorOjos(id);
//}
if (myPBClaseColorOjos != null && getPBClaseColorOjosRecords){
myPBClaseColorOjos.personasDesaparecidass = PersonasDesaparecidasDB.GetListByidColorOjos(id);
}
if (myPBClaseColorOjos != null && getPBClaseColorOjosRecords){
myPBClaseColorOjos.personasHalladass = PersonasHalladasDB.GetListByidColorOjos(id);
}
return myPBClaseColorOjos;
}

/// <summary>
/// Saves a PBClaseColorOjos in the database.
/// </summary>
/// <param name="myPBClaseColorOjos">The PBClaseColorOjos instance to save.</param>
/// <returns>The new Id if the PBClaseColorOjos is new in the database or the existing Id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(PBClaseColorOjos myPBClaseColorOjos){
using (TransactionScope myTransactionScope = new TransactionScope()){
int pBClaseColorOjosId = PBClaseColorOjosDB.Save(myPBClaseColorOjos);
foreach (Busqueda myBusqueda in myPBClaseColorOjos.busquedas){
myBusqueda.Id = pBClaseColorOjosId;
BusquedaDB.Save(myBusqueda);
}
foreach (PersonasDesaparecidas myPersonasDesaparecidas in myPBClaseColorOjos.personasDesaparecidass){
myPersonasDesaparecidas.Id = pBClaseColorOjosId;
PersonasDesaparecidasDB.Save(myPersonasDesaparecidas);
}
foreach (PersonasHalladas myPersonasHalladas in myPBClaseColorOjos.personasHalladass){
myPersonasHalladas.Id = pBClaseColorOjosId;
PersonasHalladasDB.Save(myPersonasHalladas);
}

//  Assign the PBClaseColorOjos its new (or existing Id).
myPBClaseColorOjos.Id = pBClaseColorOjosId;

myTransactionScope.Complete();

return pBClaseColorOjosId;
}
}

/// <summary>
/// Deletes a PBClaseColorOjos from the database.
/// </summary>
/// <param name="myPBClaseColorOjos">The PBClaseColorOjos instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(PBClaseColorOjos myPBClaseColorOjos){
return PBClaseColorOjosDB.Delete(myPBClaseColorOjos.Id);
}

#endregion

}

}
