using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Dal;


namespace MPBA.SIAC.Bll
{

/// <summary>
/// The PermisoUsuarioManager class is responsible for managing Business Entities.PermisoUsuario objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class PermisoUsuarioManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all PermisoUsuario objects in the database.
/// </summary>
/// <returns>A list with all PermisoUsuario from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static PermisoUsuarioList GetList(){
return PermisoUsuarioDB.GetList();
}

/// <summary>
/// Gets a single PermisoUsuario from the database without its data.
/// </summary>
/// <param name="id">The Id of the PermisoUsuario in the database.</param>
/// <returns>A PermisoUsuario object when the Id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PermisoUsuario GetItem(string id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single PermisoUsuario from the database.
/// </summary>
/// <param name="id">The Id of the PermisoUsuario in the database.</param>
/// <param name="getPermisoUsuarioRecords">Determines whether to load all associated PermisoUsuario records as well.</param>
/// <returns>
/// A PermisoUsuario object when the Id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PermisoUsuario GetItem(string id, bool getPermisoUsuarioRecords){
PermisoUsuario myPermisoUsuario = PermisoUsuarioDB.GetItem(id);
return myPermisoUsuario;
}

/// <summary>
/// Saves a PermisoUsuario in the database.
/// </summary>
/// <param name="myPermisoUsuario">The PermisoUsuario instance to save.</param>
/// <returns>The new Id if the PermisoUsuario is new in the database or the existing Id when an item was updated.</returns>
//[DataObjectMethod(DataObjectMethodType.Update, true)]
//public static string Save(PermisoUsuario myPermisoUsuario){
//using (TransactionScope myTransactionScope = new TransactionScope()){
//string permisoUsuarioId = PermisoUsuarioDB.Save(myPermisoUsuario);

////  Assign the PermisoUsuario its new (or existing Id).
//myPermisoUsuario.Id = permisoUsuarioId;

//myTransactionScope.Complete();

//return permisoUsuarioId;
//}
//}

/// <summary>
/// Deletes a PermisoUsuario from the database.
/// </summary>
/// <param name="myPermisoUsuario">The PermisoUsuario instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(PermisoUsuario myPermisoUsuario){
return PermisoUsuarioDB.Delete(myPermisoUsuario.Id);
}

#endregion

}

}
