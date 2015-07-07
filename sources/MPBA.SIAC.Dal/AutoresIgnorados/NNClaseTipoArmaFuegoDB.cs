using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The NNClaseTipoArmaFuegoDB class is responsible for interacting with the database to retrieve and store information
/// about NNClaseTipoArmaFuego objects.
/// </summary>
public partial class NNClaseTipoArmaFuegoDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of NNClaseTipoArmaFuego from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the NNClaseTipoArmaFuego in the database.</param>
/// <returns>An NNClaseTipoArmaFuego when the id was found in the database, or null otherwise.</returns>
public static NNClaseTipoArmaFuego GetItem(int id)
{
NNClaseTipoArmaFuego myNNClaseTipoArmaFuego = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseTipoArmaFuegoSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myNNClaseTipoArmaFuego = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myNNClaseTipoArmaFuego;
}
}

/// <summary>
/// Returns a list with NNClaseTipoArmaFuego objects.
/// </summary>
/// <returns>A generics List with the NNClaseTipoArmaFuego objects.</returns>
public static NNClaseTipoArmaFuegoList GetList()
{
NNClaseTipoArmaFuegoList tempList = new NNClaseTipoArmaFuegoList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseTipoArmaFuegoSelectList", myConnection))
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
/// Saves a NNClaseTipoArmaFuego in the database.
/// </summary>
/// <param name="myNNClaseTipoArmaFuego">The NNClaseTipoArmaFuego instance to save.</param>
/// <returns>The new id if the NNClaseTipoArmaFuego is new in the database or the existing id when an item was updated.</returns>
public static int Save(NNClaseTipoArmaFuego myNNClaseTipoArmaFuego)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseTipoArmaFuegoInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myNNClaseTipoArmaFuego.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myNNClaseTipoArmaFuego.id);
}
if (string.IsNullOrEmpty(myNNClaseTipoArmaFuego.descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myNNClaseTipoArmaFuego.descripcion);
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
/// Deletes a NNClaseTipoArmaFuego from the database.
/// </summary>
/// <param name="id">The id of the NNClaseTipoArmaFuego to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseTipoArmaFuegoDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the NNClaseTipoArmaFuego class and fills it with the data fom the IDataRecord.
/// </summary>
private static NNClaseTipoArmaFuego FillDataRecord(IDataRecord myDataRecord )
{
NNClaseTipoArmaFuego myNNClaseTipoArmaFuego = new NNClaseTipoArmaFuego();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myNNClaseTipoArmaFuego.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
{
myNNClaseTipoArmaFuego.descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
}
return myNNClaseTipoArmaFuego;
}
}

 } 
