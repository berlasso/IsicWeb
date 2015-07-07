using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The NNClaseMomentoDiaDB class is responsible for interacting with the database to retrieve and store information
/// about NNClaseMomentoDia objects.
/// </summary>
public partial class NNClaseMomentoDiaDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of NNClaseMomentoDia from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the NNClaseMomentoDia in the database.</param>
/// <returns>An NNClaseMomentoDia when the id was found in the database, or null otherwise.</returns>
public static NNClaseMomentoDia GetItem(int id)
{
NNClaseMomentoDia myNNClaseMomentoDia = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseMomentoDiaSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myNNClaseMomentoDia = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myNNClaseMomentoDia;
}
}

/// <summary>
/// Returns a list with NNClaseMomentoDia objects.
/// </summary>
/// <returns>A generics List with the NNClaseMomentoDia objects.</returns>
public static NNClaseMomentoDiaList GetList()
{
NNClaseMomentoDiaList tempList = new NNClaseMomentoDiaList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseMomentoDiaSelectList", myConnection))
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
/// Saves a NNClaseMomentoDia in the database.
/// </summary>
/// <param name="myNNClaseMomentoDia">The NNClaseMomentoDia instance to save.</param>
/// <returns>The new id if the NNClaseMomentoDia is new in the database or the existing id when an item was updated.</returns>
public static int Save(NNClaseMomentoDia myNNClaseMomentoDia)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseMomentoDiaInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myNNClaseMomentoDia.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myNNClaseMomentoDia.id);
}
if (string.IsNullOrEmpty(myNNClaseMomentoDia.descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myNNClaseMomentoDia.descripcion);
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
/// Deletes a NNClaseMomentoDia from the database.
/// </summary>
/// <param name="id">The id of the NNClaseMomentoDia to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseMomentoDiaDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the NNClaseMomentoDia class and fills it with the data fom the IDataRecord.
/// </summary>
private static NNClaseMomentoDia FillDataRecord(IDataRecord myDataRecord )
{
NNClaseMomentoDia myNNClaseMomentoDia = new NNClaseMomentoDia();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myNNClaseMomentoDia.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
{
myNNClaseMomentoDia.descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
}
return myNNClaseMomentoDia;
}
}

 } 
