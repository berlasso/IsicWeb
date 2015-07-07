using System;
using System.ComponentModel;
using System.Transactions;
using System.Data;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The LugaresDeTrasladoDeVictimasManager class is responsible for managing Business Object.LugaresDeTrasladoDeVictimas objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class LugaresDeTrasladoDeVictimasManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all LugaresDeTrasladoDeVictimas objects in the database.
/// </summary>
/// <returns>A list with all LugaresDeTrasladoDeVictimas from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static LugaresDeTrasladoDeVictimasList GetList(){
return LugaresDeTrasladoDeVictimasDB.GetList();
}

/// <summary>
/// Gets a single LugaresDeTrasladoDeVictimas from the database without its data.
/// </summary>
/// <param name="id">The id of the LugaresDeTrasladoDeVictimas in the database.</param>
/// <returns>A LugaresDeTrasladoDeVictimas object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static LugaresDeTrasladoDeVictimas GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single LugaresDeTrasladoDeVictimas from the database.
/// </summary>
/// <param name="id">The id of the LugaresDeTrasladoDeVictimas in the database.</param>
/// <param name="getLugaresDeTrasladoDeVictimasRecords">Determines whether to load all associated LugaresDeTrasladoDeVictimas records as well.</param>
/// <returns>
/// A LugaresDeTrasladoDeVictimas object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static LugaresDeTrasladoDeVictimas GetItem(int id, bool getLugaresDeTrasladoDeVictimasRecords){
LugaresDeTrasladoDeVictimas myLugaresDeTrasladoDeVictimas = LugaresDeTrasladoDeVictimasDB.GetItem(id);
return myLugaresDeTrasladoDeVictimas;
}

/// <summary>
/// Saves a LugaresDeTrasladoDeVictimas in the database.
/// </summary>
/// <param name="myLugaresDeTrasladoDeVictimas">The LugaresDeTrasladoDeVictimas instance to save.</param>
/// <returns>The new id if the LugaresDeTrasladoDeVictimas is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(LugaresDeTrasladoDeVictimas myLugaresDeTrasladoDeVictimas, SqlCommand myCommand)
{
    //using (TransactionScope myTransactionScope = new TransactionScope())
    //{
    int lugaresDeTrasladoDeVictimasid = LugaresDeTrasladoDeVictimasDB.Save(myLugaresDeTrasladoDeVictimas, myCommand);

    //  Assign the LugaresDeTrasladoDeVictimas its new (or existing id).
    myLugaresDeTrasladoDeVictimas.id = lugaresDeTrasladoDeVictimasid;

    //myTransactionScope.Complete();

    return lugaresDeTrasladoDeVictimasid;
    //}
}

[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(LugaresDeTrasladoDeVictimas myLugaresDeTrasladoDeVictimas)
{
    using (TransactionScope myTransactionScope = new TransactionScope())
    {
    int lugaresDeTrasladoDeVictimasid = LugaresDeTrasladoDeVictimasDB.Save(myLugaresDeTrasladoDeVictimas);

    //  Assign the LugaresDeTrasladoDeVictimas its new (or existing id).
    myLugaresDeTrasladoDeVictimas.id = lugaresDeTrasladoDeVictimasid;

    myTransactionScope.Complete();

    return lugaresDeTrasladoDeVictimasid;
    }
}

/// <summary>
/// Deletes a LugaresDeTrasladoDeVictimas from the database.
/// </summary>
/// <param name="myLugaresDeTrasladoDeVictimas">The LugaresDeTrasladoDeVictimas instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(LugaresDeTrasladoDeVictimas myLugaresDeTrasladoDeVictimas){
return LugaresDeTrasladoDeVictimasDB.Delete(myLugaresDeTrasladoDeVictimas.id);
}

#endregion

}

}
