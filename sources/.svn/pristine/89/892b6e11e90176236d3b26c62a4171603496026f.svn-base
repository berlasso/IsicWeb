using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The NNClaseMonedaDB class is responsible for interacting with the database to retrieve and store information
/// about NNClaseMoneda objects.
/// </summary>
public partial class NNClaseMonedaDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of NNClaseMoneda from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the NNClaseMoneda in the database.</param>
/// <returns>An NNClaseMoneda when the id was found in the database, or null otherwise.</returns>
public static NNClaseMoneda GetItem(int id)
{
NNClaseMoneda myNNClaseMoneda = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseMonedaSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myNNClaseMoneda = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myNNClaseMoneda;
}
}

/// <summary>
/// Returns a list with NNClaseMoneda objects.
/// </summary>
/// <returns>A generics List with the NNClaseMoneda objects.</returns>
public static NNClaseMonedaList GetList()
{
NNClaseMonedaList tempList = new NNClaseMonedaList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseMonedaSelectList", myConnection))
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
/// Saves a NNClaseMoneda in the database.
/// </summary>
/// <param name="myNNClaseMoneda">The NNClaseMoneda instance to save.</param>
/// <returns>The new id if the NNClaseMoneda is new in the database or the existing id when an item was updated.</returns>
public static int Save(NNClaseMoneda myNNClaseMoneda)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseMonedaInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myNNClaseMoneda.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myNNClaseMoneda.id);
}
if (string.IsNullOrEmpty(myNNClaseMoneda.descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myNNClaseMoneda.descripcion);
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
/// Deletes a NNClaseMoneda from the database.
/// </summary>
/// <param name="id">The id of the NNClaseMoneda to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseMonedaDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the NNClaseMoneda class and fills it with the data fom the IDataRecord.
/// </summary>
private static NNClaseMoneda FillDataRecord(IDataRecord myDataRecord )
{
NNClaseMoneda myNNClaseMoneda = new NNClaseMoneda();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myNNClaseMoneda.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
{
myNNClaseMoneda.descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
}
return myNNClaseMoneda;
}
}

 } 
