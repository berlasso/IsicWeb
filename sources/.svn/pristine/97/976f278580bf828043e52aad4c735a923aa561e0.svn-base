using System;
using System.ComponentModel;
using System.Transactions;
using System.Data;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The BienesSustraidosManager class is responsible for managing Business Object.BienesSustraidos objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BienesSustraidosManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BienesSustraidos objects in the database.
/// </summary>
/// <returns>A list with all BienesSustraidos from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BienesSustraidosList GetList(){
return BienesSustraidosDB.GetList();
}

/// <summary>
/// Gets a list with all BienesSustraidos objects in the database.
/// </summary>
/// <returns>A list with all BienesSustraidos from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BienesSustraidosList GetListByIdDelito(int idDelito)
{
    return BienesSustraidosDB.GetListByidDelito(idDelito);
}

/// <summary>
/// Gets a list with all BienesSustraidos objects in the database.
/// </summary>
/// <returns>A list with all BienesSustraidos from the database when the database contains any, or null otherwise.</returns>
/// 
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BienesSustraidosList GetListByIdDelito(int idDelito, bool getBienesSustraidoRecord)
{
    BienesSustraidosList bsl = BienesSustraidosDB.GetListByidDelito(idDelito);
    for (int i = 0; i <= bsl.Count - 1; i++)
    {
        bsl[i] = BienesSustraidosManager.GetItem(bsl[i].id, true);
    }
    return bsl;
}
/// <summary>
/// Gets a single BienesSustraidos from the database without its data.
/// </summary>
/// <param name="id">The id of the BienesSustraidos in the database.</param>
/// <returns>A BienesSustraidos object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BienesSustraidos GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single BienesSustraidos from the database.
/// </summary>
/// <param name="id">The id of the BienesSustraidos in the database.</param>
/// <param name="getBienesSustraidosRecords">Determines whether to load all associated BienesSustraidos records as well.</param>
/// <returns>
/// A BienesSustraidos object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BienesSustraidos GetItem(int id, bool getBienesSustraidosRecords){
BienesSustraidos myBienesSustraidos = BienesSustraidosDB.GetItem(id);
if (myBienesSustraidos != null && getBienesSustraidosRecords){
myBienesSustraidos.bienesSustraidosAnimals = BienesSustraidosAnimalDB.GetListByidNNBienSustraido(id);
}
if (myBienesSustraidos != null && getBienesSustraidosRecords){
myBienesSustraidos.bienesSustraidosOtros = BienesSustraidosOtroDB.GetListByidNNBienSustraido(id);
}
if (myBienesSustraidos != null && getBienesSustraidosRecords){
myBienesSustraidos.vehiculoss = VehiculosDB.GetListByidBienSustraido(id);
}
if (myBienesSustraidos != null && getBienesSustraidosRecords)
{
    myBienesSustraidos.bienSustraidoArmas = BienSustraidoArmaDB.GetListByidNNBienSustraido(id);
}
if (myBienesSustraidos != null && getBienesSustraidosRecords)
{
    myBienesSustraidos.bienSustraidoCheques = BienSustraidoChequeDB.GetListByidNNBienSustraido(id);
}
if (myBienesSustraidos != null && getBienesSustraidosRecords)
{
    myBienesSustraidos.bienSustraidoDineros = BienSustraidoDineroDB.GetListByidNNBienSustraido(id);
}
if (myBienesSustraidos != null && getBienesSustraidosRecords)
{
    myBienesSustraidos.bienSustraidoTelefonos = BienSustraidoTelefonoDB.GetListByidNNBienSustraido(id);
}
return myBienesSustraidos;
}

/// <summary>
/// Saves a BienesSustraidos in the database.
/// </summary>
/// <param name="myBienesSustraidos">The BienesSustraidos instance to save.</param>
/// <returns>The new id if the BienesSustraidos is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(BienesSustraidos myBienesSustraidos)
{
    using (TransactionScope myTransactionScope = new TransactionScope())
    {
        int bienesSustraidosid = BienesSustraidosDB.Save(myBienesSustraidos);
        int delitosId = myBienesSustraidos.idDelito;
        foreach (BienesSustraidosAnimal myBienesSustraidosAnimal in myBienesSustraidos.bienesSustraidosAnimals)
        {
            myBienesSustraidosAnimal.id = bienesSustraidosid;
            BienesSustraidosAnimalDB.Save(myBienesSustraidosAnimal);
        }
        foreach (BienesSustraidosOtro myBienesSustraidosOtro in myBienesSustraidos.bienesSustraidosOtros)
        {
            myBienesSustraidosOtro.id = bienesSustraidosid;
            BienesSustraidosOtroDB.Save(myBienesSustraidosOtro);
        }
        foreach (Vehiculos myVehiculos in myBienesSustraidos.vehiculoss)
        {
            myVehiculos.id = bienesSustraidosid;
            myVehiculos.idDelito = delitosId;
            VehiculosDB.Save(myVehiculos);
        }
        foreach (BienSustraidoArma myBienesSustraidosArma in myBienesSustraidos.bienSustraidoArmas)
        {
            myBienesSustraidosArma.idNNBienSustraido = bienesSustraidosid;
            BienSustraidoArmaManager.Save(myBienesSustraidosArma);
        }
        foreach (BienSustraidoCheque myBienSustraidoCheque in myBienesSustraidos.bienSustraidoCheques)
        {
            myBienSustraidoCheque.idNNBienSustraido = bienesSustraidosid;
            BienSustraidoChequeManager.Save(myBienSustraidoCheque);
        }
        foreach (BienSustraidoDinero myBienSustraidoDinero in myBienesSustraidos.bienSustraidoDineros)
        {
            myBienSustraidoDinero.idNNBienSustraido = bienesSustraidosid;
            BienSustraidoDineroManager.Save(myBienSustraidoDinero);
        }
        foreach (BienSustraidoTelefono myBienSustraidoTelefono in myBienesSustraidos.bienSustraidoTelefonos)
        {
            myBienSustraidoTelefono.idNNBienSustraido = bienesSustraidosid;
            BienSustraidoTelefonoManager.Save(myBienSustraidoTelefono);
        }

        //  Assign the BienesSustraidos its new (or existing id).
        myBienesSustraidos.id = bienesSustraidosid;

        myTransactionScope.Complete();

        return bienesSustraidosid;
    }
}

public static int Save(BienesSustraidos myBienesSustraidos, SqlCommand myCommand)
{
    //using (TransactionScope myTransactionScope = new TransactionScope())
    //{
        int bienesSustraidosid = BienesSustraidosDB.Save(myBienesSustraidos, myCommand);
        int delitosId = myBienesSustraidos.idDelito;
        foreach (BienesSustraidosAnimal myBienesSustraidosAnimal in myBienesSustraidos.bienesSustraidosAnimals)
        {
            myBienesSustraidosAnimal.idNNBienSustraido = bienesSustraidosid;
            BienesSustraidosAnimalManager.Save(myBienesSustraidosAnimal, myCommand);
        }
        foreach (BienesSustraidosOtro myBienesSustraidosOtro in myBienesSustraidos.bienesSustraidosOtros)
        {
            myBienesSustraidosOtro.idNNBienSustraido = bienesSustraidosid;
            BienesSustraidosOtroManager.Save(myBienesSustraidosOtro,myCommand);
        }
        foreach (Vehiculos myVehiculos in myBienesSustraidos.vehiculoss)
        {
            myVehiculos.idBienSustraido = bienesSustraidosid;
            myVehiculos.idDelito = delitosId;
            VehiculosManager.Save(myVehiculos, myCommand);
        }
        foreach (BienSustraidoArma myBienesSustraidosArma in myBienesSustraidos.bienSustraidoArmas)
        {
            myBienesSustraidosArma.idNNBienSustraido = bienesSustraidosid;
            BienSustraidoArmaManager.Save(myBienesSustraidosArma, myCommand);
        }
        foreach (BienSustraidoCheque myBienSustraidoCheque in myBienesSustraidos.bienSustraidoCheques)
        {
            myBienSustraidoCheque.idNNBienSustraido = bienesSustraidosid;
            BienSustraidoChequeManager.Save(myBienSustraidoCheque, myCommand);
        }
        foreach (BienSustraidoDinero myBienSustraidoDinero in myBienesSustraidos.bienSustraidoDineros)
        {
            myBienSustraidoDinero.idNNBienSustraido = bienesSustraidosid;
            BienSustraidoDineroManager.Save(myBienSustraidoDinero, myCommand);
        }
        foreach (BienSustraidoTelefono myBienSustraidoTelefono in myBienesSustraidos.bienSustraidoTelefonos)
        {
            myBienSustraidoTelefono.idNNBienSustraido = bienesSustraidosid;
            BienSustraidoTelefonoManager.Save(myBienSustraidoTelefono, myCommand);
        }
        //  Assign the BienesSustraidos its new (or existing id).
        myBienesSustraidos.id = bienesSustraidosid;

        //myTransactionScope.Complete();

        return bienesSustraidosid;
    //}
}


/// <summary>
/// Deletes a BienesSustraidos from the database.
/// </summary>
/// <param name="myBienesSustraidos">The BienesSustraidos instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BienesSustraidos myBienesSustraidos){
return BienesSustraidosDB.Delete(myBienesSustraidos.id);
}

#endregion

}

}
