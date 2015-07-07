using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The NNClaseTatuajeDB class is responsible for interacting with the database to retrieve and store information
/// about NNClaseTatuaje objects.
/// </summary>
public partial class NNClaseTatuajeDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of NNClaseTatuaje from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the NNClaseTatuaje in the database.</param>
/// <returns>An NNClaseTatuaje when the id was found in the database, or null otherwise.</returns>
public static NNClaseTatuaje GetItem(int id)
{
NNClaseTatuaje myNNClaseTatuaje = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseTatuajeSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myNNClaseTatuaje = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myNNClaseTatuaje;
}
}

/// <summary>
/// Returns a list with NNClaseTatuaje objects.
/// </summary>
/// <returns>A generics List with the NNClaseTatuaje objects.</returns>
public static NNClaseTatuajeList GetList()
{
NNClaseTatuajeList tempList = new NNClaseTatuajeList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseTatuajeSelectList", myConnection))
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
/// Saves a NNClaseTatuaje in the database.
/// </summary>
/// <param name="myNNClaseTatuaje">The NNClaseTatuaje instance to save.</param>
/// <returns>The new id if the NNClaseTatuaje is new in the database or the existing id when an item was updated.</returns>
public static int Save(NNClaseTatuaje myNNClaseTatuaje)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseTatuajeInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myNNClaseTatuaje.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myNNClaseTatuaje.id);
}
if (string.IsNullOrEmpty(myNNClaseTatuaje.descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myNNClaseTatuaje.descripcion);
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
/// Deletes a NNClaseTatuaje from the database.
/// </summary>
/// <param name="id">The id of the NNClaseTatuaje to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseTatuajeDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the NNClaseTatuaje class and fills it with the data fom the IDataRecord.
/// </summary>
private static NNClaseTatuaje FillDataRecord(IDataRecord myDataRecord )
{
NNClaseTatuaje myNNClaseTatuaje = new NNClaseTatuaje();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myNNClaseTatuaje.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
{
myNNClaseTatuaje.descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
}
return myNNClaseTatuaje;
}
}

 } 
