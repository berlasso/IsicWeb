using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The NNClaseLugarDB class is responsible for interacting with the database to retrieve and store information
/// about NNClaseLugar objects.
/// </summary>
public partial class NNClaseLugarDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of NNClaseLugar from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the NNClaseLugar in the database.</param>
/// <returns>An NNClaseLugar when the id was found in the database, or null otherwise.</returns>
public static NNClaseLugar GetItem(int id)
{
NNClaseLugar myNNClaseLugar = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseLugarSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myNNClaseLugar = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myNNClaseLugar;
}
}

/// <summary>
/// Returns a list with NNClaseLugar objects.
/// </summary>
/// <returns>A generics List with the NNClaseLugar objects.</returns>
public static NNClaseLugarList GetList()
{
NNClaseLugarList tempList = new NNClaseLugarList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseLugarSelectList", myConnection))
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
/// Saves a NNClaseLugar in the database.
/// </summary>
/// <param name="myNNClaseLugar">The NNClaseLugar instance to save.</param>
/// <returns>The new id if the NNClaseLugar is new in the database or the existing id when an item was updated.</returns>
public static int Save(NNClaseLugar myNNClaseLugar)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseLugarInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myNNClaseLugar.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myNNClaseLugar.id);
}
if (string.IsNullOrEmpty(myNNClaseLugar.descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myNNClaseLugar.descripcion);
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
/// Deletes a NNClaseLugar from the database.
/// </summary>
/// <param name="id">The id of the NNClaseLugar to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseLugarDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the NNClaseLugar class and fills it with the data fom the IDataRecord.
/// </summary>
private static NNClaseLugar FillDataRecord(IDataRecord myDataRecord )
{
NNClaseLugar myNNClaseLugar = new NNClaseLugar();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myNNClaseLugar.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
{
myNNClaseLugar.descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
}
return myNNClaseLugar;
}
}

 } 
