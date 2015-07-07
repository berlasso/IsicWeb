using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The NNClaseCondicionVictimaDB class is responsible for interacting with the database to retrieve and store information
/// about NNClaseCondicionVictima objects.
/// </summary>
public partial class NNClaseCondicionVictimaDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of NNClaseCondicionVictima from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the NNClaseCondicionVictima in the database.</param>
/// <returns>An NNClaseCondicionVictima when the id was found in the database, or null otherwise.</returns>
public static NNClaseCondicionVictima GetItem(int id)
{
NNClaseCondicionVictima myNNClaseCondicionVictima = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseCondicionVictimaSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myNNClaseCondicionVictima = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myNNClaseCondicionVictima;
}
}

/// <summary>
/// Returns a list with NNClaseCondicionVictima objects.
/// </summary>
/// <returns>A generics List with the NNClaseCondicionVictima objects.</returns>
public static NNClaseCondicionVictimaList GetList()
{
NNClaseCondicionVictimaList tempList = new NNClaseCondicionVictimaList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseCondicionVictimaSelectList", myConnection))
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
/// Saves a NNClaseCondicionVictima in the database.
/// </summary>
/// <param name="myNNClaseCondicionVictima">The NNClaseCondicionVictima instance to save.</param>
/// <returns>The new id if the NNClaseCondicionVictima is new in the database or the existing id when an item was updated.</returns>
public static int Save(NNClaseCondicionVictima myNNClaseCondicionVictima)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseCondicionVictimaInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myNNClaseCondicionVictima.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myNNClaseCondicionVictima.id);
}
if (string.IsNullOrEmpty(myNNClaseCondicionVictima.descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myNNClaseCondicionVictima.descripcion);
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
/// Deletes a NNClaseCondicionVictima from the database.
/// </summary>
/// <param name="id">The id of the NNClaseCondicionVictima to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseCondicionVictimaDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the NNClaseCondicionVictima class and fills it with the data fom the IDataRecord.
/// </summary>
private static NNClaseCondicionVictima FillDataRecord(IDataRecord myDataRecord )
{
NNClaseCondicionVictima myNNClaseCondicionVictima = new NNClaseCondicionVictima();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myNNClaseCondicionVictima.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
{
myNNClaseCondicionVictima.descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
}
return myNNClaseCondicionVictima;
}
}

 } 
