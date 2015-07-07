using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Dal;
using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.SIAC.Bll
{

/// <summary>
/// The ComisariaManager class is responsible for managing Business Object.Comisaria objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class ComisariaManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all Comisaria objects in the database.
/// </summary>
/// <returns>A list with all Comisaria from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static ComisariaList GetList(){
return ComisariaDB.GetList();
}

/// <summary>
/// Gets a list with all Comisaria from the specified departamento.
/// </summary>
/// <param name="id">The id of the Departamento whose comisarias you want to get.</param>
/// <returns>A Comisaria object that matches departamento.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static ComisariaList GetList(int id)
{
    return ComisariaDB.GetListByidDepartamento(id);
}


/// <summary>
/// Gets a single Comisaria from the database without its data.
/// </summary>
/// <param name="id">The id of the Comisaria in the database.</param>
/// <returns>A Comisaria object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static Comisaria GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single Comisaria from the database without its data.
/// </summary>
/// <param name="id">The id of the Comisaria in the database.</param>
/// <returns>A Comisaria object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static Comisaria GetItemByDescripcion(string descComisaria)
{
    return ComisariaDB.GetItemByDescripcion(descComisaria);
}


/// <summary>
/// Gets a single Comisaria from the database.
/// </summary>
/// <param name="id">The id of the Comisaria in the database.</param>
/// <param name="getComisariaRecords">Determines whether to load all associated Comisaria records as well.</param>
/// <returns>
/// A Comisaria object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static Comisaria GetItem(int id, bool getComisariaRecords){
Comisaria myComisaria = ComisariaDB.GetItem(id);
//if (myComisaria != null && getComisariaRecords){
//myComisaria.delitoss = DelitosDB.GetListByidComisariaH(id);
//}
//if (myComisaria != null && getComisariaRecords){
//myComisaria.delitoss = DelitosDB.GetListByidComisariaL(id);
//}
return myComisaria;
}

/// <summary>
/// Saves a Comisaria in the database.
/// </summary>
/// <param name="myComisaria">The Comisaria instance to save.</param>
/// <returns>The new id if the Comisaria is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(Comisaria myComisaria){
using (TransactionScope myTransactionScope = new TransactionScope()){
int comisariaid = ComisariaDB.Save(myComisaria);
foreach (Delitos myDelitos in myComisaria.delitoss){
myDelitos.id = comisariaid;
DelitosDB.Save(myDelitos);
}
foreach (Delitos myDelitos in myComisaria.delitoss){
myDelitos.id = comisariaid;
DelitosDB.Save(myDelitos);
}

//  Assign the Comisaria its new (or existing id).
myComisaria.id = comisariaid;

myTransactionScope.Complete();

return comisariaid;
}
}

/// <summary>
/// Deletes a Comisaria from the database.
/// </summary>
/// <param name="myComisaria">The Comisaria instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(Comisaria myComisaria){
return ComisariaDB.Delete(myComisaria.id);
}

#endregion

}

}
