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
/// The LocalidadManager class is responsible for managing Business Object.Localidad objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class LocalidadManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all Localidad objects in the database.
/// </summary>
/// <returns>A list with all Localidad from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static LocalidadList GetList(){
return LocalidadDB.GetList();
}

/// <summary>
/// Gets a list with all Localidad objects in the database matching localidad.
/// <paramref name=">localidad"/>The localidad to search
/// </summary>
/// <returns>A list with all Localidad from the database when the database that match the localidad entered.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static LocalidadList GetList(string localidad)
{
    return LocalidadDB.GetList(localidad);
}

/// <summary>
/// Gets a single Localidad from the database without its data.
/// </summary>
/// <param name="id">The id of the Localidad in the database.</param>
/// <returns>A Localidad object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static Localidad GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single Localidad from the database.
/// </summary>
/// <param name="id">The id of the Localidad in the database.</param>
/// <param name="getLocalidadRecords">Determines whether to load all associated Localidad records as well.</param>
/// <returns>
/// A Localidad object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static Localidad GetItem(int id, bool getLocalidadRecords){
Localidad myLocalidad = LocalidadDB.GetItem(id);
if (myLocalidad != null && getLocalidadRecords){
myLocalidad.delitoss = DelitosDB.GetListByidLocalidad(id);
}
if (myLocalidad != null && getLocalidadRecords){
myLocalidad.delitoss = DelitosDB.GetListByidLocalidadL(id);
}
return myLocalidad;
}

/// <summary>
/// Saves a Localidad in the database.
/// </summary>
/// <param name="myLocalidad">The Localidad instance to save.</param>
/// <returns>The new id if the Localidad is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(Localidad myLocalidad){
using (TransactionScope myTransactionScope = new TransactionScope()){
int localidadid = LocalidadDB.Save(myLocalidad);
foreach (Delitos myDelitos in myLocalidad.delitoss){
myDelitos.id = localidadid;
DelitosDB.Save(myDelitos);
}
foreach (Delitos myDelitos in myLocalidad.delitoss){
myDelitos.id = localidadid;
DelitosDB.Save(myDelitos);
}

//  Assign the Localidad its new (or existing id).
myLocalidad.id = localidadid;

myTransactionScope.Complete();

return localidadid;
}
}

/// <summary>
/// Deletes a Localidad from the database.
/// </summary>
/// <param name="myLocalidad">The Localidad instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(Localidad myLocalidad){
return LocalidadDB.Delete(myLocalidad.id);
}

#endregion

}

}
