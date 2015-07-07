using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The NNClaseModoArriboHuidaDB class is responsible for interacting with the database to retrieve and store information
/// about NNClaseModoArriboHuida objects.
/// </summary>
public partial class NNClaseModoArriboHuidaDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of NNClaseModoArriboHuida from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the NNClaseModoArriboHuida in the database.</param>
/// <returns>An NNClaseModoArriboHuida when the id was found in the database, or null otherwise.</returns>
public static NNClaseModoArriboHuida GetItem(int id)
{
NNClaseModoArriboHuida myNNClaseModoArriboHuida = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseModoArriboHuidaSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myNNClaseModoArriboHuida = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myNNClaseModoArriboHuida;
}
}

/// <summary>
/// Returns a list with NNClaseModoArriboHuida objects.
/// </summary>
/// <returns>A generics List with the NNClaseModoArriboHuida objects.</returns>
public static NNClaseModoArriboHuidaList GetList()
{
NNClaseModoArriboHuidaList tempList = new NNClaseModoArriboHuidaList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseModoArriboHuidaSelectList", myConnection))
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
/// Saves a NNClaseModoArriboHuida in the database.
/// </summary>
/// <param name="myNNClaseModoArriboHuida">The NNClaseModoArriboHuida instance to save.</param>
/// <returns>The new id if the NNClaseModoArriboHuida is new in the database or the existing id when an item was updated.</returns>
public static int Save(NNClaseModoArriboHuida myNNClaseModoArriboHuida)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseModoArriboHuidaInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myNNClaseModoArriboHuida.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myNNClaseModoArriboHuida.id);
}
if (string.IsNullOrEmpty(myNNClaseModoArriboHuida.descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myNNClaseModoArriboHuida.descripcion);
}

myCommand.Parameters.AddWithValue("@esVehiculo", myNNClaseModoArriboHuida.esVehiculo);


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
/// Deletes a NNClaseModoArriboHuida from the database.
/// </summary>
/// <param name="id">The id of the NNClaseModoArriboHuida to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseModoArriboHuidaDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the NNClaseModoArriboHuida class and fills it with the data fom the IDataRecord.
/// </summary>
private static NNClaseModoArriboHuida FillDataRecord(IDataRecord myDataRecord )
{
NNClaseModoArriboHuida myNNClaseModoArriboHuida = new NNClaseModoArriboHuida();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myNNClaseModoArriboHuida.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
{
myNNClaseModoArriboHuida.descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("esVehiculo")))
{
myNNClaseModoArriboHuida.esVehiculo = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("esVehiculo"));
}
return myNNClaseModoArriboHuida;
}
}

 } 
