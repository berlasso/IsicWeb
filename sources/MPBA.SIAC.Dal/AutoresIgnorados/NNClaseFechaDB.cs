using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The NNClaseFechaDB class is responsible for interacting with the database to retrieve and store information
/// about NNClaseFecha objects.
/// </summary>
public partial class NNClaseFechaDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of NNClaseFecha from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the NNClaseFecha in the database.</param>
/// <returns>An NNClaseFecha when the id was found in the database, or null otherwise.</returns>
public static NNClaseFecha GetItem(int id)
{
NNClaseFecha myNNClaseFecha = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseFechaSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myNNClaseFecha = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myNNClaseFecha;
}
}

/// <summary>
/// Returns a list with NNClaseFecha objects.
/// </summary>
/// <returns>A generics List with the NNClaseFecha objects.</returns>
public static NNClaseFechaList GetList()
{
NNClaseFechaList tempList = new NNClaseFechaList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseFechaSelectList", myConnection))
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
/// Saves a NNClaseFecha in the database.
/// </summary>
/// <param name="myNNClaseFecha">The NNClaseFecha instance to save.</param>
/// <returns>The new id if the NNClaseFecha is new in the database or the existing id when an item was updated.</returns>
public static int Save(NNClaseFecha myNNClaseFecha)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseFechaInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myNNClaseFecha.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myNNClaseFecha.id);
}
if (string.IsNullOrEmpty(myNNClaseFecha.descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myNNClaseFecha.descripcion);
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
/// Deletes a NNClaseFecha from the database.
/// </summary>
/// <param name="id">The id of the NNClaseFecha to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseFechaDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the NNClaseFecha class and fills it with the data fom the IDataRecord.
/// </summary>
private static NNClaseFecha FillDataRecord(IDataRecord myDataRecord )
{
NNClaseFecha myNNClaseFecha = new NNClaseFecha();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myNNClaseFecha.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
{
myNNClaseFecha.descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
}
return myNNClaseFecha;
}
}

 } 
