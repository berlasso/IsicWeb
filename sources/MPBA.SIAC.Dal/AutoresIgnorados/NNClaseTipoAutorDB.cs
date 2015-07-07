using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The NNClaseTipoAutorDB class is responsible for interacting with the database to retrieve and store information
/// about NNClaseTipoAutor objects.
/// </summary>
public partial class NNClaseTipoAutorDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of NNClaseTipoAutor from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the NNClaseTipoAutor in the database.</param>
/// <returns>An NNClaseTipoAutor when the id was found in the database, or null otherwise.</returns>
public static NNClaseTipoAutor GetItem(int id)
{
NNClaseTipoAutor myNNClaseTipoAutor = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseTipoAutorSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myNNClaseTipoAutor = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myNNClaseTipoAutor;
}
}

/// <summary>
/// Returns a list with NNClaseTipoAutor objects.
/// </summary>
/// <returns>A generics List with the NNClaseTipoAutor objects.</returns>
public static NNClaseTipoAutorList GetList()
{
NNClaseTipoAutorList tempList = new NNClaseTipoAutorList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseTipoAutorSelectList", myConnection))
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
/// Saves a NNClaseTipoAutor in the database.
/// </summary>
/// <param name="myNNClaseTipoAutor">The NNClaseTipoAutor instance to save.</param>
/// <returns>The new id if the NNClaseTipoAutor is new in the database or the existing id when an item was updated.</returns>
public static int Save(NNClaseTipoAutor myNNClaseTipoAutor)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseTipoAutorInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myNNClaseTipoAutor.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myNNClaseTipoAutor.id);
}
if (string.IsNullOrEmpty(myNNClaseTipoAutor.descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myNNClaseTipoAutor.descripcion);
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
/// Deletes a NNClaseTipoAutor from the database.
/// </summary>
/// <param name="id">The id of the NNClaseTipoAutor to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseTipoAutorDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the NNClaseTipoAutor class and fills it with the data fom the IDataRecord.
/// </summary>
private static NNClaseTipoAutor FillDataRecord(IDataRecord myDataRecord )
{
NNClaseTipoAutor myNNClaseTipoAutor = new NNClaseTipoAutor();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myNNClaseTipoAutor.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
{
myNNClaseTipoAutor.descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
}
return myNNClaseTipoAutor;
}
}

 } 
