using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Dal;
using MPBA.AutoresIgnorados.Dal;
using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.SIAC.Bll
{

/// <summary>
/// The PartidoManager class is responsible for managing Business Object.Partido objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class PartidoManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all Partido objects in the database.
/// </summary>
/// <returns>A list with all Partido from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static PartidoList GetList(){
return PartidoDB.GetList();
}

/// <summary>
/// Gets a list with all Partido objects in the database matching partido.
/// <paramref name="<partido"/>The partido to search
/// </summary>
/// <returns>A list with all partido from the database when the database that match the partido entered.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static PartidoList GetList(string partido)
{
    return PartidoDB.GetList(partido);
}
/// <summary>
/// Gets a single Partido from the database without its data.
/// </summary>
/// <param name="id">The id of the Partido in the database.</param>
/// <returns>A Partido object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static Partido GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single Partido from the database.
/// </summary>
/// <param name="id">The id of the Partido in the database.</param>
/// <param name="getPartidoRecords">Determines whether to load all associated Partido records as well.</param>
/// <returns>
/// A Partido object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static Partido GetItem(int id, bool getPartidoRecords){
Partido myPartido = PartidoDB.GetItem(id);
if (myPartido != null && getPartidoRecords){
myPartido.delitoss = DelitosDB.GetListByidPartido(id);
}
if (myPartido != null && getPartidoRecords){
myPartido.delitoss = DelitosDB.GetListByidPartidoL(id);
}
if (myPartido != null && getPartidoRecords){
myPartido.localidads = LocalidadDB.GetListByPartido(id);
}
return myPartido;
}

/// <summary>
/// Saves a Partido in the database.
/// </summary>
/// <param name="myPartido">The Partido instance to save.</param>
/// <returns>The new id if the Partido is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(Partido myPartido){
using (TransactionScope myTransactionScope = new TransactionScope()){
int partidoid = PartidoDB.Save(myPartido);
foreach (Delitos myDelitos in myPartido.delitoss){
myDelitos.id = partidoid;
DelitosDB.Save(myDelitos);
}
foreach (Delitos myDelitos in myPartido.delitoss){
myDelitos.id = partidoid;
DelitosDB.Save(myDelitos);
}
foreach (Localidad myLocalidad in myPartido.localidads){
myLocalidad.id = partidoid;
LocalidadDB.Save(myLocalidad);
}

//  Assign the Partido its new (or existing id).
myPartido.id = partidoid;

myTransactionScope.Complete();

return partidoid;
}
}

/// <summary>
/// Deletes a Partido from the database.
/// </summary>
/// <param name="myPartido">The Partido instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(Partido myPartido){
return PartidoDB.Delete(myPartido.id);
}

#endregion

}

}
