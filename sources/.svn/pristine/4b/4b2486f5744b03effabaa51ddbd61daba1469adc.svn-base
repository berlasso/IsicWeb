using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Dal;


namespace MPBA.SIAC.Bll
{

/// <summary>
/// The UsuariosManager class is responsible for managing Business Entities.Usuarios objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class UsuariosManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all Usuarios objects in the database.
/// </summary>
/// <returns>A list with all Usuarios from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static UsuariosList GetList(){
return UsuariosDB.GetList();
}

/// <summary>
/// Gets a list with all Referentes objects in the database.
/// </summary>
/// <returns>A list with all Usuarios from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static UsuariosList GetReferentes()
{
    return UsuariosDB.GetReferentes();
}

/// <summary>
/// Gets a list with all Usuarios objects in the database.
/// </summary>
/// <returns>A list with the Usuario from the database when the idUsuarioPoderJudicial contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static UsuariosList GetListByidPersonalPoderJudicial(string idPersonalPoderJudicial)
{
    return UsuariosDB.GetListByidPersonalPoderJudicial(idPersonalPoderJudicial);
}

 ///<summary>
 ///Gets a single Usuarios from the database
 ///</summary>
 ///<param name="nombreUsuario">The nombreUsuario of the Usuarios in the database.</param>
 ///<returns>A Usuarios object when the nombreUsuario exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static Usuarios GetItemByNombreUsuario(string nombreUsuario){
return UsuariosDB.GetItemByNombreUsuario(nombreUsuario);
}

///// <summary>
///// Gets a single Usuarios from the database.
///// </summary>
///// <param name="id">The id of the Usuarios in the database.</param>
///// <param name="getUsuariosRecords">Determines whether to load all associated Usuarios records as well.</param>
///// <returns>
///// A Usuarios object when the id exists in the database, or <see langword="null"/> otherwise.
///// </returns>
//[DataObjectMethod(DataObjectMethodType.Select, false)]
//public static Usuarios GetItem(string id, bool getUsuariosRecords){
//Usuarios myUsuarios = UsuariosDB.GetItem(id);
//if (myUsuarios != null && getUsuariosRecords){
//myUsuarios.permisoUsuarios = PermisoUsuarioDB.GetListByidUsuario(id);
//}
//return myUsuarios;
//}

/// <summary>
/// Saves a Usuarios in the database.
/// </summary>
/// <param name="myUsuarios">The Usuarios instance to save.</param>
/// <returns>The new id if the Usuarios is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static string Save(Usuarios myUsuarios){
using (TransactionScope myTransactionScope = new TransactionScope()){
string usuariosid = UsuariosDB.Save(myUsuarios);
foreach (PermisoUsuario myPermisoUsuario in myUsuarios.permisoUsuarios){
myPermisoUsuario.Id = usuariosid;
PermisoUsuarioDB.Save(myPermisoUsuario);
}

//  Assign the Usuarios its new (or existing id).
myUsuarios.id = usuariosid;

myTransactionScope.Complete();

return usuariosid;
}
}

/// <summary>
/// Deletes a Usuarios from the database.
/// </summary>
/// <param name="myUsuarios">The Usuarios instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(Usuarios myUsuarios){
return UsuariosDB.Delete(myUsuarios.id);
}

#endregion

}

}
