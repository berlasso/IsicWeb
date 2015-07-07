using System;
using System.ComponentModel;
using System.Transactions;
using System.Data;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The BienesSustraidosAnimalManager class is responsible for managing Business Object.BienesSustraidosAnimal objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BienesSustraidosAnimalManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BienesSustraidosAnimal objects in the database.
/// </summary>
/// <returns>A list with all BienesSustraidosAnimal from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BienesSustraidosAnimalList GetList(){
return BienesSustraidosAnimalDB.GetList();
}

/// <summary>
/// Gets a single BienesSustraidosAnimal from the database without its data.
/// </summary>
/// <param name="id">The id of the BienesSustraidosAnimal in the database.</param>
/// <returns>A BienesSustraidosAnimal object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BienesSustraidosAnimal GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single BienesSustraidosAnimal from the database without its data.
/// </summary>
/// <param name="id">The id of the BienesSustraidosAnimal in the database.</param>
/// <returns>A BienesSustraidosAnimal object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BienesSustraidosAnimal GetItemByBienSustraido(int idBienSustraido)
{
    return BienesSustraidosAnimalDB.GetItemByIdBienSustraido(idBienSustraido);
}

/// <summary>
/// Gets a single BienesSustraidosAnimal from the database.
/// </summary>
/// <param name="id">The id of the BienesSustraidosAnimal in the database.</param>
/// <param name="getBienesSustraidosAnimalRecords">Determines whether to load all associated BienesSustraidosAnimal records as well.</param>
/// <returns>
/// A BienesSustraidosAnimal object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BienesSustraidosAnimal GetItem(int id, bool getBienesSustraidosAnimalRecords){
BienesSustraidosAnimal myBienesSustraidosAnimal = BienesSustraidosAnimalDB.GetItem(id);
return myBienesSustraidosAnimal;
}

/// <summary>
/// Saves a BienesSustraidosAnimal in the database.
/// </summary>
/// <param name="myBienesSustraidosAnimal">The BienesSustraidosAnimal instance to save.</param>
/// <returns>The new id if the BienesSustraidosAnimal is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(BienesSustraidosAnimal myBienesSustraidosAnimal){
using (TransactionScope myTransactionScope = new TransactionScope()){
int bienesSustraidosAnimalid = BienesSustraidosAnimalDB.Save(myBienesSustraidosAnimal);

//  Assign the BienesSustraidosAnimal its new (or existing id).
myBienesSustraidosAnimal.id = bienesSustraidosAnimalid;

myTransactionScope.Complete();

return bienesSustraidosAnimalid;
}
}
public static int Save(BienesSustraidosAnimal myBienesSustraidosAnimal, SqlCommand myCommand)
{
    //using (TransactionScope myTransactionScope = new TransactionScope())
    //{
        int bienesSustraidosAnimalid = BienesSustraidosAnimalDB.Save(myBienesSustraidosAnimal, myCommand);

        //  Assign the BienesSustraidosAnimal its new (or existing id).
        myBienesSustraidosAnimal.id = bienesSustraidosAnimalid;

        //myTransactionScope.Complete();

        return bienesSustraidosAnimalid;
    //}
}


/// <summary>
/// Deletes a BienesSustraidosAnimal from the database.
/// </summary>
/// <param name="myBienesSustraidosAnimal">The BienesSustraidosAnimal instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BienesSustraidosAnimal myBienesSustraidosAnimal){
return BienesSustraidosAnimalDB.Delete(myBienesSustraidosAnimal.id);
}

#endregion

}

}
