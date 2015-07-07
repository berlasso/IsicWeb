using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The BusquedaRobosDelitosSexualesDB class is responsible for interacting with the database to retrieve and store information
/// about BusquedaRobosDelitosSexuales objects.
/// </summary>
public partial class BusquedaRobosDelitosSexualesDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BusquedaRobosDelitosSexuales from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BusquedaRobosDelitosSexuales in the database.</param>
/// <returns>An BusquedaRobosDelitosSexuales when the id was found in the database, or null otherwise.</returns>
public static BusquedaRobosDelitosSexuales GetItem(int id)
{
BusquedaRobosDelitosSexuales myBusquedaRobosDelitosSexuales = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBusquedaRobosDelitosSexuales = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBusquedaRobosDelitosSexuales;
}
}

/// <summary>
/// Returns a list with BusquedaRobosDelitosSexuales objects.
/// </summary>
/// <returns>A generics List with the BusquedaRobosDelitosSexuales objects.</returns>
public static BusquedaRobosDelitosSexualesList GetList()
{
BusquedaRobosDelitosSexualesList tempList = new BusquedaRobosDelitosSexualesList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesSelectList", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.HasRows)
{
while (myReader.Read())
{
tempList.Add(FillDataRecord(myReader));
}
}
myReader.Close();
}
}
}
return tempList;
}

/// <summary>
/// Saves a BusquedaRobosDelitosSexuales in the database.
/// </summary>
/// <param name="myBusquedaRobosDelitosSexuales">The BusquedaRobosDelitosSexuales instance to save.</param>
/// <returns>The new id if the BusquedaRobosDelitosSexuales is new in the database or the existing id when an item was updated.</returns>
public static int Save(BusquedaRobosDelitosSexuales myBusquedaRobosDelitosSexuales)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myBusquedaRobosDelitosSexuales.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myBusquedaRobosDelitosSexuales.id);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.HoraDesde))
{
myCommand.Parameters.AddWithValue("@horaDesde", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@horaDesde", myBusquedaRobosDelitosSexuales.HoraDesde);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.NombreAutor))
{
    myCommand.Parameters.AddWithValue("@NombreAutor", DBNull.Value);
}
else
{
    myCommand.Parameters.AddWithValue("@NombreAutor", myBusquedaRobosDelitosSexuales.NombreAutor);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.ApellidoAutor))
{
    myCommand.Parameters.AddWithValue("@ApellidoAutor", DBNull.Value);
}
else
{
    myCommand.Parameters.AddWithValue("@ApellidoAutor", myBusquedaRobosDelitosSexuales.ApellidoAutor);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.HoraHasta))
{
myCommand.Parameters.AddWithValue("@horaHasta", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@horaHasta", myBusquedaRobosDelitosSexuales.HoraHasta);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.ParajeBarrioH))
{
myCommand.Parameters.AddWithValue("@parajeBarrioH", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@parajeBarrioH", myBusquedaRobosDelitosSexuales.ParajeBarrioH);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.IdCalle))
{
myCommand.Parameters.AddWithValue("@idCalle", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idCalle", myBusquedaRobosDelitosSexuales.IdCalle);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.IdEntreCalle1))
{
myCommand.Parameters.AddWithValue("@idEntreCalle1", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idEntreCalle1", myBusquedaRobosDelitosSexuales.IdEntreCalle1);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.IdEntreCalle2))
{
myCommand.Parameters.AddWithValue("@idEntreCalle2", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idEntreCalle2", myBusquedaRobosDelitosSexuales.IdEntreCalle2);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.IdOtraCalle))
{
myCommand.Parameters.AddWithValue("@idOtraCalle", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idOtraCalle", myBusquedaRobosDelitosSexuales.IdOtraCalle);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.IdOtraEntreCalle))
{
myCommand.Parameters.AddWithValue("@idOtraEntreCalle", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idOtraEntreCalle", myBusquedaRobosDelitosSexuales.IdOtraEntreCalle);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.IdOtraEntreCalle2))
{
myCommand.Parameters.AddWithValue("@idOtraEntreCalle2", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idOtraEntreCalle2", myBusquedaRobosDelitosSexuales.IdOtraEntreCalle2);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.NroH))
{
myCommand.Parameters.AddWithValue("@nroH", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@nroH", myBusquedaRobosDelitosSexuales.NroH);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.PisoH))
{
myCommand.Parameters.AddWithValue("@pisoH", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@pisoH", myBusquedaRobosDelitosSexuales.PisoH);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.DeptoH))
{
myCommand.Parameters.AddWithValue("@deptoH", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@deptoH", myBusquedaRobosDelitosSexuales.DeptoH);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.IdComisariaH))
{
myCommand.Parameters.AddWithValue("@idComisariaH", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idComisariaH", myBusquedaRobosDelitosSexuales.IdComisariaH);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.NomReferenciaLugarRubro))
{
myCommand.Parameters.AddWithValue("@nomReferenciaLugarRubro", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@nomReferenciaLugarRubro", myBusquedaRobosDelitosSexuales.NomReferenciaLugarRubro);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.IdCausa))
{
myCommand.Parameters.AddWithValue("@idCausa", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idCausa", myBusquedaRobosDelitosSexuales.IdCausa);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.IdMarcaVehiculoMO))
{
myCommand.Parameters.AddWithValue("@idMarcaVehiculoMO", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idMarcaVehiculoMO", myBusquedaRobosDelitosSexuales.IdMarcaVehiculoMO);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.IdModeloVehiculoMO))
{
myCommand.Parameters.AddWithValue("@idModeloVehiculoMO", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idModeloVehiculoMO", myBusquedaRobosDelitosSexuales.IdModeloVehiculoMO);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.DominioMO))
{
myCommand.Parameters.AddWithValue("@dominioMO", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@dominioMO", myBusquedaRobosDelitosSexuales.DominioMO);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.IdColorVehiculoMO))
{
myCommand.Parameters.AddWithValue("@idColorVehiculoMO", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idColorVehiculoMO", myBusquedaRobosDelitosSexuales.IdColorVehiculoMO);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.IngresaronPor))
{
myCommand.Parameters.AddWithValue("@ingresaronPor", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@ingresaronPor", myBusquedaRobosDelitosSexuales.IngresaronPor);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.IdLocalidadTraslado))
{
myCommand.Parameters.AddWithValue("@idLocalidadTraslado", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idLocalidadTraslado", myBusquedaRobosDelitosSexuales.IdLocalidadTraslado);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.IdPartidoL))
{
myCommand.Parameters.AddWithValue("@idPartidoL", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idPartidoL", myBusquedaRobosDelitosSexuales.IdPartidoL);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.idLocalidadL))
{
myCommand.Parameters.AddWithValue("@idLocalidadL", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idLocalidadL", myBusquedaRobosDelitosSexuales.idLocalidadL);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.ParajeBarrioL))
{
myCommand.Parameters.AddWithValue("@parajeBarrioL", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@parajeBarrioL", myBusquedaRobosDelitosSexuales.ParajeBarrioL);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.IdCalleL))
{
myCommand.Parameters.AddWithValue("@idCalleL", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idCalleL", myBusquedaRobosDelitosSexuales.IdCalleL);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.IdOtraCalleL))
{
myCommand.Parameters.AddWithValue("@idOtraCalleL", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idOtraCalleL", myBusquedaRobosDelitosSexuales.IdOtraCalleL);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.IdEntreCalle1L))
{
myCommand.Parameters.AddWithValue("@idEntreCalle1L", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idEntreCalle1L", myBusquedaRobosDelitosSexuales.IdEntreCalle1L);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.OtraEntreCalle1L))
{
myCommand.Parameters.AddWithValue("@otraEntreCalle1L", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@otraEntreCalle1L", myBusquedaRobosDelitosSexuales.OtraEntreCalle1L);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.IdEntreCalle2L))
{
myCommand.Parameters.AddWithValue("@idEntreCalle2L", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idEntreCalle2L", myBusquedaRobosDelitosSexuales.IdEntreCalle2L);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.OtraEntreCalle2L))
{
myCommand.Parameters.AddWithValue("@otraEntreCalle2L", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@otraEntreCalle2L", myBusquedaRobosDelitosSexuales.OtraEntreCalle2L);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.IdComisariaL))
{
myCommand.Parameters.AddWithValue("@idComisariaL", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idComisariaL", myBusquedaRobosDelitosSexuales.IdComisariaL);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.ExprUtilizadaComienzoDelHecho))
{
myCommand.Parameters.AddWithValue("@exprUtilizadaComienzoDelHecho", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@exprUtilizadaComienzoDelHecho", myBusquedaRobosDelitosSexuales.ExprUtilizadaComienzoDelHecho);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.ExprReiteradaDuranteHecho))
{
myCommand.Parameters.AddWithValue("@exprReiteradaDuranteHecho", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@exprReiteradaDuranteHecho", myBusquedaRobosDelitosSexuales.ExprReiteradaDuranteHecho);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.MarcaGanado))
{
myCommand.Parameters.AddWithValue("@marcaGanado", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@marcaGanado", myBusquedaRobosDelitosSexuales.MarcaGanado);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.MarcaBienSustraidoOtro))
{
myCommand.Parameters.AddWithValue("@marcaBienSustraidoOtro", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@marcaBienSustraidoOtro", myBusquedaRobosDelitosSexuales.MarcaBienSustraidoOtro);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.NroSerieBienSustraidoOtro))
{
myCommand.Parameters.AddWithValue("@nroSerieBienSustraidoOtro", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@nroSerieBienSustraidoOtro", myBusquedaRobosDelitosSexuales.NroSerieBienSustraidoOtro);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.Nro))
{
myCommand.Parameters.AddWithValue("@nro", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@nro", myBusquedaRobosDelitosSexuales.Nro);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.CubiertoCon))
{
myCommand.Parameters.AddWithValue("@cubiertoCon", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@cubiertoCon", myBusquedaRobosDelitosSexuales.CubiertoCon);
}
//if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.UbicacionSeniaParticular))
//{
//myCommand.Parameters.AddWithValue("@ubicacionSeniaParticular", DBNull.Value);
//}
//else
//{
//myCommand.Parameters.AddWithValue("@ubicacionSeniaParticular", myBusquedaRobosDelitosSexuales.UbicacionSeniaParticular);
//}
//if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.OtroTatuaje))
//{
//myCommand.Parameters.AddWithValue("@otroTatuaje", DBNull.Value);
//}
//else
//{
//myCommand.Parameters.AddWithValue("@otroTatuaje", myBusquedaRobosDelitosSexuales.OtroTatuaje);
//}
//if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.OtraCaracteristica))
//{
//myCommand.Parameters.AddWithValue("@otraCaracteristica", DBNull.Value);
//}
//else
//{
//myCommand.Parameters.AddWithValue("@otraCaracteristica", myBusquedaRobosDelitosSexuales.OtraCaracteristica);
//}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.IdMarcaVehiculoBS))
{
myCommand.Parameters.AddWithValue("@idMarcaVehiculoBS", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idMarcaVehiculoBS", myBusquedaRobosDelitosSexuales.IdMarcaVehiculoBS);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.IdModeloVehiculoBS))
{
myCommand.Parameters.AddWithValue("@idModeloVehiculoBS", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idModeloVehiculoBS", myBusquedaRobosDelitosSexuales.IdModeloVehiculoBS);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.AnioBS))
{
myCommand.Parameters.AddWithValue("@anioBS", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@anioBS", myBusquedaRobosDelitosSexuales.AnioBS);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.DominioBS))
{
myCommand.Parameters.AddWithValue("@dominioBS", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@dominioBS", myBusquedaRobosDelitosSexuales.DominioBS);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.IdColorVehiculoBS))
{
myCommand.Parameters.AddWithValue("@idColorVehiculoBS", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idColorVehiculoBS", myBusquedaRobosDelitosSexuales.IdColorVehiculoBS);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.NumeroMotorBS))
{
myCommand.Parameters.AddWithValue("@numeroMotorBS", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@numeroMotorBS", myBusquedaRobosDelitosSexuales.NumeroMotorBS);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.NumeroChasisBS))
{
myCommand.Parameters.AddWithValue("@numeroChasisBS", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@numeroChasisBS", myBusquedaRobosDelitosSexuales.NumeroChasisBS);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.IdentificacionGNCBS))
{
myCommand.Parameters.AddWithValue("@identificacionGNCBS", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@identificacionGNCBS", myBusquedaRobosDelitosSexuales.IdentificacionGNCBS);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.OtraClaseArma))
{
myCommand.Parameters.AddWithValue("@otraClaseArma", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@otraClaseArma", myBusquedaRobosDelitosSexuales.OtraClaseArma);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.IdDepartamento))
{
myCommand.Parameters.AddWithValue("@idDepartamento", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idDepartamento", myBusquedaRobosDelitosSexuales.IdDepartamento);
}
if (myBusquedaRobosDelitosSexuales.IdDelito == null){
myCommand.Parameters.AddWithValue("@idDelito", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idDelito", myBusquedaRobosDelitosSexuales.IdDelito);
}
if (myBusquedaRobosDelitosSexuales.IdClaseDelito == null){
myCommand.Parameters.AddWithValue("@idClaseDelito", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idClaseDelito", myBusquedaRobosDelitosSexuales.IdClaseDelito);
}
if (myBusquedaRobosDelitosSexuales.IdTipoAutor == null)
{
    myCommand.Parameters.AddWithValue("@IdTipoAutor", DBNull.Value);
}
else
{
    myCommand.Parameters.AddWithValue("@IdTipoAutor", myBusquedaRobosDelitosSexuales.IdTipoAutor);
}
if (myBusquedaRobosDelitosSexuales.DocNroAutor == null)
{
    myCommand.Parameters.AddWithValue("@DocNroAutor", DBNull.Value);
}
else
{
    myCommand.Parameters.AddWithValue("@DocNroAutor", myBusquedaRobosDelitosSexuales.DocNroAutor);
}
if (myBusquedaRobosDelitosSexuales.IdClaseModusOperandi == null){
myCommand.Parameters.AddWithValue("@idClaseModusOperandi", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idClaseModusOperandi", myBusquedaRobosDelitosSexuales.IdClaseModusOperandi);
}
if (myBusquedaRobosDelitosSexuales.IdClaseMomentoDelDia == null){
myCommand.Parameters.AddWithValue("@idClaseMomentoDelDia", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idClaseMomentoDelDia", myBusquedaRobosDelitosSexuales.IdClaseMomentoDelDia);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.IdPartido))
{
myCommand.Parameters.AddWithValue("@idPartido", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idPartido", myBusquedaRobosDelitosSexuales.IdPartido);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.IdLocalidad))
{
myCommand.Parameters.AddWithValue("@idLocalidad", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idLocalidad", myBusquedaRobosDelitosSexuales.IdLocalidad);
}
if (myBusquedaRobosDelitosSexuales.IdClaseLugar == null){
myCommand.Parameters.AddWithValue("@idClaseLugar", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idClaseLugar", myBusquedaRobosDelitosSexuales.IdClaseLugar);
}
if (myBusquedaRobosDelitosSexuales.IdClaseRubro == null){
myCommand.Parameters.AddWithValue("@idClaseRubro", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idClaseRubro", myBusquedaRobosDelitosSexuales.IdClaseRubro);
}
if (myBusquedaRobosDelitosSexuales.IdClaseModoArriboHuida == null){
myCommand.Parameters.AddWithValue("@idClaseModoArriboHuida", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idClaseModoArriboHuida", myBusquedaRobosDelitosSexuales.IdClaseModoArriboHuida);
}
if (myBusquedaRobosDelitosSexuales.IdClaseVidrioVehiculoMO == null){
myCommand.Parameters.AddWithValue("@idClaseVidrioVehiculoMO", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idClaseVidrioVehiculoMO", myBusquedaRobosDelitosSexuales.IdClaseVidrioVehiculoMO);
}
if (myBusquedaRobosDelitosSexuales.IdClaseAgresion == null){
myCommand.Parameters.AddWithValue("@idClaseAgresion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idClaseAgresion", myBusquedaRobosDelitosSexuales.IdClaseAgresion);
}
if (myBusquedaRobosDelitosSexuales.IdClaseZonaCuerpoLesionada == null){
myCommand.Parameters.AddWithValue("@idClaseZonaCuerpoLesionada", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idClaseZonaCuerpoLesionada", myBusquedaRobosDelitosSexuales.IdClaseZonaCuerpoLesionada);
}
if (myBusquedaRobosDelitosSexuales.IdClaseArma == null){
myCommand.Parameters.AddWithValue("@idClaseArma", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idClaseArma", myBusquedaRobosDelitosSexuales.IdClaseArma);
}
if (myBusquedaRobosDelitosSexuales.IdClaseCantidadAutores == null){
myCommand.Parameters.AddWithValue("@idClaseCantidadAutores", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idClaseCantidadAutores", myBusquedaRobosDelitosSexuales.IdClaseCantidadAutores);
}
if (myBusquedaRobosDelitosSexuales.IdClaseEdadAproximada == null){
myCommand.Parameters.AddWithValue("@idClaseEdadAproximada", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idClaseEdadAproximada", myBusquedaRobosDelitosSexuales.IdClaseEdadAproximada);
}
if (myBusquedaRobosDelitosSexuales.IdClaseSexo == null){
myCommand.Parameters.AddWithValue("@idClaseSexo", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idClaseSexo", myBusquedaRobosDelitosSexuales.IdClaseSexo);
}
if (myBusquedaRobosDelitosSexuales.IdClaseRostro == null){
myCommand.Parameters.AddWithValue("@idClaseRostro", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idClaseRostro", myBusquedaRobosDelitosSexuales.IdClaseRostro);
}
//if (myBusquedaRobosDelitosSexuales.IdClaseSeniaParticular == null){
//myCommand.Parameters.AddWithValue("@idClaseSeniaParticular", DBNull.Value);
//}
//else
//{
//myCommand.Parameters.AddWithValue("@idClaseSeniaParticular", myBusquedaRobosDelitosSexuales.IdClaseSeniaParticular);
//}
//if (myBusquedaRobosDelitosSexuales.IdClaseLugarDelCuerpo == null){
//myCommand.Parameters.AddWithValue("@idClaseLugarDelCuerpo", DBNull.Value);
//}
//else
//{
//myCommand.Parameters.AddWithValue("@idClaseLugarDelCuerpo", myBusquedaRobosDelitosSexuales.IdClaseLugarDelCuerpo);
//}
//if (myBusquedaRobosDelitosSexuales.IdClaseTatuaje == null){
//myCommand.Parameters.AddWithValue("@idClaseTatuaje", DBNull.Value);
//}
//else
//{
//myCommand.Parameters.AddWithValue("@idClaseTatuaje", myBusquedaRobosDelitosSexuales.IdClaseTatuaje);
//}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.IdClaseSeniaParticularL))
{
    myCommand.Parameters.AddWithValue("@idClaseSeniaParticularL", DBNull.Value);
}
else
{
    myCommand.Parameters.AddWithValue("@idClaseSeniaParticularL", myBusquedaRobosDelitosSexuales.IdClaseSeniaParticularL);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.IdClaseTatuajeL))
{
    myCommand.Parameters.AddWithValue("@idClaseTatuajeL", DBNull.Value);
}
else
{
    myCommand.Parameters.AddWithValue("@idClaseTatuajeL", myBusquedaRobosDelitosSexuales.IdClaseTatuajeL);
}
if (myBusquedaRobosDelitosSexuales.IdClaseBienSustraido == null){
myCommand.Parameters.AddWithValue("@idClaseBienSustraido", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idClaseBienSustraido", myBusquedaRobosDelitosSexuales.IdClaseBienSustraido);
}
if (myBusquedaRobosDelitosSexuales.IdClaseVidrioVehiculoBS == null){
myCommand.Parameters.AddWithValue("@idClaseVidrioVehiculoBS", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idClaseVidrioVehiculoBS", myBusquedaRobosDelitosSexuales.IdClaseVidrioVehiculoBS);
}
if (myBusquedaRobosDelitosSexuales.IdClaseGanado == null){
myCommand.Parameters.AddWithValue("@idClaseGanado", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idClaseGanado", myBusquedaRobosDelitosSexuales.IdClaseGanado);
}
if (myBusquedaRobosDelitosSexuales.CantidadGanado == null){
myCommand.Parameters.AddWithValue("@cantidadGanado", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@cantidadGanado", myBusquedaRobosDelitosSexuales.CantidadGanado);
}
if (myBusquedaRobosDelitosSexuales.CantidadBienSustraidoOtro == null){
myCommand.Parameters.AddWithValue("@cantidadBienSustraidoOtro", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@cantidadBienSustraidoOtro", myBusquedaRobosDelitosSexuales.CantidadBienSustraidoOtro);
}
if (myBusquedaRobosDelitosSexuales.IdVicTestRecRueda == null){
myCommand.Parameters.AddWithValue("@idVicTestRecRueda", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idVicTestRecRueda", myBusquedaRobosDelitosSexuales.IdVicTestRecRueda);
}
if (myBusquedaRobosDelitosSexuales.IdClaseCondicionVictima == null){
myCommand.Parameters.AddWithValue("@idClaseCondicionVictima", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idClaseCondicionVictima", myBusquedaRobosDelitosSexuales.IdClaseCondicionVictima);
}
if (myBusquedaRobosDelitosSexuales.FechaDesde == null){
myCommand.Parameters.AddWithValue("@fechaDesde", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@fechaDesde", myBusquedaRobosDelitosSexuales.FechaDesde);
}
if (myBusquedaRobosDelitosSexuales.FechaHasta == null){
myCommand.Parameters.AddWithValue("@fechaHasta", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@fechaHasta", myBusquedaRobosDelitosSexuales.FechaHasta);
}
if (myBusquedaRobosDelitosSexuales.VictimasEnElLugar == null){
myCommand.Parameters.AddWithValue("@victimasEnElLugar", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@victimasEnElLugar", myBusquedaRobosDelitosSexuales.VictimasEnElLugar);
}
if (myBusquedaRobosDelitosSexuales.HuboAgresionFisicaAVictima == null){
myCommand.Parameters.AddWithValue("@huboAgresionFisicaAVictima", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@huboAgresionFisicaAVictima", myBusquedaRobosDelitosSexuales.HuboAgresionFisicaAVictima);
}
if (myBusquedaRobosDelitosSexuales.VictimaTrasladadaAOtroLugar == null){
myCommand.Parameters.AddWithValue("@victimaTrasladadaAOtroLugar", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@victimaTrasladadaAOtroLugar", myBusquedaRobosDelitosSexuales.VictimaTrasladadaAOtroLugar);
}
if (myBusquedaRobosDelitosSexuales.UsoDeArmas == null){
myCommand.Parameters.AddWithValue("@usoDeArmas", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@usoDeArmas", myBusquedaRobosDelitosSexuales.UsoDeArmas);
}
if (myBusquedaRobosDelitosSexuales.GNCBS == null){
myCommand.Parameters.AddWithValue("@gNCBS", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@gNCBS", myBusquedaRobosDelitosSexuales.GNCBS);
}
if (myBusquedaRobosDelitosSexuales.MontoTotalEstimadoBienSustraido == null){
myCommand.Parameters.AddWithValue("@montoTotalEstimadoBienSustraido", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@montoTotalEstimadoBienSustraido", myBusquedaRobosDelitosSexuales.MontoTotalEstimadoBienSustraido);
}
if (myBusquedaRobosDelitosSexuales.SusceptibleCotejoRastro == null){
myCommand.Parameters.AddWithValue("@susceptibleCotejoRastro", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@susceptibleCotejoRastro", myBusquedaRobosDelitosSexuales.SusceptibleCotejoRastro);
}
if (myBusquedaRobosDelitosSexuales.IdClaseRastro == null){
myCommand.Parameters.AddWithValue("@idClaseRastro", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idClaseRastro", myBusquedaRobosDelitosSexuales.IdClaseRastro);
}
if (myBusquedaRobosDelitosSexuales.IdClaseEstadoInformeRastro == null){
myCommand.Parameters.AddWithValue("@idClaseEstadoInformeRastro", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idClaseEstadoInformeRastro", myBusquedaRobosDelitosSexuales.IdClaseEstadoInformeRastro);
}
if (myBusquedaRobosDelitosSexuales.FechaCreacion == null){
myCommand.Parameters.AddWithValue("@fechaCreacion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@fechaCreacion", myBusquedaRobosDelitosSexuales.FechaCreacion);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.IdPuntoGestion))
{
myCommand.Parameters.AddWithValue("@idPuntoGestion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idPuntoGestion", myBusquedaRobosDelitosSexuales.IdPuntoGestion);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.DescripcionBusqueda))
{
myCommand.Parameters.AddWithValue("@descripcionBusqueda", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcionBusqueda", myBusquedaRobosDelitosSexuales.DescripcionBusqueda);
}
if (myBusquedaRobosDelitosSexuales.FechaUltimaModificacion == null){
myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", myBusquedaRobosDelitosSexuales.FechaUltimaModificacion);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.UsuarioUltimaModificacion))
{
myCommand.Parameters.AddWithValue("@usuarioUltimaModificacion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@usuarioUltimaModificacion", myBusquedaRobosDelitosSexuales.UsuarioUltimaModificacion);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.idClaseEstaturaL))
{
    myCommand.Parameters.AddWithValue("@idClaseEstaturaL", DBNull.Value);
}
else
{
    myCommand.Parameters.AddWithValue("@idClaseEstaturaL", myBusquedaRobosDelitosSexuales.idClaseEstaturaL);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.idClaseRobustezL))
{
    myCommand.Parameters.AddWithValue("@idClaseRobustezL", DBNull.Value);
}
else
{
    myCommand.Parameters.AddWithValue("@idClaseRobustezL", myBusquedaRobosDelitosSexuales.idClaseRobustezL);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.idClaseColorPielL))
{
    myCommand.Parameters.AddWithValue("@idClaseColorPielL", DBNull.Value);
}
else
{
    myCommand.Parameters.AddWithValue("@idClaseColorPielL", myBusquedaRobosDelitosSexuales.idClaseColorPielL);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.idClaseColorOjosL))
{
    myCommand.Parameters.AddWithValue("@idClaseColorOjosL", DBNull.Value);
}
else
{
    myCommand.Parameters.AddWithValue("@idClaseColorOjosL", myBusquedaRobosDelitosSexuales.idClaseColorOjosL);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.idClaseColorCabelloL))
{
    myCommand.Parameters.AddWithValue("@idClaseColorCabelloL", DBNull.Value);
}
else
{
    myCommand.Parameters.AddWithValue("@idClaseColorCabelloL", myBusquedaRobosDelitosSexuales.idClaseColorCabelloL);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.idClaseTipoCabelloL))
{
    myCommand.Parameters.AddWithValue("@idClaseTipoCabelloL", DBNull.Value);
}
else
{
    myCommand.Parameters.AddWithValue("@idClaseTipoCabelloL", myBusquedaRobosDelitosSexuales.idClaseTipoCabelloL);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.idClaseCalvicieL))
{
    myCommand.Parameters.AddWithValue("@idClaseCalvicieL", DBNull.Value);
}
else
{
    myCommand.Parameters.AddWithValue("@idClaseCalvicieL", myBusquedaRobosDelitosSexuales.idClaseCalvicieL);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.idClaseFormaCaraL))
{
    myCommand.Parameters.AddWithValue("@idClaseFormaCaraL", DBNull.Value);
}
else
{
    myCommand.Parameters.AddWithValue("@idClaseFormaCaraL", myBusquedaRobosDelitosSexuales.idClaseFormaCaraL);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.idDimensionCejaL))
{
    myCommand.Parameters.AddWithValue("@idDimensionCejaL", DBNull.Value);
}
else
{
    myCommand.Parameters.AddWithValue("@idDimensionCejaL", myBusquedaRobosDelitosSexuales.idDimensionCejaL);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.idTipoCejaL))
{
    myCommand.Parameters.AddWithValue("@idTipoCejaL", DBNull.Value);
}
else
{
    myCommand.Parameters.AddWithValue("@idTipoCejaL", myBusquedaRobosDelitosSexuales.idTipoCejaL);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.idFormaMentonL))
{
    myCommand.Parameters.AddWithValue("@idFormaMentonL", DBNull.Value);
}
else
{
    myCommand.Parameters.AddWithValue("@idFormaMentonL", myBusquedaRobosDelitosSexuales.idFormaMentonL);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.idFormaOrejaL))
{
    myCommand.Parameters.AddWithValue("@idFormaOrejaL", DBNull.Value);
}
else
{
    myCommand.Parameters.AddWithValue("@idFormaOrejaL", myBusquedaRobosDelitosSexuales.idFormaOrejaL);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.idFormaNarizL))
{
    myCommand.Parameters.AddWithValue("@idFormaNarizL", DBNull.Value);
}
else
{
    myCommand.Parameters.AddWithValue("@idFormaNarizL", myBusquedaRobosDelitosSexuales.idFormaNarizL);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.idFormaBocaL))
{
    myCommand.Parameters.AddWithValue("@idFormaBocaL", DBNull.Value);
}
else
{
    myCommand.Parameters.AddWithValue("@idFormaBocaL", myBusquedaRobosDelitosSexuales.idFormaBocaL);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.idFormaLabioInferiorL))
{
    myCommand.Parameters.AddWithValue("@idFormaLabioInferiorL", DBNull.Value);
}
else
{
    myCommand.Parameters.AddWithValue("@idFormaLabioInferiorL", myBusquedaRobosDelitosSexuales.idFormaLabioInferiorL);
}
if (string.IsNullOrEmpty(myBusquedaRobosDelitosSexuales.idFormaLabioSuperiorL))
{
    myCommand.Parameters.AddWithValue("@idFormaLabioSuperiorL", DBNull.Value);
}
else
{
    myCommand.Parameters.AddWithValue("@idFormaLabioSuperiorL", myBusquedaRobosDelitosSexuales.idFormaLabioSuperiorL);
}

  

DbParameter returnValue;
returnValue = myCommand.CreateParameter();
returnValue.Direction = ParameterDirection.ReturnValue;
myCommand.Parameters.Add(returnValue);

myConnection.Open();
myCommand.ExecuteNonQuery();
result = Convert.ToInt32(returnValue.Value);
myConnection.Close();
}
}
return result;
}
    
public static BusquedaRobosDelitosSexualesList GetListByidPuntoGestionTipoDelitoTipoAutor(string idPuntoGestion, int tipoDelito, int tipoAutor)
{
    BusquedaRobosDelitosSexualesList tempList = new BusquedaRobosDelitosSexualesList();
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesSelectListByidPuntoGestionTipoDelitoTipoAutor", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@idPuntoGestion", idPuntoGestion);
            myCommand.Parameters.AddWithValue("@tipoDelito", tipoDelito);
            myCommand.Parameters.AddWithValue("@tipoAutor", tipoAutor);
            myConnection.Open();
            using (SqlDataReader myReader = myCommand.ExecuteReader())
            {
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        tempList.Add(FillDataRecord(myReader));
                    }
                }
                myReader.Close();
            }
        }
        return tempList;
    }
}

/// <summary>
/// Deletes a BusquedaRobosDelitosSexuales from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRobosDelitosSexuales to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesDeleteSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

myCommand.Parameters.AddWithValue("@id", id);
myConnection.Open();
result = myCommand.ExecuteNonQuery();
myConnection.Close();
}
}
return result > 0;
}

#endregion

/// <summary>
/// Initializes a new instance of the BusquedaRobosDelitosSexuales class and fills it with the data fom the IDataRecord.
/// </summary>
private static BusquedaRobosDelitosSexuales FillDataRecord(IDataRecord myDataRecord )
{
BusquedaRobosDelitosSexuales myBusquedaRobosDelitosSexuales = new BusquedaRobosDelitosSexuales();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBusquedaRobosDelitosSexuales.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("HoraDesde")))
{
myBusquedaRobosDelitosSexuales.HoraDesde = myDataRecord.GetString(myDataRecord.GetOrdinal("HoraDesde"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("NombreAutor")))
{
    myBusquedaRobosDelitosSexuales.NombreAutor = myDataRecord.GetString(myDataRecord.GetOrdinal("NombreAutor"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("ApellidoAutor")))
{
    myBusquedaRobosDelitosSexuales.ApellidoAutor = myDataRecord.GetString(myDataRecord.GetOrdinal("ApellidoAutor"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("HoraHasta")))
{
myBusquedaRobosDelitosSexuales.HoraHasta = myDataRecord.GetString(myDataRecord.GetOrdinal("HoraHasta"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("ParajeBarrioH")))
{
myBusquedaRobosDelitosSexuales.ParajeBarrioH = myDataRecord.GetString(myDataRecord.GetOrdinal("ParajeBarrioH"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdCalle")))
{
myBusquedaRobosDelitosSexuales.IdCalle = myDataRecord.GetString(myDataRecord.GetOrdinal("IdCalle"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdEntreCalle1")))
{
myBusquedaRobosDelitosSexuales.IdEntreCalle1 = myDataRecord.GetString(myDataRecord.GetOrdinal("IdEntreCalle1"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdEntreCalle2")))
{
myBusquedaRobosDelitosSexuales.IdEntreCalle2 = myDataRecord.GetString(myDataRecord.GetOrdinal("IdEntreCalle2"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdOtraCalle")))
{
myBusquedaRobosDelitosSexuales.IdOtraCalle = myDataRecord.GetString(myDataRecord.GetOrdinal("IdOtraCalle"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdOtraEntreCalle")))
{
myBusquedaRobosDelitosSexuales.IdOtraEntreCalle = myDataRecord.GetString(myDataRecord.GetOrdinal("IdOtraEntreCalle"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdOtraEntreCalle2")))
{
myBusquedaRobosDelitosSexuales.IdOtraEntreCalle2 = myDataRecord.GetString(myDataRecord.GetOrdinal("IdOtraEntreCalle2"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("NroH")))
{
myBusquedaRobosDelitosSexuales.NroH = myDataRecord.GetString(myDataRecord.GetOrdinal("NroH"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("PisoH")))
{
myBusquedaRobosDelitosSexuales.PisoH = myDataRecord.GetString(myDataRecord.GetOrdinal("PisoH"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DeptoH")))
{
myBusquedaRobosDelitosSexuales.DeptoH = myDataRecord.GetString(myDataRecord.GetOrdinal("DeptoH"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdComisariaH")))
{
myBusquedaRobosDelitosSexuales.IdComisariaH = myDataRecord.GetString(myDataRecord.GetOrdinal("IdComisariaH"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("NomReferenciaLugarRubro")))
{
myBusquedaRobosDelitosSexuales.NomReferenciaLugarRubro = myDataRecord.GetString(myDataRecord.GetOrdinal("NomReferenciaLugarRubro"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdCausa")))
{
myBusquedaRobosDelitosSexuales.IdCausa = myDataRecord.GetString(myDataRecord.GetOrdinal("IdCausa"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdMarcaVehiculoMO")))
{
myBusquedaRobosDelitosSexuales.IdMarcaVehiculoMO = myDataRecord.GetString(myDataRecord.GetOrdinal("IdMarcaVehiculoMO"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdModeloVehiculoMO")))
{
myBusquedaRobosDelitosSexuales.IdModeloVehiculoMO = myDataRecord.GetString(myDataRecord.GetOrdinal("IdModeloVehiculoMO"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DominioMO")))
{
myBusquedaRobosDelitosSexuales.DominioMO = myDataRecord.GetString(myDataRecord.GetOrdinal("DominioMO"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdColorVehiculoMO")))
{
myBusquedaRobosDelitosSexuales.IdColorVehiculoMO = myDataRecord.GetString(myDataRecord.GetOrdinal("IdColorVehiculoMO"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IngresaronPor")))
{
myBusquedaRobosDelitosSexuales.IngresaronPor = myDataRecord.GetString(myDataRecord.GetOrdinal("IngresaronPor"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdLocalidadTraslado")))
{
myBusquedaRobosDelitosSexuales.IdLocalidadTraslado = myDataRecord.GetString(myDataRecord.GetOrdinal("IdLocalidadTraslado"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdPartidoL")))
{
myBusquedaRobosDelitosSexuales.IdPartidoL = myDataRecord.GetString(myDataRecord.GetOrdinal("IdPartidoL"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idLocalidadL")))
{
myBusquedaRobosDelitosSexuales.idLocalidadL = myDataRecord.GetString(myDataRecord.GetOrdinal("idLocalidadL"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("ParajeBarrioL")))
{
myBusquedaRobosDelitosSexuales.ParajeBarrioL = myDataRecord.GetString(myDataRecord.GetOrdinal("ParajeBarrioL"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdCalleL")))
{
myBusquedaRobosDelitosSexuales.IdCalleL = myDataRecord.GetString(myDataRecord.GetOrdinal("IdCalleL"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdOtraCalleL")))
{
myBusquedaRobosDelitosSexuales.IdOtraCalleL = myDataRecord.GetString(myDataRecord.GetOrdinal("IdOtraCalleL"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdEntreCalle1L")))
{
myBusquedaRobosDelitosSexuales.IdEntreCalle1L = myDataRecord.GetString(myDataRecord.GetOrdinal("IdEntreCalle1L"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("OtraEntreCalle1L")))
{
myBusquedaRobosDelitosSexuales.OtraEntreCalle1L = myDataRecord.GetString(myDataRecord.GetOrdinal("OtraEntreCalle1L"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdEntreCalle2L")))
{
myBusquedaRobosDelitosSexuales.IdEntreCalle2L = myDataRecord.GetString(myDataRecord.GetOrdinal("IdEntreCalle2L"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("OtraEntreCalle2L")))
{
myBusquedaRobosDelitosSexuales.OtraEntreCalle2L = myDataRecord.GetString(myDataRecord.GetOrdinal("OtraEntreCalle2L"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdComisariaL")))
{
myBusquedaRobosDelitosSexuales.IdComisariaL = myDataRecord.GetString(myDataRecord.GetOrdinal("IdComisariaL"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("ExprUtilizadaComienzoDelHecho")))
{
myBusquedaRobosDelitosSexuales.ExprUtilizadaComienzoDelHecho = myDataRecord.GetString(myDataRecord.GetOrdinal("ExprUtilizadaComienzoDelHecho"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("ExprReiteradaDuranteHecho")))
{
myBusquedaRobosDelitosSexuales.ExprReiteradaDuranteHecho = myDataRecord.GetString(myDataRecord.GetOrdinal("ExprReiteradaDuranteHecho"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("MarcaGanado")))
{
myBusquedaRobosDelitosSexuales.MarcaGanado = myDataRecord.GetString(myDataRecord.GetOrdinal("MarcaGanado"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("MarcaBienSustraidoOtro")))
{
myBusquedaRobosDelitosSexuales.MarcaBienSustraidoOtro = myDataRecord.GetString(myDataRecord.GetOrdinal("MarcaBienSustraidoOtro"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("NroSerieBienSustraidoOtro")))
{
myBusquedaRobosDelitosSexuales.NroSerieBienSustraidoOtro = myDataRecord.GetString(myDataRecord.GetOrdinal("NroSerieBienSustraidoOtro"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Nro")))
{
myBusquedaRobosDelitosSexuales.Nro = myDataRecord.GetString(myDataRecord.GetOrdinal("Nro"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CubiertoCon")))
{
myBusquedaRobosDelitosSexuales.CubiertoCon = myDataRecord.GetString(myDataRecord.GetOrdinal("CubiertoCon"));
}
//if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("UbicacionSeniaParticular")))
//{
//myBusquedaRobosDelitosSexuales.UbicacionSeniaParticular = myDataRecord.GetString(myDataRecord.GetOrdinal("UbicacionSeniaParticular"));
//}
//if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("OtroTatuaje")))
//{
//myBusquedaRobosDelitosSexuales.OtroTatuaje = myDataRecord.GetString(myDataRecord.GetOrdinal("OtroTatuaje"));
//}
//if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("OtraCaracteristica")))
//{
//myBusquedaRobosDelitosSexuales.OtraCaracteristica = myDataRecord.GetString(myDataRecord.GetOrdinal("OtraCaracteristica"));
//}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdMarcaVehiculoBS")))
{
myBusquedaRobosDelitosSexuales.IdMarcaVehiculoBS = myDataRecord.GetString(myDataRecord.GetOrdinal("IdMarcaVehiculoBS"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdModeloVehiculoBS")))
{
myBusquedaRobosDelitosSexuales.IdModeloVehiculoBS = myDataRecord.GetString(myDataRecord.GetOrdinal("IdModeloVehiculoBS"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("AnioBS")))
{
myBusquedaRobosDelitosSexuales.AnioBS = myDataRecord.GetString(myDataRecord.GetOrdinal("AnioBS"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DominioBS")))
{
myBusquedaRobosDelitosSexuales.DominioBS = myDataRecord.GetString(myDataRecord.GetOrdinal("DominioBS"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdColorVehiculoBS")))
{
myBusquedaRobosDelitosSexuales.IdColorVehiculoBS = myDataRecord.GetString(myDataRecord.GetOrdinal("IdColorVehiculoBS"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("NumeroMotorBS")))
{
myBusquedaRobosDelitosSexuales.NumeroMotorBS = myDataRecord.GetString(myDataRecord.GetOrdinal("NumeroMotorBS"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("NumeroChasisBS")))
{
myBusquedaRobosDelitosSexuales.NumeroChasisBS = myDataRecord.GetString(myDataRecord.GetOrdinal("NumeroChasisBS"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdentificacionGNCBS")))
{
myBusquedaRobosDelitosSexuales.IdentificacionGNCBS = myDataRecord.GetString(myDataRecord.GetOrdinal("IdentificacionGNCBS"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("OtraClaseArma")))
{
myBusquedaRobosDelitosSexuales.OtraClaseArma = myDataRecord.GetString(myDataRecord.GetOrdinal("OtraClaseArma"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdDepartamento")))
{
myBusquedaRobosDelitosSexuales.IdDepartamento = myDataRecord.GetString(myDataRecord.GetOrdinal("IdDepartamento"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdDelito")))
{
myBusquedaRobosDelitosSexuales.IdDelito = myDataRecord.GetInt32(myDataRecord.GetOrdinal("IdDelito"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdClaseDelito")))
{
myBusquedaRobosDelitosSexuales.IdClaseDelito = myDataRecord.GetInt32(myDataRecord.GetOrdinal("IdClaseDelito"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DocNroAutor")))
{
    myBusquedaRobosDelitosSexuales.DocNroAutor = myDataRecord.GetInt32(myDataRecord.GetOrdinal("DocNroAutor"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdClaseModusOperandi")))
{
myBusquedaRobosDelitosSexuales.IdClaseModusOperandi = myDataRecord.GetInt32(myDataRecord.GetOrdinal("IdClaseModusOperandi"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdTipoAutor")))
{
    myBusquedaRobosDelitosSexuales.IdTipoAutor = myDataRecord.GetInt32(myDataRecord.GetOrdinal("IdTipoAutor"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdClaseMomentoDelDia")))
{
myBusquedaRobosDelitosSexuales.IdClaseMomentoDelDia = myDataRecord.GetInt32(myDataRecord.GetOrdinal("IdClaseMomentoDelDia"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdPartido")))
{
myBusquedaRobosDelitosSexuales.IdPartido = myDataRecord.GetString(myDataRecord.GetOrdinal("IdPartido"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdLocalidad")))
{
myBusquedaRobosDelitosSexuales.IdLocalidad = myDataRecord.GetString(myDataRecord.GetOrdinal("IdLocalidad"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdClaseLugar")))
{
myBusquedaRobosDelitosSexuales.IdClaseLugar = myDataRecord.GetInt32(myDataRecord.GetOrdinal("IdClaseLugar"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdClaseRubro")))
{
myBusquedaRobosDelitosSexuales.IdClaseRubro = myDataRecord.GetInt32(myDataRecord.GetOrdinal("IdClaseRubro"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdClaseModoArriboHuida")))
{
myBusquedaRobosDelitosSexuales.IdClaseModoArriboHuida = myDataRecord.GetInt32(myDataRecord.GetOrdinal("IdClaseModoArriboHuida"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdClaseVidrioVehiculoMO")))
{
myBusquedaRobosDelitosSexuales.IdClaseVidrioVehiculoMO = myDataRecord.GetInt32(myDataRecord.GetOrdinal("IdClaseVidrioVehiculoMO"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdClaseAgresion")))
{
myBusquedaRobosDelitosSexuales.IdClaseAgresion = myDataRecord.GetInt32(myDataRecord.GetOrdinal("IdClaseAgresion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdClaseZonaCuerpoLesionada")))
{
myBusquedaRobosDelitosSexuales.IdClaseZonaCuerpoLesionada = myDataRecord.GetInt32(myDataRecord.GetOrdinal("IdClaseZonaCuerpoLesionada"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdClaseArma")))
{
myBusquedaRobosDelitosSexuales.IdClaseArma = myDataRecord.GetInt32(myDataRecord.GetOrdinal("IdClaseArma"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdClaseCantidadAutores")))
{
myBusquedaRobosDelitosSexuales.IdClaseCantidadAutores = myDataRecord.GetInt32(myDataRecord.GetOrdinal("IdClaseCantidadAutores"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdClaseEdadAproximada")))
{
myBusquedaRobosDelitosSexuales.IdClaseEdadAproximada = myDataRecord.GetInt32(myDataRecord.GetOrdinal("IdClaseEdadAproximada"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdClaseSexo")))
{
myBusquedaRobosDelitosSexuales.IdClaseSexo = myDataRecord.GetInt32(myDataRecord.GetOrdinal("IdClaseSexo"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdClaseRostro")))
{
myBusquedaRobosDelitosSexuales.IdClaseRostro = myDataRecord.GetInt32(myDataRecord.GetOrdinal("IdClaseRostro"));
}
//if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdClaseSeniaParticular")))
//{
//myBusquedaRobosDelitosSexuales.IdClaseSeniaParticular = myDataRecord.GetInt32(myDataRecord.GetOrdinal("IdClaseSeniaParticular"));
//}
//if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdClaseLugarDelCuerpo")))
//{
//myBusquedaRobosDelitosSexuales.IdClaseLugarDelCuerpo = myDataRecord.GetInt32(myDataRecord.GetOrdinal("IdClaseLugarDelCuerpo"));
//}
//if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdClaseTatuaje")))
//{
//myBusquedaRobosDelitosSexuales.IdClaseTatuaje = myDataRecord.GetInt32(myDataRecord.GetOrdinal("IdClaseTatuaje"));
//}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdClaseSeniaParticularL")))
{
    myBusquedaRobosDelitosSexuales.IdClaseSeniaParticularL = myDataRecord.GetString(myDataRecord.GetOrdinal("IdClaseSeniaParticularL"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdClaseTatuajeL")))
{
    myBusquedaRobosDelitosSexuales.IdClaseTatuajeL = myDataRecord.GetString(myDataRecord.GetOrdinal("IdClaseTatuajeL"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdClaseBienSustraido")))
{
myBusquedaRobosDelitosSexuales.IdClaseBienSustraido = myDataRecord.GetInt32(myDataRecord.GetOrdinal("IdClaseBienSustraido"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdClaseVidrioVehiculoBS")))
{
myBusquedaRobosDelitosSexuales.IdClaseVidrioVehiculoBS = myDataRecord.GetInt32(myDataRecord.GetOrdinal("IdClaseVidrioVehiculoBS"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdClaseGanado")))
{
myBusquedaRobosDelitosSexuales.IdClaseGanado = myDataRecord.GetInt32(myDataRecord.GetOrdinal("IdClaseGanado"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CantidadGanado")))
{
myBusquedaRobosDelitosSexuales.CantidadGanado = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CantidadGanado"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CantidadBienSustraidoOtro")))
{
myBusquedaRobosDelitosSexuales.CantidadBienSustraidoOtro = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CantidadBienSustraidoOtro"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdVicTestRecRueda")))
{
myBusquedaRobosDelitosSexuales.IdVicTestRecRueda = myDataRecord.GetInt32(myDataRecord.GetOrdinal("IdVicTestRecRueda"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdClaseCondicionVictima")))
{
myBusquedaRobosDelitosSexuales.IdClaseCondicionVictima = myDataRecord.GetInt32(myDataRecord.GetOrdinal("IdClaseCondicionVictima"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FechaDesde")))
{
myBusquedaRobosDelitosSexuales.FechaDesde = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("FechaDesde"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FechaHasta")))
{
myBusquedaRobosDelitosSexuales.FechaHasta = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("FechaHasta"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("VictimasEnElLugar")))
{
myBusquedaRobosDelitosSexuales.VictimasEnElLugar = myDataRecord.GetInt32(myDataRecord.GetOrdinal("VictimasEnElLugar"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("HuboAgresionFisicaAVictima")))
{
myBusquedaRobosDelitosSexuales.HuboAgresionFisicaAVictima = myDataRecord.GetInt32(myDataRecord.GetOrdinal("HuboAgresionFisicaAVictima"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("VictimaTrasladadaAOtroLugar")))
{
myBusquedaRobosDelitosSexuales.VictimaTrasladadaAOtroLugar = myDataRecord.GetInt32(myDataRecord.GetOrdinal("VictimaTrasladadaAOtroLugar"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("UsoDeArmas")))
{
myBusquedaRobosDelitosSexuales.UsoDeArmas = myDataRecord.GetInt32(myDataRecord.GetOrdinal("UsoDeArmas"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("GNCBS")))
{
myBusquedaRobosDelitosSexuales.GNCBS = myDataRecord.GetInt32(myDataRecord.GetOrdinal("GNCBS"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("MontoTotalEstimadoBienSustraido")))
{
myBusquedaRobosDelitosSexuales.MontoTotalEstimadoBienSustraido = myDataRecord.GetDecimal(myDataRecord.GetOrdinal("MontoTotalEstimadoBienSustraido"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("SusceptibleCotejoRastro")))
{
myBusquedaRobosDelitosSexuales.SusceptibleCotejoRastro = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("SusceptibleCotejoRastro"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdClaseRastro")))
{
myBusquedaRobosDelitosSexuales.IdClaseRastro = myDataRecord.GetInt32(myDataRecord.GetOrdinal("IdClaseRastro"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdClaseEstadoInformeRastro")))
{
myBusquedaRobosDelitosSexuales.IdClaseEstadoInformeRastro = myDataRecord.GetInt32(myDataRecord.GetOrdinal("IdClaseEstadoInformeRastro"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FechaCreacion")))
{
myBusquedaRobosDelitosSexuales.FechaCreacion = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("FechaCreacion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdPuntoGestion")))
{
myBusquedaRobosDelitosSexuales.IdPuntoGestion = myDataRecord.GetString(myDataRecord.GetOrdinal("IdPuntoGestion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DescripcionBusqueda")))
{
myBusquedaRobosDelitosSexuales.DescripcionBusqueda = myDataRecord.GetString(myDataRecord.GetOrdinal("DescripcionBusqueda"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FechaUltimaModificacion")))
{
myBusquedaRobosDelitosSexuales.FechaUltimaModificacion = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("FechaUltimaModificacion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("UsuarioUltimaModificacion")))
{
myBusquedaRobosDelitosSexuales.UsuarioUltimaModificacion = myDataRecord.GetString(myDataRecord.GetOrdinal("UsuarioUltimaModificacion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseEstaturaL")))
{
    myBusquedaRobosDelitosSexuales.idClaseEstaturaL = myDataRecord.GetString(myDataRecord.GetOrdinal("idClaseEstaturaL"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseRobustezL")))
{
    myBusquedaRobosDelitosSexuales.idClaseRobustezL = myDataRecord.GetString(myDataRecord.GetOrdinal("idClaseRobustezL"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseColorPielL")))
{
    myBusquedaRobosDelitosSexuales.idClaseColorPielL = myDataRecord.GetString(myDataRecord.GetOrdinal("idClaseColorPielL"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseColorOjosL")))
{
    myBusquedaRobosDelitosSexuales.idClaseColorOjosL = myDataRecord.GetString(myDataRecord.GetOrdinal("idClaseColorOjosL"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseColorCabelloL")))
{
    myBusquedaRobosDelitosSexuales.idClaseColorCabelloL = myDataRecord.GetString(myDataRecord.GetOrdinal("idClaseColorCabelloL"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseTipoCabelloL")))
{
    myBusquedaRobosDelitosSexuales.idClaseTipoCabelloL = myDataRecord.GetString(myDataRecord.GetOrdinal("idClaseTipoCabelloL"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseCalvicieL")))
{
    myBusquedaRobosDelitosSexuales.idClaseCalvicieL = myDataRecord.GetString(myDataRecord.GetOrdinal("idClaseCalvicieL"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseFormaCaraL")))
{
    myBusquedaRobosDelitosSexuales.idClaseFormaCaraL = myDataRecord.GetString(myDataRecord.GetOrdinal("idClaseFormaCaraL"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idDimensionCejaL")))
{
    myBusquedaRobosDelitosSexuales.idDimensionCejaL = myDataRecord.GetString(myDataRecord.GetOrdinal("idDimensionCejaL"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idTipoCejaL")))
{
    myBusquedaRobosDelitosSexuales.idTipoCejaL = myDataRecord.GetString(myDataRecord.GetOrdinal("idTipoCejaL"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idFormaMentonL")))
{
    myBusquedaRobosDelitosSexuales.idFormaMentonL = myDataRecord.GetString(myDataRecord.GetOrdinal("idFormaMentonL"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idFormaOrejaL")))
{
    myBusquedaRobosDelitosSexuales.idFormaOrejaL = myDataRecord.GetString(myDataRecord.GetOrdinal("idFormaOrejaL"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idFormaNarizL")))
{
    myBusquedaRobosDelitosSexuales.idFormaNarizL = myDataRecord.GetString(myDataRecord.GetOrdinal("idFormaNarizL"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idFormaBocaL")))
{
    myBusquedaRobosDelitosSexuales.idFormaBocaL = myDataRecord.GetString(myDataRecord.GetOrdinal("idFormaBocaL"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idFormaLabioInferiorL")))
{
    myBusquedaRobosDelitosSexuales.idFormaLabioInferiorL = myDataRecord.GetString(myDataRecord.GetOrdinal("idFormaLabioInferiorL"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idFormaLabioSuperiorL")))
{
    myBusquedaRobosDelitosSexuales.idFormaLabioSuperiorL = myDataRecord.GetString(myDataRecord.GetOrdinal("idFormaLabioSuperiorL"));
}


return myBusquedaRobosDelitosSexuales;
}
}

 } 
