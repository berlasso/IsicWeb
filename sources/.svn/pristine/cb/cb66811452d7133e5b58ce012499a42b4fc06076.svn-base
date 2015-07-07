using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll {

/// <summary>
/// The PBClaseCalvicieManager class is responsible for managing Business Object.PBClaseCalvicie objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class PBClaseCalvicieManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all PBClaseCalvicie objects in the database.
/// </summary>
/// <returns>A list with all PBClaseCalvicie from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static PBClaseCalvicieList GetList(){
return PBClaseCalvicieDB.GetList();
}

/// <summary>
/// Gets a single PBClaseCalvicie from the database without its data.
/// </summary>
/// <param name="id">The Id of the PBClaseCalvicie in the database.</param>
/// <returns>A PBClaseCalvicie object when the Id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PBClaseCalvicie GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single PBClaseCalvicie from the database.
/// </summary>
/// <param name="id">The Id of the PBClaseCalvicie in the database.</param>
/// <param name="getPBClaseCalvicieRecords">Determines whether to load all associated PBClaseCalvicie records as well.</param>
/// <returns>
/// A PBClaseCalvicie object when the Id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PBClaseCalvicie GetItem(int id, bool getPBClaseCalvicieRecords){
PBClaseCalvicie myPBClaseCalvicie = PBClaseCalvicieDB.GetItem(id);
//if (myPBClaseCalvicie != null && getPBClaseCalvicieRecords){
//myPBClaseCalvicie.busquedas = BusquedaDB.GetListByidCalvicie(id);
//}
if (myPBClaseCalvicie != null && getPBClaseCalvicieRecords){
myPBClaseCalvicie.personasDesaparecidass = PersonasDesaparecidasDB.GetListByidCalvicie(id);
}
if (myPBClaseCalvicie != null && getPBClaseCalvicieRecords){
myPBClaseCalvicie.personasHalladass = PersonasHalladasDB.GetListByidCalvicie(id);
}
return myPBClaseCalvicie;
}

/// <summary>
/// Saves a PBClaseCalvicie in the database.
/// </summary>
/// <param name="myPBClaseCalvicie">The PBClaseCalvicie instance to save.</param>
/// <returns>The new Id if the PBClaseCalvicie is new in the database or the existing Id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(PBClaseCalvicie myPBClaseCalvicie){
using (TransactionScope myTransactionScope = new TransactionScope()){
int pBClaseCalvicieId = PBClaseCalvicieDB.Save(myPBClaseCalvicie);
foreach (Busqueda myBusqueda in myPBClaseCalvicie.busquedas){
myBusqueda.Id = pBClaseCalvicieId;
BusquedaDB.Save(myBusqueda);
}
foreach (PersonasDesaparecidas myPersonasDesaparecidas in myPBClaseCalvicie.personasDesaparecidass){
myPersonasDesaparecidas.Id = pBClaseCalvicieId;
PersonasDesaparecidasDB.Save(myPersonasDesaparecidas);
}
foreach (PersonasHalladas myPersonasHalladas in myPBClaseCalvicie.personasHalladass){
myPersonasHalladas.Id = pBClaseCalvicieId;
PersonasHalladasDB.Save(myPersonasHalladas);
}

//  Assign the PBClaseCalvicie its new (or existing Id).
myPBClaseCalvicie.Id = pBClaseCalvicieId;

myTransactionScope.Complete();

return pBClaseCalvicieId;
}
}

/// <summary>
/// Deletes a PBClaseCalvicie from the database.
/// </summary>
/// <param name="myPBClaseCalvicie">The PBClaseCalvicie instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(PBClaseCalvicie myPBClaseCalvicie){
return PBClaseCalvicieDB.Delete(myPBClaseCalvicie.Id);
}

#endregion

}

}
