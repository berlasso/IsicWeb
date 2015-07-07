using System;
using System.ComponentModel;
using System.Transactions;
using System.Data;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The BienesSustraidosOtroManager class is responsible for managing Business Object.BienesSustraidosOtro objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BienesSustraidosOtroManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BienesSustraidosOtro objects in the database.
/// </summary>
/// <returns>A list with all BienesSustraidosOtro from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BienesSustraidosOtroList GetList(){
return BienesSustraidosOtroDB.GetList();
}

/// <summary>
/// Gets a single BienesSustraidosOtro from the database without its data.
/// </summary>
/// <param name="id">The id of the BienesSustraidosOtro in the database.</param>
/// <returns>A BienesSustraidosOtro object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BienesSustraidosOtro GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single BienesSustraidosOtro from the database without its data.
/// </summary>
/// <param name="id">The id of the BienesSustraidosOtro in the database.</param>
/// <returns>A BienesSustraidosOtro object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BienesSustraidosOtro GetItemByBienSustraido(int idBienSustraido)
{
    return BienesSustraidosOtroDB.GetItemByBienSustraido(idBienSustraido);
}

/// <summary>
/// Gets a single BienesSustraidosOtro from the database.
/// </summary>
/// <param name="id">The id of the BienesSustraidosOtro in the database.</param>
/// <param name="getBienesSustraidosOtroRecords">Determines whether to load all associated BienesSustraidosOtro records as well.</param>
/// <returns>
/// A BienesSustraidosOtro object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BienesSustraidosOtro GetItem(int id, bool getBienesSustraidosOtroRecords){
BienesSustraidosOtro myBienesSustraidosOtro = BienesSustraidosOtroDB.GetItem(id);
return myBienesSustraidosOtro;
}

/// <summary>
/// Saves a BienesSustraidosOtro in the database.
/// </summary>
/// <param name="myBienesSustraidosOtro">The BienesSustraidosOtro instance to save.</param>
/// <returns>The new id if the BienesSustraidosOtro is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(BienesSustraidosOtro myBienesSustraidosOtro){
using (TransactionScope myTransactionScope = new TransactionScope()){
int bienesSustraidosOtroid = BienesSustraidosOtroDB.Save(myBienesSustraidosOtro);

//  Assign the BienesSustraidosOtro its new (or existing id).
myBienesSustraidosOtro.id = bienesSustraidosOtroid;

myTransactionScope.Complete();

return bienesSustraidosOtroid;
}
}

public static int Save(BienesSustraidosOtro myBienesSustraidosOtro, SqlCommand myCommand)
{
    //using (TransactionScope myTransactionScope = new TransactionScope())
    //{
    int bienesSustraidosOtroid = BienesSustraidosOtroDB.Save(myBienesSustraidosOtro, myCommand);

    //  Assign the BienesSustraidosOtro its new (or existing id).
    myBienesSustraidosOtro.id = bienesSustraidosOtroid;

    //myTransactionScope.Complete();

    return bienesSustraidosOtroid;
    //}
}

/// <summary>
/// Deletes a BienesSustraidosOtro from the database.
/// </summary>
/// <param name="myBienesSustraidosOtro">The BienesSustraidosOtro instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BienesSustraidosOtro myBienesSustraidosOtro){
return BienesSustraidosOtroDB.Delete(myBienesSustraidosOtro.id);
}

#endregion

}

}
