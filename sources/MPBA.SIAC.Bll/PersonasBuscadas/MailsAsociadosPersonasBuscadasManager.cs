using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll {

/// <summary>
/// The MailsAsociadosPersonasBuscadasManager class is responsible for managing Business Object.MailsAsociadosPersonasBuscadas objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class MailsAsociadosPersonasBuscadasManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all MailsAsociadosPersonasBuscadas objects in the database.
/// </summary>
/// <returns>A list with all MailsAsociadosPersonasBuscadas from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static MailsAsociadosPersonasBuscadasList GetList(){
return MailsAsociadosPersonasBuscadasDB.GetList();
}

/// <summary>
/// Gets a list with all MailsAsociadosPersonasBuscadas objects in the database.
/// </summary>
/// <returns>A list with all MailsAsociadosPersonasBuscadas from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static MailsAsociadosPersonasBuscadasList GetListByPersonaBuscada(int idPersonaBuscada, int idTipoPersona)
{
    return MailsAsociadosPersonasBuscadasDB.GetListByPersonaBuscada(idPersonaBuscada, idTipoPersona);
}

/// <summary>
/// Gets a single MailsAsociadosPersonasBuscadas from the database without its data.
/// </summary>
/// <param name="id">The id of the MailsAsociadosPersonasBuscadas in the database.</param>
/// <returns>A MailsAsociadosPersonasBuscadas object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static MailsAsociadosPersonasBuscadas GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single MailsAsociadosPersonasBuscadas from the database.
/// </summary>
/// <param name="id">The id of the MailsAsociadosPersonasBuscadas in the database.</param>
/// <param name="getMailsAsociadosPersonasBuscadasRecords">Determines whether to load all associated MailsAsociadosPersonasBuscadas records as well.</param>
/// <returns>
/// A MailsAsociadosPersonasBuscadas object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static MailsAsociadosPersonasBuscadas GetItem(int id, bool getMailsAsociadosPersonasBuscadasRecords){
MailsAsociadosPersonasBuscadas myMailsAsociadosPersonasBuscadas = MailsAsociadosPersonasBuscadasDB.GetItem(id);
return myMailsAsociadosPersonasBuscadas;
}

/// <summary>
/// Saves a MailsAsociadosPersonasBuscadas in the database.
/// </summary>
/// <param name="myMailsAsociadosPersonasBuscadas">The MailsAsociadosPersonasBuscadas instance to save.</param>
/// <returns>The new id if the MailsAsociadosPersonasBuscadas is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(MailsAsociadosPersonasBuscadas myMailsAsociadosPersonasBuscadas){
using (TransactionScope myTransactionScope = new TransactionScope()){
int mailsAsociadosPersonasBuscadasid = MailsAsociadosPersonasBuscadasDB.Save(myMailsAsociadosPersonasBuscadas);

//  Assign the MailsAsociadosPersonasBuscadas its new (or existing id).
myMailsAsociadosPersonasBuscadas.id = mailsAsociadosPersonasBuscadasid;

myTransactionScope.Complete();

return mailsAsociadosPersonasBuscadasid;
}
}

/// <summary>
/// Deletes a MailsAsociadosPersonasBuscadas from the database.
/// </summary>
/// <param name="myMailsAsociadosPersonasBuscadas">The MailsAsociadosPersonasBuscadas instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(MailsAsociadosPersonasBuscadas myMailsAsociadosPersonasBuscadas){
return MailsAsociadosPersonasBuscadasDB.Delete(myMailsAsociadosPersonasBuscadas.id);
}

#endregion

}

}
