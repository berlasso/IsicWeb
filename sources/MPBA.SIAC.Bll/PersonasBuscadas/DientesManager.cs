using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll {

/// <summary>
/// The DientesManager class is responsible for managing Business Object.Dientes objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class DientesManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all Dientes objects in the database.
/// </summary>
/// <returns>A list with all Dientes from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static DientesList GetList(){
return DientesDB.GetList();
}

/// <summary>
/// Gets a single Dientes from the database without its data.
/// </summary>
/// <param name="id">The id of the Dientes in the database.</param>
/// <returns>A Dientes object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static Dientes GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single Dientes from the database.
/// </summary>
/// <param name="id">The id of the Dientes in the database.</param>
/// <param name="getDientesRecords">Determines whether to load all associated Dientes records as well.</param>
/// <returns>
/// A Dientes object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static Dientes GetItem(int id, bool getDientesRecords){
Dientes myDientes = DientesDB.GetItem(id);
if (myDientes != null && getDientesRecords){
myDientes.personasDesaparecidass = PersonasDesaparecidasDB.GetListByidDentadura(id);
}
if (myDientes != null && getDientesRecords){
myDientes.personasHalladass = PersonasHalladasDB.GetListByidDentadura(id);
}
return myDientes;
}

/// <summary>
/// Saves a Dientes in the database.
/// </summary>
/// <param name="myDientes">The Dientes instance to save.</param>
/// <returns>The new id if the Dientes is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(Dientes myDientes){
using (TransactionScope myTransactionScope = new TransactionScope()){
int dientesid = DientesDB.Save(myDientes);
foreach (PersonasDesaparecidas myPersonasDesaparecidas in myDientes.personasDesaparecidass){
myPersonasDesaparecidas.Id = dientesid;
PersonasDesaparecidasDB.Save(myPersonasDesaparecidas);
}
foreach (PersonasHalladas myPersonasHalladas in myDientes.personasHalladass){
myPersonasHalladas.Id = dientesid;
PersonasHalladasDB.Save(myPersonasHalladas);
}

//  Assign the Dientes its new (or existing id).
myDientes.Id = dientesid;

myTransactionScope.Complete();

return dientesid;
}
}

/// <summary>
/// Deletes a Dientes from the database.
/// </summary>
/// <param name="myDientes">The Dientes instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(Dientes myDientes){
return DientesDB.Delete(myDientes.Id);
}

#endregion

}

}
