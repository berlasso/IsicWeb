using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal
{
/// <summary>
/// The PermisoUsuarioDB class is responsible for interacting with the database to retrieve and store information
/// about PermisoUsuario objects.
/// </summary>
public partial class PermisoUsuarioDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of PermisoUsuario from the underlying datasource.
/// </summary>
/// <param name="id">The unique Id of the PermisoUsuario in the database.</param>
/// <returns>An PermisoUsuario when the Id was found in the database, or null otherwise.</returns>
public static PermisoUsuario GetItem(string id)
{
PermisoUsuario myPermisoUsuario = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PermisoUsuarioSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myPermisoUsuario = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myPermisoUsuario;
}
}

/// <summary>
/// Returns a list with PermisoUsuario objects.
/// </summary>
/// <returns>A generics List with the PermisoUsuario objects.</returns>
public static PermisoUsuarioList GetList()
{
PermisoUsuarioList tempList = new PermisoUsuarioList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PermisoUsuarioSelectList", myConnection))
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
/// Returns a list with PermisoUsuario objects.
/// </summary>
/// <returns>A generics List with the PermisoUsuario objects.</returns>
public static PermisoUsuarioList GetListByidRecurso(string idRecurso)
{
PermisoUsuarioList tempList = new PermisoUsuarioList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PermisoUsuarioSelectListByidRecurso", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idRecurso", idRecurso);
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
/// Returns a list with PermisoUsuario objects.
/// </summary>
/// <returns>A generics List with the PermisoUsuario objects.</returns>
public static PermisoUsuarioList GetListByidUsuario(string idUsuario)
{
PermisoUsuarioList tempList = new PermisoUsuarioList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PermisoUsuarioSelectListByidUsuario", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idUsuario", idUsuario);
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
/// Saves a PermisoUsuario in the database.
/// </summary>
/// <param name="myPermisoUsuario">The PermisoUsuario instance to save.</param>
/// <returns>The new Id if the PermisoUsuario is new in the database or the existing Id when an item was updated.</returns>
public static int Save(PermisoUsuario myPermisoUsuario)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PermisoUsuarioInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myPermisoUsuario.Id == null)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myPermisoUsuario.Id);
}
if (string.IsNullOrEmpty(myPermisoUsuario.idRecurso))
{
myCommand.Parameters.AddWithValue("@idRecurso", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idRecurso", myPermisoUsuario.idRecurso);
}
if (string.IsNullOrEmpty(myPermisoUsuario.idUsuario))
{
myCommand.Parameters.AddWithValue("@idUsuario", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idUsuario", myPermisoUsuario.idUsuario);
}
if (myPermisoUsuario.Lectura == null){
myCommand.Parameters.AddWithValue("@lectura", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@lectura", myPermisoUsuario.Lectura);
}
if (myPermisoUsuario.Escritura == null){
myCommand.Parameters.AddWithValue("@escritura", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@escritura", myPermisoUsuario.Escritura);
}
if (myPermisoUsuario.Creacion == null){
myCommand.Parameters.AddWithValue("@creacion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@creacion", myPermisoUsuario.Creacion);
}
if (myPermisoUsuario.Eliminacion == null){
myCommand.Parameters.AddWithValue("@eliminacion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@eliminacion", myPermisoUsuario.Eliminacion);
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
/// Deletes a PermisoUsuario from the database.
/// </summary>
/// <param name="id">The Id of the PermisoUsuario to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(string id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("PermisoUsuarioDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the PermisoUsuario class and fills it with the data fom the IDataRecord.
/// </summary>
private static PermisoUsuario FillDataRecord(IDataRecord myDataRecord )
{
PermisoUsuario myPermisoUsuario = new PermisoUsuario();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idRecurso")))
{
myPermisoUsuario.idRecurso = myDataRecord.GetString(myDataRecord.GetOrdinal("idRecurso"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idUsuario")))
{
myPermisoUsuario.idUsuario = myDataRecord.GetString(myDataRecord.GetOrdinal("idUsuario"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Lectura")))
{
myPermisoUsuario.Lectura = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("Lectura"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Escritura")))
{
myPermisoUsuario.Escritura = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("Escritura"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Creacion")))
{
myPermisoUsuario.Creacion = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("Creacion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Eliminacion")))
{
myPermisoUsuario.Eliminacion = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("Eliminacion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Id")))
{
myPermisoUsuario.Id = myDataRecord.GetString(myDataRecord.GetOrdinal("Id"));
}
return myPermisoUsuario;
}
}

 } 
