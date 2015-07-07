using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll {

/// <summary>
/// The PBClaseRostroManager class is responsible for managing Business Object.PBClaseRostro objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class PBClaseRostroManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all PBClaseRostro objects in the database.
/// </summary>
/// <returns>A list with all PBClaseRostro from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static PBClaseRostroList GetList(){
return PBClaseRostroDB.GetList();
}

/// <summary>
/// Gets a single PBClaseRostro from the database without its data.
/// </summary>
/// <param name="id">The Id of the PBClaseRostro in the database.</param>
/// <returns>A PBClaseRostro object when the Id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PBClaseRostro GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single PBClaseRostro from the database.
/// </summary>
/// <param name="id">The Id of the PBClaseRostro in the database.</param>
/// <param name="getPBClaseRostroRecords">Determines whether to load all associated PBClaseRostro records as well.</param>
/// <returns>
/// A PBClaseRostro object when the Id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PBClaseRostro GetItem(int id, bool getPBClaseRostroRecords){
PBClaseRostro myPBClaseRostro = PBClaseRostroDB.GetItem(id);
if (myPBClaseRostro != null && getPBClaseRostroRecords){
myPBClaseRostro.personasDesaparecidass = PersonasDesaparecidasDB.GetListByidRostro(id);
}
if (myPBClaseRostro != null && getPBClaseRostroRecords){
myPBClaseRostro.personasHalladass = PersonasHalladasDB.GetListByidRostro(id);
}
return myPBClaseRostro;
}

/// <summary>
/// Saves a PBClaseRostro in the database.
/// </summary>
/// <param name="myPBClaseRostro">The PBClaseRostro instance to save.</param>
/// <returns>The new Id if the PBClaseRostro is new in the database or the existing Id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(PBClaseRostro myPBClaseRostro){
using (TransactionScope myTransactionScope = new TransactionScope()){
int pBClaseRostroId = PBClaseRostroDB.Save(myPBClaseRostro);
foreach (PersonasDesaparecidas myPersonasDesaparecidas in myPBClaseRostro.personasDesaparecidass){
myPersonasDesaparecidas.Id = pBClaseRostroId;
PersonasDesaparecidasDB.Save(myPersonasDesaparecidas);
}
foreach (PersonasHalladas myPersonasHalladas in myPBClaseRostro.personasHalladass){
myPersonasHalladas.Id = pBClaseRostroId;
PersonasHalladasDB.Save(myPersonasHalladas);
}

//  Assign the PBClaseRostro its new (or existing Id).
myPBClaseRostro.Id = pBClaseRostroId;

myTransactionScope.Complete();

return pBClaseRostroId;
}
}

/// <summary>
/// Deletes a PBClaseRostro from the database.
/// </summary>
/// <param name="myPBClaseRostro">The PBClaseRostro instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(PBClaseRostro myPBClaseRostro){
return PBClaseRostroDB.Delete(myPBClaseRostro.Id);
}

#endregion

}

}
