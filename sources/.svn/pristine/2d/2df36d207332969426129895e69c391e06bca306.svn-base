using System;
using System.ComponentModel;
using System.Transactions;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The BienSustraidoChequeManager class is responsible for managing Business Entities.BienSustraidoCheque objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BienSustraidoChequeManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BienSustraidoCheque objects in the database.
/// </summary>
/// <returns>A list with all BienSustraidoCheque from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BienSustraidoChequeList GetList(){
return BienSustraidoChequeDB.GetList();
}

/// <summary>
/// Gets a single BienSustraidoCheque from the database without its data.
/// </summary>
/// <param name="id">The id of the BienSustraidoCheque in the database.</param>
/// <returns>A BienSustraidoCheque object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BienSustraidoCheque GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single BienSustraidoCheque from the database without its data.
/// </summary>
/// <param name="id">The id of the BienSustraido in the database.</param>
/// <returns>A BienSustraidoCheque object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BienSustraidoCheque GetItemByBienSustraido(int idBienSustraido)
{
    return BienSustraidoChequeDB.GetItemByBienSustraido(idBienSustraido);
}

/// <summary>
/// Gets a single BienSustraidoCheque from the database.
/// </summary>
/// <param name="id">The id of the BienSustraidoCheque in the database.</param>
/// <param name="getBienSustraidoChequeRecords">Determines whether to load all associated BienSustraidoCheque records as well.</param>
/// <returns>
/// A BienSustraidoCheque object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BienSustraidoCheque GetItem(int id, bool getBienSustraidoChequeRecords){
BienSustraidoCheque myBienSustraidoCheque = BienSustraidoChequeDB.GetItem(id);
return myBienSustraidoCheque;
}

/// <summary>
/// Saves a BienSustraidoCheque in the database.
/// </summary>
/// <param name="myBienSustraidoCheque">The BienSustraidoCheque instance to save.</param>
/// <returns>The new id if the BienSustraidoCheque is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(BienSustraidoCheque myBienSustraidoCheque){
using (TransactionScope myTransactionScope = new TransactionScope()){
int bienSustraidoChequeid = BienSustraidoChequeDB.Save(myBienSustraidoCheque);

//  Assign the BienSustraidoCheque its new (or existing id).
myBienSustraidoCheque.id = bienSustraidoChequeid;

myTransactionScope.Complete();

return bienSustraidoChequeid;
}
}


public static int Save(BienSustraidoCheque myBienSustraidoCheque, SqlCommand myCommand)
{
    //using (TransactionScope myTransactionScope = new TransactionScope())
    //{
    int bienSustraidoChequeid = BienSustraidoChequeDB.Save(myBienSustraidoCheque, myCommand);

    //  Assign the BienesSustraidosAnimal its new (or existing id).
    myBienSustraidoCheque.id = bienSustraidoChequeid;

    //myTransactionScope.Complete();

    return bienSustraidoChequeid;
    //}
}

/// <summary>
/// Deletes a BienSustraidoCheque from the database.
/// </summary>
/// <param name="myBienSustraidoCheque">The BienSustraidoCheque instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BienSustraidoCheque myBienSustraidoCheque){
return BienSustraidoChequeDB.Delete(myBienSustraidoCheque.id);
}

#endregion

}

}
