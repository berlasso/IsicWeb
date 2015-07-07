using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The NNClaseRostroDB class is responsible for interacting with the database to retrieve and store information
/// about NNClaseRostro objects.
/// </summary>
public partial class NNClaseRostroDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of NNClaseRostro from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the NNClaseRostro in the database.</param>
/// <returns>An NNClaseRostro when the id was found in the database, or null otherwise.</returns>
public static NNClaseRostro GetItem(int id)
{
NNClaseRostro myNNClaseRostro = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseRostroSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myNNClaseRostro = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myNNClaseRostro;
}
}

/// <summary>
/// Returns a list with NNClaseRostro objects.
/// </summary>
/// <returns>A generics List with the NNClaseRostro objects.</returns>
public static NNClaseRostroList GetList()
{
NNClaseRostroList tempList = new NNClaseRostroList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseRostroSelectList", myConnection))
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
/// Saves a NNClaseRostro in the database.
/// </summary>
/// <param name="myNNClaseRostro">The NNClaseRostro instance to save.</param>
/// <returns>The new id if the NNClaseRostro is new in the database or the existing id when an item was updated.</returns>
public static int Save(NNClaseRostro myNNClaseRostro)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseRostroInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myNNClaseRostro.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myNNClaseRostro.id);
}
if (string.IsNullOrEmpty(myNNClaseRostro.descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myNNClaseRostro.descripcion);
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
/// Deletes a NNClaseRostro from the database.
/// </summary>
/// <param name="id">The id of the NNClaseRostro to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseRostroDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the NNClaseRostro class and fills it with the data fom the IDataRecord.
/// </summary>
private static NNClaseRostro FillDataRecord(IDataRecord myDataRecord )
{
NNClaseRostro myNNClaseRostro = new NNClaseRostro();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myNNClaseRostro.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
{
myNNClaseRostro.descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
}
return myNNClaseRostro;
}
}

 } 
