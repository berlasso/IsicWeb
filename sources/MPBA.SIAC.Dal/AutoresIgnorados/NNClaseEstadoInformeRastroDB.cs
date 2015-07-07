using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The NNClaseEstadoInformeRastroDB class is responsible for interacting with the database to retrieve and store information
/// about NNClaseEstadoInformeRastro objects.
/// </summary>
public partial class NNClaseEstadoInformeRastroDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of NNClaseEstadoInformeRastro from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the NNClaseEstadoInformeRastro in the database.</param>
/// <returns>An NNClaseEstadoInformeRastro when the id was found in the database, or null otherwise.</returns>
public static NNClaseEstadoInformeRastro GetItem(int id)
{
NNClaseEstadoInformeRastro myNNClaseEstadoInformeRastro = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseEstadoInformeRastroSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myNNClaseEstadoInformeRastro = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myNNClaseEstadoInformeRastro;
}
}

/// <summary>
/// Returns a list with NNClaseEstadoInformeRastro objects.
/// </summary>
/// <returns>A generics List with the NNClaseEstadoInformeRastro objects.</returns>
public static NNClaseEstadoInformeRastroList GetList()
{
NNClaseEstadoInformeRastroList tempList = new NNClaseEstadoInformeRastroList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseEstadoInformeRastroSelectList", myConnection))
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
/// Saves a NNClaseEstadoInformeRastro in the database.
/// </summary>
/// <param name="myNNClaseEstadoInformeRastro">The NNClaseEstadoInformeRastro instance to save.</param>
/// <returns>The new id if the NNClaseEstadoInformeRastro is new in the database or the existing id when an item was updated.</returns>
public static int Save(NNClaseEstadoInformeRastro myNNClaseEstadoInformeRastro)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseEstadoInformeRastroInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myNNClaseEstadoInformeRastro.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myNNClaseEstadoInformeRastro.id);
}
if (string.IsNullOrEmpty(myNNClaseEstadoInformeRastro.descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myNNClaseEstadoInformeRastro.descripcion);
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
/// Deletes a NNClaseEstadoInformeRastro from the database.
/// </summary>
/// <param name="id">The id of the NNClaseEstadoInformeRastro to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseEstadoInformeRastroDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the NNClaseEstadoInformeRastro class and fills it with the data fom the IDataRecord.
/// </summary>
private static NNClaseEstadoInformeRastro FillDataRecord(IDataRecord myDataRecord )
{
NNClaseEstadoInformeRastro myNNClaseEstadoInformeRastro = new NNClaseEstadoInformeRastro();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myNNClaseEstadoInformeRastro.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
{
myNNClaseEstadoInformeRastro.descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
}
return myNNClaseEstadoInformeRastro;
}
}

 } 
