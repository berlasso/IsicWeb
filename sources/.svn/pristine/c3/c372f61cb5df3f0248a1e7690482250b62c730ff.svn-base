using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The NNClaseRubroDB class is responsible for interacting with the database to retrieve and store information
/// about NNClaseRubro objects.
/// </summary>
public partial class NNClaseRubroDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of NNClaseRubro from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the NNClaseRubro in the database.</param>
/// <returns>An NNClaseRubro when the id was found in the database, or null otherwise.</returns>
public static NNClaseRubro GetItem(int id)
{
NNClaseRubro myNNClaseRubro = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseRubroSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myNNClaseRubro = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myNNClaseRubro;
}
}

/// <summary>
/// Returns a list with NNClaseRubro objects.
/// </summary>
/// <returns>A generics List with the NNClaseRubro objects.</returns>
public static NNClaseRubroList GetList()
{
NNClaseRubroList tempList = new NNClaseRubroList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseRubroSelectList", myConnection))
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
/// Returns a list with NNClaseRubro objects.
/// </summary>
/// <returns>A generics List with the NNClaseRubro objects.</returns>
public static NNClaseRubroList GetListByidClaseLugar(int idClaseLugar)
{
NNClaseRubroList tempList = new NNClaseRubroList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseRubroSelectListByidClaseLugar", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idClaseLugar", idClaseLugar);
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
return tempList;
}
}

/// <summary>
/// Saves a NNClaseRubro in the database.
/// </summary>
/// <param name="myNNClaseRubro">The NNClaseRubro instance to save.</param>
/// <returns>The new id if the NNClaseRubro is new in the database or the existing id when an item was updated.</returns>
public static int Save(NNClaseRubro myNNClaseRubro)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseRubroInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myNNClaseRubro.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myNNClaseRubro.id);
}
if (string.IsNullOrEmpty(myNNClaseRubro.descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myNNClaseRubro.descripcion);
}

    myCommand.Parameters.AddWithValue("@idClaseLugar", myNNClaseRubro.idClaseLugar);


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
/// Deletes a NNClaseRubro from the database.
/// </summary>
/// <param name="id">The id of the NNClaseRubro to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseRubroDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the NNClaseRubro class and fills it with the data fom the IDataRecord.
/// </summary>
private static NNClaseRubro FillDataRecord(IDataRecord myDataRecord )
{
NNClaseRubro myNNClaseRubro = new NNClaseRubro();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myNNClaseRubro.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
{
myNNClaseRubro.descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseLugar")))
{
myNNClaseRubro.idClaseLugar = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseLugar"));
}
return myNNClaseRubro;
}
}

 } 
