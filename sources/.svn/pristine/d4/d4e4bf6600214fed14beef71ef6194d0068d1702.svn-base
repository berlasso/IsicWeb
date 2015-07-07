using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The NNClaseCantAutorReconocidosDB class is responsible for interacting with the database to retrieve and store information
/// about NNClaseCantAutorReconocidos objects.
/// </summary>
public partial class NNClaseCantAutorReconocidosDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of NNClaseCantAutorReconocidos from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the NNClaseCantAutorReconocidos in the database.</param>
/// <returns>An NNClaseCantAutorReconocidos when the id was found in the database, or null otherwise.</returns>
public static NNClaseCantAutorReconocidos GetItem(int id)
{
NNClaseCantAutorReconocidos myNNClaseCantAutorReconocidos = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseCantAutorReconocidosSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myNNClaseCantAutorReconocidos = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myNNClaseCantAutorReconocidos;
}
}

/// <summary>
/// Returns a list with NNClaseCantAutorReconocidos objects.
/// </summary>
/// <returns>A generics List with the NNClaseCantAutorReconocidos objects.</returns>
public static NNClaseCantAutorReconocidosList GetList()
{
NNClaseCantAutorReconocidosList tempList = new NNClaseCantAutorReconocidosList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseCantAutorReconocidosSelectList", myConnection))
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
/// Saves a NNClaseCantAutorReconocidos in the database.
/// </summary>
/// <param name="myNNClaseCantAutorReconocidos">The NNClaseCantAutorReconocidos instance to save.</param>
/// <returns>The new id if the NNClaseCantAutorReconocidos is new in the database or the existing id when an item was updated.</returns>
public static int Save(NNClaseCantAutorReconocidos myNNClaseCantAutorReconocidos)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseCantAutorReconocidosInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myNNClaseCantAutorReconocidos.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myNNClaseCantAutorReconocidos.id);
}
if (string.IsNullOrEmpty(myNNClaseCantAutorReconocidos.descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myNNClaseCantAutorReconocidos.descripcion);
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
/// Deletes a NNClaseCantAutorReconocidos from the database.
/// </summary>
/// <param name="id">The id of the NNClaseCantAutorReconocidos to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseCantAutorReconocidosDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the NNClaseCantAutorReconocidos class and fills it with the data fom the IDataRecord.
/// </summary>
private static NNClaseCantAutorReconocidos FillDataRecord(IDataRecord myDataRecord )
{
NNClaseCantAutorReconocidos myNNClaseCantAutorReconocidos = new NNClaseCantAutorReconocidos();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myNNClaseCantAutorReconocidos.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
{
myNNClaseCantAutorReconocidos.descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
}
return myNNClaseCantAutorReconocidos;
}
}

 } 
