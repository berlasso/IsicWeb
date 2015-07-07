using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The BusquedaRoboDelitosSexualesCejaFormaDB class is responsible for interacting with the database to retrieve and store information
/// about BusquedaRoboDelitosSexualesCejaForma objects.
/// </summary>
public partial class BusquedaRoboDelitosSexualesCejaFormaDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BusquedaRoboDelitosSexualesCejaForma from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BusquedaRoboDelitosSexualesCejaForma in the database.</param>
/// <returns>An BusquedaRoboDelitosSexualesCejaForma when the id was found in the database, or null otherwise.</returns>
public static BusquedaRoboDelitosSexualesCejaForma GetItem(int id)
{
BusquedaRoboDelitosSexualesCejaForma myBusquedaRoboDelitosSexualesCejaForma = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesCejaFormaSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBusquedaRoboDelitosSexualesCejaForma = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBusquedaRoboDelitosSexualesCejaForma;
}
}

/// <summary>
/// Returns a list with BusquedaRoboDelitosSexualesCejaForma objects.
/// </summary>
/// <returns>A generics List with the BusquedaRoboDelitosSexualesCejaForma objects.</returns>
public static BusquedaRoboDelitosSexualesCejaFormaList GetList()
{
BusquedaRoboDelitosSexualesCejaFormaList tempList = new BusquedaRoboDelitosSexualesCejaFormaList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesCejaFormaSelectList", myConnection))
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
/// Returns a list with BusquedaRoboDelitosSexualesCejaForma objects.
/// </summary>
/// <returns>A generics List with the BusquedaRoboDelitosSexualesCejaForma objects.</returns>
public static BusquedaRoboDelitosSexualesCejaFormaList GetListByidBusquedaRoboDS(int idBusquedaRoboDS)
{
BusquedaRoboDelitosSexualesCejaFormaList tempList = new BusquedaRoboDelitosSexualesCejaFormaList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesCejaFormaSelectListByidBusquedaRoboDS", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", idBusquedaRoboDS);
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
/// Saves a BusquedaRoboDelitosSexualesCejaForma in the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesCejaForma">The BusquedaRoboDelitosSexualesCejaForma instance to save.</param>
/// <returns>The new id if the BusquedaRoboDelitosSexualesCejaForma is new in the database or the existing id when an item was updated.</returns>
public static int Save(BusquedaRoboDelitosSexualesCejaForma myBusquedaRoboDelitosSexualesCejaForma)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesCejaFormaInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myBusquedaRoboDelitosSexualesCejaForma.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myBusquedaRoboDelitosSexualesCejaForma.id);
}
if (myBusquedaRoboDelitosSexualesCejaForma.idBusquedaRoboDS == null){
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", myBusquedaRoboDelitosSexualesCejaForma.idBusquedaRoboDS);
}
if (myBusquedaRoboDelitosSexualesCejaForma.idFormaCeja == null){
myCommand.Parameters.AddWithValue("@idFormaCeja", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idFormaCeja", myBusquedaRoboDelitosSexualesCejaForma.idFormaCeja);
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
/// Deletes a BusquedaRoboDelitosSexualesCejaForma from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesCejaForma to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesCejaFormaDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the BusquedaRoboDelitosSexualesCejaForma class and fills it with the data fom the IDataRecord.
/// </summary>
private static BusquedaRoboDelitosSexualesCejaForma FillDataRecord(IDataRecord myDataRecord )
{
BusquedaRoboDelitosSexualesCejaForma myBusquedaRoboDelitosSexualesCejaForma = new BusquedaRoboDelitosSexualesCejaForma();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBusquedaRoboDelitosSexualesCejaForma.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idBusquedaRoboDS")))
{
myBusquedaRoboDelitosSexualesCejaForma.idBusquedaRoboDS = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idBusquedaRoboDS"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idFormaCeja")))
{
myBusquedaRoboDelitosSexualesCejaForma.idFormaCeja = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idFormaCeja"));
}
return myBusquedaRoboDelitosSexualesCejaForma;
}
}

 } 
