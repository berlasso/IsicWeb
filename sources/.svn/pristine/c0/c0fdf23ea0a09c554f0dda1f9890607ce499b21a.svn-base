using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The NNClaseModusOperandiDB class is responsible for interacting with the database to retrieve and store information
/// about NNClaseModusOperandi objects.
/// </summary>
public partial class NNClaseModusOperandiDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of NNClaseModusOperandi from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the NNClaseModusOperandi in the database.</param>
/// <returns>An NNClaseModusOperandi when the id was found in the database, or null otherwise.</returns>
public static NNClaseModusOperandi GetItem(int id)
{
NNClaseModusOperandi myNNClaseModusOperandi = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseModusOperandiSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myNNClaseModusOperandi = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myNNClaseModusOperandi;
}
}

/// <summary>
/// Returns a list with NNClaseModusOperandi objects.
/// </summary>
/// <returns>A generics List with the NNClaseModusOperandi objects.</returns>
public static NNClaseModusOperandiList GetList()
{
NNClaseModusOperandiList tempList = new NNClaseModusOperandiList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseModusOperandiSelectList", myConnection))
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
/// Saves a NNClaseModusOperandi in the database.
/// </summary>
/// <param name="myNNClaseModusOperandi">The NNClaseModusOperandi instance to save.</param>
/// <returns>The new id if the NNClaseModusOperandi is new in the database or the existing id when an item was updated.</returns>
public static int Save(NNClaseModusOperandi myNNClaseModusOperandi)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseModusOperandiInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myNNClaseModusOperandi.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myNNClaseModusOperandi.id);
}
if (string.IsNullOrEmpty(myNNClaseModusOperandi.descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myNNClaseModusOperandi.descripcion);
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
/// Deletes a NNClaseModusOperandi from the database.
/// </summary>
/// <param name="id">The id of the NNClaseModusOperandi to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseModusOperandiDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the NNClaseModusOperandi class and fills it with the data fom the IDataRecord.
/// </summary>
private static NNClaseModusOperandi FillDataRecord(IDataRecord myDataRecord )
{
NNClaseModusOperandi myNNClaseModusOperandi = new NNClaseModusOperandi();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myNNClaseModusOperandi.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
{
myNNClaseModusOperandi.descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
}
return myNNClaseModusOperandi;
}
}

 } 
