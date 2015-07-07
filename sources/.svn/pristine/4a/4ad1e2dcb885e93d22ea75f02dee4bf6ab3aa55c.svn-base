using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal {
/// <summary>
/// The DientesDB class is responsible for interacting with the database to retrieve and store information
/// about Dientes objects.
/// </summary>
public partial class DientesDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of Dientes from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the Dientes in the database.</param>
/// <returns>An Dientes when the id was found in the database, or null otherwise.</returns>
public static Dientes GetItem(int id)
{
Dientes myDientes = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("DientesSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myDientes = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myDientes;
}
}

/// <summary>
/// Returns a list with Dientes objects.
/// </summary>
/// <returns>A generics List with the Dientes objects.</returns>
public static DientesList GetList()
{
DientesList tempList = new DientesList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("DientesSelectList", myConnection))
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
/// Saves a Dientes in the database.
/// </summary>
/// <param name="myDientes">The Dientes instance to save.</param>
/// <returns>The new id if the Dientes is new in the database or the existing id when an item was updated.</returns>
public static int Save(Dientes myDientes)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("DientesInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myDientes.Id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myDientes.idDiente);
}
if (myDientes.idPersona == null){
myCommand.Parameters.AddWithValue("@idPersona", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idPersona", myDientes.idPersona);
}
if (myDientes.idDiente == null){
myCommand.Parameters.AddWithValue("@idDiente", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idDiente", myDientes.idDiente);
}
if (myDientes.Existe == null){
myCommand.Parameters.AddWithValue("@existe", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@existe", myDientes.Existe);
}
if (myDientes.FechaUltimaModificacion == null){
myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", myDientes.FechaUltimaModificacion);
}
if (string.IsNullOrEmpty(myDientes.UsuarioUltimaModificacion))
{
myCommand.Parameters.AddWithValue("@usuarioUltimaModificacion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@usuarioUltimaModificacion", myDientes.UsuarioUltimaModificacion);
}
if (myDientes.Baja == null){
myCommand.Parameters.AddWithValue("@baja", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@baja", myDientes.Baja);
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
/// Deletes a Dientes from the database.
/// </summary>
/// <param name="id">The id of the Dientes to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("DientesDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the Dientes class and fills it with the data fom the IDataRecord.
/// </summary>
private static Dientes FillDataRecord(IDataRecord myDataRecord )
{
Dientes myDientes = new Dientes();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myDientes.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idPersona")))
{
myDientes.idPersona = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idPersona"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idDiente")))
{
myDientes.idDiente = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idDiente"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Existe")))
{
myDientes.Existe = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("Existe"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FechaUltimaModificacion")))
{
myDientes.FechaUltimaModificacion = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("FechaUltimaModificacion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("UsuarioUltimaModificacion")))
{
myDientes.UsuarioUltimaModificacion = myDataRecord.GetString(myDataRecord.GetOrdinal("UsuarioUltimaModificacion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Baja")))
{
myDientes.Baja = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("Baja"));
}
return myDientes;
}
}

 } 
