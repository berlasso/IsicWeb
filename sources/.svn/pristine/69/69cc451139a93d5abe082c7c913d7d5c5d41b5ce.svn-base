using System;
using System.ComponentModel;
using System.Transactions;
using System.Data.SqlClient;
using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll {

/// <summary>
/// The PBFotosManager class is responsible for managing Business Entities.PBFotos objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class PBFotosManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all PBFotos objects in the database.
/// </summary>
/// <returns>A list with all PBFotos from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static PBFotosList GetList(){
return PBFotosDB.GetList();
}

/// <summary>
/// Gets a list with all PBFotos objects in the database that match idpersona and tipopersona
/// </summary>
/// <returns>A list with all PBFotos from the database when the database contains any, or null otherwise.</returns>
/// <param name="ipp">ipp de las fotos que busco</param>
/// <param name="tipoPersona">si es fotos para halladas o desap</param>
/// <returns></returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static PBFotosList GetListByIpp(string ipp, int tipoPersona)
{
    return PBFotosDB.GetListByIppYTablaDestino(ipp, tipoPersona);
}


/// <summary>
/// Gets a list with all PBFotos objects in the database that match idpersona and tipopersona
/// </summary>
/// <returns>A list with all PBFotos from the database when the database contains any, or null otherwise.</returns>
/// <param name="idPersona">idpersona de las fotos que busco</param>
/// <param name="tipoPersona">si es fotos para halladas o desap</param>
/// <returns></returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static PBFotosList GetList(int idPersona, int tipoPersona)
{
    return PBFotosDB.GetListByidPersonaYTablaDestino(idPersona, tipoPersona);
}

/// <summary>
/// Gets a single PBFotos from the database without its data.
/// </summary>
/// <param name="id">The id of the PBFotos in the database.</param>
/// <returns>A PBFotos object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PBFotos GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single PBFotos from the database.
/// </summary>
/// <param name="id">The id of the PBFotos in the database.</param>
/// <param name="getPBFotosRecords">Determines whether to load all associated PBFotos records as well.</param>
/// <returns>
/// A PBFotos object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static PBFotos GetItem(int id, bool getPBFotosRecords){
PBFotos myPBFotos = PBFotosDB.GetItem(id);
return myPBFotos;
}

/// <summary>
/// Saves a PBFotos in the database.
/// </summary>
/// <param name="myPBFotos">The PBFotos instance to save.</param>
/// <returns>The new id if the PBFotos is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(PBFotos myPBFotos){
using (TransactionScope myTransactionScope = new TransactionScope()){
int pBFotosid = PBFotosDB.Save(myPBFotos);

//  Assign the PBFotos its new (or existing id).
myPBFotos.id = pBFotosid;

myTransactionScope.Complete();

return pBFotosid;
}
}


/// <summary>
/// Saves a PBFotos in the database.
/// </summary>
/// <param name="mySeniasParticulares">The PBFotos instance to save.</param>
/// <returns>The new id if the PBFotos is new in the database or the existing id when an item was updated.</returns>
public static int Save(PBFotos myPBFotos, SqlCommand myCommand)
{
    //using (TransactionScope myTransactionScope = new TransactionScope())
    //{
    int pbfotosid = PBFotosDB.Save(myPBFotos, myCommand);

    //  Assign the TatuajePersona its new (or existing id).
    myPBFotos.id = pbfotosid;

    //myTransactionScope.Complete();

    return pbfotosid;
}


/// <summary>
/// Deletes a PBFotos from the database.
/// </summary>
/// <param name="myPBFotos">The PBFotos instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(PBFotos myPBFotos){
return PBFotosDB.Delete(myPBFotos.id);
}

#endregion

}

}
