using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The NNClaseSexoDB class is responsible for interacting with the database to retrieve and store information
/// about NNClaseSexo objects.
/// </summary>
public partial class NNClaseSexoDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of NNClaseSexo from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the NNClaseSexo in the database.</param>
/// <returns>An NNClaseSexo when the id was found in the database, or null otherwise.</returns>
public static NNClaseSexo GetItem(int id)
{
NNClaseSexo myNNClaseSexo = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseSexoSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myNNClaseSexo = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myNNClaseSexo;
}
}

/// <summary>
/// Returns a list with NNClaseSexo objects.
/// </summary>
/// <returns>A generics List with the NNClaseSexo objects.</returns>
public static NNClaseSexoList GetList()
{
NNClaseSexoList tempList = new NNClaseSexoList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseSexoSelectList", myConnection))
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
/// Saves a NNClaseSexo in the database.
/// </summary>
/// <param name="myNNClaseSexo">The NNClaseSexo instance to save.</param>
/// <returns>The new id if the NNClaseSexo is new in the database or the existing id when an item was updated.</returns>
public static int Save(NNClaseSexo myNNClaseSexo)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseSexoInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myNNClaseSexo.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myNNClaseSexo.id);
}
if (string.IsNullOrEmpty(myNNClaseSexo.descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myNNClaseSexo.descripcion);
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
/// Deletes a NNClaseSexo from the database.
/// </summary>
/// <param name="id">The id of the NNClaseSexo to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseSexoDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the NNClaseSexo class and fills it with the data fom the IDataRecord.
/// </summary>
private static NNClaseSexo FillDataRecord(IDataRecord myDataRecord )
{
NNClaseSexo myNNClaseSexo = new NNClaseSexo();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myNNClaseSexo.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
{
myNNClaseSexo.descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
}
return myNNClaseSexo;
}
}

 } 
