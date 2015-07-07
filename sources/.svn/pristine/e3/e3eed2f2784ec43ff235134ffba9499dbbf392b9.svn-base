using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal {
/// <summary>
/// The PersonalPoderJudicialDB class is responsible for interacting with the database to retrieve and store information
/// about PersonalPoderJudicial objects.
/// </summary>
public partial class PersonalPoderJudicialDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of PersonalPoderJudicial from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the PersonalPoderJudicial in the database.</param>
/// <returns>An PersonalPoderJudicial when the id was found in the database, or null otherwise.</returns>
public static PersonalPoderJudicial GetItem(string id)
{
PersonalPoderJudicial myPersonalPoderJudicial = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PersonalPoderJudicialSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myPersonalPoderJudicial = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myPersonalPoderJudicial;
}
}

/// <summary>
/// Returns a list with PersonalPoderJudicial objects.
/// </summary>
/// <returns>A generics List with the PersonalPoderJudicial objects.</returns>
public static PersonalPoderJudicialList GetList()
{
PersonalPoderJudicialList tempList = new PersonalPoderJudicialList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PersonalPoderJudicialSelectList", myConnection))
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
/// Returns a list with PersonalPoderJudicial objects.
/// </summary>
/// <returns>A generics List with the PersonalPoderJudicial objects.</returns>
public static PersonalPoderJudicialList GetListByidPuntoGestion(string idPuntoGestion)
{
PersonalPoderJudicialList tempList = new PersonalPoderJudicialList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PersonalPoderJudicialSelectListByidPuntoGestion", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idPuntoGestion", idPuntoGestion);
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
/// Saves a PersonalPoderJudicial in the database.
/// </summary>
/// <param name="myPersonalPoderJudicial">The PersonalPoderJudicial instance to save.</param>
/// <returns>The new id if the PersonalPoderJudicial is new in the database or the existing id when an item was updated.</returns>
public static string Save(PersonalPoderJudicial myPersonalPoderJudicial)
{
    string result = "0";
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PersonalPoderJudicialInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (string.IsNullOrEmpty(myPersonalPoderJudicial.id))
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myPersonalPoderJudicial.id);
}
if (myPersonalPoderJudicial.idPersona == null)
{
myCommand.Parameters.AddWithValue("@idPersona", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idPersona", myPersonalPoderJudicial.idPersona);
}
if (myPersonalPoderJudicial.idJerarquia == null){
myCommand.Parameters.AddWithValue("@idJerarquia", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idJerarquia", myPersonalPoderJudicial.idJerarquia);
}
if (string.IsNullOrEmpty(myPersonalPoderJudicial.idPuntoGestion))
{
myCommand.Parameters.AddWithValue("@idPuntoGestion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idPuntoGestion", myPersonalPoderJudicial.idPuntoGestion);
}
if (myPersonalPoderJudicial.fechaDesde == null){
myCommand.Parameters.AddWithValue("@fechaDesde", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@fechaDesde", myPersonalPoderJudicial.fechaDesde);
}
if (myPersonalPoderJudicial.fechaHasta == null){
myCommand.Parameters.AddWithValue("@fechaHasta", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@fechaHasta", myPersonalPoderJudicial.fechaHasta);
}
if (myPersonalPoderJudicial.activo == null){
myCommand.Parameters.AddWithValue("@activo", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@activo", myPersonalPoderJudicial.activo);
}
if (myPersonalPoderJudicial.Instruye == null){
myCommand.Parameters.AddWithValue("@instruye", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@instruye", myPersonalPoderJudicial.Instruye);
}

DbParameter returnValue;
returnValue = myCommand.CreateParameter();
returnValue.Direction = ParameterDirection.ReturnValue;
myCommand.Parameters.Add(returnValue);

myConnection.Open();
myCommand.ExecuteNonQuery();
result = Convert.ToString(returnValue.Value);
myConnection.Close();
}
}
return result;
}

/// <summary>
/// Deletes a PersonalPoderJudicial from the database.
/// </summary>
/// <param name="id">The id of the PersonalPoderJudicial to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(string id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PersonalPoderJudicialDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the PersonalPoderJudicial class and fills it with the data fom the IDataRecord.
/// </summary>
private static PersonalPoderJudicial FillDataRecord(IDataRecord myDataRecord )
{
PersonalPoderJudicial myPersonalPoderJudicial = new PersonalPoderJudicial();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myPersonalPoderJudicial.id = myDataRecord.GetString(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idPersona")))
{
myPersonalPoderJudicial.idPersona = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idPersona"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idJerarquia")))
{
myPersonalPoderJudicial.idJerarquia = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idJerarquia"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idPuntoGestion")))
{
myPersonalPoderJudicial.idPuntoGestion = myDataRecord.GetString(myDataRecord.GetOrdinal("idPuntoGestion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("fechaDesde")))
{
myPersonalPoderJudicial.fechaDesde = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("fechaDesde"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("fechaHasta")))
{
myPersonalPoderJudicial.fechaHasta = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("fechaHasta"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("activo")))
{
myPersonalPoderJudicial.activo = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("activo"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Instruye")))
{
myPersonalPoderJudicial.Instruye = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("Instruye"));
}
return myPersonalPoderJudicial;
}
}

 } 
