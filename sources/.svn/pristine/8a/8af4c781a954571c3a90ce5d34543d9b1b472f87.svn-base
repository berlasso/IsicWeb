using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll {

/// <summary>
/// The BusquedaRobosDelitosSexualesManager class is responsible for managing Business Object.BusquedaRobosDelitosSexuales objects in the system.
/// </summary>
[DataObjectAttribute()]
 public partial class BusquedaRobosDelitosSexualesManager
  {

#region "Public Methods"

/// <summary>
/// Gets a list with all BusquedaRobosDelitosSexuales objects in the database.
/// </summary>
/// <returns>A list with all BusquedaRobosDelitosSexuales from the database when the database contains any, or null otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, true)]
public static BusquedaRobosDelitosSexualesList GetList(){
return BusquedaRobosDelitosSexualesDB.GetList();
}

[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRobosDelitosSexualesList GetListByIdPuntoGestionTipoDelitoTipoAutor(string idPuntoGestion, int tipoDelito, int tipoAutor)
{
    BusquedaRobosDelitosSexualesList myBusquedaList = BusquedaRobosDelitosSexualesDB.GetListByidPuntoGestionTipoDelitoTipoAutor(idPuntoGestion, tipoDelito, tipoAutor);
    return myBusquedaList;
}

/// <summary>
/// Gets a single BusquedaRobosDelitosSexuales from the database without its data.
/// </summary>
/// <param name="id">The id of the BusquedaRobosDelitosSexuales in the database.</param>
/// <returns>A BusquedaRobosDelitosSexuales object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRobosDelitosSexuales GetItem(int id){
return GetItem(id, false);
}

/// <summary>
/// Gets a single BusquedaRobosDelitosSexuales from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRobosDelitosSexuales in the database.</param>
/// <param name="getBusquedaRobosDelitosSexualesRecords">Determines whether to load all associated BusquedaRobosDelitosSexuales records as well.</param>
/// <returns>
/// A BusquedaRobosDelitosSexuales object when the id exists in the database, or <see langword="null"/> otherwise.
/// </returns>
[DataObjectMethod(DataObjectMethodType.Select, false)]
public static BusquedaRobosDelitosSexuales GetItem(int id, bool getBusquedaRobosDelitosSexualesRecords){
BusquedaRobosDelitosSexuales myBusquedaRobosDelitosSexuales = BusquedaRobosDelitosSexualesDB.GetItem(id);
if (myBusquedaRobosDelitosSexuales != null && getBusquedaRobosDelitosSexualesRecords)
{
    myBusquedaRobosDelitosSexuales.busquedaRoboDelitosSexualesCejaDimensions = BusquedaRoboDelitosSexualesCejaDimensionDB.GetListByidBusquedaRoboDS(id);
}
if (myBusquedaRobosDelitosSexuales != null && getBusquedaRobosDelitosSexualesRecords)
{
    myBusquedaRobosDelitosSexuales.busquedaRoboDelitosSexualesCejaFormas = BusquedaRoboDelitosSexualesCejaFormaDB.GetListByidBusquedaRoboDS(id);
}
if (myBusquedaRobosDelitosSexuales != null && getBusquedaRobosDelitosSexualesRecords)
{
    myBusquedaRobosDelitosSexuales.busquedaRoboDelitosSexualesColorCabellos = BusquedaRoboDelitosSexualesColorCabelloDB.GetListByidBusquedaRoboDS(id);
}
if (myBusquedaRobosDelitosSexuales != null && getBusquedaRobosDelitosSexualesRecords)
{
    myBusquedaRobosDelitosSexuales.busquedaRoboDelitosSexualesFormaBocas = BusquedaRoboDelitosSexualesFormaBocaDB.GetListByidBusquedaRoboDS(id);
}
if (myBusquedaRobosDelitosSexuales != null && getBusquedaRobosDelitosSexualesRecords)
{
    myBusquedaRobosDelitosSexuales.busquedaRoboDelitosSexualesFormaCaras = BusquedaRoboDelitosSexualesFormaCaraDB.GetListByidBusquedaRoboDS(id);
}
if (myBusquedaRobosDelitosSexuales != null && getBusquedaRobosDelitosSexualesRecords)
{
    myBusquedaRobosDelitosSexuales.busquedaRoboDelitosSexualesFormaLabioinfs = BusquedaRoboDelitosSexualesFormaLabioinfDB.GetListByidBusquedaRoboDS(id);
}
if (myBusquedaRobosDelitosSexuales != null && getBusquedaRobosDelitosSexualesRecords)
{
    myBusquedaRobosDelitosSexuales.busquedaRoboDelitosSexualesFormaLabioSups = BusquedaRoboDelitosSexualesFormaLabioSupDB.GetListByidBusquedaRoboDS(id);
}
if (myBusquedaRobosDelitosSexuales != null && getBusquedaRobosDelitosSexualesRecords)
{
    myBusquedaRobosDelitosSexuales.busquedaRoboDelitosSexualesFormaMentons = BusquedaRoboDelitosSexualesFormaMentonDB.GetListByidBusquedaRoboDS(id);
}
if (myBusquedaRobosDelitosSexuales != null && getBusquedaRobosDelitosSexualesRecords)
{
    myBusquedaRobosDelitosSexuales.busquedaRoboDelitosSexualesFormaNarizs = BusquedaRoboDelitosSexualesFormaNarizDB.GetListByidBusquedaRoboDS(id);
}
if (myBusquedaRobosDelitosSexuales != null && getBusquedaRobosDelitosSexualesRecords)
{
    myBusquedaRobosDelitosSexuales.busquedaRoboDelitosSexualesFormaOrejas = BusquedaRoboDelitosSexualesFormaOrejaDB.GetListByidBusquedaRoboDS(id);
}
if (myBusquedaRobosDelitosSexuales != null && getBusquedaRobosDelitosSexualesRecords)
{
    myBusquedaRobosDelitosSexuales.busquedaRoboDelitosSexualesRobustezs = BusquedaRoboDelitosSexualesRobustezDB.GetListByidBusquedaRoboDS(id);
}
if (myBusquedaRobosDelitosSexuales != null && getBusquedaRobosDelitosSexualesRecords)
{
    myBusquedaRobosDelitosSexuales.busquedaRoboDelitosSexualesTipoCabellos = BusquedaRoboDelitosSexualesTipoCabelloDB.GetListByidBusquedaRoboDS(id);
}
if (myBusquedaRobosDelitosSexuales != null && getBusquedaRobosDelitosSexualesRecords)
{
    myBusquedaRobosDelitosSexuales.busquedaRoboDelitosSexualesTipoCalvicies = BusquedaRoboDelitosSexualesTipoCalvicieDB.GetListByidBusquedaRoboDS(id);
}
if (myBusquedaRobosDelitosSexuales != null && getBusquedaRobosDelitosSexualesRecords)
{
    myBusquedaRobosDelitosSexuales.busquedaRobosDelitosSexualesColorOjoss = BusquedaRobosDelitosSexualesColorOjosDB.GetListByidBusquedaRoboDS(id);
}
if (myBusquedaRobosDelitosSexuales != null && getBusquedaRobosDelitosSexualesRecords)
{
    myBusquedaRobosDelitosSexuales.busquedaRobosDelitosSexualesColorPiels = BusquedaRobosDelitosSexualesColorPielDB.GetListByidBusquedaRoboDS(id);
}
if (myBusquedaRobosDelitosSexuales != null && getBusquedaRobosDelitosSexualesRecords)
{
    myBusquedaRobosDelitosSexuales.busquedaRobosDelitosSexualesComisariass = BusquedaRobosDelitosSexualesComisariasDB.GetListByidBusquedaRoboDS(id);
}
if (myBusquedaRobosDelitosSexuales != null && getBusquedaRobosDelitosSexualesRecords)
{
    myBusquedaRobosDelitosSexuales.busquedaRobosDelitosSexualesEstaturas = BusquedaRobosDelitosSexualesEstaturaDB.GetListByidBusquedaRoboDS(id);
}
if (myBusquedaRobosDelitosSexuales != null && getBusquedaRobosDelitosSexualesRecords)
{
    myBusquedaRobosDelitosSexuales.busquedaRobosDelitosSexualesLocalidadess = BusquedaRobosDelitosSexualesLocalidadesDB.GetListByidBusquedaRoboDS(id);
}
if (myBusquedaRobosDelitosSexuales != null && getBusquedaRobosDelitosSexualesRecords)
{
    myBusquedaRobosDelitosSexuales.busquedaRobosDelitosSexualesSeniass = BusquedaRobosDelitosSexualesSeniasDB.GetListByidBusquedaRoboDS(id);
}
if (myBusquedaRobosDelitosSexuales != null && getBusquedaRobosDelitosSexualesRecords)
{
    myBusquedaRobosDelitosSexuales.busquedaRobosDelitosSexualesTatuajess = BusquedaRobosDelitosSexualesTatuajesDB.GetListByidBusquedaRoboDS(id);
}
return myBusquedaRobosDelitosSexuales;
}

/// <summary>
/// Saves a BusquedaRobosDelitosSexuales in the database.
/// </summary>
/// <param name="myBusquedaRobosDelitosSexuales">The BusquedaRobosDelitosSexuales instance to save.</param>
/// <returns>The new id if the BusquedaRobosDelitosSexuales is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(BusquedaRobosDelitosSexuales myBusquedaRobosDelitosSexuales){
using (TransactionScope myTransactionScope = new TransactionScope()){
int busquedaRobosDelitosSexualesid = BusquedaRobosDelitosSexualesDB.Save(myBusquedaRobosDelitosSexuales);
foreach (BusquedaRoboDelitosSexualesCejaDimension myBusquedaRoboDelitosSexualesCejaDimension in myBusquedaRobosDelitosSexuales.busquedaRoboDelitosSexualesCejaDimensions)
{
    myBusquedaRoboDelitosSexualesCejaDimension.id = busquedaRobosDelitosSexualesid;
    BusquedaRoboDelitosSexualesCejaDimensionDB.Save(myBusquedaRoboDelitosSexualesCejaDimension);
}
foreach (BusquedaRoboDelitosSexualesCejaForma myBusquedaRoboDelitosSexualesCejaForma in myBusquedaRobosDelitosSexuales.busquedaRoboDelitosSexualesCejaFormas)
{
    myBusquedaRoboDelitosSexualesCejaForma.id = busquedaRobosDelitosSexualesid;
    BusquedaRoboDelitosSexualesCejaFormaDB.Save(myBusquedaRoboDelitosSexualesCejaForma);
}
foreach (BusquedaRoboDelitosSexualesColorCabello myBusquedaRoboDelitosSexualesColorCabello in myBusquedaRobosDelitosSexuales.busquedaRoboDelitosSexualesColorCabellos)
{
    myBusquedaRoboDelitosSexualesColorCabello.id = busquedaRobosDelitosSexualesid;
    BusquedaRoboDelitosSexualesColorCabelloDB.Save(myBusquedaRoboDelitosSexualesColorCabello);
}
foreach (BusquedaRoboDelitosSexualesFormaBoca myBusquedaRoboDelitosSexualesFormaBoca in myBusquedaRobosDelitosSexuales.busquedaRoboDelitosSexualesFormaBocas)
{
    myBusquedaRoboDelitosSexualesFormaBoca.id = busquedaRobosDelitosSexualesid;
    BusquedaRoboDelitosSexualesFormaBocaDB.Save(myBusquedaRoboDelitosSexualesFormaBoca);
}
foreach (BusquedaRoboDelitosSexualesFormaCara myBusquedaRoboDelitosSexualesFormaCara in myBusquedaRobosDelitosSexuales.busquedaRoboDelitosSexualesFormaCaras)
{
    myBusquedaRoboDelitosSexualesFormaCara.id = busquedaRobosDelitosSexualesid;
    BusquedaRoboDelitosSexualesFormaCaraDB.Save(myBusquedaRoboDelitosSexualesFormaCara);
}
foreach (BusquedaRoboDelitosSexualesFormaLabioinf myBusquedaRoboDelitosSexualesFormaLabioinf in myBusquedaRobosDelitosSexuales.busquedaRoboDelitosSexualesFormaLabioinfs)
{
    myBusquedaRoboDelitosSexualesFormaLabioinf.id = busquedaRobosDelitosSexualesid;
    BusquedaRoboDelitosSexualesFormaLabioinfDB.Save(myBusquedaRoboDelitosSexualesFormaLabioinf);
}
foreach (BusquedaRoboDelitosSexualesFormaLabioSup myBusquedaRoboDelitosSexualesFormaLabioSup in myBusquedaRobosDelitosSexuales.busquedaRoboDelitosSexualesFormaLabioSups)
{
    myBusquedaRoboDelitosSexualesFormaLabioSup.id = busquedaRobosDelitosSexualesid;
    BusquedaRoboDelitosSexualesFormaLabioSupDB.Save(myBusquedaRoboDelitosSexualesFormaLabioSup);
}
foreach (BusquedaRoboDelitosSexualesFormaMenton myBusquedaRoboDelitosSexualesFormaMenton in myBusquedaRobosDelitosSexuales.busquedaRoboDelitosSexualesFormaMentons)
{
    myBusquedaRoboDelitosSexualesFormaMenton.id = busquedaRobosDelitosSexualesid;
    BusquedaRoboDelitosSexualesFormaMentonDB.Save(myBusquedaRoboDelitosSexualesFormaMenton);
}
foreach (BusquedaRoboDelitosSexualesFormaNariz myBusquedaRoboDelitosSexualesFormaNariz in myBusquedaRobosDelitosSexuales.busquedaRoboDelitosSexualesFormaNarizs)
{
    myBusquedaRoboDelitosSexualesFormaNariz.id = busquedaRobosDelitosSexualesid;
    BusquedaRoboDelitosSexualesFormaNarizDB.Save(myBusquedaRoboDelitosSexualesFormaNariz);
}
foreach (BusquedaRoboDelitosSexualesFormaOreja myBusquedaRoboDelitosSexualesFormaOreja in myBusquedaRobosDelitosSexuales.busquedaRoboDelitosSexualesFormaOrejas)
{
    myBusquedaRoboDelitosSexualesFormaOreja.id = busquedaRobosDelitosSexualesid;
    BusquedaRoboDelitosSexualesFormaOrejaDB.Save(myBusquedaRoboDelitosSexualesFormaOreja);
}
foreach (BusquedaRoboDelitosSexualesRobustez myBusquedaRoboDelitosSexualesRobustez in myBusquedaRobosDelitosSexuales.busquedaRoboDelitosSexualesRobustezs)
{
    myBusquedaRoboDelitosSexualesRobustez.id = busquedaRobosDelitosSexualesid;
    BusquedaRoboDelitosSexualesRobustezDB.Save(myBusquedaRoboDelitosSexualesRobustez);
}
foreach (BusquedaRoboDelitosSexualesTipoCabello myBusquedaRoboDelitosSexualesTipoCabello in myBusquedaRobosDelitosSexuales.busquedaRoboDelitosSexualesTipoCabellos)
{
    myBusquedaRoboDelitosSexualesTipoCabello.id = busquedaRobosDelitosSexualesid;
    BusquedaRoboDelitosSexualesTipoCabelloDB.Save(myBusquedaRoboDelitosSexualesTipoCabello);
}
foreach (BusquedaRoboDelitosSexualesTipoCalvicie myBusquedaRoboDelitosSexualesTipoCalvicie in myBusquedaRobosDelitosSexuales.busquedaRoboDelitosSexualesTipoCalvicies)
{
    myBusquedaRoboDelitosSexualesTipoCalvicie.id = busquedaRobosDelitosSexualesid;
    BusquedaRoboDelitosSexualesTipoCalvicieDB.Save(myBusquedaRoboDelitosSexualesTipoCalvicie);
}
foreach (BusquedaRobosDelitosSexualesColorOjos myBusquedaRobosDelitosSexualesColorOjos in myBusquedaRobosDelitosSexuales.busquedaRobosDelitosSexualesColorOjoss)
{
    myBusquedaRobosDelitosSexualesColorOjos.id = busquedaRobosDelitosSexualesid;
    BusquedaRobosDelitosSexualesColorOjosDB.Save(myBusquedaRobosDelitosSexualesColorOjos);
}
foreach (BusquedaRobosDelitosSexualesColorPiel myBusquedaRobosDelitosSexualesColorPiel in myBusquedaRobosDelitosSexuales.busquedaRobosDelitosSexualesColorPiels)
{
    myBusquedaRobosDelitosSexualesColorPiel.id = busquedaRobosDelitosSexualesid;
    BusquedaRobosDelitosSexualesColorPielDB.Save(myBusquedaRobosDelitosSexualesColorPiel);
}
foreach (BusquedaRobosDelitosSexualesComisarias myBusquedaRobosDelitosSexualesComisarias in myBusquedaRobosDelitosSexuales.busquedaRobosDelitosSexualesComisariass)
{
    myBusquedaRobosDelitosSexualesComisarias.id = busquedaRobosDelitosSexualesid;
    BusquedaRobosDelitosSexualesComisariasDB.Save(myBusquedaRobosDelitosSexualesComisarias);
}
foreach (BusquedaRobosDelitosSexualesEstatura myBusquedaRobosDelitosSexualesEstatura in myBusquedaRobosDelitosSexuales.busquedaRobosDelitosSexualesEstaturas)
{
    myBusquedaRobosDelitosSexualesEstatura.id = busquedaRobosDelitosSexualesid;
    BusquedaRobosDelitosSexualesEstaturaDB.Save(myBusquedaRobosDelitosSexualesEstatura);
}
foreach (BusquedaRobosDelitosSexualesLocalidades myBusquedaRobosDelitosSexualesLocalidades in myBusquedaRobosDelitosSexuales.busquedaRobosDelitosSexualesLocalidadess)
{
    myBusquedaRobosDelitosSexualesLocalidades.id = busquedaRobosDelitosSexualesid;
    BusquedaRobosDelitosSexualesLocalidadesDB.Save(myBusquedaRobosDelitosSexualesLocalidades);
}
foreach (BusquedaRobosDelitosSexualesSenias myBusquedaRobosDelitosSexualesSenias in myBusquedaRobosDelitosSexuales.busquedaRobosDelitosSexualesSeniass)
{
    myBusquedaRobosDelitosSexualesSenias.id = busquedaRobosDelitosSexualesid;
    BusquedaRobosDelitosSexualesSeniasDB.Save(myBusquedaRobosDelitosSexualesSenias);
}
foreach (BusquedaRobosDelitosSexualesTatuajes myBusquedaRobosDelitosSexualesTatuajes in myBusquedaRobosDelitosSexuales.busquedaRobosDelitosSexualesTatuajess)
{
    myBusquedaRobosDelitosSexualesTatuajes.id = busquedaRobosDelitosSexualesid;
    BusquedaRobosDelitosSexualesTatuajesDB.Save(myBusquedaRobosDelitosSexualesTatuajes);
}


//  Assign the BusquedaRobosDelitosSexuales its new (or existing id).
myBusquedaRobosDelitosSexuales.id = busquedaRobosDelitosSexualesid;

myTransactionScope.Complete();

return busquedaRobosDelitosSexualesid;
}
}

/// <summary>
/// Deletes a BusquedaRobosDelitosSexuales from the database.
/// </summary>
/// <param name="myBusquedaRobosDelitosSexuales">The BusquedaRobosDelitosSexuales instance to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
[DataObjectMethod(DataObjectMethodType.Delete, true)]
public static bool Delete(BusquedaRobosDelitosSexuales myBusquedaRobosDelitosSexuales){
return BusquedaRobosDelitosSexualesDB.Delete(myBusquedaRobosDelitosSexuales.id);
}

#endregion

}

}
