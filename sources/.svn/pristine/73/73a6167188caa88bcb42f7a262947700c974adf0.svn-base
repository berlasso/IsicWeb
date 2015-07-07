using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The NNClaseSubtipoArmaDB class is responsible for interacting with the database to retrieve and store information
/// about NNClaseSubtipoArma objects.
/// </summary>
public partial class NNClaseSubtipoArmaDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of NNClaseSubtipoArma from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the NNClaseSubtipoArma in the database.</param>
/// <returns>An NNClaseSubtipoArma when the id was found in the database, or null otherwise.</returns>
public static NNClaseSubtipoArma GetItem(short id)
{
NNClaseSubtipoArma myNNClaseSubtipoArma = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseSubtipoArmaSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myNNClaseSubtipoArma = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myNNClaseSubtipoArma;
}
}

/// <summary>
/// Returns a list with NNClaseSubtipoArma objects.
/// </summary>
/// <returns>A generics List with the NNClaseSubtipoArma objects.</returns>
public static NNClaseSubtipoArmaList GetList()
{
NNClaseSubtipoArmaList tempList = new NNClaseSubtipoArmaList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseSubtipoArmaSelectList", myConnection))
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
/// Returns a list with NNClaseSubtipoArma objects.
/// </summary>
/// <returns>A generics List with the NNClaseSubtipoArma objects.</returns>
public static NNClaseSubtipoArmaList GetListByidClaseArma(int idClaseArma)
{
NNClaseSubtipoArmaList tempList = new NNClaseSubtipoArmaList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseSubtipoArmaSelectListByidClaseArma", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idClaseArma", idClaseArma);
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
/// Saves a NNClaseSubtipoArma in the database.
/// </summary>
/// <param name="myNNClaseSubtipoArma">The NNClaseSubtipoArma instance to save.</param>
/// <returns>The new id if the NNClaseSubtipoArma is new in the database or the existing id when an item was updated.</returns>
public static short Save(NNClaseSubtipoArma myNNClaseSubtipoArma)
{
short result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseSubtipoArmaInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myNNClaseSubtipoArma.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myNNClaseSubtipoArma.id);
}
if (string.IsNullOrEmpty(myNNClaseSubtipoArma.descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myNNClaseSubtipoArma.descripcion);
}
if (myNNClaseSubtipoArma.idClaseArma == null){
myCommand.Parameters.AddWithValue("@idClaseArma", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idClaseArma", myNNClaseSubtipoArma.idClaseArma);
}

DbParameter returnValue;
returnValue = myCommand.CreateParameter();
returnValue.Direction = ParameterDirection.ReturnValue;
myCommand.Parameters.Add(returnValue);

myConnection.Open();
myCommand.ExecuteNonQuery();
result = Convert.ToInt16(returnValue.Value);
myConnection.Close();
}
}
return result;
}

/// <summary>
/// Deletes a NNClaseSubtipoArma from the database.
/// </summary>
/// <param name="id">The id of the NNClaseSubtipoArma to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(short id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseSubtipoArmaDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the NNClaseSubtipoArma class and fills it with the data fom the IDataRecord.
/// </summary>
private static NNClaseSubtipoArma FillDataRecord(IDataRecord myDataRecord )
{
NNClaseSubtipoArma myNNClaseSubtipoArma = new NNClaseSubtipoArma();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myNNClaseSubtipoArma.id = myDataRecord.GetInt16(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
{
myNNClaseSubtipoArma.descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseArma")))
{
myNNClaseSubtipoArma.idClaseArma = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseArma"));
}
return myNNClaseSubtipoArma;
}
}

 } 
