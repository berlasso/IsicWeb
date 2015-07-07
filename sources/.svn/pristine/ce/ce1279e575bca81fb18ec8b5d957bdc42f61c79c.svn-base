using System;
using System.ComponentModel;
using System.Transactions;
using System.Data;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;
using MPBA.SIAC.Dal;
using MPBA.PersonasBuscadas.Dal;
using MPBA.SIAC.BusinessEntities;
using MPBA.PersonasBuscadas.BusinessEntities;

namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The AutoresManager class is responsible for managing Business Object.Autores objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class AutoresManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all Autores objects in the database.
/// </summary>
/// <returns>A list with all Autores from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static AutoresList GetList(){
return AutoresDB.GetList();
}

/// <summary>
/// Gets a list with all Autores objects in the database.
/// </summary>
/// <returns>A list with all Autores from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static AutoresList GetListJoinedPersonasByIdPersona(int idPersona)
{
    return AutoresDB.GetListJoinedPersonasByIdPersona(idPersona);
}

/// <summary>
/// Gets a single Autores from the database without its data.
/// </summary>
/// <param name="id">The id of the Autores in the database.</param>
/// <returns>A Autores object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static Autores GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single Autores from the database.
/// </summary>
/// <param name="id">The id of the Autores in the database.</param>
/// <param name="getAutoresRecords">Determines whether to load all associated Autores records as well.</param>
/// <returns>
/// A Autores object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static Autores GetItem(int id, bool getAutoresRecords){
Autores myAutores = AutoresDB.GetItem(id);

return myAutores;
}

/// <summary>
/// Saves a Autores in the database.
/// </summary>
/// <param name="myAutores">The Autores instance to save.</param>
/// <returns>The new id if the Autores is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(Autores myAutores)
{
    using (TransactionScope myTransactionScope = new TransactionScope())
    {
        int autoresid = AutoresDB.Save(myAutores);

        //  Assign the Autores its new (or existing id).
        myAutores.id = autoresid;

        /*Recorro la coleccion de Senias Particulares y las grabo
        Veer si ya actualizo la tabla destino*/
        foreach (SeniasParticulares mySenias in myAutores.seniasParticularess)
        {
            mySenias.idAutor = autoresid;
            mySenias.idPersona = myAutores.idPersona;
            SeniasParticularesDB.Save(mySenias);
        }

        foreach (TatuajesPersona myTatuajes in myAutores.tatuajesPersonas)
        {
            myTatuajes.idAutor = autoresid;
            myTatuajes.idPersona = myAutores.idPersona;
            TatuajesPersonaDB.Save(myTatuajes);
        }
        myTransactionScope.Complete();

        return autoresid;
    }
}

public static int Save(Autores myAutores, SqlCommand myCommand)
{
    //using (TransactionScope myTransactionScope = new TransactionScope())
    //{
    int autoresid = AutoresDB.Save(myAutores, myCommand);

    //  Assign the Autores its new (or existing id).
    myAutores.id = autoresid;
    /*Recorro la coleccion de Senias Particulares y las grabo
     Veer si ya actualizo la tabla destino*/
    foreach (SeniasParticulares mySenias in myAutores.seniasParticularess)
    {
        mySenias.idAutor = autoresid;
        mySenias.idPersona = myAutores.idPersona;
        SeniasParticularesDB.Save(mySenias,myCommand);
    }

    foreach (TatuajesPersona myTatuajes in myAutores.tatuajesPersonas)
    {
        myTatuajes.idAutor = autoresid;
        myTatuajes.idPersona = myAutores.idPersona;
        TatuajesPersonaDB.Save(myTatuajes,myCommand);
    }

    //myTransactionScope.Complete();

    return autoresid;
    //}
}

/// <summary>
/// Deletes a Autores from the database.
/// </summary>
/// <param name="myAutores">The Autores instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(Autores myAutores){
return AutoresDB.Delete(myAutores.id);
}

#endregion

}

}
