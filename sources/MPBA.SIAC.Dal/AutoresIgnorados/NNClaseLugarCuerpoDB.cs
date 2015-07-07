using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The NNClaseLugarCuerpoDB class is responsible for interacting with the database to retrieve and store information
/// about NNClaseLugarCuerpo objects.
/// </summary>
public partial class NNClaseLugarCuerpoDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of NNClaseLugarCuerpo from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the NNClaseLugarCuerpo in the database.</param>
/// <returns>An NNClaseLugarCuerpo when the id was found in the database, or null otherwise.</returns>
public static NNClaseLugarCuerpo GetItem(int id)
{
NNClaseLugarCuerpo myNNClaseLugarCuerpo = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseLugarCuerpoSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myNNClaseLugarCuerpo = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myNNClaseLugarCuerpo;
}
}

/// <summary>
/// Returns a list with NNClaseLugarCuerpo objects.
/// </summary>
/// <returns>A generics List with the NNClaseLugarCuerpo objects.</returns>
public static NNClaseLugarCuerpoList GetList()
{
NNClaseLugarCuerpoList tempList = new NNClaseLugarCuerpoList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseLugarCuerpoSelectList", myConnection))
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
/// Saves a NNClaseLugarCuerpo in the database.
/// </summary>
/// <param name="myNNClaseLugarCuerpo">The NNClaseLugarCuerpo instance to save.</param>
/// <returns>The new id if the NNClaseLugarCuerpo is new in the database or the existing id when an item was updated.</returns>
public static int Save(NNClaseLugarCuerpo myNNClaseLugarCuerpo)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseLugarCuerpoInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myNNClaseLugarCuerpo.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myNNClaseLugarCuerpo.id);
}
if (string.IsNullOrEmpty(myNNClaseLugarCuerpo.descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myNNClaseLugarCuerpo.descripcion);
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
/// Deletes a NNClaseLugarCuerpo from the database.
/// </summary>
/// <param name="id">The id of the NNClaseLugarCuerpo to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseLugarCuerpoDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the NNClaseLugarCuerpo class and fills it with the data fom the IDataRecord.
/// </summary>
private static NNClaseLugarCuerpo FillDataRecord(IDataRecord myDataRecord )
{
NNClaseLugarCuerpo myNNClaseLugarCuerpo = new NNClaseLugarCuerpo();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myNNClaseLugarCuerpo.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
{
myNNClaseLugarCuerpo.descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
}
return myNNClaseLugarCuerpo;
}
}

 } 
