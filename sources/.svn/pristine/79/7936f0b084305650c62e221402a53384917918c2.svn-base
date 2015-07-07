using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The NNClaseCantidadAutoresDB class is responsible for interacting with the database to retrieve and store information
/// about NNClaseCantidadAutores objects.
/// </summary>
public partial class NNClaseCantidadAutoresDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of NNClaseCantidadAutores from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the NNClaseCantidadAutores in the database.</param>
/// <returns>An NNClaseCantidadAutores when the id was found in the database, or null otherwise.</returns>
public static NNClaseCantidadAutores GetItem(int id)
{
NNClaseCantidadAutores myNNClaseCantidadAutores = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseCantidadAutoresSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myNNClaseCantidadAutores = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myNNClaseCantidadAutores;
}
}

/// <summary>
/// Returns a list with NNClaseCantidadAutores objects.
/// </summary>
/// <returns>A generics List with the NNClaseCantidadAutores objects.</returns>
public static NNClaseCantidadAutoresList GetList()
{
NNClaseCantidadAutoresList tempList = new NNClaseCantidadAutoresList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseCantidadAutoresSelectList", myConnection))
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
/// Saves a NNClaseCantidadAutores in the database.
/// </summary>
/// <param name="myNNClaseCantidadAutores">The NNClaseCantidadAutores instance to save.</param>
/// <returns>The new id if the NNClaseCantidadAutores is new in the database or the existing id when an item was updated.</returns>
public static int Save(NNClaseCantidadAutores myNNClaseCantidadAutores)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseCantidadAutoresInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myNNClaseCantidadAutores.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myNNClaseCantidadAutores.id);
}
if (string.IsNullOrEmpty(myNNClaseCantidadAutores.descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myNNClaseCantidadAutores.descripcion);
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
/// Deletes a NNClaseCantidadAutores from the database.
/// </summary>
/// <param name="id">The id of the NNClaseCantidadAutores to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseCantidadAutoresDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the NNClaseCantidadAutores class and fills it with the data fom the IDataRecord.
/// </summary>
private static NNClaseCantidadAutores FillDataRecord(IDataRecord myDataRecord )
{
NNClaseCantidadAutores myNNClaseCantidadAutores = new NNClaseCantidadAutores();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myNNClaseCantidadAutores.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
{
myNNClaseCantidadAutores.descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
}
return myNNClaseCantidadAutores;
}
}

 } 
