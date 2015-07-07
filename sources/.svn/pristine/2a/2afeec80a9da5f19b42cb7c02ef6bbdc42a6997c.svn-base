using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The NNClaseCantVictTestRecRuedaDB class is responsible for interacting with the database to retrieve and store information
/// about NNClaseCantVictTestRecRueda objects.
/// </summary>
public partial class NNClaseCantVictTestRecRuedaDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of NNClaseCantVictTestRecRueda from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the NNClaseCantVictTestRecRueda in the database.</param>
/// <returns>An NNClaseCantVictTestRecRueda when the id was found in the database, or null otherwise.</returns>
public static NNClaseCantVictTestRecRueda GetItem(int id)
{
NNClaseCantVictTestRecRueda myNNClaseCantVictTestRecRueda = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseCantVictTestRecRuedaSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myNNClaseCantVictTestRecRueda = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myNNClaseCantVictTestRecRueda;
}
}

/// <summary>
/// Returns a list with NNClaseCantVictTestRecRueda objects.
/// </summary>
/// <returns>A generics List with the NNClaseCantVictTestRecRueda objects.</returns>
public static NNClaseCantVictTestRecRuedaList GetList()
{
NNClaseCantVictTestRecRuedaList tempList = new NNClaseCantVictTestRecRuedaList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseCantVictTestRecRuedaSelectList", myConnection))
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
/// Saves a NNClaseCantVictTestRecRueda in the database.
/// </summary>
/// <param name="myNNClaseCantVictTestRecRueda">The NNClaseCantVictTestRecRueda instance to save.</param>
/// <returns>The new id if the NNClaseCantVictTestRecRueda is new in the database or the existing id when an item was updated.</returns>
public static int Save(NNClaseCantVictTestRecRueda myNNClaseCantVictTestRecRueda)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseCantVictTestRecRuedaInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myNNClaseCantVictTestRecRueda.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myNNClaseCantVictTestRecRueda.id);
}
if (string.IsNullOrEmpty(myNNClaseCantVictTestRecRueda.descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myNNClaseCantVictTestRecRueda.descripcion);
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
/// Deletes a NNClaseCantVictTestRecRueda from the database.
/// </summary>
/// <param name="id">The id of the NNClaseCantVictTestRecRueda to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseCantVictTestRecRuedaDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the NNClaseCantVictTestRecRueda class and fills it with the data fom the IDataRecord.
/// </summary>
private static NNClaseCantVictTestRecRueda FillDataRecord(IDataRecord myDataRecord )
{
NNClaseCantVictTestRecRueda myNNClaseCantVictTestRecRueda = new NNClaseCantVictTestRecRueda();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myNNClaseCantVictTestRecRueda.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
{
myNNClaseCantVictTestRecRueda.descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
}
return myNNClaseCantVictTestRecRueda;
}
}

 } 
