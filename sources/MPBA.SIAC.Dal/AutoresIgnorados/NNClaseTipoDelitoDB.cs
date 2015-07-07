using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The NNClaseTipoDelitoDB class is responsible for interacting with the database to retrieve and store information
/// about NNClaseTipoDelito objects.
/// </summary>
public partial class NNClaseTipoDelitoDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of NNClaseTipoDelito from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the NNClaseTipoDelito in the database.</param>
/// <returns>An NNClaseTipoDelito when the id was found in the database, or null otherwise.</returns>
public static NNClaseTipoDelito GetItem(int id)
{
NNClaseTipoDelito myNNClaseTipoDelito = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseTipoDelitoSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myNNClaseTipoDelito = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myNNClaseTipoDelito;
}
}

/// <summary>
/// Returns a list with NNClaseTipoDelito objects.
/// </summary>
/// <returns>A generics List with the NNClaseTipoDelito objects.</returns>
public static NNClaseTipoDelitoList GetList()
{
NNClaseTipoDelitoList tempList = new NNClaseTipoDelitoList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseTipoDelitoSelectList", myConnection))
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
/// Saves a NNClaseTipoDelito in the database.
/// </summary>
/// <param name="myNNClaseTipoDelito">The NNClaseTipoDelito instance to save.</param>
/// <returns>The new id if the NNClaseTipoDelito is new in the database or the existing id when an item was updated.</returns>
public static int Save(NNClaseTipoDelito myNNClaseTipoDelito)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseTipoDelitoInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myNNClaseTipoDelito.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myNNClaseTipoDelito.id);
}
if (string.IsNullOrEmpty(myNNClaseTipoDelito.descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myNNClaseTipoDelito.descripcion);
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
/// Deletes a NNClaseTipoDelito from the database.
/// </summary>
/// <param name="id">The id of the NNClaseTipoDelito to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseTipoDelitoDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the NNClaseTipoDelito class and fills it with the data fom the IDataRecord.
/// </summary>
private static NNClaseTipoDelito FillDataRecord(IDataRecord myDataRecord )
{
NNClaseTipoDelito myNNClaseTipoDelito = new NNClaseTipoDelito();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myNNClaseTipoDelito.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
{
myNNClaseTipoDelito.descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
}
return myNNClaseTipoDelito;
}
}

 } 
