using System;
using System.ComponentModel;
using System.Transactions;


using MPBA.SIAC.Dal;
using MPBA.SIAC.BusinessEntities;


 
namespace MPBA.SIAC.Bll {

/// <summary>
/// The PreguntasFrecuentesManager class is responsible for managing Business Entities.PreguntasFrecuentes objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class PreguntasFrecuentesManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all PreguntasFrecuentes objects in the database.
/// </summary>
/// <returns>A list with all PreguntasFrecuentes from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static PreguntasFrecuentesList GetList(){
return PreguntasFrecuentesDB.GetList();
}
         

 /// <summary>
/// Dada una pergunta devuelve la respuesta
/// </summary>
/// <param name="id">The id of the PreguntasFrecuentes in the database.</param>
/// <returns>A PreguntasFrecuentes object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PreguntasFrecuentes GetRespuesta(int id){
PreguntasFrecuentes myPreguntasFrecuentes = PreguntasFrecuentesDB.GetRespuesta(id);
return myPreguntasFrecuentes;
}


/// <summary>
/// Gets a single PreguntasFrecuentes from the database without its data.
/// </summary>
/// <param name="id">The id of the PreguntasFrecuentes in the database.</param>
/// <returns>A PreguntasFrecuentes object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PreguntasFrecuentes GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single PreguntasFrecuentes from the database.
/// </summary>
/// <param name="id">The id of the PreguntasFrecuentes in the database.</param>
/// <param name="getPreguntasFrecuentesRecords">Determines whether to load all associated PreguntasFrecuentes records as well.</param>
/// <returns>
/// A PreguntasFrecuentes object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PreguntasFrecuentes GetItem(int id, bool getPreguntasFrecuentesRecords){
PreguntasFrecuentes myPreguntasFrecuentes = PreguntasFrecuentesDB.GetItem(id);
return myPreguntasFrecuentes;
}

/// <summary>
/// Saves a PreguntasFrecuentes in the database.
/// </summary>
/// <param name="myPreguntasFrecuentes">The PreguntasFrecuentes instance to save.</param>
/// <returns>The new id if the PreguntasFrecuentes is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(PreguntasFrecuentes myPreguntasFrecuentes){
using (TransactionScope myTransactionScope = new TransactionScope()){
int preguntasFrecuentesid = PreguntasFrecuentesDB.Save(myPreguntasFrecuentes);

//  Assign the PreguntasFrecuentes its new (or existing id).
myPreguntasFrecuentes.id = preguntasFrecuentesid;

myTransactionScope.Complete();

return preguntasFrecuentesid;
}
}

/// <summary>
/// Deletes a PreguntasFrecuentes from the database.
/// </summary>
/// <param name="myPreguntasFrecuentes">The PreguntasFrecuentes instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(PreguntasFrecuentes myPreguntasFrecuentes){
return PreguntasFrecuentesDB.Delete(myPreguntasFrecuentes.id);
}

#endregion

}

}
