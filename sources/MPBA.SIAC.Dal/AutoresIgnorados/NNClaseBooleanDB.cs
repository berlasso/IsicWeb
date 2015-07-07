using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The NNClaseBooleanDB class is responsible for interacting with the database to retrieve and store information
/// about NNClaseBoolean objects.
/// </summary>
public partial class NNClaseBooleanDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of NNClaseBoolean from the underlying datasource.
/// </summary>
/// <param name="id">The unique Id of the NNClaseBoolean in the database.</param>
/// <returns>An NNClaseBoolean when the Id was found in the database, or null otherwise.</returns>
public static NNClaseBoolean GetItem(int id)
{
NNClaseBoolean myNNClaseBoolean = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseBooleanSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myNNClaseBoolean = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myNNClaseBoolean;
}
}

/// <summary>
/// Returns a list with NNClaseBoolean objects.
/// </summary>
/// <returns>A generics List with the NNClaseBoolean objects.</returns>
public static NNClaseBooleanList GetList()
{
NNClaseBooleanList tempList = new NNClaseBooleanList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseBooleanSelectList", myConnection))
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
/// Saves a NNClaseBoolean in the database.
/// </summary>
/// <param name="myNNClaseBoolean">The NNClaseBoolean instance to save.</param>
/// <returns>The new Id if the NNClaseBoolean is new in the database or the existing Id when an item was updated.</returns>
public static int Save(NNClaseBoolean myNNClaseBoolean)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseBooleanInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myNNClaseBoolean.Id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myNNClaseBoolean.Id);
}
if (string.IsNullOrEmpty(myNNClaseBoolean.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myNNClaseBoolean.Descripcion);
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
/// Deletes a NNClaseBoolean from the database.
/// </summary>
/// <param name="id">The Id of the NNClaseBoolean to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseBooleanDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the NNClaseBoolean class and fills it with the data fom the IDataRecord.
/// </summary>
private static NNClaseBoolean FillDataRecord(IDataRecord myDataRecord )
{
NNClaseBoolean myNNClaseBoolean = new NNClaseBoolean();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Id")))
{
myNNClaseBoolean.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
myNNClaseBoolean.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
return myNNClaseBoolean;
}
}

 } 
