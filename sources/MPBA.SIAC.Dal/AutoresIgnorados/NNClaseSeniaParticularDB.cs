using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The NNClaseSeniaParticularDB class is responsible for interacting with the database to retrieve and store information
/// about NNClaseSeniaParticular objects.
/// </summary>
public partial class NNClaseSeniaParticularDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of NNClaseSeniaParticular from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the NNClaseSeniaParticular in the database.</param>
/// <returns>An NNClaseSeniaParticular when the id was found in the database, or null otherwise.</returns>
public static NNClaseSeniaParticular GetItem(int id)
{
NNClaseSeniaParticular myNNClaseSeniaParticular = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseSeniaParticularSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myNNClaseSeniaParticular = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myNNClaseSeniaParticular;
}
}

/// <summary>
/// Returns a list with NNClaseSeniaParticular objects.
/// </summary>
/// <returns>A generics List with the NNClaseSeniaParticular objects.</returns>
public static NNClaseSeniaParticularList GetList()
{
NNClaseSeniaParticularList tempList = new NNClaseSeniaParticularList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseSeniaParticularSelectList", myConnection))
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
/// Saves a NNClaseSeniaParticular in the database.
/// </summary>
/// <param name="myNNClaseSeniaParticular">The NNClaseSeniaParticular instance to save.</param>
/// <returns>The new id if the NNClaseSeniaParticular is new in the database or the existing id when an item was updated.</returns>
public static int Save(NNClaseSeniaParticular myNNClaseSeniaParticular)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseSeniaParticularInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myNNClaseSeniaParticular.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myNNClaseSeniaParticular.id);
}
if (string.IsNullOrEmpty(myNNClaseSeniaParticular.descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myNNClaseSeniaParticular.descripcion);
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
/// Deletes a NNClaseSeniaParticular from the database.
/// </summary>
/// <param name="id">The id of the NNClaseSeniaParticular to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseSeniaParticularDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the NNClaseSeniaParticular class and fills it with the data fom the IDataRecord.
/// </summary>
private static NNClaseSeniaParticular FillDataRecord(IDataRecord myDataRecord )
{
NNClaseSeniaParticular myNNClaseSeniaParticular = new NNClaseSeniaParticular();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myNNClaseSeniaParticular.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
{
myNNClaseSeniaParticular.descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
}
return myNNClaseSeniaParticular;
}
}

 } 
