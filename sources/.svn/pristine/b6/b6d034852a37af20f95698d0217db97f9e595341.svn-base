using System;
using System.ComponentModel;
using System.Transactions;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The BienSustraidoDineroManager class is responsible for managing Business Entities.BienSustraidoDinero objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BienSustraidoDineroManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BienSustraidoDinero objects in the database.
/// </summary>
/// <returns>A list with all BienSustraidoDinero from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BienSustraidoDineroList GetList(){
return BienSustraidoDineroDB.GetList();
}

/// <summary>
/// Gets a single BienSustraidoDinero from the database without its data.
/// </summary>
/// <param name="id">The id of the BienSustraido in the database.</param>
/// <returns>A BienSustraidoDinero object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BienSustraidoDinero GetItemByBienSustraido(int idBienSustraido){
    return BienSustraidoDineroDB.GetItemByBienSustraido(idBienSustraido);
}

/// <summary>
/// Gets a single BienSustraidoDinero from the database without its data.
/// </summary>
/// <param name="id">The id of the BienSustraidoDinero in the database.</param>
/// <returns>A BienSustraidoDinero object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BienSustraidoDinero GetItem(int id)
{
    return GetItem(id, false);
}

/// <summary>
/// Gets a single BienSustraidoDinero from the database.
/// </summary>
/// <param name="id">The id of the BienSustraidoDinero in the database.</param>
/// <param name="getBienSustraidoDineroRecords">Determines whether to load all associated BienSustraidoDinero records as well.</param>
/// <returns>
/// A BienSustraidoDinero object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BienSustraidoDinero GetItem(int id, bool getBienSustraidoDineroRecords){
BienSustraidoDinero myBienSustraidoDinero = BienSustraidoDineroDB.GetItem(id);
return myBienSustraidoDinero;
}

/// <summary>
/// Saves a BienSustraidoDinero in the database.
/// </summary>
/// <param name="myBienSustraidoDinero">The BienSustraidoDinero instance to save.</param>
/// <returns>The new id if the BienSustraidoDinero is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(BienSustraidoDinero myBienSustraidoDinero){
using (TransactionScope myTransactionScope = new TransactionScope()){
int bienSustraidoDineroid = BienSustraidoDineroDB.Save(myBienSustraidoDinero);

//  Assign the BienSustraidoDinero its new (or existing id).
myBienSustraidoDinero.id = bienSustraidoDineroid;

myTransactionScope.Complete();

return bienSustraidoDineroid;
}
}

public static int Save(BienSustraidoDinero myBienesSustraidosDinero, SqlCommand myCommand)
{
    //using (TransactionScope myTransactionScope = new TransactionScope())
    //{
    int bienSustraidoDineroid = BienSustraidoDineroDB.Save(myBienesSustraidosDinero, myCommand);

    //  Assign the BienesSustraidosAnimal its new (or existing id).
    myBienesSustraidosDinero.id = bienSustraidoDineroid;

    //myTransactionScope.Complete();

    return bienSustraidoDineroid;
    //}
}

/// <summary>
/// Deletes a BienSustraidoDinero from the database.
/// </summary>
/// <param name="myBienSustraidoDinero">The BienSustraidoDinero instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BienSustraidoDinero myBienSustraidoDinero){
return BienSustraidoDineroDB.Delete(myBienSustraidoDinero.id);
}

#endregion

}

}
