using System;
using System.ComponentModel;
using System.Transactions;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The BienSustraidoArmaManager class is responsible for managing Business Entities.BienSustraidoArma objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BienSustraidoArmaManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BienSustraidoArma objects in the database.
/// </summary>
/// <returns>A list with all BienSustraidoArma from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BienSustraidoArmaList GetList(){
return BienSustraidoArmaDB.GetList();
}

/// <summary>
/// Gets a single BienSustraidoArma from the database without its data.
/// </summary>
/// <param name="id">The id of the BienSustraidoArma in the database.</param>
/// <returns>A BienSustraidoArma object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BienSustraidoArma GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single BienSustraidoArma from the database.
/// </summary>
/// <param name="id">The id of the BienSustraidoArma in the database.</param>
/// <param name="getBienSustraidoArmaRecords">Determines whether to load all associated BienSustraidoArma records as well.</param>
/// <returns>
/// A BienSustraidoArma object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BienSustraidoArma GetItem(int id, bool getBienSustraidoArmaRecords){
BienSustraidoArma myBienSustraidoArma = BienSustraidoArmaDB.GetItem(id);
return myBienSustraidoArma;
}

/// <summary>
/// Gets a single BienSustraidoArma from the database without its data.
/// </summary>
/// <param name="id">The id of the BienSustraido in the database.</param>
/// <returns>A BienSustraidoArma object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BienSustraidoArma GetItemByBienSustraido(int idBienSustraido)
{
    return BienSustraidoArmaDB.GetItemByBienSustraido(idBienSustraido);
}

/// <summary>
/// Saves a BienSustraidoArma in the database.
/// </summary>
/// <param name="myBienSustraidoArma">The BienSustraidoArma instance to save.</param>
/// <returns>The new id if the BienSustraidoArma is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(BienSustraidoArma myBienSustraidoArma){
using (TransactionScope myTransactionScope = new TransactionScope()){
int bienSustraidoArmaid = BienSustraidoArmaDB.Save(myBienSustraidoArma);

//  Assign the BienSustraidoArma its new (or existing id).
myBienSustraidoArma.id = bienSustraidoArmaid;

myTransactionScope.Complete();

return bienSustraidoArmaid;
}
}

public static int Save(BienSustraidoArma myBienSustraidoArma, SqlCommand myCommand)
{
    //using (TransactionScope myTransactionScope = new TransactionScope())
    //{
    int bienesSustraidosArmaid = BienSustraidoArmaDB.Save(myBienSustraidoArma, myCommand);

    //  Assign the BienesSustraidosAnimal its new (or existing id).
    myBienSustraidoArma.id = bienesSustraidosArmaid;

    //myTransactionScope.Complete();

    return bienesSustraidosArmaid;
    //}
}

/// <summary>
/// Deletes a BienSustraidoArma from the database.
/// </summary>
/// <param name="myBienSustraidoArma">The BienSustraidoArma instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BienSustraidoArma myBienSustraidoArma){
return BienSustraidoArmaDB.Delete(myBienSustraidoArma.id);
}

#endregion

}

}
