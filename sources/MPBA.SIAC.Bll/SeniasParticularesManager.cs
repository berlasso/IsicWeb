using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Dal;

using System.Data;
using System.Data.SqlClient;

namespace MPBA.SIAC.Bll {

/// <summary>
/// The SeniasParticularesManager class is responsible for managing Business Entities.SeniasParticulares objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class SeniasParticularesManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all SeniasParticulares objects in the database.
/// </summary>
/// <returns>A list with all SeniasParticulares from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static SeniasParticularesList GetList(){
    return SeniasParticularesDB.GetList();
}




/// <summary>
/// Gets a list of SeniasParticulares from the database without its data.
/// </summary>
/// <param name="idPersona">The id of the Persona in the database.</param>
/// <returns>A SeniasParticulares object when the persona exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static SeniasParticularesList GetList(int idPersona, int idTablaDestino)
{
    return SeniasParticularesDB.GetList(idPersona, idTablaDestino);
}



/// <summary>
/// Gets a list of SeniasParticulares from the database without its data.
/// </summary>
/// <param name="idPersona">Dado un id de Autor.</param>
/// <returns>retorna las SeniasParticulares object cuando el autor ignorado o aprehendido esta en la base  <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static SeniasParticularesList GetListByidAutor(int idAutor)
{
    return SeniasParticularesDB.GetListByidAutor(idAutor);
}


/// <summary>
/// Gets a single SeniasParticulares from the database without its data.
/// </summary>
/// <param name="id">The id of the SeniasParticulares in the database.</param>
/// <returns>A SeniasParticulares object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static SeniasParticulares GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single SeniasParticulares from the database.
/// </summary>
/// <param name="id">The id of the SeniasParticulares in the database.</param>
/// <param name="getSeniasParticularesRecords">Determines whether to load all associated SeniasParticulares records as well.</param>
/// <returns>
/// A SeniasParticulares object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static SeniasParticulares GetItem(int id, bool getSeniasParticularesRecords){
SeniasParticulares mySeniasParticulares = SeniasParticularesDB.GetItem(id);
return mySeniasParticulares;
}

/// <summary>
/// Saves a SeniasParticulares in the database.
/// </summary>
/// <param name="mySeniasParticulares">The SeniasParticulares instance to save.</param>
/// <returns>The new id if the SeniasParticulares is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(SeniasParticulares mySeniasParticulares){
using (TransactionScope myTransactionScope = new TransactionScope()){
int seniasParticularesid = SeniasParticularesDB.Save(mySeniasParticulares);

//  Assign the SeniasParticulares its new (or existing id).
mySeniasParticulares.id = seniasParticularesid;

myTransactionScope.Complete();

return seniasParticularesid;
}
}

public static int Save(SeniasParticulares mySeniasParticulares, SqlCommand myCommand)
{
    //using (TransactionScope myTransactionScope = new TransactionScope())
    //{
    int seniasParticularesid = SeniasParticularesDB.Save(mySeniasParticulares, myCommand);

    //  Assign the SeniasParticulares its new (or existing id).
    mySeniasParticulares.id = seniasParticularesid;

    //myTransactionScope.Complete();

    return seniasParticularesid;
}

/// <summary>
/// Deletes a SeniasParticulares from the database.
/// </summary>
/// <param name="mySeniasParticulares">The SeniasParticulares instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(SeniasParticulares mySeniasParticulares){
return SeniasParticularesDB.Delete(mySeniasParticulares.id);
}

#endregion

}

}
