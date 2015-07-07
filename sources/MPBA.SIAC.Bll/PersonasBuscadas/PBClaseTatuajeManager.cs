using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll {

/// <summary>
/// The PBClaseTatuajeManager class is responsible for managing Business Entities.PBClaseTatuaje objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class PBClaseTatuajeManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all PBClaseTatuaje objects in the database.
/// </summary>
/// <returns>A list with all PBClaseTatuaje from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static PBClaseTatuajeList GetList(){
return PBClaseTatuajeDB.GetList();
}

/// <summary>
/// Gets a single PBClaseTatuaje from the database without its data.
/// </summary>
/// <param name="id">The id of the PBClaseTatuaje in the database.</param>
/// <returns>A PBClaseTatuaje object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PBClaseTatuaje GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single PBClaseTatuaje from the database.
/// </summary>
/// <param name="id">The id of the PBClaseTatuaje in the database.</param>
/// <param name="getPBClaseTatuajeRecords">Determines whether to load all associated PBClaseTatuaje records as well.</param>
/// <returns>
/// A PBClaseTatuaje object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PBClaseTatuaje GetItem(int id, bool getPBClaseTatuajeRecords){
PBClaseTatuaje myPBClaseTatuaje = PBClaseTatuajeDB.GetItem(id);
if (myPBClaseTatuaje != null && getPBClaseTatuajeRecords){
myPBClaseTatuaje.busquedaTatuajess = BusquedaTatuajesDB.GetListByIdClaseTatuaje(id);
}
if (myPBClaseTatuaje != null && getPBClaseTatuajeRecords){
myPBClaseTatuaje.tatuajesPersonas = TatuajesPersonaDB.GetListByidTatuaje(id);
}
return myPBClaseTatuaje;
}

/// <summary>
/// Saves a PBClaseTatuaje in the database.
/// </summary>
/// <param name="myPBClaseTatuaje">The PBClaseTatuaje instance to save.</param>
/// <returns>The new id if the PBClaseTatuaje is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(PBClaseTatuaje myPBClaseTatuaje){
using (TransactionScope myTransactionScope = new TransactionScope()){
int pBClaseTatuajeid = PBClaseTatuajeDB.Save(myPBClaseTatuaje);
foreach (BusquedaTatuajes myBusquedaTatuajes in myPBClaseTatuaje.busquedaTatuajess){
myBusquedaTatuajes.id = pBClaseTatuajeid;
BusquedaTatuajesDB.Save(myBusquedaTatuajes);
}
foreach (TatuajesPersona myTatuajesPersona in myPBClaseTatuaje.tatuajesPersonas){
myTatuajesPersona.id = pBClaseTatuajeid;
TatuajesPersonaDB.Save(myTatuajesPersona);
}

//  Assign the PBClaseTatuaje its new (or existing id).
myPBClaseTatuaje.id = pBClaseTatuajeid;

myTransactionScope.Complete();

return pBClaseTatuajeid;
}
}

/// <summary>
/// Deletes a PBClaseTatuaje from the database.
/// </summary>
/// <param name="myPBClaseTatuaje">The PBClaseTatuaje instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(PBClaseTatuaje myPBClaseTatuaje){
return PBClaseTatuajeDB.Delete(myPBClaseTatuaje.id);
}

#endregion

}

}
