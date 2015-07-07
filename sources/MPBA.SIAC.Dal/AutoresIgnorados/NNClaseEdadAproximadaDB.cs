using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The NNClaseEdadAproximadaDB class is responsible for interacting with the database to retrieve and store information
/// about NNClaseEdadAproximada objects.
/// </summary>
public partial class NNClaseEdadAproximadaDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of NNClaseEdadAproximada from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the NNClaseEdadAproximada in the database.</param>
/// <returns>An NNClaseEdadAproximada when the id was found in the database, or null otherwise.</returns>
public static NNClaseEdadAproximada GetItem(int id)
{
NNClaseEdadAproximada myNNClaseEdadAproximada = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseEdadAproximadaSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myNNClaseEdadAproximada = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myNNClaseEdadAproximada;
}
}

/// <summary>
/// Returns a list with NNClaseEdadAproximada objects.
/// </summary>
/// <returns>A generics List with the NNClaseEdadAproximada objects.</returns>
public static NNClaseEdadAproximadaList GetList()
{
NNClaseEdadAproximadaList tempList = new NNClaseEdadAproximadaList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseEdadAproximadaSelectList", myConnection))
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
/// Saves a NNClaseEdadAproximada in the database.
/// </summary>
/// <param name="myNNClaseEdadAproximada">The NNClaseEdadAproximada instance to save.</param>
/// <returns>The new id if the NNClaseEdadAproximada is new in the database or the existing id when an item was updated.</returns>
public static int Save(NNClaseEdadAproximada myNNClaseEdadAproximada)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseEdadAproximadaInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myNNClaseEdadAproximada.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myNNClaseEdadAproximada.id);
}
if (string.IsNullOrEmpty(myNNClaseEdadAproximada.descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myNNClaseEdadAproximada.descripcion);
}
if (myNNClaseEdadAproximada.idSICEdad == null)
{
    myCommand.Parameters.AddWithValue("@idSICEdad", DBNull.Value);
}
else
{
    myCommand.Parameters.AddWithValue("@idSICEdad", myNNClaseEdadAproximada.idSICEdad);
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
/// Deletes a NNClaseEdadAproximada from the database.
/// </summary>
/// <param name="id">The id of the NNClaseEdadAproximada to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseEdadAproximadaDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the NNClaseEdadAproximada class and fills it with the data fom the IDataRecord.
/// </summary>
private static NNClaseEdadAproximada FillDataRecord(IDataRecord myDataRecord )
{
NNClaseEdadAproximada myNNClaseEdadAproximada = new NNClaseEdadAproximada();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myNNClaseEdadAproximada.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
{
myNNClaseEdadAproximada.descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idSICEdad")))
{
    myNNClaseEdadAproximada.idSICEdad = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idSICEdad"));
}

return myNNClaseEdadAproximada;
}

public static NNClaseEdadAproximadaList GetListByidSICEdad(int id)
{
    throw new NotImplementedException();
}
}

 } 
