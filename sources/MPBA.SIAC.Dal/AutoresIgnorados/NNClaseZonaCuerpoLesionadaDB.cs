using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The NNClaseZonaCuerpoLesionadaDB class is responsible for interacting with the database to retrieve and store information
/// about NNClaseZonaCuerpoLesionada objects.
/// </summary>
public partial class NNClaseZonaCuerpoLesionadaDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of NNClaseZonaCuerpoLesionada from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the NNClaseZonaCuerpoLesionada in the database.</param>
/// <returns>An NNClaseZonaCuerpoLesionada when the id was found in the database, or null otherwise.</returns>
public static NNClaseZonaCuerpoLesionada GetItem(int id)
{
NNClaseZonaCuerpoLesionada myNNClaseZonaCuerpoLesionada = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseZonaCuerpoLesionadaSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myNNClaseZonaCuerpoLesionada = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myNNClaseZonaCuerpoLesionada;
}
}

/// <summary>
/// Returns a list with NNClaseZonaCuerpoLesionada objects.
/// </summary>
/// <returns>A generics List with the NNClaseZonaCuerpoLesionada objects.</returns>
public static NNClaseZonaCuerpoLesionadaList GetList()
{
NNClaseZonaCuerpoLesionadaList tempList = new NNClaseZonaCuerpoLesionadaList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseZonaCuerpoLesionadaSelectList", myConnection))
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
/// Saves a NNClaseZonaCuerpoLesionada in the database.
/// </summary>
/// <param name="myNNClaseZonaCuerpoLesionada">The NNClaseZonaCuerpoLesionada instance to save.</param>
/// <returns>The new id if the NNClaseZonaCuerpoLesionada is new in the database or the existing id when an item was updated.</returns>
public static int Save(NNClaseZonaCuerpoLesionada myNNClaseZonaCuerpoLesionada)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseZonaCuerpoLesionadaInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myNNClaseZonaCuerpoLesionada.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myNNClaseZonaCuerpoLesionada.id);
}
if (string.IsNullOrEmpty(myNNClaseZonaCuerpoLesionada.descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myNNClaseZonaCuerpoLesionada.descripcion);
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
/// Deletes a NNClaseZonaCuerpoLesionada from the database.
/// </summary>
/// <param name="id">The id of the NNClaseZonaCuerpoLesionada to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseZonaCuerpoLesionadaDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the NNClaseZonaCuerpoLesionada class and fills it with the data fom the IDataRecord.
/// </summary>
private static NNClaseZonaCuerpoLesionada FillDataRecord(IDataRecord myDataRecord )
{
NNClaseZonaCuerpoLesionada myNNClaseZonaCuerpoLesionada = new NNClaseZonaCuerpoLesionada();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myNNClaseZonaCuerpoLesionada.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
{
myNNClaseZonaCuerpoLesionada.descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
}
return myNNClaseZonaCuerpoLesionada;
}
}

 } 
