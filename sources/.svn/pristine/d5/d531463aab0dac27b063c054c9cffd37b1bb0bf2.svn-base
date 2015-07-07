using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The NNClaseDiametroArmaFuegoDB class is responsible for interacting with the database to retrieve and store information
/// about NNClaseDiametroArmaFuego objects.
/// </summary>
public partial class NNClaseDiametroArmaFuegoDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of NNClaseDiametroArmaFuego from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the NNClaseDiametroArmaFuego in the database.</param>
/// <returns>An NNClaseDiametroArmaFuego when the id was found in the database, or null otherwise.</returns>
public static NNClaseDiametroArmaFuego GetItem(int id)
{
NNClaseDiametroArmaFuego myNNClaseDiametroArmaFuego = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseDiametroArmaFuegoSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myNNClaseDiametroArmaFuego = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myNNClaseDiametroArmaFuego;
}
}

/// <summary>
/// Returns a list with NNClaseDiametroArmaFuego objects.
/// </summary>
/// <returns>A generics List with the NNClaseDiametroArmaFuego objects.</returns>
public static NNClaseDiametroArmaFuegoList GetList()
{
NNClaseDiametroArmaFuegoList tempList = new NNClaseDiametroArmaFuegoList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseDiametroArmaFuegoSelectList", myConnection))
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
/// Saves a NNClaseDiametroArmaFuego in the database.
/// </summary>
/// <param name="myNNClaseDiametroArmaFuego">The NNClaseDiametroArmaFuego instance to save.</param>
/// <returns>The new id if the NNClaseDiametroArmaFuego is new in the database or the existing id when an item was updated.</returns>
public static int Save(NNClaseDiametroArmaFuego myNNClaseDiametroArmaFuego)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseDiametroArmaFuegoInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myNNClaseDiametroArmaFuego.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myNNClaseDiametroArmaFuego.id);
}
if (string.IsNullOrEmpty(myNNClaseDiametroArmaFuego.descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myNNClaseDiametroArmaFuego.descripcion);
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
/// Deletes a NNClaseDiametroArmaFuego from the database.
/// </summary>
/// <param name="id">The id of the NNClaseDiametroArmaFuego to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseDiametroArmaFuegoDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the NNClaseDiametroArmaFuego class and fills it with the data fom the IDataRecord.
/// </summary>
private static NNClaseDiametroArmaFuego FillDataRecord(IDataRecord myDataRecord )
{
NNClaseDiametroArmaFuego myNNClaseDiametroArmaFuego = new NNClaseDiametroArmaFuego();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myNNClaseDiametroArmaFuego.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
{
myNNClaseDiametroArmaFuego.descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
}
return myNNClaseDiametroArmaFuego;
}
}

 } 
