using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The NNClaseAgresionDB class is responsible for interacting with the database to retrieve and store information
/// about NNClaseAgresion objects.
/// </summary>
public partial class NNClaseAgresionDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of NNClaseAgresion from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the NNClaseAgresion in the database.</param>
/// <returns>An NNClaseAgresion when the id was found in the database, or null otherwise.</returns>
public static NNClaseAgresion GetItem(int id)
{
NNClaseAgresion myNNClaseAgresion = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseAgresionSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myNNClaseAgresion = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myNNClaseAgresion;
}
}

/// <summary>
/// Returns a list with NNClaseAgresion objects.
/// </summary>
/// <returns>A generics List with the NNClaseAgresion objects.</returns>
public static NNClaseAgresionList GetList()
{
NNClaseAgresionList tempList = new NNClaseAgresionList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseAgresionSelectList", myConnection))
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
/// Saves a NNClaseAgresion in the database.
/// </summary>
/// <param name="myNNClaseAgresion">The NNClaseAgresion instance to save.</param>
/// <returns>The new id if the NNClaseAgresion is new in the database or the existing id when an item was updated.</returns>
public static int Save(NNClaseAgresion myNNClaseAgresion)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseAgresionInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myNNClaseAgresion.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myNNClaseAgresion.id);
}
if (string.IsNullOrEmpty(myNNClaseAgresion.descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myNNClaseAgresion.descripcion);
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
/// Deletes a NNClaseAgresion from the database.
/// </summary>
/// <param name="id">The id of the NNClaseAgresion to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseAgresionDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the NNClaseAgresion class and fills it with the data fom the IDataRecord.
/// </summary>
private static NNClaseAgresion FillDataRecord(IDataRecord myDataRecord )
{
NNClaseAgresion myNNClaseAgresion = new NNClaseAgresion();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myNNClaseAgresion.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
{
myNNClaseAgresion.descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
}
return myNNClaseAgresion;
}
}

 } 
