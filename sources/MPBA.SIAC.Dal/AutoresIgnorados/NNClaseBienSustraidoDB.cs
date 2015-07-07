using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The NNClaseBienSustraidoDB class is responsible for interacting with the database to retrieve and store information
/// about NNClaseBienSustraido objects.
/// </summary>
public partial class NNClaseBienSustraidoDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of NNClaseBienSustraido from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the NNClaseBienSustraido in the database.</param>
/// <returns>An NNClaseBienSustraido when the id was found in the database, or null otherwise.</returns>
public static NNClaseBienSustraido GetItem(int id)
{
NNClaseBienSustraido myNNClaseBienSustraido = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseBienSustraidoSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myNNClaseBienSustraido = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myNNClaseBienSustraido;
}
}

/// <summary>
/// Returns a list with NNClaseBienSustraido objects.
/// </summary>
/// <returns>A generics List with the NNClaseBienSustraido objects.</returns>
public static NNClaseBienSustraidoList GetList()
{
NNClaseBienSustraidoList tempList = new NNClaseBienSustraidoList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseBienSustraidoSelectList", myConnection))
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
/// Saves a NNClaseBienSustraido in the database.
/// </summary>
/// <param name="myNNClaseBienSustraido">The NNClaseBienSustraido instance to save.</param>
/// <returns>The new id if the NNClaseBienSustraido is new in the database or the existing id when an item was updated.</returns>
public static int Save(NNClaseBienSustraido myNNClaseBienSustraido)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseBienSustraidoInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myNNClaseBienSustraido.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myNNClaseBienSustraido.id);
}
if (string.IsNullOrEmpty(myNNClaseBienSustraido.descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myNNClaseBienSustraido.descripcion);
}
if (string.IsNullOrEmpty(myNNClaseBienSustraido.tipo))
{
myCommand.Parameters.AddWithValue("@tipo", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@tipo", myNNClaseBienSustraido.tipo);
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
/// Deletes a NNClaseBienSustraido from the database.
/// </summary>
/// <param name="id">The id of the NNClaseBienSustraido to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseBienSustraidoDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the NNClaseBienSustraido class and fills it with the data fom the IDataRecord.
/// </summary>
private static NNClaseBienSustraido FillDataRecord(IDataRecord myDataRecord )
{
NNClaseBienSustraido myNNClaseBienSustraido = new NNClaseBienSustraido();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myNNClaseBienSustraido.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
{
myNNClaseBienSustraido.descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("tipo")))
{
myNNClaseBienSustraido.tipo = myDataRecord.GetString(myDataRecord.GetOrdinal("tipo"));
}
return myNNClaseBienSustraido;
}
}

 } 
