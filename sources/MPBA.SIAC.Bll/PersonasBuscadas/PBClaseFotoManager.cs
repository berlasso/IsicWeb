using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll {

/// <summary>
/// The PBClaseFotoManager class is responsible for managing Business Entities.PBClaseFoto objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class PBClaseFotoManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all PBClaseFoto objects in the database.
/// </summary>
/// <returns>A list with all PBClaseFoto from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static PBClaseFotoList GetList(){
return PBClaseFotoDB.GetList();
}

/// <summary>
/// Gets a single PBClaseFoto from the database without its data.
/// </summary>
/// <param name="id">The id of the PBClaseFoto in the database.</param>
/// <returns>A PBClaseFoto object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PBClaseFoto GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single PBClaseFoto from the database.
/// </summary>
/// <param name="id">The id of the PBClaseFoto in the database.</param>
/// <param name="getPBClaseFotoRecords">Determines whether to load all associated PBClaseFoto records as well.</param>
/// <returns>
/// A PBClaseFoto object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PBClaseFoto GetItem(int id, bool getPBClaseFotoRecords){
PBClaseFoto myPBClaseFoto = PBClaseFotoDB.GetItem(id);
if (myPBClaseFoto != null && getPBClaseFotoRecords){
    myPBClaseFoto.fotoss = PBFotosDB.GetListByidTipoFoto(id);
}
return myPBClaseFoto;
}

/// <summary>
/// Saves a PBClaseFoto in the database.
/// </summary>
/// <param name="myPBClaseFoto">The PBClaseFoto instance to save.</param>
/// <returns>The new id if the PBClaseFoto is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(PBClaseFoto myPBClaseFoto){
using (TransactionScope myTransactionScope = new TransactionScope()){
int pBClaseFotoid = PBClaseFotoDB.Save(myPBClaseFoto);
foreach (PBFotos myFotos in myPBClaseFoto.fotoss)
{
myFotos.idTipoFoto = pBClaseFotoid;
PBFotosDB.Save(myFotos);
}

//  Assign the PBClaseFoto its new (or existing id).
myPBClaseFoto.id = pBClaseFotoid;

myTransactionScope.Complete();

return pBClaseFotoid;
}
}

/// <summary>
/// Deletes a PBClaseFoto from the database.
/// </summary>
/// <param name="myPBClaseFoto">The PBClaseFoto instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(PBClaseFoto myPBClaseFoto){
return PBClaseFotoDB.Delete(myPBClaseFoto.id);
}

#endregion

}

}
