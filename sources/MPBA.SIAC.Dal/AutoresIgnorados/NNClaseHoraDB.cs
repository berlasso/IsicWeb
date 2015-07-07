using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The NNClaseHoraDB class is responsible for interacting with the database to retrieve and store information
/// about NNClaseHora objects.
/// </summary>
public partial class NNClaseHoraDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of NNClaseHora from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the NNClaseHora in the database.</param>
/// <returns>An NNClaseHora when the id was found in the database, or null otherwise.</returns>
public static NNClaseHora GetItem(int id)
{
NNClaseHora myNNClaseHora = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseHoraSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myNNClaseHora = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myNNClaseHora;
}
}

/// <summary>
/// Returns a list with NNClaseHora objects.
/// </summary>
/// <returns>A generics List with the NNClaseHora objects.</returns>
public static NNClaseHoraList GetList()
{
NNClaseHoraList tempList = new NNClaseHoraList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseHoraSelectList", myConnection))
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
/// Saves a NNClaseHora in the database.
/// </summary>
/// <param name="myNNClaseHora">The NNClaseHora instance to save.</param>
/// <returns>The new id if the NNClaseHora is new in the database or the existing id when an item was updated.</returns>
public static int Save(NNClaseHora myNNClaseHora)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseHoraInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myNNClaseHora.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myNNClaseHora.id);
}
if (string.IsNullOrEmpty(myNNClaseHora.descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myNNClaseHora.descripcion);
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
/// Deletes a NNClaseHora from the database.
/// </summary>
/// <param name="id">The id of the NNClaseHora to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseHoraDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the NNClaseHora class and fills it with the data fom the IDataRecord.
/// </summary>
private static NNClaseHora FillDataRecord(IDataRecord myDataRecord )
{
NNClaseHora myNNClaseHora = new NNClaseHora();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myNNClaseHora.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
{
myNNClaseHora.descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
}
return myNNClaseHora;
}
}

 } 
