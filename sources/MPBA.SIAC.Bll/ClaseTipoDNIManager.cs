using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Dal;
using  MPBA.PersonasBuscadas.Dal;
using MPBA.PersonasBuscadas.BusinessEntities;

namespace MPBA.SIAC.Bll {

/// <summary>
/// The ClaseTipoDNIManager class is responsible for managing Business Entities.ClaseTipoDNI objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class ClaseTipoDNIManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all ClaseTipoDNI objects in the database.
/// </summary>
/// <returns>A list with all ClaseTipoDNI from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static ClaseTipoDNIList GetList(){
return ClaseTipoDNIDB.GetList();
}

/// <summary>
/// Gets a single ClaseTipoDNI from the database without its data.
/// </summary>
/// <param name="id">The id of the ClaseTipoDNI in the database.</param>
/// <returns>A ClaseTipoDNI object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static ClaseTipoDNI GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single ClaseTipoDNI from the database.
/// </summary>
/// <param name="id">The id of the ClaseTipoDNI in the database.</param>
/// <param name="getClaseTipoDNIRecords">Determines whether to load all associated ClaseTipoDNI records as well.</param>
/// <returns>
/// A ClaseTipoDNI object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static ClaseTipoDNI GetItem(int id, bool getClaseTipoDNIRecords){
ClaseTipoDNI myClaseTipoDNI = ClaseTipoDNIDB.GetItem(id);
if (myClaseTipoDNI != null && getClaseTipoDNIRecords){
myClaseTipoDNI.personasDesaparecidass = PersonasDesaparecidasDB.GetListByTipoDNI(id);
}
if (myClaseTipoDNI != null && getClaseTipoDNIRecords){
    myClaseTipoDNI.personasHalladass = PersonasHalladasDB.GetListByTipoDNI(id);
}
return myClaseTipoDNI;
}

/// <summary>
/// Saves a ClaseTipoDNI in the database.
/// </summary>
/// <param name="myClaseTipoDNI">The ClaseTipoDNI instance to save.</param>
/// <returns>The new id if the ClaseTipoDNI is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(ClaseTipoDNI myClaseTipoDNI){
using (TransactionScope myTransactionScope = new TransactionScope()){
int claseTipoDNIid = ClaseTipoDNIDB.Save(myClaseTipoDNI);
foreach (PersonasDesaparecidas myPersonasDesaparecidas in myClaseTipoDNI.personasDesaparecidass){
myPersonasDesaparecidas.Id = claseTipoDNIid;
PersonasDesaparecidasDB.Save(myPersonasDesaparecidas);
}
foreach (PersonasHalladas myPersonasHalladas in myClaseTipoDNI.personasHalladass){
myPersonasHalladas.Id = claseTipoDNIid;
PersonasHalladasDB.Save(myPersonasHalladas);
}

//  Assign the ClaseTipoDNI its new (or existing id).
myClaseTipoDNI.id = claseTipoDNIid;

myTransactionScope.Complete();

return claseTipoDNIid;
}
}

/// <summary>
/// Deletes a ClaseTipoDNI from the database.
/// </summary>
/// <param name="myClaseTipoDNI">The ClaseTipoDNI instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(ClaseTipoDNI myClaseTipoDNI){
return ClaseTipoDNIDB.Delete(myClaseTipoDNI.id);
}

#endregion

}

}
