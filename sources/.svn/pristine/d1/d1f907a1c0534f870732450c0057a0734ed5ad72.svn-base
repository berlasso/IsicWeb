using System;
using System.ComponentModel;
using System.Transactions;
using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.SIAC.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;
using MPBA.AutoresIgnorados.Dal;
using MPBA.SIAC.Dal;


namespace MPBA.SIAC.Bll {

/// <summary>
/// The ClaseTatuajeManager class is responsible for managing Business Entities.ClaseTatuaje objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class ClaseTatuajeManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all ClaseTatuaje objects in the database.
/// </summary>
/// <returns>A list with all ClaseTatuaje from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static ClaseTatuajeList GetList(){
return ClaseTatuajeDB.GetList();
}

/// <summary>
/// Gets a single ClaseTatuaje from the database without its data.
/// </summary>
/// <param name="id">The id of the ClaseTatuaje in the database.</param>
/// <returns>A ClaseTatuaje object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static ClaseTatuaje GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single ClaseTatuaje from the database.
/// </summary>
/// <param name="id">The id of the ClaseTatuaje in the database.</param>
/// <param name="getClaseTatuajeRecords">Determines whether to load all associated ClaseTatuaje records as well.</param>
/// <returns>
/// A ClaseTatuaje object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static ClaseTatuaje GetItem(int id, bool getClaseTatuajeRecords){
ClaseTatuaje myClaseTatuaje = ClaseTatuajeDB.GetItem(id);
if (myClaseTatuaje != null && getClaseTatuajeRecords){
myClaseTatuaje.busquedaRobosDelitosSexualesTatuajess = BusquedaRobosDelitosSexualesTatuajesDB.GetListByidTatuaje(id);
}
if (myClaseTatuaje != null && getClaseTatuajeRecords){
myClaseTatuaje.tatuajesPersonas = TatuajesPersonaDB.GetListByidTatuaje(id);
}
return myClaseTatuaje;
}

/// <summary>
/// Saves a ClaseTatuaje in the database.
/// </summary>
/// <param name="myClaseTatuaje">The ClaseTatuaje instance to save.</param>
/// <returns>The new id if the ClaseTatuaje is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(ClaseTatuaje myClaseTatuaje){
using (TransactionScope myTransactionScope = new TransactionScope()){
int claseTatuajeid = ClaseTatuajeDB.Save(myClaseTatuaje);
foreach (BusquedaRobosDelitosSexualesTatuajes myBusquedaRobosDelitosSexualesTatuajes in myClaseTatuaje.busquedaRobosDelitosSexualesTatuajess){
myBusquedaRobosDelitosSexualesTatuajes.id = claseTatuajeid;
BusquedaRobosDelitosSexualesTatuajesDB.Save(myBusquedaRobosDelitosSexualesTatuajes);
}
foreach (TatuajesPersona myTatuajesPersona in myClaseTatuaje.tatuajesPersonas){
myTatuajesPersona.id = claseTatuajeid;
TatuajesPersonaDB.Save(myTatuajesPersona);
}

//  Assign the ClaseTatuaje its new (or existing id).
myClaseTatuaje.id = claseTatuajeid;

myTransactionScope.Complete();

return claseTatuajeid;
}
}

/// <summary>
/// Deletes a ClaseTatuaje from the database.
/// </summary>
/// <param name="myClaseTatuaje">The ClaseTatuaje instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(ClaseTatuaje myClaseTatuaje){
return ClaseTatuajeDB.Delete(myClaseTatuaje.id);
}

#endregion

}

}
