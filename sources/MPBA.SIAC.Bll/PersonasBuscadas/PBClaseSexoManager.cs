using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll{

/// <summary>
/// The PBClaseSexoManager class is responsible for managing Business Object.PBClaseSexo objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class PBClaseSexoManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all PBClaseSexo objects in the database.
/// </summary>
/// <returns>A list with all PBClaseSexo from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static PBClaseSexoList GetList(){
return PBClaseSexoDB.GetList();
}

/// <summary>
/// Gets a single PBClaseSexo from the database without its data.
/// </summary>
/// <param name="id">The Id of the PBClaseSexo in the database.</param>
/// <returns>A PBClaseSexo object when the Id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PBClaseSexo GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single PBClaseSexo from the database.
/// </summary>
/// <param name="id">The Id of the PBClaseSexo in the database.</param>
/// <param name="getPBClaseSexoRecords">Determines whether to load all associated PBClaseSexo records as well.</param>
/// <returns>
/// A PBClaseSexo object when the Id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PBClaseSexo GetItem(int id, bool getPBClaseSexoRecords){
PBClaseSexo myPBClaseSexo = PBClaseSexoDB.GetItem(id);
if (myPBClaseSexo != null && getPBClaseSexoRecords){
myPBClaseSexo.busquedas = BusquedaDB.GetListByidsexo(id);
}
if (myPBClaseSexo != null && getPBClaseSexoRecords){
myPBClaseSexo.personasDesaparecidass = PersonasDesaparecidasDB.GetListByidSexo(id);
}
if (myPBClaseSexo != null && getPBClaseSexoRecords){
myPBClaseSexo.personasHalladass = PersonasHalladasDB.GetListByidSexo(id);
}
return myPBClaseSexo;
}

/// <summary>
/// Saves a PBClaseSexo in the database.
/// </summary>
/// <param name="myPBClaseSexo">The PBClaseSexo instance to save.</param>
/// <returns>The new Id if the PBClaseSexo is new in the database or the existing Id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(PBClaseSexo myPBClaseSexo){
using (TransactionScope myTransactionScope = new TransactionScope()){
int pBClaseSexoId = PBClaseSexoDB.Save(myPBClaseSexo);
foreach (Busqueda myBusqueda in myPBClaseSexo.busquedas){
myBusqueda.Id = pBClaseSexoId;
BusquedaDB.Save(myBusqueda);
}
foreach (PersonasDesaparecidas myPersonasDesaparecidas in myPBClaseSexo.personasDesaparecidass){
myPersonasDesaparecidas.Id = pBClaseSexoId;
PersonasDesaparecidasDB.Save(myPersonasDesaparecidas);
}
foreach (PersonasHalladas myPersonasHalladas in myPBClaseSexo.personasHalladass){
myPersonasHalladas.Id = pBClaseSexoId;
PersonasHalladasDB.Save(myPersonasHalladas);
}

//  Assign the PBClaseSexo its new (or existing Id).
myPBClaseSexo.Id = pBClaseSexoId;

myTransactionScope.Complete();

return pBClaseSexoId;
}
}

/// <summary>
/// Deletes a PBClaseSexo from the database.
/// </summary>
/// <param name="myPBClaseSexo">The PBClaseSexo instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(PBClaseSexo myPBClaseSexo){
return PBClaseSexoDB.Delete(myPBClaseSexo.Id);
}

#endregion

}

}
