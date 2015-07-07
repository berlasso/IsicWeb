using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Dal;


namespace MPBA.SIAC.Bll
{

/// <summary>
/// The ProvinciaManager class is responsible for managing Business Object.Provincia objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class ProvinciaManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all Provincia objects in the database.
/// </summary>
/// <returns>A list with all Provincia from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static ProvinciaList GetList(){
return ProvinciaDB.GetList();
}

/// <summary>
/// Gets a single Provincia from the database without its data.
/// </summary>
/// <param name="id">The id of the Provincia in the database.</param>
/// <returns>A Provincia object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static Provincia GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single Provincia from the database.
/// </summary>
/// <param name="id">The id of the Provincia in the database.</param>
/// <param name="getProvinciaRecords">Determines whether to load all associated Provincia records as well.</param>
/// <returns>
/// A Provincia object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static Provincia GetItem(int id, bool getProvinciaRecords){
Provincia myProvincia = ProvinciaDB.GetItem(id);
if (myProvincia != null && getProvinciaRecords){
myProvincia.localidads = LocalidadDB.GetListByProvincia(id);
}
if (myProvincia != null && getProvinciaRecords){
myProvincia.partidos = PartidoDB.GetListByidProvincia(id);
}
return myProvincia;
}

/// <summary>
/// Saves a Provincia in the database.
/// </summary>
/// <param name="myProvincia">The Provincia instance to save.</param>
/// <returns>The new id if the Provincia is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(Provincia myProvincia){
using (TransactionScope myTransactionScope = new TransactionScope()){
int provinciaid = ProvinciaDB.Save(myProvincia);
foreach (Localidad myLocalidad in myProvincia.localidads){
myLocalidad.id = provinciaid;
LocalidadDB.Save(myLocalidad);
}
foreach (Partido myPartido in myProvincia.partidos){
myPartido.id = provinciaid;
PartidoDB.Save(myPartido);
}

//  Assign the Provincia its new (or existing id).
myProvincia.id = provinciaid;

myTransactionScope.Complete();

return provinciaid;
}
}

/// <summary>
/// Deletes a Provincia from the database.
/// </summary>
/// <param name="myProvincia">The Provincia instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(Provincia myProvincia){
return ProvinciaDB.Delete(myProvincia.id);
}

#endregion

}

}
