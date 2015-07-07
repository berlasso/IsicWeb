using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll {

/// <summary>
/// The PBClaseUbicacionSeniaPartManager class is responsible for managing Business Object.PBClaseUbicacionSeniaPart objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class PBClaseUbicacionSeniaPartManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all PBClaseUbicacionSeniaPart objects in the database.
/// </summary>
/// <returns>A list with all PBClaseUbicacionSeniaPart from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static PBClaseUbicacionSeniaPartList GetList(){
return PBClaseUbicacionSeniaPartDB.GetList();
}

/// <summary>
/// Gets a single PBClaseUbicacionSeniaPart from the database without its data.
/// </summary>
/// <param name="id">The Id of the PBClaseUbicacionSeniaPart in the database.</param>
/// <returns>A PBClaseUbicacionSeniaPart object when the Id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PBClaseUbicacionSeniaPart GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single PBClaseUbicacionSeniaPart from the database.
/// </summary>
/// <param name="id">The Id of the PBClaseUbicacionSeniaPart in the database.</param>
/// <param name="getPBClaseUbicacionSeniaPartRecords">Determines whether to load all associated PBClaseUbicacionSeniaPart records as well.</param>
/// <returns>
/// A PBClaseUbicacionSeniaPart object when the Id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PBClaseUbicacionSeniaPart GetItem(int id, bool getPBClaseUbicacionSeniaPartRecords){
PBClaseUbicacionSeniaPart myPBClaseUbicacionSeniaPart = PBClaseUbicacionSeniaPartDB.GetItem(id);
//if (myPBClaseUbicacionSeniaPart != null && getPBClaseUbicacionSeniaPartRecords){
//myPBClaseUbicacionSeniaPart.busquedas = BusquedaDB.GetListByidUbicacionSeniaParticular(id);
//}
if (myPBClaseUbicacionSeniaPart != null && getPBClaseUbicacionSeniaPartRecords){
myPBClaseUbicacionSeniaPart.personasDesaparecidass = PersonasDesaparecidasDB.GetListByidSeniaParticular(id);
}
if (myPBClaseUbicacionSeniaPart != null && getPBClaseUbicacionSeniaPartRecords){
myPBClaseUbicacionSeniaPart.personasHalladass = PersonasHalladasDB.GetListByidUbicacionSeniaParticular(id);
}
return myPBClaseUbicacionSeniaPart;
}

/// <summary>
/// Saves a PBClaseUbicacionSeniaPart in the database.
/// </summary>
/// <param name="myPBClaseUbicacionSeniaPart">The PBClaseUbicacionSeniaPart instance to save.</param>
/// <returns>The new Id if the PBClaseUbicacionSeniaPart is new in the database or the existing Id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(PBClaseUbicacionSeniaPart myPBClaseUbicacionSeniaPart){
using (TransactionScope myTransactionScope = new TransactionScope()){
int pBClaseUbicacionSeniaPartId = PBClaseUbicacionSeniaPartDB.Save(myPBClaseUbicacionSeniaPart);
foreach (Busqueda myBusqueda in myPBClaseUbicacionSeniaPart.busquedas){
myBusqueda.Id = pBClaseUbicacionSeniaPartId;
BusquedaDB.Save(myBusqueda);
}
foreach (PersonasDesaparecidas myPersonasDesaparecidas in myPBClaseUbicacionSeniaPart.personasDesaparecidass){
myPersonasDesaparecidas.Id = pBClaseUbicacionSeniaPartId;
PersonasDesaparecidasDB.Save(myPersonasDesaparecidas);
}
foreach (PersonasHalladas myPersonasHalladas in myPBClaseUbicacionSeniaPart.personasHalladass){
myPersonasHalladas.Id = pBClaseUbicacionSeniaPartId;
PersonasHalladasDB.Save(myPersonasHalladas);
}

//  Assign the PBClaseUbicacionSeniaPart its new (or existing Id).
myPBClaseUbicacionSeniaPart.Id = pBClaseUbicacionSeniaPartId;

myTransactionScope.Complete();

return pBClaseUbicacionSeniaPartId;
}
}

/// <summary>
/// Deletes a PBClaseUbicacionSeniaPart from the database.
/// </summary>
/// <param name="myPBClaseUbicacionSeniaPart">The PBClaseUbicacionSeniaPart instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(PBClaseUbicacionSeniaPart myPBClaseUbicacionSeniaPart){
return PBClaseUbicacionSeniaPartDB.Delete(myPBClaseUbicacionSeniaPart.Id);
}

#endregion

}

}
