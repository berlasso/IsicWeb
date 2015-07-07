using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal {
/// <summary>
/// The ClasePuntoGestionDB class is responsible for interacting with the database to retrieve and store information
/// about ClasePuntoGestion objects.
/// </summary>
public partial class ClasePuntoGestionDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of ClasePuntoGestion from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the ClasePuntoGestion in the database.</param>
/// <returns>An ClasePuntoGestion when the id was found in the database, or null otherwise.</returns>
public static ClasePuntoGestion GetItem(string id)
{
ClasePuntoGestion myClasePuntoGestion = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ClasePuntoGestionSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myClasePuntoGestion = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myClasePuntoGestion;
}
}

/// <summary>
/// Returns a list with ClasePuntoGestion objects.
/// </summary>
/// <returns>A generics List with the ClasePuntoGestion objects.</returns>
public static ClasePuntoGestionList GetList()
{
ClasePuntoGestionList tempList = new ClasePuntoGestionList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ClasePuntoGestionSelectList", myConnection))
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
/// Saves a ClasePuntoGestion in the database.
/// </summary>
/// <param name="myClasePuntoGestion">The ClasePuntoGestion instance to save.</param>
/// <returns>The new id if the ClasePuntoGestion is new in the database or the existing id when an item was updated.</returns>
public static int Save(ClasePuntoGestion myClasePuntoGestion)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ClasePuntoGestionInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myClasePuntoGestion.id == "-1")
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myClasePuntoGestion.id);
}
if (string.IsNullOrEmpty(myClasePuntoGestion.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myClasePuntoGestion.Descripcion);
}
if (string.IsNullOrEmpty(myClasePuntoGestion.DescripcionCorta))
{
myCommand.Parameters.AddWithValue("@descripcionCorta", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcionCorta", myClasePuntoGestion.DescripcionCorta);
}
if (myClasePuntoGestion.PermiteDenuncia == null){
myCommand.Parameters.AddWithValue("@permiteDenuncia", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@permiteDenuncia", myClasePuntoGestion.PermiteDenuncia);
}
if (myClasePuntoGestion.ordenMuestra == null){
myCommand.Parameters.AddWithValue("@ordenMuestra", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@ordenMuestra", myClasePuntoGestion.ordenMuestra);
}
if (myClasePuntoGestion.UsuarioDelSistema == null){
myCommand.Parameters.AddWithValue("@usuarioDelSistema", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@usuarioDelSistema", myClasePuntoGestion.UsuarioDelSistema);
}
if (myClasePuntoGestion.idMinisterio == null){
myCommand.Parameters.AddWithValue("@idMinisterio", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idMinisterio", myClasePuntoGestion.idMinisterio);
}
if (string.IsNullOrEmpty(myClasePuntoGestion.idClaseCategoria))
{
myCommand.Parameters.AddWithValue("@idClaseCategoria", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idClaseCategoria", myClasePuntoGestion.idClaseCategoria);
}
if (myClasePuntoGestion.UsaFicha == null){
myCommand.Parameters.AddWithValue("@usaFicha", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@usaFicha", myClasePuntoGestion.UsaFicha);
}
if (myClasePuntoGestion.UsaPapeles == null){
myCommand.Parameters.AddWithValue("@usaPapeles", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@usaPapeles", myClasePuntoGestion.UsaPapeles);
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

/// <summary>
/// Deletes a ClasePuntoGestion from the database.
/// </summary>
/// <param name="id">The id of the ClasePuntoGestion to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(string id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ClasePuntoGestionDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the ClasePuntoGestion class and fills it with the data fom the IDataRecord.
/// </summary>
private static ClasePuntoGestion FillDataRecord(IDataRecord myDataRecord )
{
ClasePuntoGestion myClasePuntoGestion = new ClasePuntoGestion();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myClasePuntoGestion.id = myDataRecord.GetString(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
myClasePuntoGestion.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DescripcionCorta")))
{
myClasePuntoGestion.DescripcionCorta = myDataRecord.GetString(myDataRecord.GetOrdinal("DescripcionCorta"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("PermiteDenuncia")))
{
myClasePuntoGestion.PermiteDenuncia = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("PermiteDenuncia"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("ordenMuestra")))
{
myClasePuntoGestion.ordenMuestra = myDataRecord.GetInt32(myDataRecord.GetOrdinal("ordenMuestra"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("UsuarioDelSistema")))
{
myClasePuntoGestion.UsuarioDelSistema = myDataRecord.GetInt32(myDataRecord.GetOrdinal("UsuarioDelSistema"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idMinisterio")))
{
myClasePuntoGestion.idMinisterio = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idMinisterio"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseCategoria")))
{
myClasePuntoGestion.idClaseCategoria = myDataRecord.GetString(myDataRecord.GetOrdinal("idClaseCategoria"));
}

return myClasePuntoGestion;
}
}

 } 
