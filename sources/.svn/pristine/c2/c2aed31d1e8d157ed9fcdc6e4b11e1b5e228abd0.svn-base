using System;
using System.ComponentModel;
using System.Transactions;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The BienSustraidoTelefonoManager class is responsible for managing Business Entities.BienSustraidoTelefono objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BienSustraidoTelefonoManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BienSustraidoTelefono objects in the database.
/// </summary>
/// <returns>A list with all BienSustraidoTelefono from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BienSustraidoTelefonoList GetList(){
return BienSustraidoTelefonoDB.GetList();
}

/// <summary>
/// Gets a single BienSustraidoTelefono from the database without its data.
/// </summary>
/// <param name="id">The id of the BienSustraidoTelefono in the database.</param>
/// <returns>A BienSustraidoTelefono object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BienSustraidoTelefono GetItem(int id){
return GetItem(id, false);
}



/// <summary>
/// Gets a single BienSustraidoTelefono from the database.
/// </summary>
/// <param name="id">The id of the BienSustraidoTelefono in the database.</param>
/// <param name="getBienSustraidoTelefonoRecords">Determines whether to load all associated BienSustraidoTelefono records as well.</param>
/// <returns>
/// A BienSustraidoTelefono object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BienSustraidoTelefono GetItem(int id, bool getBienSustraidoTelefonoRecords){
BienSustraidoTelefono myBienSustraidoTelefono = BienSustraidoTelefonoDB.GetItem(id);
return myBienSustraidoTelefono;
}

/// <summary>
/// Gets a single BienSustraidoTelefono from the database without its data.
/// </summary>
/// <param name="id">The id of the BienSustraido in the database.</param>
/// <returns>A BienSustraidoTelefono object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BienSustraidoTelefono GetItemByBienSustraido(int idBienSustraido)
{
    return BienSustraidoTelefonoDB.GetItemByBienSustraido(idBienSustraido);
}

/// <summary>
/// Saves a BienSustraidoTelefono in the database.
/// </summary>
/// <param name="myBienSustraidoTelefono">The BienSustraidoTelefono instance to save.</param>
/// <returns>The new id if the BienSustraidoTelefono is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(BienSustraidoTelefono myBienSustraidoTelefono){
using (TransactionScope myTransactionScope = new TransactionScope()){
int bienSustraidoTelefonoid = BienSustraidoTelefonoDB.Save(myBienSustraidoTelefono);

//  Assign the BienSustraidoTelefono its new (or existing id).
myBienSustraidoTelefono.id = bienSustraidoTelefonoid;

myTransactionScope.Complete();

return bienSustraidoTelefonoid;
}
}

public static int Save(BienSustraidoTelefono myBienSustraidoTelefono, SqlCommand myCommand)
{
    //using (TransactionScope myTransactionScope = new TransactionScope())
    //{
    int bienSustraidoTelefonoid = BienSustraidoTelefonoDB.Save(myBienSustraidoTelefono, myCommand);

    //  Assign the BienesSustraidosAnimal its new (or existing id).
    myBienSustraidoTelefono.id = bienSustraidoTelefonoid;

    //myTransactionScope.Complete();

    return bienSustraidoTelefonoid;
    //}
}

/// <summary>
/// Deletes a BienSustraidoTelefono from the database.
/// </summary>
/// <param name="myBienSustraidoTelefono">The BienSustraidoTelefono instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BienSustraidoTelefono myBienSustraidoTelefono){
return BienSustraidoTelefonoDB.Delete(myBienSustraidoTelefono.id);
}

#endregion

}

}
