using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll {

/// <summary>
/// The PBClaseMotivoHallazgoManager class is responsible for managing Business Object.PBClaseMotivoHallazgo objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class PBClaseMotivoHallazgoManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all PBClaseMotivoHallazgo objects in the database.
/// </summary>
/// <returns>A list with all PBClaseMotivoHallazgo from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static PBClaseMotivoHallazgoList GetList(){
return PBClaseMotivoHallazgoDB.GetList();
}

/// <summary>
/// Gets a single PBClaseMotivoHallazgo from the database without its data.
/// </summary>
/// <param name="id">The Id of the PBClaseMotivoHallazgo in the database.</param>
/// <returns>A PBClaseMotivoHallazgo object when the Id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PBClaseMotivoHallazgo GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single PBClaseMotivoHallazgo from the database.
/// </summary>
/// <param name="id">The Id of the PBClaseMotivoHallazgo in the database.</param>
/// <param name="getPBClaseMotivoHallazgoRecords">Determines whether to load all associated PBClaseMotivoHallazgo records as well.</param>
/// <returns>
/// A PBClaseMotivoHallazgo object when the Id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PBClaseMotivoHallazgo GetItem(int id, bool getPBClaseMotivoHallazgoRecords){
PBClaseMotivoHallazgo myPBClaseMotivoHallazgo = PBClaseMotivoHallazgoDB.GetItem(id);
if (myPBClaseMotivoHallazgo != null && getPBClaseMotivoHallazgoRecords){
myPBClaseMotivoHallazgo.busquedas = BusquedaDB.GetListByidMotivoHallazgo(id);
}
return myPBClaseMotivoHallazgo;
}

/// <summary>
/// Saves a PBClaseMotivoHallazgo in the database.
/// </summary>
/// <param name="myPBClaseMotivoHallazgo">The PBClaseMotivoHallazgo instance to save.</param>
/// <returns>The new Id if the PBClaseMotivoHallazgo is new in the database or the existing Id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(PBClaseMotivoHallazgo myPBClaseMotivoHallazgo){
using (TransactionScope myTransactionScope = new TransactionScope()){
int pBClaseMotivoHallazgoId = PBClaseMotivoHallazgoDB.Save(myPBClaseMotivoHallazgo);
foreach (Busqueda myBusqueda in myPBClaseMotivoHallazgo.busquedas){
myBusqueda.Id = pBClaseMotivoHallazgoId;
BusquedaDB.Save(myBusqueda);
}

//  Assign the PBClaseMotivoHallazgo its new (or existing Id).
myPBClaseMotivoHallazgo.Id = pBClaseMotivoHallazgoId;

myTransactionScope.Complete();

return pBClaseMotivoHallazgoId;
}
}

/// <summary>
/// Deletes a PBClaseMotivoHallazgo from the database.
/// </summary>
/// <param name="myPBClaseMotivoHallazgo">The PBClaseMotivoHallazgo instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(PBClaseMotivoHallazgo myPBClaseMotivoHallazgo){
return PBClaseMotivoHallazgoDB.Delete(myPBClaseMotivoHallazgo.Id);
}

#endregion

}

}
