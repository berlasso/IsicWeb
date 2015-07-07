using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The NNClaseRastroDB class is responsible for interacting with the database to retrieve and store information
/// about NNClaseRastro objects.
/// </summary>
public partial class NNClaseRastroDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of NNClaseRastro from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the NNClaseRastro in the database.</param>
/// <returns>An NNClaseRastro when the id was found in the database, or null otherwise.</returns>
public static NNClaseRastro GetItem(int id)
{
NNClaseRastro myNNClaseRastro = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseRastroSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myNNClaseRastro = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myNNClaseRastro;
}
}

/// <summary>
/// Returns a list with NNClaseRastro objects.
/// </summary>
/// <returns>A generics List with the NNClaseRastro objects.</returns>
public static NNClaseRastroList GetList()
{
NNClaseRastroList tempList = new NNClaseRastroList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseRastroSelectList", myConnection))
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
/// Saves a NNClaseRastro in the database.
/// </summary>
/// <param name="myNNClaseRastro">The NNClaseRastro instance to save.</param>
/// <returns>The new id if the NNClaseRastro is new in the database or the existing id when an item was updated.</returns>
public static int Save(NNClaseRastro myNNClaseRastro)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseRastroInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myNNClaseRastro.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myNNClaseRastro.id);
}
if (string.IsNullOrEmpty(myNNClaseRastro.descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myNNClaseRastro.descripcion);
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
/// Deletes a NNClaseRastro from the database.
/// </summary>
/// <param name="id">The id of the NNClaseRastro to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseRastroDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the NNClaseRastro class and fills it with the data fom the IDataRecord.
/// </summary>
private static NNClaseRastro FillDataRecord(IDataRecord myDataRecord )
{
NNClaseRastro myNNClaseRastro = new NNClaseRastro();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myNNClaseRastro.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
{
myNNClaseRastro.descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
}
return myNNClaseRastro;
}
}

 } 
